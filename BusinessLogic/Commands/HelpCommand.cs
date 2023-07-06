using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class HelpCommand : IBotCommand
    {
        public string Name => "/help";
        public TelegramBotClient Client => Bot.GetTelegramBot();
        public async Task Execute(Update update)
        {
            await Client.SendTextMessageAsync(update.Message.Chat.Id,
                "/faq - <b>ответы на чато задаваемые вопросы</b>\n" +
                "/start - <b>повторить приветствие</b>\n" +
                "/map - <b>важные посты нашей группы</b>\n" +
                "/price - <b>про цены на наши услуги</b>\n"
                , parseMode: ParseMode.Html);
        }
    }
}
