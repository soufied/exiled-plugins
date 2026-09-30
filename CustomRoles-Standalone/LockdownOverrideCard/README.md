# LockdownOverrideCard

A custom keycard (`CustomItem`) that can only open *locked* doors/gates (not through normal scanner checkpoints) and, optionally, call locked LCZ elevators during a decontamination event, with a Harmony patch to keep LCZ elevators usable during decontamination.

## Features
- Registers a `CustomItem` (base type `KeycardZoneManager`, default item ID `51`) that reverses normal keycard logic: it opens doors that are currently *locked* rather than bypassing scanners on unlocked doors.
- Excludes specific door types (e.g. SCP-079 containment doors) and door lock reasons (e.g. admin command, warhead, decontamination locks) from being openable, even while locked.
- Optional `CanOpenDefDoors` setting to let the card additionally open standard non-keycard doors regardless of lock state.
- Special elevator-interaction logic for LCZ elevators (A/B) tied to the decontamination state: normally usable via the card only *during* decontamination, unless `CanUseUnlockedElevators` is enabled.
- Optional Harmony patch (`DoPatch`) applied to keep LCZ elevators functional during decontamination lockdown, since the card's elevator logic depends on it.
- Optional SCP-914 craft/upgrade recipes to create or convert the card, similar to `CustomItemHazardSuit`.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `CustomItemId` (`uint`, default `51`) — the custom item's internal ID.
- `CustomItemWeight` (`float`, default `1`) — inventory weight of the card.
- `SpawnChance` (`float`, default `70`) — chance the card spawns at its dynamic spawn point.
- `SpawnLocationType` (`SpawnLocationType`, default `Inside914`) — where the card can spawn.
- `HintDuration` (`float`, default `4`) — seconds hints related to the card are shown.
- `CanOpenDefDoors` (`bool`, default `true`) — allows the card to open standard doors without a scanner regardless of lock state.
- `DoorTypes` (`List<DoorType>`, default `[Scp079First, Scp079Second]`) — door types the card can never open/close.
- `DoorLockTypes` (`List<DoorLockType>`, default `[AdminCommand, Warhead, DecontEvacuate, DecontLockdown]`) — lock reasons the card cannot override.
- `DoPatch` (`bool`, default `true`) — applies a Harmony patch to allow LCZ elevator use during decontamination; disable if another plugin also manages LCZ elevator locking to avoid conflicts.
- `CanUseUnlockedElevators` (`bool`, default `true`) — allows the card to call elevators that aren't locked (outside decontamination).
- `From914` (`bool`, default `true`) — whether the card can be crafted by running an item through SCP-914.
- `CustomCraft` (`Dictionary<Scp914KnobSetting, CustomCraft>`, default `OneToOne → { KeycardZoneManager, 20% }`, `Fine → { KeycardO5, 50% }`) — per-knob-setting item + chance required to craft the card from SCP-914.
- `In914` (`bool`, default `true`) — whether the card itself can be upgraded/converted by SCP-914.
- `CustomUpgrade` (`Dictionary<Scp914KnobSetting, CustomCraft>`, default `VeryFine → { AntiSCP207, 50% }`, `Fine → { KeycardO5, 100% }`, `OneToOne → { KeycardZoneManager, 100% }`) — per-knob-setting output item + chance when upgrading the card in SCP-914.

```yaml
lockdown_override_card:
  is_enabled: true
  debug: false
  custom_item_id: 51
  custom_item_weight: 1.0
  spawn_chance: 70.0
  spawn_location_type: INSIDE_914
  hint_duration: 4.0
  can_open_def_doors: true
  door_types:
  - SCP_079_FIRST
  - SCP_079_SECOND
  door_lock_types:
  - ADMIN_COMMAND
  - WARHEAD
  - DECONT_EVACUATE
  - DECONT_LOCKDOWN
  do_patch: true
  can_use_unlocked_elevators: true
  from914: true
  custom_craft:
    OneToOne:
      item: KEYCARD_ZONE_MANAGER
      chance: 20
    Fine:
      item: KEYCARD_O5
      chance: 50
  in914: true
  custom_upgrade:
    VeryFine:
      item: ANTI_SCP207
      chance: 50
    Fine:
      item: KEYCARD_O5
      chance: 100
    OneToOne:
      item: KEYCARD_ZONE_MANAGER
      chance: 100
```

```yaml
# Translation
keycard_name: Lockdown Override Card
keycard_select: You select the Lockdown Override Card.
keycard_description: "<size=60%>This keycard can open ONLY locked doors. (Scp-079, Scp-2176)\n and\n USE locked elevators. (Decontamination)</size>"
keycard_cant_open: You place the keycard on the scanner but nothing happens.
keycard_cant_call_elevator: You place the keycard on the scanner but nothing happens.
keycard_dropped: You dropped the Lockdown Override Card.
keycard_taken: You taken the Lockdown Override Card.
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `LockdownOverrideCard.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).