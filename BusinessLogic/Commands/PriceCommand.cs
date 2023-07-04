using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class PriceCommand : IBotCommand
    {
        public string Name => "/price";

        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {

        }
    }
}
