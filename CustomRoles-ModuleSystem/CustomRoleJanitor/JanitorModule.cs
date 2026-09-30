using CustomRoleJanitor.Configs;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;
namespace CustomRoleJanitor
{
    public class JanitorModule : CoreModule<Configs.JanitorConfig, Configs.JanitorTranslation>
    {
        public override string Name => "Janitor";
        public override byte Priority => 1;
        public override CustomRoleModuleSystem CustomRole => Janitor;
        public override string Author => "_soufi";
        public static JanitorConfig ModuleConfig;
        public static JanitorTranslation ModuleTranslation;
        public Api.Roles.Janitor Janitor;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            base.OnEnabled();
            Janitor = new Api.Roles.Janitor { Role = Config.Role };
            Janitor.RegisterModule();
        }
        public override void OnDisabled()
        {
            ModuleConfig = null;
            ModuleTranslation = null;
            Janitor.UnregisterModule();
            Janitor = null;
            base.OnDisabled();
        }
    }
}