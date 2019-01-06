using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.GlobalBan
{
    public class CommandIPBan : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "ipban";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    var p = UnturnedPlayer.FromName(args[0]);
                    if (p != null)
                    {
                        GlobalBan.Instance.Database.BanPlayer(p.CharacterName, p.CSteamID.m_SteamID.ToString(), caller.DisplayName, "", 0, p.IP, DatabaseManager.BanType.ByUserNameAndIP);
                        UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_ban_public"));
                    }
                    else
                        UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_generic_invalid_parameter"));
                    break;
                case 2:
                    var pa = UnturnedPlayer.FromName(args[0]);
                    if (pa != null)
                    {
                        GlobalBan.Instance.Database.BanPlayer(pa.CharacterName, pa.CSteamID.m_SteamID.ToString(), caller.DisplayName, args[1], 0, pa.IP, DatabaseManager.BanType.ByUserNameAndIP);
                        UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_ban_public_reason", args[1]));
                    }
                    else
                        UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_generic_invalid_parameter"));
                    break;
                case 3:
                    var paa = UnturnedPlayer.FromName(args[0]);
                    if (int.TryParse(args[2], out int dura))
                    {
                        if (paa != null)
                        {
                            GlobalBan.Instance.Database.BanPlayer(paa.CharacterName, paa.CSteamID.m_SteamID.ToString(), caller.DisplayName, args[1], dura, paa.IP, DatabaseManager.BanType.ByUserNameAndIP);
                            UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_ban_public_reason", args[1]));
                        }
                        else
                            UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_generic_invalid_parameter"));
                    }
                    else
                        UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_generic_invalid_parameter"));
                    break;

                default:
                    UnturnedChat.Say(caller, GlobalBan.Instance.Translate("command_generic_invalid_parameter"));
                    break;
            }
        }
    }
}
