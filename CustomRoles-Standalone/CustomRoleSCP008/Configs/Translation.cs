using System.Collections.Generic;
using System.ComponentModel;
using CustomRoleScp008.API.Semifaces;
using Exiled.API.Interfaces;

namespace CustomRoleScp008.Configs
{
    public sealed class Translation : ITranslation
    {
        [Description("Duration of hints can be configurated in CustomRoles config")]
        public string CustomName { get; set; } = "SCP-008-1";
        public string CustomInfo { get; set; } = "SCP-008-1";
        public string Description { get; set; } = "You are <color=red>SCP-008-1</color>, check console for more info (~)";
        public string ConsoleMsg { get; set; } = "<size=60%>You are <color=red>SCP-008-1</color>.\nEvery time you hit a player you infect him with <color=red>SCP-008</color>\nThe strength of the effect depends on the number of hits on the player</size>";
        public string TargetGotInfected { get; set; } = "<size=80%>You are infected with SCP-008 if you dont find SCP-500 you will become one of them...</size>";
        public Dictionary<API.Enums.CassieMsgType, API.Semifaces.CustomCassieMessage> CassieMessages { get; set; } = new Dictionary<API.Enums.CassieMsgType, API.Semifaces.CustomCassieMessage>()
        {
            { API.Enums.CassieMsgType.Warhead, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 successfully terminated by alpha warhead",
                Translation = "SCP-008 successfully terminated by Alpha Warhead."
            } },
            { API.Enums.CassieMsgType.Tesla, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 successfully terminated by automatic security system",
                Translation = "SCP-008 successfully terminated by Automatic Security System."
            }},
            { API.Enums.CassieMsgType.Unknown, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 successfully terminated . termination cause unspecified",
                Translation = "SCP-008 successfully terminated. Termination Cause Unspecified."
            }},
            { API.Enums.CassieMsgType.Human, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 ContainedSuccessfully by %role%",
                Translation = "SCP-008 contained successfully by %role%"
            }},
            { API.Enums.CassieMsgType.Ntf, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 ContainedSuccessfully . containmentunit %designation%",
                Translation = "SCP-008 contained successfully. Containment Unit %designation%"
            }},
            { API.Enums.CassieMsgType.Decontamination, new API.Semifaces.CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 lost in decontamination sequence",
                Translation = "SCP-008 lost in Decontamination Sequence"
            }},
            { API.Enums.CassieMsgType.Scp, new CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 successfully terminated by %role%",
                Translation = "SCP-008 successfully terminated By %role%"
            }},
            { API.Enums.CassieMsgType.Tutorial, new CustomCassieMessage()
            {
                CassieMessage = "SCP 0 0 8 successfully terminated . termination cause unspecified",
                Translation = "SCP-008 successfully terminated. Termination Cause Unspecified."
            }}
        };
    }
}