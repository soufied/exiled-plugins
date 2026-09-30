using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AntiGivingAbuse.Configs;

public sealed class Translation : ITranslation
{
    [Description("Error in console")]
    public string ErrorMsg { get; set; } = "Prevented by _soufi";
}