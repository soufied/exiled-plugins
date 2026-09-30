using Exiled.API.Interfaces;

namespace CustomRoleContainmentEngineer.Configs
{
    public sealed class Translation : ITranslation
    {
        public string CustomName { get; set; } = "Containment Engineer";
        public string CustomInfo { get; set; } = "<color=#FFFF00>Containment Engineer</color>";
        public string Spawn { get; set; } = "You have spawned as a <color=yellow>Containment Engineer</color>";
        public string Description { get; set; } = "You are <color=yellow>Containment Engineer</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=yellow>Containment Engineer</color></size>";
    }
}