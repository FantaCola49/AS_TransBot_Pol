using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class MapCommand : IBotCommand
    {
        public string Name => "/map";
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            var contacts = new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("🥸 НАШИ КОНТАКТЫ 🥸", "https://t.me/c/1575923230/6/33"));

            await Client.SendTextMessageAsync(chatId, "Предлогаем вам ознакомиться с нашими услугами!" +
                "\n[\U0001f978 НАШИ КОНТАКТЫ \U0001f978](https://t.me/c/1575923230/6/33)",
                parseMode: ParseMode.Markdown,
                replyMarkup: contacts);
        }

        
    }
}
