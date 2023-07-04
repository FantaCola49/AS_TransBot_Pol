using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class FaqCommand : IBotCommand
    {
        public string Name => "/faq";

        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            await Client.SendTextMessageAsync(update.Message.Chat.Id, "<b>Ответы на часто задаваемые вопросы вы можете найти здесь!</b>",
                parseMode: ParseMode.Html,
                replyMarkup: GetKeyboard());
        }

        /// <summary>
        /// Создаст клавиатуру для ответа
        /// </summary>
        /// <returns></returns>
        private InlineKeyboardMarkup GetKeyboard()
        {
            InlineKeyboardButton animals = new InlineKeyboardButton("FAQ ПО ПЕРЕВОЗКЕ ЖИВОТНЫХ") { Url = "https://telegra.ph/CHasto-zadavaemye-voprosy-o-perevozke-pitomcev-06-29" };
            InlineKeyboardButton passangers = new InlineKeyboardButton("FAQ ПРО ПЕРЕВОЗКУ ПАССАЖИРОВ") { Url = "https://telegra.ph/Otvety-na-chastye-voprosy-o-perevozke-passazhirov-06-29" };

            // Кнопки по рядам
            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
            {
                // Первый ряд
                new InlineKeyboardButton[] {animals},
                // Второй ряд
                new InlineKeyboardButton[] {passangers},
            };

            // Клавиатура
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
            return keyboard;
        }
    }
}
