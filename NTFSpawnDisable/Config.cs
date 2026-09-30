using System.ComponentModel;
using Exiled.API.Interfaces;

namespace NTFSpawnDisable
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
    }
}
