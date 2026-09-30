# ExplodingCorpses

Gives ragdolls of configured roles a chance to spawn a live, armed HE grenade hovering above the body — but only when a spectator is present to witness/trigger it.

## Features
- Hooks `Player.SpawningRagdoll` to roll a per-death explosion chance for configured roles.
- Only triggers if at least one spectator exists on the server (the spectator is set as the grenade's owner for kill attribution).
- Spawns a live `ExplosiveGrenade` (HE grenade) slightly above the ragdoll's position with a configurable fuse time, blast radius, and SCP damage multiplier.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `BoomClasses` (`List<RoleTypeId>`, default includes `ClassD`, `ChaosConscript`, `ChaosMarauder`, `ChaosRepressor`, `ChaosRifleman`, `NtfCaptain`, `NtfPrivate`, `NtfSergeant`, `NtfSpecialist`, `Scientist`, `FacilityGuard`, `Scp173`, `Scp0492`, `Scp049`) — roles whose corpses can explode.
- `TickTack` (`float`, default `1`) — grenade fuse time in seconds before detonation.
- `ScpDamageMultiplier` (`float`, default `3`) — damage multiplier applied to SCPs caught in the blast.
- `MaxRadius` (`float`, default `9`) — explosion blast radius.
- `ExpChance` (`int`, default `20`) — percentage chance (1–100) that a given death triggers the explosion.

```yaml
exploding_corpses:
  is_enabled: true
  debug: false
  boom_classes:
  - CLASS_D
  - CHAOS_CONSCRIPT
  - CHAOS_MARAUDER
  - CHAOS_REPRESSOR
  - CHAOS_RIFLEMAN
  - NTF_CAPTAIN
  - NTF_PRIVATE
  - NTF_SERGEANT
  - NTF_SPECIALIST
  - SCIENTIST
  - FACILITY_GUARD
  - SCP_173
  - SCP_049_2
  - SCP_049
  tick_tack: 1.0
  scp_damage_multiplier: 3.0
  max_radius: 9.0
  exp_chance: 20
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `ExplodingCorpses.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).