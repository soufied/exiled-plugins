# SurfaceTension

After the Alpha Warhead detonates, deals configurable damage-over-time (flat HP or % of max HP) to all surviving players on the server, with optional Cassie announcement, broadcast warning, and console logging.
Fork of original plugin by BuildBoy12.

## Features
- Hooks `Warhead.Detonated` to begin a delayed damage-over-time cycle once the Alpha Warhead goes off.
- Damage can be configured as a flat HP amount or a percentage of each player's max HP.
- Optional Cassie announcement and optional server-wide broadcast when the radiation tension begins.
- Per-tick hint shown to each damaged player with a configurable warning message.
- Optional console logging of when surface tension starts and its damage parameters.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `DelayTime` (`int`, default `90`) — seconds to wait after detonation before damage begins; values below 1 start damage instantly.
- `DamageAmount` (`int`, default `1`) — amount of damage dealt per interval (flat HP or percentage, depending on `DamageAsPercentage`).
- `DamageInterval` (`float`, default `1`) — seconds between each damage tick.
- `DamageAsPercentage` (`bool`, default `true`) — `true` treats `DamageAmount` as a percentage of max HP, `false` treats it as a flat HP value.
- `DamageMessage` (`string`, default `"You are being damaged by radiation!"`) — hint shown to players while they're being damaged.
- `EnableCassie` (`bool`, default `true`) — whether Cassie announces the start of surface tension.
- `CassieMessage` (`string`, default `"Alpha Warhead Radiation Warning"`) — the Cassie announcement text.
- `EnableBroadcast` (`bool`, default `false`) — whether a broadcast warning is sent to all players.
- `BroadcastMessage` (`string`, default `"Radiation warning, leave the facility immediately!"`) — broadcast warning text.
- `BroadcastDuration` (`ushort`, default `6`) — seconds the broadcast stays on screen.
- `ConsoleLogs` (`bool`, default `true`) — whether surface tension start/parameters are logged to console.

```yaml
surface_tension:
  is_enabled: true
  delay_time: 90
  damage_amount: 1
  damage_interval: 1.0
  damage_as_percentage: true
  damage_message: You are being damaged by radiation!
  enable_cassie: true
  cassie_message: Alpha Warhead Radiation Warning
  enable_broadcast: false
  broadcast_message: Radiation warning, leave the facility immediately!
  broadcast_duration: 6
  console_logs: true
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `SurfaceTension.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).