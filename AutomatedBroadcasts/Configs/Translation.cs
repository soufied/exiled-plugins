using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AutoBroadcasts
{
    public class Translation : ITranslation
    {
        [Description("First Broadcast text")]
        public string Broadcast1Text { get; set; } = "Hello";

        [Description("Second Broadcast text")]
        public string Broadcast2Text { get; set; } = "<color=#FF0000>Red text</color>";

        [Description("Third Broadcast text")]
        public string Broadcast3Text { get; set; } = "<size=12>Size 12 text</size>";

        [Description("The fourth Broadcast text")]
        public string Broadcast4Text { get; set; } = "4 text";

        [Description("Fifth Broadcast text")]
        public string Broadcast5Text { get; set; } = "5 text";
    }
}