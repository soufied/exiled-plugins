using System.Collections.Generic;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleJanitor.Api.Roles
{
    public class Janitor : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = JanitorModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = JanitorModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = JanitorModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = JanitorModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = JanitorModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = JanitorModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = JanitorModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = JanitorModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = JanitorModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = JanitorModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = JanitorModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = JanitorModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = JanitorModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = JanitorModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = JanitorModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = JanitorModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = JanitorModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = JanitorModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = JanitorModule.ModuleConfig.ShowCustomInfoToEveryone;
    }
}