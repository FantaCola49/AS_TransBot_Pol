using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TransBotPol.BusinessLogic;
using TransBotPol.BusinessLogic.Commands;
using TransBotPol.BusinessLogic.Functions;

namespace TransBotPol
{
    public class Program
    {
        public static TelegramBotClient bot => Bot.GetTelegramBot();
        private static CheckMembership check;

        static void Main(string[] args)
        {
            var bot = Bot.GetTelegramBot();
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
            check = new CheckMembership();
            //var cts = new CancellationTokenSource();
            //var cancellationToken = cts.Token;

            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync
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
            // Тут обрабатываются подписки и добавления в группы
            if (update.Type == UpdateType.ChatMember && update.Message.NewChatMembers != null)
            {
                foreach (var newMember in update.Message.NewChatMembers)
                {
                    if (check.CheckGroupMembership(newMember.Id).Status == ChatMemberStatus.Left)
                        Console.WriteLine("Пропал подпещик!");
                    else if (check.CheckGroupMembership(newMember.Id).Status == ChatMemberStatus.Member)
                        Console.WriteLine("Добавили молютку подпещика!");
                }
            }

            // Тут обрабатываются все команды для ботецкого
            else if (update.Type == UpdateType.Message && !string.IsNullOrEmpty(update.Message.Text))
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