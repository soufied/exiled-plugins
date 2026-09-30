using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleContainmentEngineer.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Hint duration")]
        public float HintDuration { get; set; } = 5f;
        [Description("Role Id")]
        public uint CustomRoleId { get; set; } = 53;
        [Description("Max health of the Containment Engineer")]
        public int MaxHealth { get; set; } = 100;
        [Description("Role of the Containment Engineer")]
        public RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;
        [Description("Scale of the Containment Engineer")]
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        public float SpawnChance { get; set; } = 40;
        [Description("If true, then will be spawned in Entrance Zone, else will use SpawnLocationType")]
        public bool SpawnLocationAsGuard { get; set; } = true;
        public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.InsideServersBottom;
        public bool IgnoreSpawnSystem { get; set; } = true;
        public int MinPlayersForSpawn { get; set; } = 3;
        [Description("Ammo on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1082601409846984754)")]
        public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato9, 90 }
        };
        [Description("Inventory on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1081961667874795521)")]
        public List<string> Inventory { get; set; } = new List<string>()
        {
            "KeycardContainmentEngineer",
            "GunFSP9",
            "Medkit",
            "GrenadeFlash",
            "Radio",
            "ArmorLight",
            "MicroHID"
        };
    }
}