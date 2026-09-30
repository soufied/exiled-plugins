# NTFSpawnDisable

Adds a remote-admin command that lets staff toggle NTF and/or Chaos Insurgency team respawns on or off mid-round, automatically re-enabling both teams' respawns at round end / waiting-for-players. (Internal plugin name: `ReSpawnDisable`.)

## Features
- Hooks `Server.RespawningTeam` and blocks the respawn wave (`ev.IsAllowed = false`) for NTF and/or Chaos Insurgency when disabled.
- State resets to "both teams enabled" automatically on `RoundEnded` and `WaitingForPlayers`, so toggles don't persist across rounds.
- Adds the `respawn` (alias `rsp`) remote admin command to toggle either team independently.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.

```yaml
ntf_spawn_disable:
  is_enabled: true
```

## Commands & Permissions (if applicable)
- `respawn` (alias: `rsp`) — Remote Admin command. Usage: `respawn <enable|disable> <ntf|ci>` (or `rsp <enable|disable> <ntf|ci>`).
  - Toggling NTF requires permission `rsp.ntf`.
  - Toggling Chaos Insurgency requires permission `rsp.ci`.
  - Invalid or incomplete arguments return: `Error. Usage: respawn disable/enable ntf/ci or rsp disable/enable ntf/ci`.

## Installation
- Drop `NTFSpawnDisable.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).