using Telegram.Bot;

namespace TransBotPol.BusinessLogic
{
    /// <summary>
    /// Класс @AS_TransBot
    /// </summary>
    public class Bot
    {
        private static readonly string _botToken = "6303121427:AAE_THql3BTEbPCF3kD62V6ljNoStF-pNmk";
        private static TelegramBotClient client { get; set; }

        public static TelegramBotClient GetTelegramBot()
        {
            if (client != null)
            {
                return client;
            }

            client = new TelegramBotClient(_botToken);
            return client;
        }
    }
}
