using Exiled.API.Interfaces;

namespace CustomItemHazardSuit.Configs
{
    public sealed class Translation : ITranslation
    {
        public string SuitName { get; set; } = "Hazard Suit";
        public string SuitDescription { get; set; } = "<size=60%>Hazard Suit protects against SCP-049 and SCP-049-2 attacks</size>";
        public string SuitDropped { get; set; } = "You dropped the Hazard Suit.";
        public string SuitTaken { get; set; } = "You taken the Hazard Suit.";
        public string SuitAttacker { get; set; } = "You cant infect or attack this player cuz he is wearing Hazard Suit.";
    }
}