using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace Scp173Elevators
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "Scp173Elevators";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(7, 1, 0);
        public static Plugin Singleton = new Plugin();
        public override void OnEnabled()
        {
            Singleton = this;
            Exiled.Events.Handlers.Player.InteractingElevator += OnInteractingElevator;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Singleton = null;
            Exiled.Events.Handlers.Player.InteractingElevator -= OnInteractingElevator;
            base.OnDisabled();
        }
        public void OnInteractingElevator(InteractingElevatorEventArgs ev)
        {
            if (ev.Player.Role.Type != RoleTypeId.Scp173) return;
            if (Round.ElapsedTime.TotalSeconds > Config.Scp173Time) return;
            ev.IsAllowed = false;
            var time = TimeSpan.FromSeconds(Config.Scp173Time);
            var msg = Translation.Scp173TimeHint.Replace("%starttime%", time.Minutes.ToString()).Replace("%rtmin%", time.Subtract(Round.ElapsedTime).Minutes.ToString()).Replace("%rtsec%", time.Subtract(Round.ElapsedTime).Seconds.ToString());
            ev.Player.ShowHint(msg, Config.HintDuration);
        }
    }
}