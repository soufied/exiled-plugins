using System;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Scp914;
using HarmonyLib;
using Scp914;
namespace LockdownOverrideCard
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "CustomItemLockdownOverrideCard";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 1, 1);
        public override Version RequiredExiledVersion => new Version(7, 2, 0);
        public static Plugin Singleton = new Plugin();
        public LockdownOverrideCard LockdownOverrideCard;
        private Harmony _harmony;
        public override void OnEnabled()
        {
            if (Config.DoPatch)
            {
                _harmony = new Harmony($"soufi.LockdownOverrideCard.{DateTime.UtcNow.Ticks}");
                _harmony.PatchAll();
            }
            Singleton = this;
            base.OnEnabled();
            LockdownOverrideCard = new LockdownOverrideCard { Type = ItemType.KeycardZoneManager };
            LockdownOverrideCard.Register();
        }
        public override void OnDisabled()
        {
            if (Config.DoPatch)
            {
                _harmony?.UnpatchAll(_harmony.Id);
                _harmony = null;
            }
            Singleton = null;
            base.OnDisabled();
        }
    }
}