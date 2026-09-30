using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using PlayerRoles;

namespace CustomRoleScp008.API
{
    public static class Extensions
    {
        public static bool IsInfected(this Player player)
        {
            return API.Semifaces.Infected.Infected_List.ContainsKey(player.Id);
        }
        public static void CheckForCassie(CustomDamageHandler damageHandler, Player killer)
        {
            if (Plugin.Singleton.Config.Debug)
            {
                Log.Debug("Trying to get all Infected Players...");
                foreach (var infected in API.Semifaces.Infected.Infected_List)
                {
                    Log.Debug(infected.Value.Player.Nickname);
                }
                foreach (var infected in API.Roles.Scp008.InfectedPlayers)
                {
                    Log.Debug(Player.Get(infected).Nickname);
                }
                Log.Debug("Done.");
            }
            if (API.Semifaces.Infected.Infected_List.Count != 0 || API.Roles.Scp008.InfectedPlayers.Count != 0) return;
            try
            {
                if (killer == null)
                {
                    switch (damageHandler.Type)
                    {
                        case DamageType.Warhead:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Warhead];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        case DamageType.Custom:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Unknown];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        case DamageType.Crushed:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Unknown];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        case DamageType.Unknown:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Unknown];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        case DamageType.Tesla:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Tesla];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        case DamageType.Decontamination:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Decontamination];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                    }
                }
                else
                {
                    switch (killer.Role.Team)
                    {
                        case Team.ClassD:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Human];
                            Cassie.MessageTranslated(msgs.CassieMessage.Replace("%role%", "CLASSD PERSONNEL"), msgs.Translation.Replace("%role%", "Class-D Personnel"));
                            break;
                        }
                        case Team.ChaosInsurgency:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Human];
                            Cassie.MessageTranslated(msgs.CassieMessage.Replace("%role%", "CHAOSINSURGENCY"), msgs.Translation.Replace("%role%", "Chaos Insurgency"));
                            break;
                        }
                        case Team.Scientists:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Human];
                            Cassie.MessageTranslated(msgs.CassieMessage.Replace("%role%", "SCIENCE PERSONNEL"), msgs.Translation.Replace("%role%", "Science Personnel"));
                            break;
                        }
                        case Team.FoundationForces:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Ntf];
                            Cassie.MessageTranslated(msgs.CassieMessage.Replace("%designation%", damageHandler.CassieDeathAnnouncement.Announcement.Replace("CONTAINEDSUCCESSFULLY CONTAINMENTUNIT","")), msgs.Translation.Replace("%designation%", killer.UnitName));
                            break;
                        }
                        case Team.SCPs:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Scp];
                            Cassie.MessageTranslated(msgs.CassieMessage.Replace("%role%", damageHandler.CassieDeathAnnouncement.Announcement.Replace("TERMINATED BY","")), msgs.Translation.Replace("%role%", killer.Role.Type.ToString()));
                            break;
                        }
                        case Team.OtherAlive:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Tutorial];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                        default:
                        {
                            var msgs = Plugin.Singleton.Translation.CassieMessages[API.Enums.CassieMsgType.Unknown];
                            Cassie.MessageTranslated(msgs.CassieMessage, msgs.Translation);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error($"Pretty sure you are broke your Translation config...\nError:\n{e}");
            }
        }
        public static string RetCorrectUnit(string msg)
        {
            var newMsg = msg.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries);
            switch (newMsg[0])
            {
                case "NATO_A": return msg.Replace("NATO_A", "Alpha");
                case "NATO_B": return msg.Replace("NATO_B", "Bravo");
                case "NATO_C": return msg.Replace("NATO_C", "Charlie");
                case "NATO_D": return msg.Replace("NATO_D", "Delta");
                case "NATO_E": return msg.Replace("NATO_E", "Echo");
                case "NATO_F": return msg.Replace("NATO_F", "Foxtrot");
                case "NATO_G": return msg.Replace("NATO_G", "Golf");
                case "NATO_H": return msg.Replace("NATO_H", "Hotel");
                case "NATO_I": return msg.Replace("NATO_I", "India");
                case "NATO_J": return msg.Replace("NATO_J", "Juliet");
                case "NATO_K": return msg.Replace("NATO_K", "Kilo");
                case "NATO_L": return msg.Replace("NATO_L", "Lima");
                case "NATO_M": return msg.Replace("NATO_M", "Mike");
                case "NATO_N": return msg.Replace("NATO_N", "November");
                case "NATO_O": return msg.Replace("NATO_O", "Oscar");
                case "NATO_P": return msg.Replace("NATO_P", "Papa");
                case "NATO_Q": return msg.Replace("NATO_Q", "Quebec");
                case "NATO_R": return msg.Replace("NATO_R", "Romeo");
                case "NATO_S": return msg.Replace("NATO_S", "Sierra");
                case "NATO_T": return msg.Replace("NATO_T", "Tango");
                case "NATO_U": return msg.Replace("NATO_U", "Uniform");
                case "NATO_V": return msg.Replace("NATO_V", "Victor");
                case "NATO_W": return msg.Replace("NATO_W", "Whiskey");
                case "NATO_X": return msg.Replace("NATO_X", "X-ray");
                case "NATO_Y": return msg.Replace("NATO_Y", "Yankee");
                case "NATO_Z": return msg.Replace("NATO_Z", "Zulu");
                default: return "Null";
            }
        }
    }
}