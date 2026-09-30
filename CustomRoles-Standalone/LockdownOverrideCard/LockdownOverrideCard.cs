using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API.EventArgs;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp914;
using MEC;
using Scp914;
using UnityEngine;
using Random = System.Random;
namespace LockdownOverrideCard
{
    [CustomItem(ItemType.KeycardZoneManager)]
    public class LockdownOverrideCard : CustomItem
    {
        public override uint Id { get; set; } = Plugin.Singleton.Config.CustomItemId;
        public override string Name { get; set; } = Plugin.Singleton.Translation.KeycardName;
        public override string Description { get; set; } = Plugin.Singleton.Translation.KeycardDescription;
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
        //idk, ev.Door.IsMoving doesnt work
        //public bool IsGateMoving = false;
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            //Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUp;
            Exiled.Events.Handlers.Player.DroppingItem += OnDropping;
            Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
            if (Plugin.Singleton.Config.DoPatch) Exiled.Events.Handlers.Player.InteractingElevator += OnInteractingElevator;
            Exiled.Events.Handlers.Scp914.UpgradingPickup += OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem += OnUpgradingInventoryItem;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            //Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUp;
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropping;
            Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
            if (Plugin.Singleton.Config.DoPatch) Exiled.Events.Handlers.Player.InteractingElevator -= OnInteractingElevator;
            if (!Plugin.Singleton.Config.From914) return;
            Exiled.Events.Handlers.Scp914.UpgradingPickup -= OnUpgradingPickup;
            Exiled.Events.Handlers.Scp914.UpgradingInventoryItem -= OnUpgradingInventoryItem;
        }
        protected override void ShowPickedUpMessage(Player player)
        {
            player.ShowHint($"{Plugin.Singleton.Translation.KeycardTaken}\n{Plugin.Singleton.Translation.KeycardDescription}", Plugin.Singleton.Config.HintDuration);
        }
        protected override void ShowSelectedMessage(Player player)
        {
            player.ShowHint($"{Plugin.Singleton.Translation.KeycardSelect}\n{Plugin.Singleton.Translation.KeycardDescription}", Plugin.Singleton.Config.HintDuration);
        }
        /*protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            if (!Check(ev.Pickup)) return;
            base.OnPickingUp(ev);
            ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardTake, Plugin.Singleton.Config.HintDuration);
        }*/
        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (!Check(ev.Item)) return;
            base.OnDropping(ev);
            ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardDropped, Plugin.Singleton.Config.HintDuration);
        }
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (!Check(ev.Player.CurrentItem)) return;
            if (Plugin.Singleton.Config.DoorTypes.Contains(ev.Door.Type))
            {
                //Log.Error("Door in doortypes list");
                ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardCantOpen, Plugin.Singleton.Config.HintDuration);
                return;
            }
            if (Plugin.Singleton.Config.DoorLockTypes.Contains(ev.Door.DoorLockType))
            {
                //Log.Error("Door in doorlocktypes list");
                ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardCantOpen, Plugin.Singleton.Config.HintDuration);
                return;
            }
            if (ev.Door.IsGate)
            {
                //if (IsGateMoving)
                if (ev.Door.IsMoving)
                {
                    ev.IsAllowed = false;
                    //Log.Error("Gate door is moving. Return.");
                    return;
                }
                if (Plugin.Singleton.Config.CanOpenDefDoors && !ev.Door.IsKeycardDoor)
                {
                    ev.IsAllowed = true;
                    //IsGateMoving = true;
                    //Log.Error("Gate door without scanner.");
                    //Timing.CallDelayed(2.2f, () => IsGateMoving = false); // shitty bug fix
                    return;
                }
                if (!ev.Door.IsLocked)
                {
                    ev.IsAllowed = false;
                    //Log.Error("Gate door is not locked. Return.");
                    return;
                }
                ev.IsAllowed = true;
                //IsGateMoving = true;
                //Timing.CallDelayed(2.2f, () => IsGateMoving = false); // shitty bug fix
                //Log.Error("No statements detected.");
            }
            else
            {
                if (Plugin.Singleton.Config.CanOpenDefDoors && !ev.Door.IsKeycardDoor)
                {
                    ev.IsAllowed = true;
                    //Log.Error("Door without scanner.");
                    return;
                }
                if (!ev.Door.IsLocked)
                {
                    ev.IsAllowed = false;
                    //Log.Error("Door is not locked. Return.");
                    return;
                }
                ev.IsAllowed = true;
                //Log.Error("No statements detected.");
            }
        }
        public void OnInteractingElevator(InteractingElevatorEventArgs ev) // shit coded :(
        {
            if (ev.Lift.Type == ElevatorType.LczA || ev.Lift.Type == ElevatorType.LczB)
            {
                if (Check(ev.Player.CurrentItem) && Plugin.Singleton.Config.CanUseUnlockedElevators && !LightContainmentZoneDecontamination.DecontaminationController.Singleton.IsDecontaminating)
                {
                    //Log.Error("Player using elevator before Decontamination, he have a special keycard and CanUseUnlockedElevators - True.");
                    return;
                }
                if (Check(ev.Player.CurrentItem) && !Plugin.Singleton.Config.CanUseUnlockedElevators && !LightContainmentZoneDecontamination.DecontaminationController.Singleton.IsDecontaminating)
                {
                    //Log.Error("Player using elevator before Decontamination, he have a special keycard and CanUseUnlockedElevators - False.");
                    ev.IsAllowed = false;
                    ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardCantCallElevator, Plugin.Singleton.Config.HintDuration);
                    return;
                }
                if (!LightContainmentZoneDecontamination.DecontaminationController.Singleton.IsDecontaminating)
                {
                    //Log.Error("Player using elevator before Decontamination.");
                    return;
                }
                if (!Check(ev.Player.CurrentItem))
                {
                    //Log.Error("Player using elevator after Decontamination but he doesnt have a special keycard.");
                    ev.IsAllowed = false;
                    ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardCantCallElevator, Plugin.Singleton.Config.HintDuration);
                    return;
                }
                //Log.Error("Player using elevator after Decontamination and he have a special keycard.");
                ev.IsAllowed = true;
            }
            else
            {
                if (!Check(ev.Player.CurrentItem))
                {
                    //Log.Error("Player doesnt have a special keycard.");
                    return;
                }
                if (Plugin.Singleton.Config.CanUseUnlockedElevators && !ev.Lift.IsLocked)
                {
                    //Log.Error("Elevator is not locked. CanUseUnlockedElevators - True.");
                    return;
                }
                ev.IsAllowed = false;
                ev.Player.ShowHint(Plugin.Singleton.Translation.KeycardCantCallElevator, Plugin.Singleton.Config.HintDuration);
            }
            
            /*if (Plugin.Singleton.Config.ElevatorTypes.Contains(ev.Lift.Type))
            {
                ev.Player.ShowHint(Plugin.Singleton.Translation.LockdownOverrideCard_CannotCallElevator, Plugin.Singleton.Config.HintDuration);
                return;
            }
            if (Plugin.Singleton.Config.ElevatorLockTypes.Contains(ev.Elevator.ActiveLocks))
            {
                ev.Player.ShowHint(Plugin.Singleton.Translation.LockdownOverrideCard_CannotCallElevator, Plugin.Singleton.Config.HintDuration);
                return;
            }
            switch (ev.Lift.IsLocked)
            {
                case false when Plugin.Singleton.Config.CanUseUnlockedElevators:
                    Log.Error("Elevator is not locked. Return. CanUseUnlockedElevators - True.");
                    return;
                case true:
                    Log.Error("Elevator is locked.");
                    ev.IsAllowed = true;
                    return;
                default:
                    Log.Error("No statements detected.");
                    break;
            }*/
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
                    Log.Debug($"LockdownOverrideCard: Lockdown Override Card was destroyed in SCP-914; Mode: {ev.KnobSetting}; Chance: {rnd} > {customUpgrade.Chance}; New Item was supposed to be: {customUpgrade.Item}");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.IsAllowed = false;
                    ev.Pickup.Destroy();
                    Pickup.CreateAndSpawn(customUpgrade.Item, ev.OutputPosition, new Quaternion(0,0,0,0));
                    Log.Debug($"LockdownOverrideCard: Lockdown Override Card was recycled in SCP-914; Mode: {ev.KnobSetting}; Chance: {rnd} < {customUpgrade.Chance}; New Item: {customUpgrade.Item}");
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
                    Log.Debug($"LockdownOverrideCard: {customCraft.Item} was destroyed during processing into a Lockdown Override Card; Mode: {ev.KnobSetting}; Chance: {rnd} > {customCraft.Chance};");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Pickup.Destroy();
                    CustomItem.TrySpawn(Plugin.Singleton.Config.CustomItemId, ev.OutputPosition, out Pickup pickup);
                    Log.Debug($"LockdownOverrideCard: {customCraft.Item} was recycled into a Lockdown Override Card; Mode: {ev.KnobSetting}; Chance: {rnd} < {customCraft.Chance};");
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
                    Log.Debug($"LockdownOverrideCard: Lockdown Override Card was destroyed in SCP-914 by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} > {customUpgrade.Chance}; New Item was supposed to be: {customUpgrade.Item}");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Item.Destroy();
                    ev.Player.AddItem(customUpgrade.Item); 
                    Log.Debug($"LockdownOverrideCard: Lockdown Override Card was recycled in SCP-914 by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} < {customUpgrade.Chance}; New Item: {customUpgrade.Item}");
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
                    Log.Debug($"LockdownOverrideCard: {customCraft.Item} was destroyed during processing into a Lockdown Override Card by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} > {customCraft.Chance};");
                    ev.IsAllowed = true;
                }
                else
                {
                    ev.Item.Destroy();
                    CustomItem.TryGive(ev.Player, Plugin.Singleton.Config.CustomItemId);
                    Log.Debug($"LockdownOverrideCard: {customCraft.Item} was recycled into a Lockdown Override Card by {ev.Player.Nickname}; Mode: {ev.KnobSetting}; Chance: {rnd} < {customCraft.Chance};");
                }
            }
        }
    }
}