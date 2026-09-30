using System.Collections.Generic;
using CustomPlayerEffects;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using CustomRoleUtr.Api.Components;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace CustomRoleUtr.Api.Roles
{
    public class Utr : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = UtrModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = UtrModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = UtrModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = UtrModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = UtrModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = UtrModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = UtrModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = UtrModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = UtrModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = UtrModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = UtrModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = UtrModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = UtrModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = UtrModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = UtrModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = UtrModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = UtrModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = UtrModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = UtrModule.ModuleConfig.ShowCustomInfoToEveryone;
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.EnteringPocketDimension += OnEnteringPocket;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.EnteringPocketDimension -= OnEnteringPocket;
        }
        public override void AddRole(Player player)
        {
            base.AddRole(player);
            /*if (player.Role.Is(out FpcRole role))
            {
                role.FirstPersonController.FpcModule.
            }*/
            player.GameObject.AddComponent<DisableStaminaComp>();
            Scp173Role.TurnedPlayers.Add(player);
            Scp096Role.TurnedPlayers.Add(player);
        }
        public override void ReviveRole(Player player)
        {
            base.ReviveRole(player);
            player.GameObject.AddComponent<DisableStaminaComp>();
            Scp173Role.TurnedPlayers.Add(player);
            Scp096Role.TurnedPlayers.Add(player);
        }
        public override void RemoveRole(Player player)
        {
            base.RemoveRole(player);
            player.GameObject.GetComponent<DisableStaminaComp>().Destroy();
            Scp173Role.TurnedPlayers.Remove(player);
            Scp096Role.TurnedPlayers.Remove(player);
        }
        public void OnEnteringPocket(EnteringPocketDimensionEventArgs ev)
        {
            if (!Check(ev.Player)) return;
            ev.IsAllowed = false;
        }
    }
}