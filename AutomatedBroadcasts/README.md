# AutomatedBroadcasts

Cycles through five configurable broadcast messages at independently configurable intervals for the entire duration of a round, useful for rules reminders, Discord links, or event announcements. (Internal plugin name: `AutoBroadcasts`.)

## Features
- Runs a repeating coroutine from `RoundStarted` that loops through 5 broadcasts, each with its own delay before showing.
- Coroutine is killed on `RoundEnded` and `WaitingForPlayers` so broadcasts don't bleed into the next round or lobby.
- Each broadcast's on-screen display duration is shared and configurable (`BroadcastTime`).
- Broadcast text supports rich text formatting (color, size tags, etc.) via the Translation file.

## Configuration
- `IsEnabled` (`bool`, default `true`) — enables/disables the plugin.
- `BroadcastTime` (`ushort`, default `5`) — seconds each broadcast stays visible on screen.
- `Broadcast1RefreshTime` (`ushort`, default `10`) — seconds after round start before Broadcast 1 shows.
- `Broadcast2RefreshTime` (`ushort`, default `20`) — seconds after Broadcast 1 before Broadcast 2 shows.
- `Broadcast3RefreshTime` (`ushort`, default `30`) — seconds after Broadcast 2 before Broadcast 3 shows.
- `Broadcast4RefreshTime` (`ushort`, default `40`) — seconds after Broadcast 3 before Broadcast 4 shows.
- `Broadcast5RefreshTime` (`ushort`, default `50`) — seconds after Broadcast 4 before Broadcast 5 shows, after which the cycle repeats.

```yaml
automated_broadcasts:
  is_enabled: true
  broadcast_time: 5
  broadcast1_refresh_time: 10
  broadcast2_refresh_time: 20
  broadcast3_refresh_time: 30
  broadcast4_refresh_time: 40
  broadcast5_refresh_time: 50
```

```yaml
# Translation
broadcast1_text: Hello
broadcast2_text: <color=#FF0000>Red text</color>
broadcast3_text: <size=12>Size 12 text</size>
broadcast4_text: 4 text
broadcast5_text: 5 text
```

## Commands & Permissions (if applicable)
`None`

## Installation
- Drop `AutomatedBroadcasts.dll` into `%appdata%/EXILED/Plugins` (Windows) or `~/.config/EXILED/Plugins` (Linux).