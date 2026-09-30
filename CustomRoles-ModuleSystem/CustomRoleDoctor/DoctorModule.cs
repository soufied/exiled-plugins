using CustomRoleDoctor.Configs;
using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;

namespace CustomRoleDoctor
{
    public class DoctorModule : CoreModule<Configs.DoctorConfig, Configs.DoctorTranslation>
    {
        public override string Name => "Doctor";
        public override byte Priority => 2;
        public override CustomRoleModuleSystem CustomRole => Doctor;
        public override string Author => "_soufi";
        public static DoctorConfig ModuleConfig;
        public static DoctorTranslation ModuleTranslation;
        public Api.Roles.Doctor Doctor;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            base.OnEnabled();
            Doctor = new Api.Roles.Doctor { Role = Config.Role };
            Doctor.RegisterModule();
        }
        public override void OnDisabled()
        {
            ModuleConfig = null;
            ModuleTranslation = null;
            Doctor.UnregisterModule();
            Doctor = null;
            base.OnDisabled();
        }
    }
}