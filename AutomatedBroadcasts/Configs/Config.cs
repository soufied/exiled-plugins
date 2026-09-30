using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AutoBroadcasts
{
    public sealed class Config : IConfig
    {
        private readonly Plugin plugin;
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Time that broadcast will be seen")]
        public ushort BroadcastTime { get; set; } = 5;

        [Description("Time after which First Broadcast will be shown (B1-10s then B2-20s then B3-30s then B4-40s then B5-50s)")]
        public ushort Broadcast1RefreshTime { get; set; } = 10;

        [Description("Time after which Second Broadcast will be shown")]
        public ushort Broadcast2RefreshTime { get; set; } = 20;

        [Description("Time after which Third Broadcast will be shown")]
        public ushort Broadcast3RefreshTime { get; set; } = 30;

        [Description("Time after which fourth Broadcast will be shown")]
        public ushort Broadcast4RefreshTime { get; set; } = 40;

        [Description("Time after which Fifth Broadcast will be shown")]
        public ushort Broadcast5RefreshTime { get; set; } = 50;
    }
}