using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Commands;
using Server.Network;

namespace Server.Extra.Commands
{
	public static class Thirst
	{
		public static void Initialize()
		{
			CommandSystem.Register("Thirst", AccessLevel.Player, HungryCommand);


		}

		private static void HungryCommand(CommandEventArgs e)
		{
			if (e.Mobile.Thirst <= 5)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are extremaly thirsty*", e.Mobile.NetState);
			}
			else if (e.Mobile.Thirst <= 10)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are thirsty*", e.Mobile.NetState);
			}
			else if (e.Mobile.Thirst <= 15)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You feel fine*", e.Mobile.NetState);
			}
			else if (e.Mobile.Thirst <= 20)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are hidratated*", e.Mobile.NetState);
			}

		}
	}
}
