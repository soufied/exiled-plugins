# Scp173Elevators

Blocks SCP-173 from using elevators for a configurable grace period at the start of the round, showing a countdown hint explaining how much longer the restriction lasts.

## Features
- Hooks `Player.InteractingElevator` and denies the interaction specifically for players currently playing SCP-173.
- Restriction is only active until `Scp173Time` seconds have elapsed in the round; after that, SCP-173 can use elevators normally.
- Shows a dynamic hint on each blocked attempt with the remaining lockout time (minutes and seconds) substituted into the message.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `Scp173Time` (`ushort`, default `480`) — seconds into the round during which SCP-173 is blocked from elevators (max `65535`).
- `HintDuration` (`float`, default `3`) — seconds the hint is displayed on screen.
- `Scp173TimeHint` (Translation, `string`, default `"You cannot use the elevators for the first %starttime% minutes of the round.\nWait %rtmin% min. %rtsec% sec."`) — hint text; supports `%starttime%`, `%rtmin%`, and `%rtsec%` placeholders.

```yaml
scp173_elevators:
  is_enabled: true
  debug: false
  scp173_time: 480
  hint_duration: 3.0
```

```yaml
# Translation
scp173_time_hint: |-
  You cannot use the elevators for the first %starttime% minutes of the round.
  Wait %rtmin% min. %rtsec% sec.
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `Scp173Elevators.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).