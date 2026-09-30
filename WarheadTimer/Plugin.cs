using Exiled.API.Features;
using Warhead = Exiled.Events.Handlers.Warhead;
using Version = System.Version;

namespace WarheadTimer
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Warhead Timer";
        public override string Author => "soufi#9707";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(4, 1, 7);
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
            Warhead.Detonated += EventHandler.OnWarheadDetonated;
            Warhead.Starting += EventHandler.OnWarheadStarted;
            Warhead.Stopping += EventHandler.OnWarheadStopping;
        }
        internal void UnregisterEvents()
        {
            Warhead.Detonated -= EventHandler.OnWarheadDetonated;
            Warhead.Starting -= EventHandler.OnWarheadStarted;
            Warhead.Stopping -= EventHandler.OnWarheadStopping;
        }
    }
}
