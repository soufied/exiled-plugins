using CustomRoleGuardSupervisor.Configs;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;

namespace CustomRoleGuardSupervisor
{
    public class GuardSupervisorModule : CoreModule<GuardSupervisorConfig, GuardSupervisorTranslation>
    {
        public override string Name => "GuardSupervisor";
        public override byte Priority => 3;
        public override CustomRoleModuleSystem CustomRole => GuardSupervisor;
        public override string Author => "_soufi";
        public static GuardSupervisorConfig ModuleConfig;
        public static GuardSupervisorTranslation ModuleTranslation;
        public Api.Roles.GuardSupervisor GuardSupervisor;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            base.OnEnabled();
            GuardSupervisor = new Api.Roles.GuardSupervisor { Role = Config.Role };
            GuardSupervisor.RegisterModule();
        }
        public override void OnDisabled()
        {
            ModuleConfig = null;
            ModuleTranslation = null;
            GuardSupervisor.UnregisterModule();
            GuardSupervisor = null;
            base.OnDisabled();
        }
    }
}