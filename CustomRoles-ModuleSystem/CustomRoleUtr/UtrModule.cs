using CustomRolesModuleSystem.Api.CustomRoleModule;
using CustomRolesModuleSystem.Api.Loader.Features;
using CustomRoleUtr.Configs;
using HarmonyLib;

namespace CustomRoleUtr
{
    public class UtrModule : CoreModule<UtrConfig, UtrTranslation>
    {
        public override string Name => "UTR";
        public override byte Priority => 7;
        public override CustomRoleModuleSystem CustomRole => Utr;
        public override string Author => "_soufi";
        public static UtrConfig ModuleConfig;
        public static UtrTranslation ModuleTranslation;
        public Api.Roles.Utr Utr;
        public Harmony Harmony;
        public override void OnEnabled()
        {
            ModuleConfig = Config;
            ModuleTranslation = Translation;
            Harmony = new Harmony("soufi.utr.role");
            Harmony.PatchAll();
            base.OnEnabled();
            Utr = new Api.Roles.Utr { Role = Config.Role };
            Utr.RegisterModule();
        }
        public override void OnDisabled()
        {
            Harmony.UnpatchAll(Harmony.Id);
            Harmony = null;
            ModuleConfig = null;
            ModuleTranslation = null;
            Utr.UnregisterModule();
            Utr = null;
            base.OnDisabled();
        }
    }
}