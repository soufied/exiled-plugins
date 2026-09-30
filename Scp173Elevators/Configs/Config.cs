using System.ComponentModel;
using Exiled.API.Interfaces;
namespace Scp173Elevators.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("The time after which SCP-173 will be able to use the elevators. (max - 65535)")]
        public ushort Scp173Time { get; set; } = 480;
        public float HintDuration { get; set; } = 3;
    }
}