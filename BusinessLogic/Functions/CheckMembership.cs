using Telegram.Bot;
using Telegram.Bot.Types;

namespace TransBotPol.BusinessLogic.Functions
{
    public class CheckMembership
    {
        /// <summary>
        /// Название группы
        /// </summary>
        private readonly string _chatNickName = @"@AS_Trans2";
        private int userId;

        public TelegramBotClient bot => Bot.GetTelegramBot();
        public ChatMember CheckGroupMembership(long chatId, long userId)
        {
            var response = bot.GetChatMemberAsync(chatId, userId);
            return response.Result;
        }

        public ChatMember CheckGroupMembership(long userId)
        {
            var response = bot.GetChatMemberAsync(_chatNickName, userId);
            return response.Result;
        }
    }
}
