using Exiled.API.Interfaces;

namespace CustomRoleDirector.Configs
{
    public sealed class DirectorTranslation : ITranslation
    {
        public string CustomName { get; set; } = "Director";
        public string CustomInfo { get; set; } = "<color=#FAFF86>Directeur</color>";
        public string NameTranslation { get; set; } = "<color=#FAFF86>Directeur</color>";
        public string Description { get; set; } = "You are <color=#FAFF86>Directeur</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#FAFF86>Directeur</color></size>";
    }
}