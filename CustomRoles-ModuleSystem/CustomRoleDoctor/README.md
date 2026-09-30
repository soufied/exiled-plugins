# CustomRoleDoctor

A custom role module, Infirmier (Doctor) (base role: Scientist), that has a chance to replace an existing Scientist player at round start, spawning with a Defibrillator and other medical loadout items.

> ⚠️ **Requires the `CustomRolesModuleSystem` core plugin.** This module registers itself against `CoreModule<TConfig, TTranslation>` / `CustomRoleModuleSystem` classes from the `CustomRolesModuleSystem` core framework, which is not included in this archive. It will not compile or load standalone — see [`CRMS README.md`](https://github.com/soufied/exiled-plugins/tree/main/CustomRoles-ModuleSystem) for details. Priority `2` determines its order relative to the others when the core loads them.

## Features
- On module enable, registers a `Doctor` custom role (`CustomRoleModuleSystem`) with the core framework and unregisters it on disable.
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role (Scientist) and convert them into the Doctor.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Grants a custom loadout — notably a Defibrillator alongside a Medkit, keycard, and radio — that replaces the player's inventory on conversion. Does **not** keep the player's prior position or inventory on spawn.
- Spawns via a `SpawnProperties`/`DynamicSpawnPoint` entry at a configurable location and chance, drawn from a configurable source team.
- Defines a `TeammatesToThisRole` list so other roles/teammate custom roles are recognized as friendly for name/info display purposes.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the module.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`uint`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `57`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `100`) — max HP of the Doctor.
- `Role` (`RoleTypeId`, default `Scientist`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `100`) — percentage chance the role spawns each round.
- `SpawnFromTeam` (`Team`, default `Scientists`) — team from which the replaced player is selected.
- `SpawnProperties` (`SpawnProperties`) — dynamic spawn point at `InsideGr18` (20% chance), limited to 1 spawn, plus a role spawn point override targeting `Scientist` (100%).
- `SpawnLocation` (`RoomType`, default `LczGlassBox`) — additional configured spawn room.
- `MinPlayersForSpawn` (`uint`, default `4`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ }` — empty) — ammo granted on spawn; none configured by default.
- `Inventory` (`List<string>`, default `["KeycardScientist", "Medkit", "Radio", "Defibrillator"]`) — starting inventory item names.
- `ShowCustomInfoToEveryone` (`bool`, default `true`) — if `false`, only teammates see the role's custom info.
- `TeammatesToThisRole` (`Teammates`) — default teammate roles: `Scientist`, `FacilityGuard`, `NtfCaptain`, `NtfPrivate`, `NtfSergeant`, `NtfSpecialist`; default teammate custom roles: `"UTR"`, `"Director"`, `"Guard Supervisor"`.

```yaml
custom_role_doctor:
  is_enabled: true
  debug: false
  hint_duration: 5
  custom_role_id: 57
  max_health: 100
  role: SCIENTIST
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 100.0
  spawn_from_team: SCIENTISTS
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - chance: 20
      location: INSIDE_GR18
    role_spawn_points:
    - chance: 100
      role: SCIENTIST
  spawn_location: LCZ_GLASS_BOX
  min_players_for_spawn: 4
  ammo: {}
  inventory:
  - KeycardScientist
  - Medkit
  - Radio
  - Defibrillator
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
    - Guard Supervisor
```

```yaml
# Translation
custom_name: Doctor
custom_info: <color=#FAFF86>Infirmier</color>
name_translation: <color=#FAFF86>Infirmier</color>
description: You are <color=#FAFF86>Infirmier</color>, check console for more info (~)
console_msg: <size=60%>You are <color=#FAFF86>Infirmier</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleDoctor.dll`, **together with the `CustomRolesModuleSystem` core plugin DLL**, into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux). This module will not load without the core plugin present.