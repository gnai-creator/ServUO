using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Commands;
using Server.Network;

namespace Server.Extra.Commands
{
	public static class Hungry
	{
		public static void Initialize()
		{
			CommandSystem.Register("Hungry", AccessLevel.Player, HungryCommand);


		}

		private static void HungryCommand(CommandEventArgs e)
		{
			if (e.Mobile.Hunger <= 5)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are extremaly hungry*", e.Mobile.NetState);
			}
			else if (e.Mobile.Hunger <= 10)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are hungry*", e.Mobile.NetState);
			}
			else if (e.Mobile.Hunger <= 15)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are satisfied*", e.Mobile.NetState);
			}
			else if (e.Mobile.Hunger <= 20)
			{
				e.Mobile.PrivateOverheadMessage(MessageType.Emote, 0x04b9, false, "*You are stuffed*", e.Mobile.NetState);
			}

		}
	}
}
