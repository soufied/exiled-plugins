using System.Collections.Generic;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleDirector.Api.Roles
{
    public class Director : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = DirectorModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = DirectorModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = DirectorModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = DirectorModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = DirectorModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = DirectorModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = DirectorModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = DirectorModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = DirectorModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = DirectorModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = DirectorModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = DirectorModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = DirectorModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = DirectorModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = DirectorModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = DirectorModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = DirectorModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = DirectorModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = DirectorModule.ModuleConfig.ShowCustomInfoToEveryone;
    }
}