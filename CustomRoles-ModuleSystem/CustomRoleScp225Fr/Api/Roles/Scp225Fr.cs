using System.Collections.Generic;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Semifaces;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace CustomRoleScp225Fr.Api.Roles
{
    public class Scp225Fr : CustomRoleModuleSystem
    {
        public override uint Id { get; set; } = Scp225FrModule.ModuleConfig.CustomRoleId;
        public override int MaxHealth { get; set; } = Scp225FrModule.ModuleConfig.MaxHealth;
        public override string Name { get; set; } = Scp225FrModule.ModuleTranslation.CustomName;
        public override string Description { get; set; } = Scp225FrModule.ModuleTranslation.Description;
        public override string CustomInfo { get; set; } = Scp225FrModule.ModuleTranslation.CustomInfo;
        public override string ConsoleMessage { get; set; } = Scp225FrModule.ModuleTranslation.ConsoleMsg;
        public override uint MinPlayersToSpawn { get; set; } = Scp225FrModule.ModuleConfig.MinPlayersForSpawn;
        public override RoomType SpawnLocation { get; set; } = Scp225FrModule.ModuleConfig.SpawnLocation;
        public override Team SpawnFromTeam { get; set; } = Scp225FrModule.ModuleConfig.SpawnFromTeam;
        public override string NameTranslation { get; set; } = Scp225FrModule.ModuleTranslation.NameTranslation;
        public override uint HintDuration { get; set; } = Scp225FrModule.ModuleConfig.HintDuration;
        public override float SpawnChance { get; set; } = Scp225FrModule.ModuleConfig.SpawnChance;
        public override RoleTypeId Role { get; set; } = Scp225FrModule.ModuleConfig.Role;
        public override bool KeepPositionOnSpawn { get; set; } = false;
        public override bool KeepInventoryOnSpawn { get; set; } = false;
        public override Dictionary<AmmoType, ushort> Ammo { get; set; } = Scp225FrModule.ModuleConfig.Ammo;
        public override List<string> Inventory { get; set; } = Scp225FrModule.ModuleConfig.Inventory;
        public override Vector3 Scale { get; set; } = Scp225FrModule.ModuleConfig.Scale;
        public override SpawnProperties SpawnProperties { get; set; } = Scp225FrModule.ModuleConfig.SpawnProperties;
        public override Teammates TeammatesToThisRole { get; set; } = Scp225FrModule.ModuleConfig.TeammatesToThisRole;
        public override bool ShowCustomInfoToEveryone { get; set; } = Scp225FrModule.ModuleConfig.ShowCustomInfoToEveryone;
        protected override void OnHurting(HurtingEventArgs ev)
        {
            base.OnHurting(ev);
            if (ev.Attacker == null || ev.Player == null) return;
            if (!Check(ev.Attacker)) return;
            ev.Amount = Scp225FrModule.ModuleConfig.DmgPerAtt;
        }
    }
}