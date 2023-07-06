using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class StartCommand : IBotCommand
    {
        public string Name => "/start";
        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            long chatId = update.Message.Chat.Id;
            //var checkMember = new InlineKeyboardMarkup(InlineKeyboardButton.("ПРОВЕРИТЬ", ));
            await Client.SendTextMessageAsync(chatId, "Добрый день! Благодарим за выбор нашей компании!\n" +
                "Этот бот поможет вам быстрее ознакомиться с ассортиментом нашей группы @AS_Trans2." +
                "\nДля выбора команды воспользуйтесь Menu или /help", 
                parseMode: ParseMode.Html
                /*replyMarkup: checkMember*/);
        }
    }
}
