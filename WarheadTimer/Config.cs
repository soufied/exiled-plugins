using System.ComponentModel;
using Exiled.API.Interfaces;

namespace WarheadTimer
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Text showing the time until the explosion of the warhead")]
        public string WarheadTimerHintText { get; set; } = "<align=right><size=80%>%customplugincolor% %WarheadTime%</color></align></size>";

        [Description("131 Seconds Text Color")]
        public string onescolor { get; set; } = "<color=#4bd3e2ff>";

        [Description("120 Seconds Text Color")]
        public string twoscolor { get; set; } = "<color=#64bcc9ff>";

        [Description("90 Seconds Text Color")]
        public string threescolor { get; set; } = "<color=#7da6b0ff>";

        [Description("60 Seconds Text Color")]
        public string fourscolor { get; set; } = "<color=#968f96ff>";

        [Description("45 Seconds Text Color")]
        public string fivescolor { get; set; } = "<color=#b0787dff>";

        [Description("15 Seconds Text Color")]
        public string sixscolor { get; set; } = "<color=#c96264ff>";

        [Description("10 Seconds Text Color")]
        public string sevenscolor { get; set; } = "<color=#e24b4bff>";
    }
}