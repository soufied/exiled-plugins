# CustomRoleGuardSupervisor

A custom role module, Garde Superviseur (Guard Supervisor) (base role: Facility Guard), that has a chance to replace an existing Facility Guard player at round start with an upgraded Foundation Forces loadout.

> ⚠️ **Requires the `CustomRolesModuleSystem` core plugin.** This module registers itself against `CoreModule<TConfig, TTranslation>` / `CustomRoleModuleSystem` classes from the `CustomRolesModuleSystem` core framework, which is not included in this archive. It will not compile or load standalone — see [`CRMS README.md`](https://github.com/soufied/exiled-plugins/tree/main/CustomRoles-ModuleSystem) for details. Priority `3` determines its order relative to the others when the core loads them.

## Features
- On module enable, registers a `GuardSupervisor` custom role (`CustomRoleModuleSystem`) with the core framework and unregisters it on disable.
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role (Facility Guard) and convert them into the Guard Supervisor.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Grants an upgraded combat loadout (NTF Lieutenant keycard, Crossvec, combat armor, medkit, radio) that replaces the player's inventory on conversion. Does **not** keep the player's prior position or inventory on spawn.
- Spawns via a `SpawnProperties`/`RoleSpawnPoint` override targeting `FacilityGuard` (100% chance), drawn from the `FoundationForces` team.
- Defines a `TeammatesToThisRole` list so other roles/teammate custom roles are recognized as friendly for name/info display purposes.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the module.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`uint`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `58`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `100`) — max HP of the Guard Supervisor.
- `Role` (`RoleTypeId`, default `FacilityGuard`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `100`) — percentage chance the role spawns each round.
- `SpawnFromTeam` (`Team`, default `FoundationForces`) — team from which the replaced player is selected.
- `SpawnProperties` (`SpawnProperties`) — role spawn point override targeting `FacilityGuard` (100% chance), limited to 1 spawn; no dynamic spawn points configured.
- `SpawnLocation` (`RoomType`, default `EzPcs`) — additional configured spawn room.
- `MinPlayersForSpawn` (`uint`, default `6`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ Nato9: 60 }`) — ammo granted on spawn.
- `Inventory` (`List<string>`, default `["KeycardNTFLieutenant", "GunCrossvec", "Medkit", "Radio", "ArmorCombat"]`) — starting inventory item names.
- `ShowCustomInfoToEveryone` (`bool`, default `true`) — if `false`, only teammates see the role's custom info.
- `TeammatesToThisRole` (`Teammates`) — default teammate roles: `Scientist`, `FacilityGuard`, `NtfCaptain`, `NtfPrivate`, `NtfSergeant`, `NtfSpecialist`; default teammate custom roles: `"UTR"`, `"Director"`, `"Doctor"`.

```yaml
custom_role_guard_supervisor:
  is_enabled: true
  debug: false
  hint_duration: 5
  custom_role_id: 58
  max_health: 100
  role: FACILITY_GUARD
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 100.0
  spawn_from_team: FOUNDATION_FORCES
  spawn_properties:
    limit: 1
    role_spawn_points:
    - chance: 100
      role: FACILITY_GUARD
  spawn_location: EZ_PCS
  min_players_for_spawn: 6
  ammo:
    Nato9: 60
  inventory:
  - KeycardNTFLieutenant
  - GunCrossvec
  - Medkit
  - Radio
  - ArmorCombat
  show_custom_info_to_everyone: true
  teammates_to_this_role:
    teammates_role:
    - SCIENTIST
    - FACILITY_GUARD
    - NTF_CAPTAIN
    - NTF_PRIVATE
    - NTF_SERGEANT
    - NTF_SPECIALIST
    teammates_custom_roles:
    - UTR
    - Director
    - Doctor
```

```yaml
# Translation
custom_name: Guard Supervisor
custom_info: <color=#A0A0A0>Garde Superviseur</color>
name_translation: <color=#A0A0A0>Garde Superviseur</color>
description: You are <color=#A0A0A0>Garde Superviseur</color>, check console for more info (~)
console_msg: <size=60%>You are <color=#A0A0A0>Garde Superviseur</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleGuardSupervisor.dll`, **together with the `CustomRolesModuleSystem` core plugin DLL**, into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux). This module will not load without the core plugin present.