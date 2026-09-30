using System.Collections.Generic;
using System.ComponentModel;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleScp225Fr.Configs
{
    public sealed class Scp225FrConfig : IConfig
    {
        [Description("Is the custom role enabled?")] public bool IsEnabled { get; set; } = true;
        [Description("Is the debug mod enabled?")] public bool Debug { get; set; } = false;
        [Description("Hint duration")] public uint HintDuration { get; set; } = 5;
        [Description("Role Id (must be unique)")] public uint CustomRoleId { get; set; } = 60;
        [Description("Max health of the custom role")] public int MaxHealth { get; set; } = 200;
        [Description("Role of the custom role")] public RoleTypeId Role { get; set; } = RoleTypeId.Scp939;
        [Description("Scale of the custom role")] public Vector3 Scale { get; set; } = new Vector3(0.8f, 0.8f, 0.8f);
        [Description("Role spawn chance")] public float SpawnChance { get; set; } = 100;
        [Description("Team from which the player is selected")] public Team SpawnFromTeam { get; set; } = Team.ClassD;
        [Description("https://github.com/Exiled-Team/EXILED/blob/dev/Exiled.API/Enums/SpawnLocationType.cs")] public SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
        {
            Limit = 1,
            RoleSpawnPoints = new List<RoleSpawnPoint>()
            {
                new RoleSpawnPoint()
                {
                    Chance = 100,
                    Role = RoleTypeId.Scp939
                }
            }
        };
        //[Description("https://github.com/Exiled-Team/EXILED/blob/dev/Exiled.API/Enums/SpawnLocationType.cs")] public SpawnLocationType SpawnLocationType { get; set; } = SpawnLocationType.InsideLczWc;
        [Description("https://discord.com/channels/656673194693885975/1081925714569338941/1081925714569338941")] public RoomType SpawnLocation { get; set; } = RoomType.Hcz939;
        [Description("Minimal amount of player on server to spawn custom role")] public uint MinPlayersForSpawn { get; set; } = 8;
        [Description("Ammo on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1082601409846984754)")] public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            
        };
        [Description("Inventory on spawn - (https://discord.com/channels/656673194693885975/1081961667874795521/1081961667874795521)")] public List<string> Inventory { get; set; } = new List<string>()
        {
            
        };
        [Description("Show custom info to everyone, if False only teammates will see custom info of this role")] public bool ShowCustomInfoToEveryone { get; set; } = true;
        [Description("Teammates for this role (Custom roles using Name from Translation so it must be exactly the same!)")] public Teammates TeammatesToThisRole { get; set; } = new Teammates()
        {
            TeammatesRole = new List<RoleTypeId>()
            {
                RoleTypeId.Scp049,
                RoleTypeId.Scp079,
                RoleTypeId.Scp096,
                RoleTypeId.Scp106,
                RoleTypeId.Scp173,
                RoleTypeId.Scp0492,
                RoleTypeId.Scp939
            },
            TeammatesCustomRoles = new List<string>()
            {
                
            }
        };
        [Description("Amount of damage per attack")] public float DmgPerAtt { get; set; } = 5f;
    }
}