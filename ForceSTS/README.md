# ForceSTS

Forces NTF respawn-wave players into fixed formation spawn positions and rotations instead of the vanilla scattered spawn system — oriented toward roleplay (RP) servers wanting a uniform "lineup" look for NTF drop-ins.
Fork of original plugin by Jesus-QC.

## Features
- Hooks `Server.RespawningTeam` and, when the incoming wave is Nine-Tailed Fox, repositions each respawning player half a second after the event fires.
- NTF Captain is placed at a fixed dedicated position/rotation.
- Remaining NTF troops are lined up along two fixed rows (`SpawnPos`/`SpawnPos2`), offset incrementally per player, up to 30 players in the first row and 27 in the second.

## Configuration
- `IsEnabled` (`bool`, default `true`) — present in the config class but not currently referenced by any code path, so it has no observable effect on plugin behavior as shipped.

```yaml
forcests:
  is_enabled: true
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `ForceSTS.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).