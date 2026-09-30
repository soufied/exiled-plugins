using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace AutoBroadcasts
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "AutoBroadcasts";
        public override string Author => "soufi#9707";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(3, 5, 0);

        public static Plugin Singleton = new Plugin();
        internal EventHandlers EventHandler;
        public override void OnEnabled()
        {
            Singleton = this;
            EventHandler = new EventHandlers(this);
            RegEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            EventHandler = null;
            Singleton = null;
            UnregEvents();
            base.OnDisabled();
        }
        private void RegEvents()
        {
            Server.RoundEnded += EventHandler.OnRoundEnded;
            Server.WaitingForPlayers += EventHandler.OnWaitingForPlayers;
            Server.RoundStarted += EventHandler.OnRoundStarted;
        }
        private void UnregEvents()
        {
            Server.RoundEnded -= EventHandler.OnRoundEnded;
            Server.WaitingForPlayers -= EventHandler.OnWaitingForPlayers;
            Server.RoundStarted -= EventHandler.OnRoundStarted;
        }
    }
}
