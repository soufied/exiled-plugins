using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomPlayerEffects;
using CustomRoleScp008.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp0492;
using Exiled.Loader;
using MEC;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CustomRoleScp008.API.Roles
{
    public class Scp008 : CustomRole
    {
        public static List<int> InfectedPlayers { get; set; } = new List<int>();
        
        public override uint Id { get; set; } = Plugin.Singleton.Config.CustomRoleId;
        public override int MaxHealth { get; set; } = Plugin.Singleton.Config.MaxHealth;
        public override string Name { get; set; } = Plugin.Singleton.Translation.CustomName;
        public override string Description { get; set; } = Plugin.Singleton.Translation.Description;
        public override string CustomInfo { get; set; } = Plugin.Singleton.Translation.CustomInfo;
        public override string ConsoleMessage { get; set; } = Plugin.Singleton.Translation.ConsoleMsg;
        public override bool IgnoreSpawnSystem { get; set; } = Plugin.Singleton.Config.IgnoreSpawnSystem;
        public override RoleTypeId Role { get; set; } = Plugin.Singleton.Config.Role;
        public override bool KeepPositionOnSpawn { get; set; } = true;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Vector3 Scale { get; set; } = Plugin.Singleton.Config.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,//Plugin.Singleton.Config.MaxSpawns,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.SpawnChance,
                    Location = Plugin.Singleton.Config.SpawnLocationType
                }
            }
        };
        public override void AddRole(Player player)
        {
            base.AddRole(player);
            InfectedPlayers.Add(player.Id);
            if (!Plugin.Singleton.Config.AppliedScp207Effect) return;
            Timing.CallDelayed(0.5f, () =>
            {
                 player.EnableEffect<Scp207>();
                 player.MaxHealth = Plugin.Singleton.Config.MaxHealth;
                 player.Health = Plugin.Singleton.Config.MaxHealth;
            });
        }
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.Dying += OnDying;
            Exiled.Events.Handlers.Player.UsedItem += OnUsedItem;
            Exiled.Events.Handlers.Player.Left += OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
            Exiled.Events.Handlers.Scp0492.TriggeringBloodlust += OnBloodLust;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound += OnRoundRestarting;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.Dying -= OnDying;
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedItem;
            Exiled.Events.Handlers.Player.Left -= OnLeft;
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
            Exiled.Events.Handlers.Scp0492.TriggeringBloodlust -= OnBloodLust;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound -= OnRoundRestarting;
        }

        #region Events
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.DamageHandler.Type == DamageType.Scp207 && Check(ev.Player) && Plugin.Singleton.Config.AppliedScp207Effect)
            {
                ev.Amount = 0;
                return;
            }
            if (ev.Attacker == null || ev.Player == null) return;
            if (ev.Attacker == ev.Player) return;
            if (!Check(ev.Attacker)) return;
            if (Loader.Plugins.FirstOrDefault(pl => pl.Name == "CustomItemHazardSuit") != null)
            {
                if (ev.Player.Items.ToList().Any(CustomItem.Get(Plugin.Singleton.Config.HazardSuitId).Check)) return;
            }
            ev.Amount = Plugin.Singleton.Config.DamageOnImpact;
            Infect(ev.Player);
        }
        public void OnDying(DyingEventArgs ev)
        {
            if (Check(ev.Player))
            {
                InfectedPlayers.Remove(ev.Player.Id);
                Extensions.CheckForCassie(ev.DamageHandler, ev.Attacker);
            }
            
            //if (ev.DamageHandler.Base is CustomReasonDamageHandler customReasonDamageHandler && customReasonDamageHandler._deathReason != "SCP-008") return;
            if (!ev.Player.IsInfected()) return;
            ev.Player.DropItems();
            ev.IsAllowed = false;
            SpawnScp008(ev.Player);
        }
        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if (!ev.Player.IsInfected()) return;
            if (!Plugin.Singleton.Config.HealthItems.Contains(ev.Item.Type)) return;
            UnInfect(ev.Player);
        }
        public void OnLeft(LeftEventArgs ev)
        {
            if (Check(ev.Player)) InfectedPlayers.Remove(ev.Player.Id);
            UnInfect(ev.Player);
        }
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (Check(ev.Player)) InfectedPlayers.Remove(ev.Player.Id);
            UnInfect(ev.Player);
        }
        public void OnBloodLust(TriggeringBloodlustEventArgs ev)
        {
            if (!Check(ev.Player)) return;
            ev.IsAllowed = false;
        }
        public void OnRoundStarted()
        {
            ClearAll();
            if (Player.List.Count() < Plugin.Singleton.Config.MinPlayersForSpawn) return;
            if (Random.Range(0, 101) > Plugin.Singleton.Config.SpawnChance)
            {
                Log.Debug("SCP-008 will not be spawned in this round.");
                return;
            }
            if (Player.List.Count(x => x.Role.Team == Plugin.Singleton.Config.SpawnFrom) == 0)
            {
                Log.Debug($"There is no one from team - {Plugin.Singleton.Config.Role}");
                return;
            }
            Player ply;
            var list = Player.List.Where(x => x.Role.Team == Plugin.Singleton.Config.SpawnFrom);
            if (list.Count() == 1)
            {
                ply = list.First();
                Log.Debug($"There is only one person from team - {Plugin.Singleton.Config.Role}");
            }
            else
            {
                ply = list.ToList()[(Random.Range(0, list.Count()))];
                Log.Debug($"There is more than one person from team - {Plugin.Singleton.Config.Role}");
            }
            Get(typeof(Scp008))?.AddRole(ply);
            
            /*if (Plugin.Singleton.Config.UseClassDInsteadScp)
            {
                var player = Player.List.Where(x => x.Role.Type == RoleTypeId.ClassD).ElementAt(Random.Range(0, Player.List.Count()));
                Get(typeof(Scp008))?.AddRole(player);
                //InfectedPlayers.Add(player.Id);
                //Timing.CallDelayed(0.5f, () =>
                //{
                //    if (Plugin.Singleton.Config.AppliedScp207Effect) player.EnableEffect<Scp207>();
                //});
            }
            else
            {
                var player = Player.List.Where(x => x.Role.Team == Team.SCPs).ElementAt(Random.Range(0, Player.List.Count()));
                Get(typeof(Scp008))?.AddRole(player);
                //InfectedPlayers.Add(player.Id);
                //Timing.CallDelayed(0.5f, () =>
                //{
                //    if (Plugin.Singleton.Config.AppliedScp207Effect) player.EnableEffect<Scp207>();
                //});
            }*/
        }
        public void OnRoundRestarting() => ClearAll();
        #endregion
        
        #region Misc

        public void Infect(Player player)
        {
            if (API.Semifaces.Infected.Infected_List.TryGetValue(player.Id, out var infected)) infected.Power++;
            else
            {
                if (Plugin.Singleton.Config.ShowMsgToTargetWhenInfect) player.ShowHint(Plugin.Singleton.Translation.TargetGotInfected, CustomRoles.Instance.Config.GotRoleHint.Duration);
                var dp = new API.Semifaces.Infected(player, 1);
                dp.Start();
            }
        }
        public void UnInfect(Player player)
        {
            if (!API.Semifaces.Infected.Infected_List.ContainsKey(player.Id)) return;
            var infected = API.Semifaces.Infected.Infected_List[player.Id];
            infected.Stop();
        }
        public void SpawnScp008(Player player)
        {
            UnInfect(player);
            var oldPos = player.Position;
            Get(typeof(Scp008))?.AddRole(player);
            //InfectedPlayers.Add(player.Id);
            Timing.CallDelayed(0.2f, () =>
            {
                //player.HumeShield = Plugin.Singleton.Config.HumeShield;
                player.Position = oldPos;
                //if (Plugin.Singleton.Config.AppliedScp207Effect) player.EnableEffect<Scp207>();
            });
        }
        public void ClearAll()
        {
            if (InfectedPlayers.Count >= 1) InfectedPlayers.Clear();
            if (API.Semifaces.Infected.Infected_List.Count == 0) return;
            foreach (var infected in API.Semifaces.Infected.Infected_List.Values)
            {
                infected.Stop();
            }
            API.Semifaces.Infected.Infected_List.Clear();
        }
        #endregion
    }
}