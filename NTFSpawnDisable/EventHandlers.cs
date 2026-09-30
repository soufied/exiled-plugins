using Exiled.Events.EventArgs;
using Respawning;

namespace NTFSpawnDisable
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private readonly Config Config = Plugin.Singleton.Config;
        public bool CanNTF { get; set; }
        public bool CanCI { get; set; }
        internal void OnSpawning(RespawningTeamEventArgs ev)
        {
            if (!CanNTF && ev.NextKnownTeam == SpawnableTeamType.NineTailedFox) ev.IsAllowed = false;
            if (!CanCI && ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency) ev.IsAllowed = false;
        }
        internal void OnRoundEnded(RoundEndedEventArgs ev)
        {
            CanNTF = true;
            CanCI = true;
        }
        internal void OnWaitingForPlayer()
        {
            CanNTF = true;
            CanCI = true;
        }
    }
}
