# CustomRoleContainmentEngineer

A custom role, Containment Engineer (base role: Facility Guard), that has a chance to replace an existing Facility Guard player at round start with its own loadout, name tag, and spawn point.

## Features
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role and convert them into the Containment Engineer.
- Overrides the player's nickname display (hides role/unit name, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Grants a custom loadout (weapon, ammo, armor, medkit, keycard, etc.) that replaces the player's inventory on conversion.
- Configurable spawn position: either at the standard Facility Guard spawn or at a custom `SpawnLocationType`.
- Shows an on-screen hint with the role's description upon assignment.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`float`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `53`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `100`) — max HP of the Containment Engineer.
- `Role` (`RoleTypeId`, default `FacilityGuard`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `40`) — percentage chance the role spawns each round.
- `SpawnLocationAsGuard` (`bool`, default `true`) — if `true`, spawns at the base role's normal spawn; if `false`, uses `SpawnLocationType`.
- `SpawnLocationType` (`SpawnLocationType`, default `InsideServersBottom`) — custom spawn location, used only when `SpawnLocationAsGuard` is `false`.
- `IgnoreSpawnSystem` (`bool`, default `true`) — whether the role ignores the base game's spawn system.
- `MinPlayersForSpawn` (`int`, default `3`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ Nato9: 90 }`) — ammo granted on spawn.
- `Inventory` (`List<string>`, default `["KeycardContainmentEngineer", "GunFSP9", "Medkit", "GrenadeFlash", "Radio", "ArmorLight", "MicroHID"]`) — starting inventory item names.

```yaml
custom_role_containment_engineer:
  is_enabled: true
  debug: false
  hint_duration: 5.0
  custom_role_id: 53
  max_health: 100
  role: FACILITY_GUARD
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 40.0
  spawn_location_as_guard: true
  spawn_location_type: INSIDE_SERVERS_BOTTOM
  ignore_spawn_system: true
  min_players_for_spawn: 3
  ammo:
    Nato9: 90
  inventory:
  - KeycardContainmentEngineer
  - GunFSP9
  - Medkit
  - GrenadeFlash
  - Radio
  - ArmorLight
  - MicroHID
```

```yaml
# Translation
custom_name: Containment Engineer
custom_info: <color=#FFFF00>Containment Engineer</color>
spawn: You have spawned as a <color=yellow>Containment Engineer</color>
description: You are <color=yellow>Containment Engineer</color>, check console for more info (~)
console_msg: <size=60%>You are <color=yellow>Containment Engineer</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleContainmentEngineer.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).