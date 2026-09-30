using System;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Scp914;
using Scp914;

namespace CustomItemHazardSuit
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "CustomItemHazardSuit";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(7, 2, 0);
        public static Plugin Singleton = new Plugin();
        public HazardSuit HazardSuit;
        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
            HazardSuit = new HazardSuit { Type = ItemType.ArmorHeavy };
            HazardSuit.Register();
        }
        public override void OnDisabled()
        {
            HazardSuit.Unregister();
            Singleton = null;
            base.OnDisabled();
        }
    }
}