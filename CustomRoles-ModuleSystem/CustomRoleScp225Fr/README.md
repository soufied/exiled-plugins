# CustomRoleScp225Fr

A custom role module, SCP-225-FR (base role: SCP-939), that has a chance to replace an existing SCP-939 player at round start and deals a fixed, configurable damage amount per attack instead of the base role's normal damage.

> ⚠️ **Requires the `CustomRolesModuleSystem` core plugin.** This module registers itself against `CoreModule<TConfig, TTranslation>` / `CustomRoleModuleSystem` classes from the `CustomRolesModuleSystem` core framework, which is not included in this archive. It will not compile or load standalone — see `CustomRoles-ModuleSystem/README.md` for details. Priority `5` (lowest of the six modules) determines its order relative to the others when the core loads them.

## Features
- On module enable, registers a `Scp225Fr` custom role (`CustomRoleModuleSystem`) with the core framework and unregisters it on disable.
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role (SCP-939) and convert them into SCP-225-FR.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- Overrides `OnHurting`: when the custom role's player is the attacker (per the inherited `Check` method — see note above), the outgoing damage is replaced with a fixed `DmgPerAtt` value instead of the base game's calculated damage.
- Slightly smaller model scale (`0.8, 0.8, 0.8`) than the other modules in this collection (which default to `1, 1, 1`).
- Spawns via a `SpawnProperties`/`RoleSpawnPoint` override targeting `Scp939` (100% chance), drawn from the Class-D team. Does **not** keep the player's prior position or inventory on spawn.
- No starting ammo or inventory items are configured by default (both empty).
- Defines a `TeammatesToThisRole` list of SCP roles so other SCPs are recognized as friendly for name/info display purposes; no teammate custom roles configured.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the module.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`uint`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `60`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `200`) — max HP of SCP-225-FR.
- `Role` (`RoleTypeId`, default `Scp939`) — base role this custom role replaces.
- `Scale` (`Vector3`, default `(0.8, 0.8, 0.8)`) — player model scale.
- `SpawnChance` (`float`, default `100`) — percentage chance the role spawns each round.
- `SpawnFromTeam` (`Team`, default `ClassD`) — team from which the replaced player is selected.
- `SpawnProperties` (`SpawnProperties`) — role spawn point override targeting `Scp939` (100% chance), limited to 1 spawn; no dynamic spawn points configured.
- `SpawnLocation` (`RoomType`, default `Hcz939`) — additional configured spawn room.
- `MinPlayersForSpawn` (`uint`, default `8`) — minimum connected players required for the role to be eligible to spawn.
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ }` — empty) — ammo granted on spawn; none configured by default.
- `Inventory` (`List<string>`, default `[]` — empty) — starting inventory items; none configured by default.
- `ShowCustomInfoToEveryone` (`bool`, default `true`) — if `false`, only teammates see the role's custom info.
- `TeammatesToThisRole` (`Teammates`) — default teammate roles: `Scp049`, `Scp079`, `Scp096`, `Scp106`, `Scp173`, `Scp0492`, `Scp939`; no teammate custom roles configured.
- `DmgPerAtt` (`float`, default `5`) — flat damage dealt per attack landed by SCP-225-FR.

```yaml
custom_role_scp225_fr:
  is_enabled: true
  debug: false
  hint_duration: 5
  custom_role_id: 60
  max_health: 200
  role: SCP_939
  scale:
    x: 0.8
    y: 0.8
    z: 0.8
  spawn_chance: 100.0
  spawn_from_team: CLASS_D
  spawn_properties:
    limit: 1
    role_spawn_points:
    - chance: 100
      role: SCP_939
  spawn_location: HCZ_939
  min_players_for_spawn: 8
  ammo: {}
  inventory: []
  show_custom_info_to_everyone: true
  teammates_to_this_role:
    teammates_role:
    - SCP_049
    - SCP_079
    - SCP_096
    - SCP_106
    - SCP_173
    - SCP_0492
    - SCP_939
    teammates_custom_roles: []
  dmg_per_att: 5.0
```

```yaml
# Translation
custom_name: Scp225Fr
custom_info: <color=#C50000>SCP-225-FR</color>
name_translation: <color=#C50000>SCP-225-FR</color>
description: You are <color=#C50000>SCP-225-FR</color>, check console for more info (~)
console_msg: <size=60%>You are <color=#C50000>SCP-225-FR</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleScp225Fr.dll`, **together with the `CustomRolesModuleSystem` core plugin DLL**, into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux). This module will not load without the core plugin present.