using Exiled.API.Interfaces;

namespace CustomRoleUtr.Configs
{
    public sealed class UtrTranslation : ITranslation
    {
        public string CustomName { get; set; } = "UTR";
        public string CustomInfo { get; set; } = "<color=#32CD32>UTR</color>";
        public string NameTranslation { get; set; } = "<color=#32CD32>UTR</color>";
        public string Description { get; set; } = "You are <color=#32CD32>UTR</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#32CD32>UTR</color></size>";
    }
}