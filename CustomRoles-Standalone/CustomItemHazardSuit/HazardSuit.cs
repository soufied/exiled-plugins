using System.Collections.Generic;
using System.Linq;
using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.EventArgs;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp914;
using PlayerRoles;
using UnityEngine;
using Random = System.Random;

namespace CustomItemHazardSuit
{
    [CustomItem(ItemType.ArmorHeavy)]
    public class HazardSuit : CustomArmor
    {
        public override uint Id { get; set; } = Plugin.Singleton.Config.CustomItemId;
        public override string Name { get; set; } = Plugin.Singleton.Translation.SuitName;
        public override string Description { get; set; } = Plugin.Singleton.Translation.SuitDescription;
        public override float Weight { get; set; } = Plugin.Singleton.Config.CustomItemWeight;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.SpawnChance,
                    Location = Plugin.Singleton.Config.SpawnLocationType
                }
            }
        };
        public override float StaminaUseMultiplier { get; set; } = Plugin.Singleton.Config.StaminaUseMultiplier;
        public override int HelmetEfficacy { get; set; } = Plugin.Singleton.Config.HelmetEfficacy;
        public override int VestEfficacy { get; set; } = Plugin.Singleton.Config.VestEfficacy;
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            //Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUp;
            Exiled.Events.Handlers.Player.DroppingItem += OnDropping;
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            if (!Plugin.Singleton.Config.From914) return;
            Exiled.Events.Handlers.Scp914.UpgradingPickup += OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem += OnUpgradingInventoryItem;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            //Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUp;
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropping;
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            if (!Plugin.Singleton.Config.From914) return;
            Exiled.Events.Handlers.Scp914.UpgradingPickup -= OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem -= OnUpgradingInventoryItem;
        }
        protected override void ShowPickedUpMessage(Player player)
        {
            player.ShowHint($"{Plugin.Singleton.Translation.SuitTaken}\n{Plugin.Singleton.Translation.SuitDescription}", Plugin.Singleton.Config.HintDuration);
        }
        /*protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            if (!Check(ev.Pickup)) return;
            base.OnPickingUp(ev);
            ev.Player.ShowHint(Plugin.Singleton.Translation.HazardSuitTaken, Plugin.Singleton.Config.HintDuration);
        }*/
        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (!Check(ev.Item)) return;
            base.OnDropping(ev);
            ev.Player.ShowHint(Plugin.Singleton.Translation.SuitDropped, Plugin.Singleton.Config.HintDuration);
        }
        public void OnUpgradingPickup(UpgradingPickupEventArgs ev)
        {
            if (Check(ev.Pickup))
            {
                if (!Plugin.Singleton.Config.In914) return;
                if (!Plugin.Singleton.Config.CustomUpgrade.ContainsKey(ev.KnobSetting)) return;
                var customUpgrade = Plugin.Singleton.Config.CustomUpgrade[ev.KnobSetting];
                var rnd = new Random().Next(1,101);
                if (rnd > customUpgrade.Chance)
                {
                    Log.Debug($"HazardSuit: Hazard Suit was destroyed in SCP-914; Mode: {ev.KnobSetting}; Chance: {rnd} > {customUpgrade.Chance}; New Item was supposed to be: {customUpgrade.Item}");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.IsAllowed = false;
                    ev.Pickup.Destroy();
                    Pickup.CreateAndSpawn(customUpgrade.Item, ev.OutputPosition, new Quaternion(0,0,0,0));
                    Log.Debug($"HazardSuit: Hazard Suit was recycled in SCP-914; Mode: {ev.KnobSetting}; Chance: {rnd} < {customUpgrade.Chance}; New Item: {customUpgrade.Item}");
                }
            }
            else
            {
                if (!Plugin.Singleton.Config.From914) return;
                if (!Plugin.Singleton.Config.CustomCraft.ContainsKey(ev.KnobSetting)) return;
                var customCraft = Plugin.Singleton.Config.CustomCraft[ev.KnobSetting];
                if (ev.Pickup.Type != customCraft.Item)
                {
                    ev.IsAllowed = true;
                    return;
                }
                ev.IsAllowed = false;
                var rnd = new Random().Next(1, 101);
                if (rnd > customCraft.Chance)
                {
                    Log.Debug($"HazardSuit: {customCraft.Item} was destroyed during processing into a Hazard Suit; Mode: {ev.KnobSetting}; Chance: {rnd} > {customCraft.Chance};");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Pickup.Destroy();
                    CustomItem.TrySpawn(Plugin.Singleton.Config.CustomItemId, ev.OutputPosition, out Pickup pickup);
                    Log.Debug($"HazardSuit: {customCraft.Item} was recycled into a Hazard Suit; Mode: {ev.KnobSetting}; Chance: {rnd} < {customCraft.Chance};");
                }
            }
        }
        public void OnUpgradingInventoryItem(UpgradingInventoryItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                if (!Plugin.Singleton.Config.In914) return;
                if (!Plugin.Singleton.Config.CustomUpgrade.ContainsKey(ev.KnobSetting)) return;
                ev.IsAllowed = false;
                var customUpgrade = Plugin.Singleton.Config.CustomUpgrade[ev.KnobSetting];
                var rnd = new Random().Next(1,101);
                if (rnd > customUpgrade.Chance)
                {
                    Log.Debug($"HazardSuit: Hazard Suit was destroyed in SCP-914 by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} > {customUpgrade.Chance}; New Item was supposed to be: {customUpgrade.Item}");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Item.Destroy();
                    ev.Player.AddItem(customUpgrade.Item);
                    Log.Debug($"HazardSuit: Hazard Suit was recycled in SCP-914 by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} < {customUpgrade.Chance}; New Item: {customUpgrade.Item}");
                }
            }
            else
            {
                if (!Plugin.Singleton.Config.From914) return;
                if (!Plugin.Singleton.Config.CustomCraft.ContainsKey(ev.KnobSetting)) return;
                var customCraft = Plugin.Singleton.Config.CustomCraft[ev.KnobSetting];
                if (ev.Item.Type != customCraft.Item)
                {
                    ev.IsAllowed = true;
                    return;
                }
                ev.IsAllowed = false;
                var rnd = new Random().Next(1,101);
                if (rnd > customCraft.Chance)
                {
                    Log.Debug($"HazardSuit: {customCraft.Item} was destroyed during processing into a Hazard Suit by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} > {customCraft.Chance};");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Item.Destroy();
                    CustomItem.TryGive(ev.Player, Plugin.Singleton.Config.CustomItemId);
                    Log.Debug($"HazardSuit: {customCraft.Item} was recycled into a Hazard Suit by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} < {customCraft.Chance};");
                }
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Player == null)
            {
                Log.Debug("HazardSuit: Attacker or Player is null");
                return;
            }
            if (ev.Attacker == ev.Player)
            {
                Log.Debug("HazardSuit: Attacker is Player");
                return;
            }
            if (ev.Attacker.Role.Type == RoleTypeId.Scp049 || ev.Attacker.Role.Type == RoleTypeId.Scp0492)
            {
                if (!ev.Player.Items.ToList().Any(Check))
                {
                    Log.Debug("HazardSuit: Didnt find hazard suit");
                    return;
                }
                ev.IsAllowed = false;
                ev.Player.DisableEffect<CardiacArrest>(); // i dunno why this effect is applied when isAllowed = false
                ev.Attacker.ShowHint(Plugin.Singleton.Translation.SuitAttacker, Plugin.Singleton.Config.HintDuration);
                return;
            }
            Log.Debug($"HazardSuit: Attacker is not SCP-049 or SCP-049-2");
        }
    }
}