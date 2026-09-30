# CustomItemHazardSuit

A custom armor item (`CustomArmor`), the Hazard Suit, that completely blocks SCP-049 and SCP-049-2 attacks while worn, with configurable spawn locations and optional SCP-914 craft/upgrade recipes.

## Features
- Registers a `CustomArmor`-based custom item (default item ID `52`, base type `ArmorHeavy`) with configurable weight, spawn chance/location, stamina use multiplier, and helmet/vest efficacy.
- Hooks `Player.Hurting` to fully cancel damage from SCP-049 / SCP-049-2 against a wearer, and suppresses the Cardiac Arrest effect that would otherwise still apply.
- Hooks `Player.DroppingItem` to show a hint when the suit is dropped, and overrides the pickup hint to show the suit's name and description.
- Optional SCP-914 integration (`From914`): feeding a configured item type into SCP-914 on a specific knob setting has a percentage chance to craft the Hazard Suit instead.
- Optional SCP-914 integration (`In914`): running the Hazard Suit through SCP-914 on a specific knob setting has a percentage chance to convert it into another configured item, both for dropped pickups and items in inventory.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `CustomItemId` (`uint`, default `52`) — the custom item's internal ID.
- `CustomItemWeight` (`float`, default `1`) — inventory weight of the suit.
- `SpawnChance` (`float`, default `40`) — chance (of the configured dynamic spawn point) that the suit spawns.
- `SpawnLocationType` (`SpawnLocationType`, default `Inside049Armory`) — where the suit can spawn.
- `StaminaUseMultiplier` (`float`, default `1.8`) — stamina drain multiplier while worn; must be between 1 and 2.
- `HelmetEfficacy` (`int`, default `10`) — helmet damage reduction efficacy; must be between 0 and 100.
- `VestEfficacy` (`int`, default `20`) — vest damage reduction efficacy; must be between 0 and 100.
- `HintDuration` (`float`, default `4`) — seconds hints related to the suit are shown.
- `From914` (`bool`, default `true`) — whether the suit can be crafted by running an item through SCP-914.
- `CustomCraft` (`Dictionary<Scp914KnobSetting, CustomCraft>`, default `VeryFine → { ArmorCombat, 20% }`, `Fine → { ArmorHeavy, 30% }`) — per-knob-setting item + chance required to craft the suit from SCP-914.
- `In914` (`bool`, default `true`) — whether the suit itself can be upgraded/converted by SCP-914.
- `CustomUpgrade` (`Dictionary<Scp914KnobSetting, CustomCraft>`, default `VeryFine → { SCP500, 90% }`, `Fine → { SCP500, 50% }`) — per-knob-setting output item + chance when upgrading the suit in SCP-914.

```yaml
custom_item_hazard_suit:
  is_enabled: true
  debug: false
  custom_item_id: 52
  custom_item_weight: 1.0
  spawn_chance: 40.0
  spawn_location_type: INSIDE_049_ARMORY
  stamina_use_multiplier: 1.8
  helmet_efficacy: 10
  vest_efficacy: 20
  hint_duration: 4.0
  from914: true
  custom_craft:
    VeryFine:
      item: ARMOR_COMBAT
      chance: 20
    Fine:
      item: ARMOR_HEAVY
      chance: 30
  in914: true
  custom_upgrade:
    VeryFine:
      item: SCP500
      chance: 90
    Fine:
      item: SCP500
      chance: 50
```

```yaml
# Translation
suit_name: Hazard Suit
suit_description: <size=60%>Hazard Suit protects against SCP-049 and SCP-049-2 attacks</size>
suit_dropped: You dropped the Hazard Suit.
suit_taken: You taken the Hazard Suit.
suit_attacker: You cant infect or attack this player cuz he is wearing Hazard Suit.
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomItemHazardSuit.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).