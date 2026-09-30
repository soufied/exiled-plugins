using System.Collections.Generic;
using Exiled.API.Features;
using MEC;

namespace CustomRoleScp008.API.Semifaces
{
    public class Infected
    {
        public static Dictionary<int, Infected> Infected_List = new Dictionary<int, Infected>();
        public Player Player { get; set; }
        public float Power { get; set; }
        public Infected(Player player, float power)
        {
            Player = player;
            Power = power;
            Infected_List.Add(player.Id, this);
        }
        public CoroutineHandle CoroutineHandle { get; set; }
        public void Start()
        {
            if (!Infected_List.ContainsKey(Player.Id)) return;
            CoroutineHandle = Timing.RunCoroutine(DamageInfected(Player));
        }
        public void Stop()
        {
            if (!Infected_List.ContainsKey(Player.Id)) return;
            Timing.KillCoroutines(this.CoroutineHandle);
            Infected_List.Remove(Player.Id);
        }
        public IEnumerator<float> DamageInfected(Player infected)
        {
            while (true)
            {
                infected.Hurt(Plugin.Singleton.Config.DPS * Power, "SCP-008");
                yield return Timing.WaitForSeconds(Plugin.Singleton.Config.EverySec);
            }
        }
    }
}