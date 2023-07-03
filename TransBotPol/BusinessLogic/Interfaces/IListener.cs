using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Commands;

namespace TransBotPol.BusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со сложными командами, требующих несколько сообщений
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// Получение обновлений, т.е. ответов пользователя
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public async Task GetUpdate(Update update) { }

        /// <summary>
        /// Исполнитель комманд
        /// </summary>
        /// <returns></returns>
        public CommandExecutor Executor { get; }
    }
}
