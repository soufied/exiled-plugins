using CustomRoleDirector.Configs;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;

namespace CustomRoleDirector
{
    public class DirectorModule : CoreModule<Configs.DirectorConfig, Configs.DirectorTranslation>
    {
        public override string Name => "Director";
        public override byte Priority => 4;
        public override CustomRoleModuleSystem CustomRole => Director;
        public override string Author => "_soufi";
        public static DirectorConfig ModuleConfig;
        public static DirectorTranslation ModuleTranslation;
        public Api.Roles.Director Director;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            base.OnEnabled();
            Director = new Api.Roles.Director { Role = Config.Role };
            Director.RegisterModule();
        }
        public override void OnDisabled()
        {
            ModuleConfig = null;
            ModuleTranslation = null;
            Director.UnregisterModule();
            Director = null;
            base.OnDisabled();
        }
    }
}