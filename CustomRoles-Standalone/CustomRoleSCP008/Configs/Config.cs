using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleScp008.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        //[Description("How many can be spawned at the start of a round?")]
        //public uint MaxSpawns { get; set; } = 1;
        public uint CustomRoleId { get; set; } = 51;
        [Description("Max health of SCP-008-1")]
        public int MaxHealth { get; set; } = 700;
        //public float HumeShield { get; set; } = 500;
        [Description("Every X seconds damage will be applied")]
        public float EverySec = 1;
        [Description("How much damage will be dealt every X seconds?")]
        public float DPS { get; set; } = 5;
        [Description("Impact Damage")]
        public float DamageOnImpact { get; set; } = 10;
        [Description("Role of SCP-008-1")]
        public RoleTypeId Role { get; set; } = RoleTypeId.Scp0492;
        [Description("Scale of SCP-008-1")]
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        public float SpawnChance { get; set; } = 20;
        public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.Inside049Armory;
        public bool UseClassDInsteadScp { get; set; } = true;
        public bool IgnoreSpawnSystem { get; set; } = true;
        public int MinPlayersForSpawn { get; set; } = 6;
        [Description("Items that can heal from SCP-008")]
        public List<ItemType> HealthItems { get; set; } = new List<ItemType>()
        {
            ItemType.SCP500
        };
        [Description("If the player will be infected a hint will be shown")]
        public bool ShowMsgToTargetWhenInfect { get; set; } = true;
        [Description("If true, then all SCP-008-1 will have SCP-207 effect. (without damage)")]
        public bool AppliedScp207Effect { get; set; } = true;
        [Description("If you are using Hazmat Suit please specify it ID")]
        public uint HazardSuitId { get; set; } = 52;
    }
}