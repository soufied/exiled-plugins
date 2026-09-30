using Exiled.API.Interfaces;

namespace CustomRoleGuardSupervisor.Configs
{
    public sealed class GuardSupervisorTranslation : ITranslation
    {
        public string CustomName { get; set; } = "Guard Supervisor";
        public string CustomInfo { get; set; } = "<color=#A0A0A0>Garde Superviseur</color>";
        public string NameTranslation { get; set; } = "<color=#A0A0A0>Garde Superviseur</color>";
        public string Description { get; set; } = "You are <color=#A0A0A0>Garde Superviseur</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#A0A0A0>Garde Superviseur</color></size>";
    }
}