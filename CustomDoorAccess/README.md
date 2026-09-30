# CustomDoorAccess

Fine-grained, per-door/elevator/locker/generator/workstation keycard access control, with optional SCP bypass and a "revoke all other keycards" mode.
Fork of original plugin by Faety.

## Features
- Overrides default keycard access on a per-door basis via `Player.InteractingDoor`, with support for named item sets rather than the game's hardcoded permission flags.
- Handles generator unlocking (`Player.UnlockingGenerator`), elevator calls (`Player.InteractingElevator`), locker access (`Player.InteractingLocker`), and workstation activation (`Player.ActivatingWorkstation`) each with their own configurable access lists.
- Optional SCP bypass so SCPs can open specific configured checkpoint doors even without keycards.
- Optional SCP-079 bypass setting for camera-based door interactions.
- `RevokeAll` mode to strip default keycard access so only explicitly configured items work.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `RevokeAll` (`bool`, default `false`) — revokes access to all other keycards not explicitly configured.
- `ScpAccess` (`bool`, default `false`) — allows SCPs to open doors listed in `ScpAccessDoors`.
- `AccessSet` (`Dictionary<string, string>`, default `{"INTERCOM": "5&7"}`) — maps a door/object name to the item(s) permitted to access it.
- `ScpAccessDoors` (`List<string>`, default `["CHECKPOINT_LCZ_A", "CHECKPOINT_LCZ_B", "CHECKPOINT_EZ_HCZ"]`) — doors SCPs may open (only effective if also present in `AccessSet`).
- `Scp079Bypass` (`bool`, default `false`) — allows SCP-079 to bypass door access restrictions.
- `GeneratorAccess` (`List<int>`, default empty) — item IDs allowed to unlock generators; empty uses default keycard behavior.
- `ElevatorAccess` (`Dictionary<string, string>`, default empty) — per-elevator item access; empty means no restriction is applied.
- `LockersAccess` (`Dictionary<string, string>`, default empty) — per-locker item access; empty uses default keycard behavior or no restriction.
- `WorkStationAccess` (`List<int>`, default empty) — item IDs required to activate workstations; empty allows activation without any item.

```yaml
cda:
  is_enabled: true
  revoke_all: false
  scp_access: false
  access_set:
    INTERCOM: 5&7
  scp_access_doors:
  - CHECKPOINT_LCZ_A
  - CHECKPOINT_LCZ_B
  - CHECKPOINT_EZ_HCZ
  scp079_bypass: false
  generator_access: []
  elevator_access: {}
  lockers_access: {}
  work_station_access: []
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomDoorAccess.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).