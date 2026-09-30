# CustomRoleSCP008

SCP-008 "infection" role: attacks from a configured host role (SCP-0492 by default) inflict a stacking infection with damage-over-time, which escalates into full transformation into SCP-008-1 unless the victim cures it with a configured healing item in time. Includes custom Cassie announcements for various death/termination scenarios.

> ⚠️ **Known issue:** `API/Roles/Scp008.cs` references `Plugin.Singleton.Config.SpawnFrom` on lines handling round-start spawn selection, but no `SpawnFrom` property exists on the `Config` class in `Configs/Config.cs`. **This will fail to compile as-is** unless a `Team` (or similar) `SpawnFrom` property is added back to `Config`.

## Features
- Hooks `Player.Hurting` so attacks from the infection-carrier role deal configured impact damage and apply/stack an infection status on the victim (bypassed if the victim is wearing a registered Hazard Suit from the companion `CustomItemHazardSuit` plugin, if present).
- Hooks `Player.Dying`: an infected player who would die instead has the death cancelled, drops their items, and is transformed into SCP-008-1 at their death position.
- Hooks `Player.UsedItem` to cure the infection when a configured healing item (default: SCP-500) is consumed.
- Hooks `Player.Left` and `Player.ChangingRole` to clean up infection state when a player disconnects or changes role.
- Hooks `Scp0492.TriggeringBloodlust` to prevent SCP-008-1 instances from triggering the vanilla SCP-049-2 bloodlust mechanic.
- Custom Cassie announcement text/translation pairs for Warhead, Tesla, Decontamination, human-contained, NTF-contained, SCP-killed, Tutorial-killed, and unknown termination scenarios.
- Optional SCP-207 ("adrenaline") visual/stat effect applied to SCP-008-1 instances.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `CustomRoleId` (`uint`, default `51`) — the custom role's internal ID.
- `MaxHealth` (`int`, default `700`) — max HP of SCP-008-1.
- `EverySec` (`float`, default `1`) — interval in seconds at which damage is applied (referenced in code comments; not directly wired into the visible damage loop shown in the excerpted source).
- `DPS` (`float`, default `5`) — damage per tick.
- `DamageOnImpact` (`float`, default `10`) — damage dealt to a victim when infected on hit.
- `Role` (`RoleTypeId`, default `Scp0492`) — role whose attacks inflict the infection, and the role SCP-008-1 itself assumes.
- `Scale` (`Vector3`, default `(1, 1, 1)`) — player model scale.
- `SpawnChance` (`float`, default `20`) — percentage chance SCP-008 spawns each round.
- `SpawnLocationType` (`SpawnLocationType`, default `Inside049Armory`) — dynamic spawn point location.
- `UseClassDInsteadScp` (`bool`, default `true`) — present in config but the alternate spawn-source logic referencing it is commented out in the current source.
- `IgnoreSpawnSystem` (`bool`, default `true`) — whether the role ignores the base game's spawn system.
- `MinPlayersForSpawn` (`int`, default `6`) — minimum connected players required for the role to be eligible to spawn.
- `HealthItems` (`List<ItemType>`, default `[SCP500]`) — items that cure the infection when used.
- `ShowMsgToTargetWhenInfect` (`bool`, default `true`) — shows a hint to a freshly-infected player.
- `AppliedScp207Effect` (`bool`, default `true`) — applies the SCP-207 (adrenaline) visual effect to SCP-008-1 instances.
- `HazardSuitId` (`uint`, default `52`) — custom item ID of the Hazard Suit (from `CustomItemHazardSuit`) that blocks infection when worn, if that plugin is loaded.

```yaml
custom_role_scp008:
  is_enabled: true
  debug: false
  custom_role_id: 51
  max_health: 700
  every_sec: 1.0
  dps: 5.0
  damage_on_impact: 10.0
  role: SCP_0492
  scale:
    x: 1.0
    y: 1.0
    z: 1.0
  spawn_chance: 20.0
  spawn_location_type: INSIDE_049_ARMORY
  use_class_d_instead_scp: true
  ignore_spawn_system: true
  min_players_for_spawn: 6
  health_items:
  - SCP500
  show_msg_to_target_when_infect: true
  applied_scp207_effect: true
  hazard_suit_id: 52
```

```yaml
# Translation (abridged — see source for full Cassie message dictionary)
custom_name: SCP-008-1
custom_info: SCP-008-1
description: You are <color=red>SCP-008-1</color>, check console for more info (~)
console_msg: "<size=60%>You are <color=red>SCP-008-1</color>.\nEvery time you hit a player you infect him with <color=red>SCP-008</color>\nThe strength of the effect depends on the number of hits on the player</size>"
target_got_infected: <size=80%>You are infected with SCP-008 if you dont find SCP-500 you will become one of them...</size>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `CustomRoleSCP008.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).