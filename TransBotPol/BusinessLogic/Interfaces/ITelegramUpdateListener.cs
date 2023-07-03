using Telegram.Bot.Types;

namespace TransBotPol.BusinessLogic.Interfaces
{
    public interface ITelegramUpdateListener
    {
        /// <summary>
        /// Получит обновления от телеграм
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        Task GetUpdate(Update update);
    }
}
