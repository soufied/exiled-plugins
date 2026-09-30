using Exiled.API.Interfaces;
namespace LockdownOverrideCard.Configs
{
    public sealed class Translation : ITranslation
    {
        public string KeycardName { get; set; } = "Lockdown Override Card";
        public string KeycardSelect { get; set; } = "You select the Lockdown Override Card.";
        public string KeycardDescription { get; set; } = "<size=60%>This keycard can open ONLY locked doors. (Scp-079, Scp-2176)\n and\n USE locked elevators. (Decontamination)</size>";
        public string KeycardCantOpen { get; set; } = "You place the keycard on the scanner but nothing happens.";
        public string KeycardCantCallElevator { get; set; } = "You place the keycard on the scanner but nothing happens.";
        public string KeycardDropped { get; set; } = "You dropped the Lockdown Override Card.";
        public string KeycardTaken { get; set; } = "You taken the Lockdown Override Card.";
    }
}