using Telegram.Bot;
using Telegram.Bot.Types;
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
            await Client.SendTextMessageAsync(chatId, "Добрый день! Благодарим за выбор нашей компании!\n" +
                "Для получения краткого списка информации о нас нажмите /help!");
        }
    }
}
