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
            await Client.SendTextMessageAsync(update.Message.Chat.Id, "<b>Предлогаем вам ознакомиться с нашими услугами!</b>",
                parseMode: ParseMode.Html,
                replyMarkup: GetKeyboard());
        }

        /// <summary>
        /// Создаст клавиатуру для ответа
        /// </summary>
        /// <returns></returns>
        private InlineKeyboardMarkup GetKeyboard()
        {
            InlineKeyboardButton services = new InlineKeyboardButton("GENERAL") { Url = "https://t.me/AS_Trans2/1/29" };
            InlineKeyboardButton aboutUs = new InlineKeyboardButton("МЫ И НАШИ УСЛУГИ") { Url = "https://t.me/AS_Trans2/6/32" };
            InlineKeyboardButton storrages = new InlineKeyboardButton("СКЛАДЫ") { Url = "https://t.me/AS_Trans2/8/24" };
            InlineKeyboardButton contacts = new InlineKeyboardButton("КОНТАКТЫ") { Url = "https://t.me/AS_Trans2/6/33" };

            // Кнопки по рядам
            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
            {
                // Первый ряд
                new InlineKeyboardButton[] {services},
                // Второй ряд
                new InlineKeyboardButton[] {aboutUs},
                // Третий ряд
                new InlineKeyboardButton[] {storrages},
                // Четвёртый ряд
                new InlineKeyboardButton[] {contacts},
            };

            // Клавиатура
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
            return keyboard;
        }


    }
}
