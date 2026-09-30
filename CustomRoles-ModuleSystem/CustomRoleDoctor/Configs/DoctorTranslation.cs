using Exiled.API.Interfaces;

namespace CustomRoleDoctor.Configs
{
    public sealed class DoctorTranslation : ITranslation
    {
        public string CustomName { get; set; } = "Doctor";
        public string CustomInfo { get; set; } = "<color=#FAFF86>Infirmier</color>";
        public string NameTranslation { get; set; } = "<color=#FAFF86>Infirmier</color>";
        public string Description { get; set; } = "You are <color=#FAFF86>Infirmier</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=#FAFF86>Infirmier</color></size>";
    }
}