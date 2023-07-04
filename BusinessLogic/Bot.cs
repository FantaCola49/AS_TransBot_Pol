using Telegram.Bot;

namespace TransBotPol.BusinessLogic
{
    /// <summary>
    /// Класс @AS_TransBot
    /// </summary>
    public class Bot
    {
        private static readonly string _botToken = "6314833718:AAFXcmQ0inMxxh-uNpVWpSDDALsPnu4RgTM";
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
