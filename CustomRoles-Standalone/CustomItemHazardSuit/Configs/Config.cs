using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using Scp914;

namespace CustomItemHazardSuit.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public uint CustomItemId { get; set; } = 52;
        public float CustomItemWeight { get; set; } = 1;
        public float SpawnChance { get; set; } = 40;
        public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.Inside049Armory;
        [Description("The value must be above 1 and below 2")]
        public float StaminaUseMultiplier { get; set; } = 1.8f;
        [Description("The value must be above 0 and below 100")]
        public int HelmetEfficacy { get; set; } = 10;
        [Description("The value must be above 0 and below 100")]
        public int VestEfficacy { get; set; } = 20;
        public float HintDuration { get; set; } = 4;
        [Description("Can be obtained from the SCP-914?")]
        public bool From914 { get; set; } = true;
        public Dictionary<Scp914KnobSetting, CustomCraft> CustomCraft { get; set; } = new Dictionary<Scp914KnobSetting, CustomCraft>()
        {
            { Scp914KnobSetting.VeryFine , new CustomCraft()
            {
                Item = ItemType.ArmorCombat,
                Chance = 20
            }},
            { Scp914KnobSetting.Fine , new CustomCraft()
            {
                Item = ItemType.ArmorHeavy,
                Chance = 30
            }}
        };
        [Description("Can be upgraded in SCP-914?")]
        public bool In914 { get; set; } = true;
        public Dictionary<Scp914KnobSetting, CustomCraft> CustomUpgrade { get; set; } = new Dictionary<Scp914KnobSetting, CustomCraft>()
        {
            { Scp914KnobSetting.VeryFine , new CustomCraft()
            {
                Item = ItemType.SCP500,
                Chance = 90
            }},
            { Scp914KnobSetting.Fine , new CustomCraft()
            {
                Item = ItemType.SCP500,
                Chance = 50
            }}
        };
    }
}