using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TransBotPol.BusinessLogic;
using TransBotPol.BusinessLogic.Commands;

namespace TransBotPol
{
    public class Program
    {
        public static TelegramBotClient bot => Bot.GetTelegramBot();

        static void Main(string[] args)
        {
            var bot = Bot.GetTelegramBot();
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            // На что реагируем?
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.ChatMember,
                    UpdateType.MyChatMember,
                    UpdateType.CallbackQuery

                }
            };

            // Простираем наш взор к Внешнему Миру
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }


        /// <summary>
        /// Обработка всех поступающих обновлений
        /// </summary>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));

            // Тут обрабатываются все команды для ботецкого, которые мы пишем напрямую
            if (update.Type == UpdateType.Message && !string.IsNullOrEmpty(update.Message.Text))
            {
                // Фиксируем ответ
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
                CommandExecutor exe = new CommandExecutor();
                // Если пришла команда - находим её и исполняем!
                await exe.GetUpdate(update);
            }
            else
                return;
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Логгируем ошибку
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            return;
        }
    }
}