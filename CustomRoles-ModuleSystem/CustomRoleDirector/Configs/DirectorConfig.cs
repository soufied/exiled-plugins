using System.Collections.Generic;
using System.ComponentModel;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleDirector.Configs
{
    public sealed class DirectorConfig : IConfig
    {
        [Description("Is the custom role enabled?")] public bool IsEnabled { get; set; } = true;
        [Description("Is the debug mod enabled?")] public bool Debug { get; set; } = false;
        [Description("Hint duration")] public uint HintDuration { get; set; } = 5;
        [Description("Role Id (must be unique)")] public uint CustomRoleId { get; set; } = 59;
        [Description("Max health of the custom role")] public int MaxHealth { get; set; } = 100;
        [Description("Role of the custom role")] public RoleTypeId Role { get; set; } = RoleTypeId.Scientist;
        [Description("Scale of the custom role")] public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);
        [Description("Role spawn chance")] public float SpawnChance { get; set; } = 100;
        [Description("Team from which the player is selected")] public Team SpawnFromTeam { get; set; } = Team.Scientists;
        [Description("https://github.com/Exiled-Team/EXILED/blob/dev/Exiled.API/Enums/SpawnLocationType.cs")] public SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>()
            {
                new DynamicSpawnPoint()
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideGateA
                },
                new DynamicSpawnPoint()
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideGateB
                },
                new DynamicSpawnPoint()
                {
                    Chance = 50,
                    Location = SpawnLocationType.InsideIntercom
                }
            },
            RoleSpawnPoints = new List<RoleSpawnPoint>()
            {
                new RoleSpawnPoint()
                {
                    Chance = 100,
                    Role = RoleTypeId.FacilityGuard
                }
            }
        };
        //[Description("https://github.com/Exiled-Team/EXILED/blob/dev/Exiled.API/Enums/SpawnLocationType.cs")] public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.InsideLczWc;
        [Description("https://discord.com/channels/656673194693885975/1081925714569338941/1081925714569338941")] public RoomType SpawnLocation { get; set; } = RoomType.EzGateB;
        [Description("Minimal amount of player on server to spawn custom role")] public uint MinPlayersForSpawn { get; set; } = 4;
        [Description("Ammo on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1082601409846984754)")] public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Ammo44Cal, 18 }
        };
        [Description("Inventory on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1081961667874795521)")] public List<string> Inventory { get; set; } = new List<string>()
        {
            "KeycardFacilityManager",
            "Radio",
            "GunRevolver"
        };
        [Description("Show custom info to everyone, if False only teammates will see custom info of this role")] public bool ShowCustomInfoToEveryone { get; set; } = true;
        [Description("Teammates for this role (Custom roles using Name from Translation so it must be exactly the same!)")] public Teammates TeammatesToThisRole { get; set; } = new Teammates()
        {
            TeammatesRole = new List<RoleTypeId>()
            {
                RoleTypeId.Scientist,
                RoleTypeId.FacilityGuard,
                RoleTypeId.NtfCaptain,
                RoleTypeId.NtfPrivate,
                RoleTypeId.NtfSergeant,
                RoleTypeId.NtfSpecialist
            },
            TeammatesCustomRoles = new List<string>()
            {
                "UTR",
                "Doctor",
                "Guard Supervisor"
            }
        };
    }
}