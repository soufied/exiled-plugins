using System;
using AntiGivingAbuse.API.EventArgs;
using Exiled.API.Features;
using HarmonyLib;
namespace AntiGivingAbuse
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "AntiGivingAbuse";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(7, 1, 0);
        public static Plugin Singleton = new Plugin();
        private Harmony harmony;
        public override void OnEnabled()
        {
            harmony = new Harmony($"soufi.AntiGivingAbuse.{DateTime.UtcNow.Ticks}");
            harmony.PatchAll();
            Singleton = this;
            AntiGivingAbuse.API.Handlers.SendingCommandHandler.SendingCommand += OnSendingCommand;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            harmony?.UnpatchAll(harmony.Id);
            harmony = null;
            Singleton = null;
            AntiGivingAbuse.API.Handlers.SendingCommandHandler.SendingCommand -= OnSendingCommand;
            base.OnDisabled();
        }
        public void OnSendingCommand(SendingCommandEventArgs ev)
        {
            if (ev.Args[0] == "$7" || ev.Args[0] == "$0") return;
            if (!ev.Player.RemoteAdminAccess || ev.Player.IsNorthwoodStaff) return;
            if (!Config.UserGroups.Contains(ev.Player.GroupName)) return;
            if (ev.Args[0] != "give") return;
            if (ev.Player.Id.ToString() == ev.Args[1].Replace(".","")) return;
            ev.ErrorText = Translation.ErrorMsg;
            ev.IsAllowed = false;
        }
    }
}