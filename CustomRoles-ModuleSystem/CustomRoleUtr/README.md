# CustomRoleUtr

A custom role module, UTR (base role: Tutorial by default), that has a chance to replace an existing player at round start, is immune to SCP-173 and SCP-096 (treated as already "turned"/seen), has permanently zeroed stamina, and cannot enter the pocket dimension.

> ⚠️ **Requires the `CustomRolesModuleSystem` core plugin.** This module registers itself against `CoreModule<TConfig, TTranslation>` / `CustomRoleModuleSystem` classes from the `CustomRolesModuleSystem` core framework, which is not included in this archive. It will not compile or load standalone — see `CustomRoles-ModuleSystem/README.md` for details. Priority `7` determines its order relative to the others when the core loads them (the highest numeric priority of the six, and the only one to also install its own Harmony patches).

## Features
- On module enable, patches the game via its own Harmony instance (`soufi.utr.role`) in addition to registering the `Utr` custom role (`CustomRoleModuleSystem`) with the core framework; both the Harmony patches and the role registration are cleanly undone on disable.
- Each round start, rolls a configured spawn chance (gated behind a minimum player count) to select one existing player of the base role and convert them into UTR.
- Overrides the player's nickname display (hides role tag, shows nickname + custom info) and sets a custom console message visible via the player's console (`~`).
- On role assignment (`AddRole`) and revival (`ReviveRole`), attaches a custom `DisableStaminaComp` component to the player's `GameObject` that forces `Player.Stamina` to `0` every `FixedUpdate` tick, and adds the player to both `Scp173Role.TurnedPlayers` and `Scp096Role.TurnedPlayers` — making UTR immune to SCP-173's freeze mechanic and to SCP-096's rage trigger from being looked at. The component is removed and the player pulled from both lists on `RemoveRole`.
- Subscribes to `Exiled.Events.Handlers.Player.EnteringPocketDimension`: if the entering player is this custom role (per the inherited `Check` method — see note above), pocket dimension entry is cancelled (`ev.IsAllowed = false`).
- Grants a combat loadout (NTF Lieutenant keycard, Logicer rifle, combat armor, radio) that replaces the player's inventory on conversion. Does **not** keep the player's prior position or inventory on spawn.
- Spawns via a `SpawnProperties`/`DynamicSpawnPoint` entry at `InsideLczArmory` (50% chance) plus a role spawn point override targeting `Scientist` (100%), drawn from the Foundation Forces team.
- Defines a `TeammatesToThisRole` list so other roles/teammate custom roles are recognized as friendly for name/info display purposes.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the module.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `HintDuration` (`uint`, default `5`) — seconds the spawn hint is displayed.
- `CustomRoleId` (`uint`, default `61`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `300`) — max HP of UTR.
- `Role` (`RoleTypeId`, default `Tutorial`) — base role this custom role replaces (see config oddity note above).
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `60`) — percentage chance the role spawns each round.
- `SpawnFromTeam` (`Team`, default `FoundationForces`) — team from which the replaced player is selected.
- `SpawnProperties` (`SpawnProperties`) — dynamic spawn point at `InsideLczArmory` (50% chance), limited to 1 spawn, plus a role spawn point override targeting `Scientist` (100%).
- `SpawnLocation` (`RoomType`, default `LczArmory`) — additional configured spawn room.
- `MinPlayersForSpawn` (`uint`, default `12`) — minimum connected players required for the role to be eligible to spawn (the highest threshold of the six modules).
- `Ammo` (`Dictionary<AmmoType, ushort>`, default `{ Nato762: 100 }`) — ammo granted on spawn.
- `Inventory` (`List<string>`, default `["KeycardNTFLieutenant", "GunLogicer", "Radio", "ArmorCombat"]`) — starting inventory item names.
- `ShowCustomInfoToEveryone` (`bool`, default `true`) — if `false`, only teammates see the role's custom info.
- `TeammatesToThisRole` (`Teammates`) — default teammate roles: `Scientist`, `FacilityGuard`, `NtfCaptain`, `NtfPrivate`, `NtfSergeant`, `NtfSpecialist`; default teammate custom roles: `"Doctor"`, `"Director"`, `"Guard Supervisor"`.

```yaml
custom_role_utr:
  is_enabled: true
  debug: false
  hint_duration: 5
  custom_role_id: 61
  max_health: 300
  role: TUTORIAL
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 60.0
  spawn_from_team: FOUNDATION_FORCES
  spawn_properties:
    limit: 1
    dynamic_spawn_points:
    - chance: 50
      location: INSIDE_LCZ_ARMORY
    role_spawn_points:
    - chance: 100
      role: SCIENTIST
  spawn_location: LCZ_ARMORY
  min_players_for_spawn: 12
  ammo:
    Nato762: 100
  inventory:
  - KeycardNTFLieutenant
  - GunLogicer
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
    - Doctor
    - Director
    - Guard Supervisor
```

```yaml
# Translation
custom_name: UTR
custom_info: <color=#32CD32>UTR</color>
name_translation: <color=#32CD32>UTR</color>
description: You are <color=#32CD32>UTR</color>, check console for more info (~)
console_msg: <size=60%>You are <color=#32CD32>UTR</color></size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleUtr.dll`, **together with the `CustomRolesModuleSystem` core plugin DLL**, into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux). This module will not load without the core plugin present.