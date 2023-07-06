using Telegram.Bot;
using Telegram.Bot.Types;

namespace TransBotPol.BusinessLogic.Functions
{
    public class CheckMembership
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private readonly string _chatNickName = "@AS_Trans2";
        private long groupId = -1001575923230;

        public TelegramBotClient bot => Bot.GetTelegramBot();
        public ChatMember CheckGroupMembership(long userId, long chatId)
        {
            var response = bot.GetChatMemberAsync(chatId, userId);
            return response.Result;
        }

        public ChatMember CheckGroupMembership(long userId)
        {
            var response = bot.GetChatMemberAsync(groupId, userId);
            return response.Result;
        }

    }
}
