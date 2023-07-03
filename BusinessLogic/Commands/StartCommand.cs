using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class StartCommand : IBotCommand
    {
        public string Name => "/start";
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            var checkMember = new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("ПРОВЕРИТЬ", "https://t.me/c/1575923230/6/33"));
            await Client.SendTextMessageAsync(chatId, "Добрый день! Благодарим за выбор нашей компании!\n" +
                "Этот бот <b>только для подписчиков.</b> Для для запуска нужна проверка подписки.", 
                parseMode: ParseMode.Html,
                replyMarkup: checkMember);
        }
    }
}
