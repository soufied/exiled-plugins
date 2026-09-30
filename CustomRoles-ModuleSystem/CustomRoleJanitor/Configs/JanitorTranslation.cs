using Exiled.API.Interfaces;

namespace CustomRoleJanitor.Configs
{
    public sealed class JanitorTranslation : ITranslation
    {
        public string CustomName { get; set; } = "Janitor";
        public string CustomInfo { get; set; } = "<color=#EE7600>Concierge</color>";
        public string NameTranslation { get; set; } = "<color=#EE7600>Concierge</color>";
        public string Description { get; set; } = "You are <color=#EE7600>Concierge</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#EE7600>Concierge</color></size>";
    }
}