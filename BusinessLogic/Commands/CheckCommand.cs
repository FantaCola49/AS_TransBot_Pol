using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Functions;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class CheckCommand : IBotCommand
    {
        public string Name => "/check";
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            try
            {
                CheckMembership check = new();
                // Выполняем запрос к Telegram Bot API для получения информации о чате или группе
                var member = check.CheckGroupMembership(update.Message.Chat.Id);
                Console.WriteLine(member.ToString());
                await Client.SendTextMessageAsync(update.Message.Chat.Id, $"Чекнул юзверя! Он по статусу {member.Status}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }
    }
}
