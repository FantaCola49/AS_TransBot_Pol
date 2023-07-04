using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Functions;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class CheckCommand : IBotCommand
    {
        public string Name => "/check";

        /*
         * Айди
         * Мой Id =     1029929252
         * Id Влада =   5931568527
         * Id Subotic = 6152453221
         * 
         * Id группы = -1001575923230
         */
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            try
            {
                CheckMembership check = new();
                var userId = update.Message.Chat.Id;
                // Выполняем запрос к Telegram Bot API для получения информации о чате или группе
                var member = check.CheckGroupMembership(5931568527);
                Console.WriteLine(member.ToString());
                await Client.SendTextMessageAsync(userId, $"Чекнул юзверя! Он по статусу {member.Status}, его Id {update.Message.Chat.Id}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }
    }
}
