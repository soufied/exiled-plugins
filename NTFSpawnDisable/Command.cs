using System;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace NTFSpawnDisable
{
    public class Commands
    {
        private static bool enable { get; set; }
        [CommandHandler(typeof(RemoteAdminCommandHandler))]
        public class ReSpawnDisable : ICommand
        {
            public string Command { get; } = "respawn";
            public string[] Aliases { get; } = { "rsp" };
            public string Description { get; } = "This command disable or enable the spawn of one of the teams";
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                if (arguments.Count == 2)
                {
                    switch (arguments.At(0).ToLower())
                    {
                        case "enable":
                        {
                            enable = true;
                            break;
                        }
                        case "disable":
                        {
                            enable = false;
                            break;
                        }
                        default:
                        {
                            response = "Error. Usage: respawn disable/enable ntf/ci or rsp disable/enable ntf/ci";
                            return false;
                        }
                    }
                    switch (arguments.At(1).ToLower())
                    {
                        case "ntf":
                        {
                            if (!sender.CheckPermission("rsp.ntf"))
                            {
                                response = "You don't have permission to execute this command. Required permission - rsp.ntf";
                                return false;
                            }
                            if (enable)
                            {
                                Plugin.Singleton.EventHandler.CanNTF = true;
                                response = $"NTF spawn was enabled";
                                return true;
                            }
                            else
                            {
                                Plugin.Singleton.EventHandler.CanNTF = false;
                                response = $"NTF spawn was disabled";
                                return true;
                            }
                        }
                        case "ci":
                        {
                            if (!sender.CheckPermission("rsp.ci"))
                            {
                                response = "You don't have permission to execute this command. Required permission - rsp.ci";
                                return false;
                            }
                            if (enable)
                            {
                                Plugin.Singleton.EventHandler.CanCI = true;
                                response = $"Ci spawn was enabled";
                                return true;
                            }
                            else
                            {
                                Plugin.Singleton.EventHandler.CanCI = false;
                                response = $"Ci spawn was disabled";
                                return true;
                            }
                        }
                    }
                }
                response = "Error. Usage: respawn disable/enable ntf/ci or rsp disable/enable ntf/ci";
                return false;
            }
        }
    }
}
