# CustomRoles-ModuleSystem

A modular collection of six custom SCP: Secret Laboratory roles — Director, Doctor, Guard Supervisor, Janitor, SCP-225-FR, and UTR — built as independent "role modules" against a shared, private core framework rather than as standalone EXILED plugins.

## Upstream Architecture & Foundation

Each module in this folder is a `CoreModule<TConfig, TTranslation>` subclass exposing a `CustomRoleModuleSystem`-derived role class. The underlying engine these modules run on — **`CustomRolesModuleSystem`** — is a personal, heavily modified fork of the open-source [`Exiled.CustomRoles`](https://github.com/ExMod-Team/EXILED/tree/master/EXILED/Exiled.CustomRoles) framework, extended with deeper role lifecycle handling, expanded ability abstractions, and richer event integration than the old base provides.

> [!IMPORTANT]
> **Why the core framework's source is withheld.** The `CustomRolesModuleSystem` core engine that these six modules depend on is intentionally **not included** in this repository. This is a deliberate decision to prevent server owners — particularly the predatory monetization practices common on some Russian SCP:SL servers, which extract money from underage players through abusive donation systems, paywalled VIP privileges, and monetized custom roles — from commercially exploiting this framework. The role modules themselves are shared publicly as reference and showcase material; the engine that powers them is kept private.
>
> **Practical consequence:** none of the modules below will compile or load on their own. Each requires the `CustomRolesModuleSystem` core plugin DLL to be present alongside it at runtime, and that DLL is not distributed with this collection.

## Included Role Modules

| Module / Role Name | Base Role / Team | Summary / Core Gimmick |
|---|---|---|
| [`Director`](./CustomRoleDirector/README.md) | Scientist / Scientists | Chance-based Scientist replacement with its own loadout, spawn points, and console message; no special mechanics beyond the standard module conversion flow. |
| [`Doctor`](./CustomRoleDoctor/README.md) | Scientist / Scientists | Chance-based Scientist replacement ("Infirmier") that spawns with a Defibrillator and medical loadout. |
| [`Guard Supervisor`](./CustomRoleGuardSupervisor/README.md) | Facility Guard / Foundation Forces | Chance-based Facility Guard replacement ("Garde Superviseur") upgraded with an NTF-tier combat loadout. |
| [`Janitor`](./CustomRoleJanitor/README.md) | Class-D / Class-D | Chance-based Class-D replacement ("Concierge") with a minimal, single-keycard loadout. |
| [`SCP-225-FR`](./CustomRoleScp225Fr/README.md) | SCP-939 / Class-D | Chance-based SCP-939 replacement that deals a fixed, configurable damage amount per attack instead of the base role's normal damage. |
| [`UTR`](./CustomRoleUtr/README.md) | Tutorial (configurable) / Foundation Forces | Chance-based replacement with permanently disabled stamina, immunity to SCP-173's freeze and SCP-096's rage trigger, and a block on entering the pocket dimension; the only module that also installs its own Harmony patches. |

Full configuration values, YAML snippets, and per-module caveats are documented in each module's own README, linked above.

## Module System Architecture

All six modules follow the same integration pattern with the core engine:

- **Modular inheritance**: each module's entry point subclasses `CoreModule<TConfig, TTranslation>` (from `CustomRolesModuleSystem.Api.Loader.Features`), supplying its own strongly-typed config and translation classes. Each module's actual role behavior is defined in a nested `CustomRoleModuleSystem`-derived class (from `CustomRolesModuleSystem.Api.CustomRoleModule`) that the module exposes via a `CustomRole` property.
- **Lifecycle hooks**: modules register their role with the core on `OnEnabled()` (via `RegisterModule()`) and unregister it on `OnDisabled()` (via `UnregisterModule()`). Two modules — Scp225Fr and UTR — additionally override role-level lifecycle/event methods (`OnHurting`, `AddRole`, `ReviveRole`, `RemoveRole`, `SubscribeEvents`/`UnsubscribeEvents`) to layer custom behavior on top of the base conversion/spawn flow the core provides.
- **Event binding**: role-specific event handling is done by overriding virtual members on the base `CustomRoleModuleSystem` class (e.g. `OnHurting` in SCP-225-FR, `EnteringPocketDimension` subscription in UTR) rather than each module wiring up its own independent EXILED event handlers from scratch — the core appears to route relevant EXILED events into these overridable hooks.
- **Isolated configs**: every module ships its own `IConfig`/`ITranslation` pair (e.g. `DirectorConfig`/`DirectorTranslation`), loaded independently by the core's loader. There is no shared or centralized config file across modules — each is configured and can be enabled/disabled separately.
- **Priority ordering**: each module declares a `Priority` byte (ranging from `1` for Janitor to `7` for UTR in this collection), which the core framework presumably uses to determine module load/processing order, though the exact scheduling semantics are defined in the (withheld) core and can't be confirmed from these modules alone.

Because the core framework itself is not part of this archive, these architectural notes describe only what is observable from how the six included modules consume the core's API surface — not the core's internal implementation.