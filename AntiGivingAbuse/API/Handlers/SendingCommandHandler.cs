using AntiGivingAbuse.API.EventArgs;
using Exiled.Events.Extensions;
namespace AntiGivingAbuse.API.Handlers
{
    public static class SendingCommandHandler
    {
        public static event Exiled.Events.Events.CustomEventHandler<SendingCommandEventArgs> SendingCommand;
        public static void OnSendingCommand(SendingCommandEventArgs ev) => SendingCommand?.InvokeSafely(ev);
    }
}