# CustomRoleJanitor

A custom role module, Concierge (Janitor) (base role: Class-D), that has a chance to replace an existing Class-D player at round start with a minimal janitorial loadout.

> ⚠️ **Requires the `CustomRolesModuleSystem` core plugin.** This module registers itself against `CoreModule<TConfig, TTranslation>` / `CustomRoleModuleSystem` classes from the `CustomRolesModuleSystem` core framework, which is not included in this archive. It will not compile or load standalone — see `CustomRoles-ModuleSystem/README.md` for details. Priority `1` (highest load priority among the six modules) determines its order relative to the others when the core loads them.
>
> ⚠️ **Config/name mismatch:** `TeammatesToThisRole.TeammatesCustomRoles` lists `"Dr Maynard"`, `"Agent Skinner"`, and `"Captain of Chaos"` — none of these match the `CustomName` of any custom role module present in this archive (Director, Doctor, Guard Supervisor, SCP-225-FR, UTR). These entries appear to reference custom roles from outside this collection.

## Features
- On module enable, registers a `Janitor` custom role (`CustomRoleModuleSystem`) with the core framework and unregisters it on disable.
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role (Class-D) and convert them into the Janitor.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Grants a minimal loadout (just a Janitor keycard) that replaces the player's inventory on conversion. Does **not** keep the player's prior position or inventory on spawn.
- Spawns via a `SpawnProperties`/`DynamicSpawnPoint` entry at a configurable location and chance, drawn from the Class-D team.
- Defines a `TeammatesToThisRole` list so other roles/teammate custom roles are recognized as friendly for name/info display purposes (see mismatch note above).

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the module.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`uint`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `56`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `100`) — max HP of the Janitor.
- `Role` (`RoleTypeId`, default `ClassD`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `40`) — percentage chance the role spawns each round.
- `SpawnFromTeam` (`Team`, default `ClassD`) — team from which the replaced player is selected.
- `SpawnProperties` (`SpawnProperties`) — dynamic spawn point at `InsideLczWc` (100% chance), limited to 1 spawn; no role spawn point override configured.
- `SpawnLocation` (`RoomType`, default `LczToilets`) — additional configured spawn room.
- `MinPlayersForSpawn` (`uint`, default `1`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ }` — empty) — ammo granted on spawn; none configured by default.
- `Inventory` (`List<string>`, default `["KeycardJanitor"]`) — starting inventory item names.
- `ShowCustomInfoToEveryone` (`bool`, default `true`) — if `false`, only teammates see the role's custom info.
- `TeammatesToThisRole` (`Teammates`) — default teammate roles: `ClassD`, `ChaosConscript`, `ChaosMarauder`, `ChaosRepressor`, `ChaosRifleman`; default teammate custom roles: `"Dr Maynard"`, `"Agent Skinner"`, `"Captain of Chaos"` (see mismatch note above).

```yaml
custom_role_janitor:
  is_enabled: true
  debug: false
  hint_duration: 5
  custom_role_id: 56
  max_health: 100
  role: CLASS_D
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 40.0
  spawn_from_team: CLASS_D
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - chance: 100
      location: INSIDE_LCZ_WC
  spawn_location: LCZ_TOILETS
  min_players_for_spawn: 1
  ammo: {}
  inventory:
  - KeycardJanitor
  show_custom_info_to_everyone: true
  teammates_to_this_role:
    teammates_role:
    - CLASS_D
    - CHAOS_CONSCRIPT
    - CHAOS_MARAUDER
    - CHAOS_REPRESSOR
    - CHAOS_RIFLEMAN
    teammates_custom_roles:
    - Dr Maynard
    - Agent Skinner
    - Captain of Chaos
```

```yaml
# Translation
custom_name: Janitor
custom_info: <color=#EE7600>Concierge</color>
name_translation: <color=#EE7600>Concierge</color>
description: You are <color=#EE7600>Concierge</color>, check console for more info (~)
console_msg: <size=60%>You are <color=#EE7600>Concierge</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleJanitor.dll`, **together with the `CustomRolesModuleSystem` core plugin DLL**, into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux). This module will not load without the core plugin present.