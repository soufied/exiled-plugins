using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Version = System.Version;

namespace NTFSpawnDisable
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "ReSpawnDisable";
        public override string Author => "soufi#9707";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(4, 2, 2);
        public static Plugin Singleton = new Plugin();
        internal EventHandlers EventHandler;
        public override void OnEnabled()
        {
            Singleton = this;
            EventHandler = new EventHandlers(this);
            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            EventHandler = null;
            Singleton = null;
            UnregisterEvents();
            base.OnDisabled();
        }
        internal void RegisterEvents()
        {
            Server.WaitingForPlayers += EventHandler.OnWaitingForPlayer;
            Server.RoundEnded += EventHandler.OnRoundEnded;
            Server.RespawningTeam += EventHandler.OnSpawning;
        }
        internal void UnregisterEvents()
        {
            Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayer;
            Server.RoundEnded -= EventHandler.OnRoundEnded;
            Server.RespawningTeam -= EventHandler.OnSpawning;
        }
    }
}