using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;
namespace AntiGivingAbuse.Configs
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public List<string> UserGroups { get; set; } = new List<string>()
        {
            "owner",
            "moderator",
            "admin"
        };
    }
}