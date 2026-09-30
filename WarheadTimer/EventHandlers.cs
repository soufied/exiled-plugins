using System;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using MEC;
using Player = Exiled.API.Features.Player;
using Warhead = Exiled.API.Features.Warhead;

namespace WarheadTimer
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private readonly Config Config = Plugin.Singleton.Config;
        CoroutineHandle coroutine;
        internal void OnWarheadStarted(StartingEventArgs ev)
        {
            if (coroutine.IsRunning) Timing.KillCoroutines(coroutine);
            coroutine = Timing.RunCoroutine(WarheadTimerEnumerator());
        }
        internal void OnWarheadStopping(StoppingEventArgs ev)
        {
            Timing.KillCoroutines(coroutine);
        }
        internal void OnWarheadDetonated()
        {
            if (coroutine.IsRunning) Timing.KillCoroutines(coroutine);
        }
        public IEnumerator<float> WarheadTimerEnumerator()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(1f);
                string message = String.Empty;
                message += new string('\n', 9);
                message += Plugin.Singleton.Config.WarheadTimerHintText;
                if (Warhead.RealDetonationTimer < 140 && Warhead.RealDetonationTimer > 121) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.onescolor}");
                if (Warhead.RealDetonationTimer < 120 && Warhead.RealDetonationTimer > 91) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.twoscolor}");
                if (Warhead.RealDetonationTimer < 90 && Warhead.RealDetonationTimer > 61) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.threescolor}");
                if (Warhead.RealDetonationTimer < 60 && Warhead.RealDetonationTimer > 46) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.fourscolor}");
                if (Warhead.RealDetonationTimer < 45 && Warhead.RealDetonationTimer > 16) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.fivescolor}");
                if (Warhead.RealDetonationTimer < 15 && Warhead.RealDetonationTimer > 9) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.sixscolor}");
                if (Warhead.RealDetonationTimer < 10 && Warhead.RealDetonationTimer > 0) message = message.Replace("%customplugincolor%", $"{Plugin.Singleton.Config.sevenscolor}");
                message = message.Replace("%WarheadTime%", $"{Warhead.DetonationTimer.ToString("000")}");
                foreach (Player player in Player.List)
                {
                    player.ShowHint(message, 1.1f);
                }
            }
        }
    }
}
