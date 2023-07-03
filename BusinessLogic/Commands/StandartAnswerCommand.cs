using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class StandartAnswerCommand : IBotCommand
    {
        public string Name => string.Empty;
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            await Client.SendTextMessageAsync(chatId, "Простите, я не понимаю вашего запроса!" +
                "\nНаберите комманду /help чтобы ознакомиться с функционалом бота");
        }
    }
}
