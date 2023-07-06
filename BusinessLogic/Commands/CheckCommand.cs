using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Functions;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class CheckCommand // : IBotCommand
    {
        //public string Name => "/check";

        ///*
        // * Айди
        // * Мой Id =     1029929252
        // * Id Влада =   5931568527
        // * Id Subotic = 6152453221
        // * 
        // * Id группы = -1001575923230
        // */
        //public TelegramBotClient Client => Bot.GetTelegramBot();

        //public async Task Execute(Update update)
        //{
        //    /*try
        //    {
        //        CheckMembership check = new();
        //        var userId = update.Message.Chat.Id;

        //        ChannelInfo ch = new();
        //        var members = ch.GetChatMembers();
        //        await members;
        //        // Выполняем запрос к Telegram Bot API для получения информации о чате или группе
        //        var member = check.CheckGroupMembership(userId);
        //        Console.WriteLine(member.ToString());
        //        await Client.SendTextMessageAsync(userId, $"Чекнул юзверя! Он по статусу {member.Status}, его Id {update.Message.Chat.Id}");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ошибка: {ex.Message}");
        //    }*/


        //    try
        //    {
        //        var member = await Client.GetChatMemberAsync(-1001575923230, 5931568527);

        //        List<string> usernames = new List<string>();
        //        if (member.User.Username != null)
        //            usernames.Add(member.User.Username);

                
        //        await Client.SendTextMessageAsync(1029929252, $"STATUS {member.Status}" +
        //            $"\n {member.User.Id}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }

        //}
    }
}
