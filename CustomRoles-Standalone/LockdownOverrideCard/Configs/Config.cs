using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using Interactables.Interobjects.DoorUtils;
using Scp914;

namespace LockdownOverrideCard.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public uint CustomItemId { get; set; } = 51;
        public float CustomItemWeight { get; set; } = 1;
        public float SpawnChance { get; set; } = 70;
        public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.Inside914;
        public float HintDuration { get; set; } = 4;
        [Description("Can open doors without scanner anyway?")]
        public bool CanOpenDefDoors { get; set; } = true;
        [Description("DoorTypes that the keycard cannot open or close")]
        public List<DoorType> DoorTypes { get; set; } = new List<DoorType>()
        {
            DoorType.Scp079First,
            DoorType.Scp079Second
        };
        [Description("DoorLockTypes that the keycard cannot open or close")]
        public List<DoorLockType> DoorLockTypes { get; set; } = new List<DoorLockType>()
        {
            DoorLockType.AdminCommand,
            DoorLockType.Warhead,
            DoorLockType.DecontEvacuate,
            DoorLockType.DecontLockdown
        };
        [Description("Use the patch to enable possibility to use LCZ elevators during decontamination? (If your server is affected by the plugins on the lcz, more specifically to lock elevators, I advise you to disable the patch to avoid bugs)")]
        public bool DoPatch { get; set; } = true;
        [Description("Can unlocked elevators be used with a keycard?")]
        public bool CanUseUnlockedElevators { get; set; } = true;
        /*[Description("ElevatorsTypes that the keycard cannot open or close")]
        public List<ElevatorType> ElevatorTypes { get; set; } = new List<ElevatorType>()
        {
            ElevatorType.Unknown
        };
        [Description("ElevatorsLockTypes that the keycard cannot open or close")]
        public List<DoorLockReason> ElevatorLockTypes { get; set; } = new List<DoorLockReason>()
        {
            DoorLockReason.AdminCommand,
            DoorLockReason.Warhead
        };*/
        [Description("Can be obtained from the SCP-914?")]
        public bool From914 { get; set; } = true;
        public Dictionary<Scp914KnobSetting, CustomCraft> CustomCraft { get; set; } = new Dictionary<Scp914KnobSetting, CustomCraft>()
        {
            { Scp914KnobSetting.OneToOne , new CustomCraft()
            {
                Item = ItemType.KeycardZoneManager,
                Chance = 20
            }},
            { Scp914KnobSetting.Fine , new CustomCraft()
            {
                Item = ItemType.KeycardO5,
                Chance = 50
            }}
        };
        [Description("Can be upgraded in SCP-914?")]
        public bool In914 { get; set; } = true;
        public Dictionary<Scp914KnobSetting, CustomCraft> CustomUpgrade { get; set; } = new Dictionary<Scp914KnobSetting, CustomCraft>()
        {
            { Scp914KnobSetting.VeryFine , new CustomCraft()
            {
                Item = ItemType.AntiSCP207,
                Chance = 50
            }},
            { Scp914KnobSetting.Fine , new CustomCraft()
            {
                Item = ItemType.KeycardO5,
                Chance = 100
            }},
            { Scp914KnobSetting.OneToOne , new CustomCraft()
            {
                Item = ItemType.KeycardZoneManager,
                Chance = 100
            }}
        };
    }
}