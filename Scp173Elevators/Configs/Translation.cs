using Exiled.API.Interfaces;

namespace Scp173Elevators.Configs
{
    public sealed class Translation : ITranslation
    {
        public string Scp173TimeHint { get; set; } = "You cannot use the elevators for the first %starttime% minutes of the round.\nWait %rtmin% min. %rtsec% sec.";
    }
}