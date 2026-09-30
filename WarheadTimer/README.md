# WarheadTimer

Shows every player a persistent, color-coded countdown hint of the time remaining until warhead detonation, with the text color shifting through seven stages as detonation approaches.

## Features
- Hooks `Warhead.Starting`, `Warhead.Stopping`, and `Warhead.Detonated` to run/stop a repeating coroutine that refreshes the on-screen hint every second.
- Hint text color changes across 7 configurable thresholds (roughly 140s, 120s, 90s, 60s, 45s, 15s, and 10s remaining) to visually signal urgency.
- Displays the live countdown value formatted as a 3-digit number, refreshed once per second for all connected players.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `WarheadTimerHintText` (`string`, default `"<align=right><size=80%>%customplugincolor% %WarheadTime%</color></align></size>"`) — hint template; supports `%customplugincolor%` and `%WarheadTime%` placeholders.
- `onescolor` (`string`, default `"<color=#4bd3e2ff>"`) — text color for the ~131–139s remaining range.
- `twoscolor` (`string`, default `"<color=#64bcc9ff>"`) — text color for the ~120s remaining range.
- `threescolor` (`string`, default `"<color=#7da6b0ff>"`) — text color for the ~90s remaining range.
- `fourscolor` (`string`, default `"<color=#968f96ff>"`) — text color for the ~60s remaining range.
- `fivescolor` (`string`, default `"<color=#b0787dff>"`) — text color for the ~45s remaining range.
- `sixscolor` (`string`, default `"<color=#c96264ff>"`) — text color for the ~15s remaining range.
- `sevenscolor` (`string`, default `"<color=#e24b4bff>"`) — text color for the ~10s remaining range.

```yaml
warhead_timer:
  is_enabled: true
  warhead_timer_hint_text: <align=right><size=80%>%customplugincolor% %WarheadTime%</color></align></size>
  onescolor: <color=#4bd3e2ff>
  twoscolor: <color=#64bcc9ff>
  threescolor: <color=#7da6b0ff>
  fourscolor: <color=#968f96ff>
  fivescolor: <color=#b0787dff>
  sixscolor: <color=#c96264ff>
  sevenscolor: <color=#e24b4bff>
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `WarheadTimer.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).