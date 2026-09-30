using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace AutoBroadcasts
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private readonly Config Config = Plugin.Singleton.Config;
        private readonly Translation Translation = Plugin.Singleton.Translation;
        private CoroutineHandle coroutineBroadCast = new CoroutineHandle();
        internal void OnRoundStarted()
        {
            coroutineBroadCast = Timing.RunCoroutine(BroadCast());
        }
        internal void OnWaitingForPlayers()
        {
            if (coroutineBroadCast.IsRunning) Timing.KillCoroutines(coroutineBroadCast);
        }
        internal void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (coroutineBroadCast.IsRunning) Timing.KillCoroutines(coroutineBroadCast);
        }
        private IEnumerator<float> BroadCast()
        {
            while (Round.IsStarted)
            {
                yield return Timing.WaitForSeconds(Config.Broadcast1RefreshTime);
                try
                {
                    Map.Broadcast(Config.BroadcastTime,Translation.Broadcast1Text);
                }
                catch (Exception)
                {
                    continue;
                }
                yield return Timing.WaitForSeconds(Config.Broadcast2RefreshTime);
                try
                {
                    Map.Broadcast(Config.BroadcastTime, Translation.Broadcast2Text);
                }
                catch (Exception)
                {
                    continue;
                }
                yield return Timing.WaitForSeconds(Config.Broadcast3RefreshTime);
                try
                {
                    Map.Broadcast(Config.BroadcastTime, Translation.Broadcast3Text);
                }
                catch (Exception)
                {
                    continue;
                }
                yield return Timing.WaitForSeconds(Config.Broadcast4RefreshTime);
                try
                {
                    Map.Broadcast(Config.BroadcastTime, Translation.Broadcast4Text);
                }
                catch (Exception)
                {
                    continue;
                }
                yield return Timing.WaitForSeconds(Config.Broadcast5RefreshTime);
                try
                {
                    Map.Broadcast(Config.BroadcastTime, Translation.Broadcast5Text);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
