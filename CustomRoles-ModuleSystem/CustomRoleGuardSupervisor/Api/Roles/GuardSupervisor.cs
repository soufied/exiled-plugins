using System.Collections.Generic;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleGuardSupervisor.Api.Roles
{
    public class GuardSupervisor : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = GuardSupervisorModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = GuardSupervisorModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = GuardSupervisorModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = GuardSupervisorModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = GuardSupervisorModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = GuardSupervisorModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = GuardSupervisorModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = GuardSupervisorModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = GuardSupervisorModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = GuardSupervisorModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = GuardSupervisorModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = GuardSupervisorModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = GuardSupervisorModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = GuardSupervisorModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = GuardSupervisorModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = GuardSupervisorModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = GuardSupervisorModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = GuardSupervisorModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = GuardSupervisorModule.ModuleConfig.ShowCustomInfoToEveryone;
    }
}