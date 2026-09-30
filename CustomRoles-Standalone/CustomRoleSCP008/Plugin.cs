using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Version = System.Version;

namespace CustomRoleScp008
{
    public class Plugin : Plugin<Configs.Config, Configs.Translation>
    {
        public override string Name => "CustomRoleScp008";
        public override string Author => "_soufi";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(7, 2, 0);
        public static Plugin Singleton = new Plugin();
        public API.Roles.Scp008 Scp008;
        public override void OnEnabled()
        {
            Singleton = this;
            base.OnEnabled();
            Scp008 = new API.Roles.Scp008 { Role = Config.Role };
            Scp008.Register();
        }
        public override void OnDisabled()
        {
            Scp008.Unregister();
            Singleton = null;
            base.OnDisabled();
        }
    }
}