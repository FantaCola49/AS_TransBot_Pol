using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TransBotPol.BusinessLogic.Interfaces
{
    /// <summary>
    /// Интерфейс комманды
    /// </summary>
    public interface IBotCommand
    {
        /// <summary>
        /// Клиет
        /// </summary>
        public TelegramBotClient Client { get; }
        /// <summary>
        /// Название комманды
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Выполнение комманды
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>

        public async Task Execute(Update update) { }
    }
}
