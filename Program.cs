using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic;
using TransBotPol.BusinessLogic.Commands;

namespace TransBotPol
{
    public class Program
    {

        static void Main(string[] args)
        {
            var bot = Bot.GetTelegramBot();
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            //var cts = new CancellationTokenSource();
            //var cancellationToken = cts.Token;

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync
            );
            Console.ReadLine();
        }


        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(update.Message.Text)) //если чел прислал пустоту
                return;

            // Да ёпты как это сделать?
            //if (update.Message.NewChatMembers.Contains())

            // Фиксируем ответ
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            CommandExecutor exe = new CommandExecutor();
            // Если пришла команда - находим её и исполняем!
            await exe.GetUpdate(update);
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Логгируем ошибку
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
            return;
        }
    }
}