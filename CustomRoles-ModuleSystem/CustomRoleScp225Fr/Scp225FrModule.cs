using CustomRoleScp225Fr.Configs;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;

namespace CustomRoleScp225Fr
{
    public class Scp225FrModule : CoreModule<Scp225FrConfig, Scp225FrTranslation>
    {
        public override string Name => "Scp225Fr";
        public override byte Priority => 5;
        public override CustomRoleModuleSystem CustomRole => Scp225Fr;
        public override string Author => "_soufi";
        public static Scp225FrConfig ModuleConfig;
        public static Scp225FrTranslation ModuleTranslation;
        public Api.Roles.Scp225Fr Scp225Fr;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            base.OnEnabled();
            Scp225Fr = new Api.Roles.Scp225Fr { Role = Config.Role };
            Scp225Fr.RegisterModule();
        }
        public override void OnDisabled()
        {
            ModuleConfig = null;
            ModuleTranslation = null;
            Scp225Fr.UnregisterModule();
            Scp225Fr = null;
            base.OnDisabled();
        }
    }
}