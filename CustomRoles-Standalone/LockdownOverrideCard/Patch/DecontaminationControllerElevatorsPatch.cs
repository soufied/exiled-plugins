using HarmonyLib;
using LightContainmentZoneDecontamination;

namespace LockdownOverrideCard.Patch
{
    [HarmonyPatch(typeof(DecontaminationController), nameof(DecontaminationController.DisableElevators))]
    internal static class DecontaminationControllerElevatorsPatch
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}