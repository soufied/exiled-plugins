# CustomRoleFacilityManager

A custom role, Facility Manager (base role: Scientist), that has a chance to replace an existing Scientist player at round start with its own loadout, name tag, and spawn point.

## Features
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role and convert them into the Facility Manager.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Grants a custom loadout (weapon, ammo, armor, keycard, radio) that replaces the player's inventory on conversion.
- Spawns via a `SpawnProperties`/`DynamicSpawnPoint` entry at a configurable location and chance.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`float`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `52`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `120`) — max HP of the Facility Manager.
- `Role` (`RoleTypeId`, default `Scientist`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `50`) — percentage chance the role spawns each round.
- `SpawnLocationType` (`SpawnLocationType`, default `InsideIntercom`) — dynamic spawn point location.
- `IgnoreSpawnSystem` (`bool`, default `true`) — whether the role ignores the base game's spawn system.
- `MinPlayersForSpawn` (`int`, default `6`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ Nato9: 18, Nato556: 30 }`) — ammo granted on spawn.
- `Inventory` (`List<string>`, default `["KeycardFacilityManager", "GunE11SR", "Radio", "ArmorLight"]`) — starting inventory item names.

```yaml
custom_role_facility_manager:
  is_enabled: true
  debug: false
  hint_duration: 5.0
  custom_role_id: 52
  max_health: 120
  role: SCIENTIST
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 50.0
  spawn_location_type: INSIDE_INTERCOM
  ignore_spawn_system: true
  min_players_for_spawn: 6
  ammo:
    Nato9: 18
    Nato556: 30
  inventory:
  - KeycardFacilityManager
  - GunE11SR
  - Radio
  - ArmorLight
```

```yaml
# Translation
custom_name: Facility Manager
custom_info: Facility Manager
spawn: You have spawned as a <color=red>Facility Manager</color>
description: You are <color=red>Facility Manager</color>, check console for more info (~)
console_msg: <size=60%>You are <color=red>Facility Manager</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleFacilityManager.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).