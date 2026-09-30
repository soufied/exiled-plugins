using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;
namespace AntiGivingAbuse.API.EventArgs
{
    public class SendingCommandEventArgs : IDeniableEvent, IPlayerEvent
    {
        public SendingCommandEventArgs(string command, string[] args, Player player, string errorText, bool isAllowed)
        {
            Command = command;
            Args = args;
            Player = player;
            ErrorText = errorText;
            IsAllowed = isAllowed;
        }
        public string Command { get; }
        public string[] Args { get; }
        public Player Player { get; }
        public string ErrorText { get; set; }
        public bool IsAllowed { get; set; }
    }
}