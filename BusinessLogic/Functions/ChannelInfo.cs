using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TransBotPol.BusinessLogic.Functions
{
    public class ChannelInfo
    {
        private readonly string _botNick = "@AS_TransBot";
        private readonly long _chatId = -1001575923230;

        public async Task<ChatMember> GetChatMembers()
        {
            var bot = Bot.GetTelegramBot();
            var userInfo = bot.GetChatMemberAsync(_botNick, _chatId);
            var members = bot.GetChatMemberCountAsync(_chatId);
            await members;
            await userInfo;
            return userInfo.Result;
        }
    }
}
