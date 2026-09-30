# AntiGivingAbuse

Prevents remote-admin staff in specified permission groups from using the `give` command to hand items/ammo to other players (self-gives to your own player ID are still permitted), closing a common admin-abuse loophole.

## Features
- Hooks remote admin command dispatch via a Harmony patch on `SendingCommand` to intercept commands before execution.
- Blocks the `give` command when issued by a player whose RA group is listed in `UserGroups`, unless the target is the issuing player themselves.
- Northwood staff (verified NW accounts) and players without remote admin access are exempt from the check.
- Custom error text is returned to the console/RA panel when a give attempt is blocked.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `Debug` (`bool`, default `false`) — debug logging toggle.
- `UserGroups` (`List<string>`, default `["owner", "moderator", "admin"]`) — the RA permission group names this restriction applies to.
- `ErrorMsg` (Translation, `string`, default `"Prevented by _soufi"`) — message shown in console/RA when a give is blocked.

```yaml
anti_giving_abuse:
  is_enabled: true
  debug: false
  user_groups:
  - owner
  - moderator
  - admin
```

```yaml
# Translation
error_msg: Prevented by _soufi
```

## Commands & Permissions (if applicable)
None — this plugin works passively by intercepting the existing `give` RA command; it adds no new commands.

## Installation
- Drop `AntiGivingAbuse.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).