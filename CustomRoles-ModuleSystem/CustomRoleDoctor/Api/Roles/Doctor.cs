using System.Collections.Generic;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleDoctor.Api.Roles
{
    public class Doctor : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = DoctorModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = DoctorModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = DoctorModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = DoctorModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = DoctorModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = DoctorModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = DoctorModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = DoctorModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = DoctorModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = DoctorModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = DoctorModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = DoctorModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = DoctorModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = DoctorModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = DoctorModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = DoctorModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = DoctorModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = DoctorModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = DoctorModule.ModuleConfig.ShowCustomInfoToEveryone;
    }
}