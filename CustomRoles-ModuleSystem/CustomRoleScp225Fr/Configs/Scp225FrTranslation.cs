using Exiled.API.Interfaces;

namespace CustomRoleScp225Fr.Configs
{
    public sealed class Scp225FrTranslation : ITranslation
    {
        public string CustomName { get; set; } = "Scp225Fr";
        public string CustomInfo { get; set; } = "<color=#C50000>SCP-225-FR</color>";
        public string NameTranslation { get; set; } = "<color=#C50000>SCP-225-FR</color>";
        public string Description { get; set; } = "You are <color=#C50000>SCP-225-FR</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#C50000>SCP-225-FR</color></size>";
    }
}