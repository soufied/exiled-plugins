# SCP:SL EXILED Plugin Collection

A monorepo of custom [EXILED](https://github.com/ExMod-Team/EXILED) plugins for **SCP: Secret Laboratory** dedicated servers. The collection covers moderation/admin-abuse prevention, round-flow automation, custom doors/keycards, custom roles, and several standalone gameplay tweaks. The vast majority of plugins in this repo are originally authored by `soufi`. Three plugins are forks maintained by `soufi` of other developers' original standalone plugins (see below); all others — including every plugin in the Custom Roles Standalone and Custom Roles Module System sections — are original `soufi` works.

| Plugin | Fork of / Original Author |
|---|---|
| `CustomDoorAccess` | Faety |
| `SurfaceTension` | BuildBoy12 |
| `ForceSTS` | Jesus-QC |

> ⚠️ **Codebase notice:** This is a legacy/archival collection of independently-developed plugins pulled together into one repo. Target EXILED versions, authors, and code quality vary significantly between plugins (see the table below and each plugin's own README for specifics). Some plugins reference features that are not self-contained in this repo (see **Custom Roles — Module System** below). Review each plugin's target EXILED version against your server's installed EXILED build before deploying.

---

## Plugins Catalog

### Standalone plugins

| Plugin Name | Folder / Link | Description / What it Adds | EXILED / Target |
|---|---|---|---|
| **AntiGivingAbuse** | [`AntiGivingAbuse/`](./AntiGivingAbuse/README.md) | Blocks staff in configured permission groups from using the RA `give` command on other players (self-gives still allowed). Uses a Harmony transpiler to hook command dispatch. | EXILED ≥ 7.1.0 |
| **AutomatedBroadcasts** | [`AutomatedBroadcasts/`](./AutomatedBroadcasts/README.md) | Cycles through 5 configurable broadcasts at configurable intervals for the duration of the round. | EXILED ≥ 3.5.0 |
| **CustomDoorAccess** | [`CustomDoorAccess/`](./CustomDoorAccess/README.md) | Fine-grained, per-door/elevator/locker/generator/workstation keycard access control, with optional SCP bypass and "revoke all other keycards" mode. | EXILED ≥ 4.2.3 |
| **ExplodingCorpses** | [`ExplodingCorpses/`](./ExplodingCorpses/README.md) | Gives ragdolls of configured roles a chance to spawn a live HE grenade above the body when a spectator is present. | EXILED ≥ 7.1.0 |
| **ForceSTS** | [`ForceSTS/`](./ForceSTS/README.md) | Forces NTF respawn-wave players (RP-server oriented) into fixed formation spawn positions/rotations instead of the vanilla spawn system. | EXILED ≥ 3.5.0* |
| **NTFSpawnDisable** (`ReSpawnDisable`) | [`NTFSpawnDisable/`](./NTFSpawnDisable/README.md) | Adds a `respawn`/`rsp` RA command to toggle NTF and/or Chaos Insurgency team respawns on/off; resets to enabled each round. | EXILED ≥ 4.2.2 |
| **Scp173Elevators** | [`Scp173Elevators/`](./Scp173Elevators/README.md) | Blocks SCP-173 from using elevators for a configurable grace period at the start of the round, with a countdown hint. | EXILED ≥ 7.1.0 |
| **SurfaceTension** | [`SurfaceTension/`](./SurfaceTension/README.md) | After the Alpha Warhead detonates, deals configurable damage-over-time (flat or % of max HP) to all surviving players, with optional Cassie announcement and broadcast warning. | EXILED ≥ 2.1.29 |
| **WarheadTimer** | [`WarheadTimer/`](./WarheadTimer/README.md) | Shows every player a persistent, color-coded countdown hint of the time remaining until warhead detonation. | EXILED ≥ 4.1.7 |

### Custom Roles — Standalone

Self-contained custom roles/items, each its own EXILED plugin (no shared dependency beyond EXILED itself, other than the optional cross-plugin check in SCP-008 for the Hazard Suit).

| Plugin Name | Folder / Link | Description / What it Adds | EXILED / Target |
|---|---|---|---|
| **CustomItemHazardSuit** | [`CustomRoles-Standalone/CustomItemHazardSuit/`](./CustomRoles-Standalone/CustomItemHazardSuit/README.md) | Custom armor item (`CustomArmor`) that blocks SCP-049 / SCP-049-2 attacks while worn, with configurable SCP-914 upgrade/craft recipes. | EXILED ≥ 7.2.0 |
| **CustomRoleContainmentEngineer** | [`CustomRoles-Standalone/CustomRoleContainmentEngineer/`](./CustomRoles-Standalone/CustomRoleContainmentEngineer/README.md) | Custom role (base: Facility Guard) that has a chance to replace an existing player of that role at round start, with its own loadout and spawn point. | EXILED ≥ 7.2.0 |
| **CustomRoleFacilityManager** | [`CustomRoles-Standalone/CustomRoleFacilityManager/`](./CustomRoles-Standalone/CustomRoleFacilityManager/README.md) | Custom role (base: Scientist) that has a chance to replace an existing player of that role at round start, with its own loadout and spawn point. | EXILED ≥ 7.2.0 |
| **CustomRoleSCP008** | [`CustomRoles-Standalone/CustomRoleSCP008/`](./CustomRoles-Standalone/CustomRoleSCP008/README.md) | SCP-008 "infection" role: SCP-049-2 hits inflict a stacking infection with DoT, escalating into full transformation unless cured with a configured healing item. Includes custom Cassie announcements. | EXILED ≥ 7.2.0 (**known config issue**, see plugin README) |
| **LockdownOverrideCard** | [`CustomRoles-Standalone/LockdownOverrideCard/`](./CustomRoles-Standalone/LockdownOverrideCard/README.md) | Custom keycard (`CustomItem`) that can only open *locked* doors/gates and optionally call locked LCZ elevators during decontamination, with a Harmony patch to keep LCZ elevators usable during decontamination. | EXILED ≥ 7.2.0 |

### Custom Roles — Module System

Six "role modules" written against an internal **`CustomRolesModuleSystem`** core (classes such as `CoreModule<TConfig, TTranslation>` and `CustomRoleModuleSystem`). **The core framework project is not included in this archive** — these modules will not compile or load on their own; they must be paired with their host/core plugin.

| Module Name | Folder / Link | Description / What it Adds | Base Role | Priority |
|---|---|---|---|---|
| **Janitor** | [`CustomRoles-ModuleSystem/CustomRoleJanitor/`](./CustomRoles-ModuleSystem/CustomRoleJanitor/README.md) | Custom role replacing a Class-D/Chaos player ("Concierge"). | Class-D | 1 |
| **Doctor** | [`CustomRoles-ModuleSystem/CustomRoleDoctor/`](./CustomRoles-ModuleSystem/CustomRoleDoctor/README.md) | Custom role replacing a Scientist ("Infirmier"), spawns with a Defibrillator. | Scientist | 2 |
| **GuardSupervisor** | [`CustomRoles-ModuleSystem/CustomRoleGuardSupervisor/`](./CustomRoles-ModuleSystem/CustomRoleGuardSupervisor/README.md) | Custom role replacing a Facility Guard ("Garde Superviseur"). | Facility Guard | 3 |
| **Director** | [`CustomRoles-ModuleSystem/CustomRoleDirector/`](./CustomRoles-ModuleSystem/CustomRoleDirector/README.md) | Custom role replacing a Scientist ("Directeur"). | Scientist | 4 |
| **Scp225Fr** | [`CustomRoles-ModuleSystem/CustomRoleScp225Fr/`](./CustomRoles-ModuleSystem/CustomRoleScp225Fr/README.md) | Custom SCP role (base SCP-939) that deals a fixed configurable damage per attack. | SCP-939 | 5 |
| **UTR** | [`CustomRoles-ModuleSystem/CustomRoleUtr/`](./CustomRoles-ModuleSystem/CustomRoleUtr/README.md) | Elite custom role: unlimited stamina, immune to SCP-173/SCP-096 "turned" mechanics and pocket-dimension entry. Uses a Harmony patch. | Tutorial | 7 |

---

## Known Issues Across the Collection

- **`CustomRoleSCP008`**: `Api/Roles/Scp008.cs` references `Plugin.Singleton.Config.SpawnFrom`, a property that does **not** exist on its `Config` class. This will fail to compile as-is unless the property is added back (see the plugin's own README for details).
- **`CustomRoles-ModuleSystem/*`**: none of these six modules compile or run standalone — they all depend on an external `CustomRolesModuleSystem` core assembly that isn't part of this archive.
- Several plugins hardcode Discord message links in `[Description]` attributes as documentation for enum values (e.g., ammo/inventory item name lists); these links are preserved as-is in the per-plugin READMEs for reference but may no longer resolve.
