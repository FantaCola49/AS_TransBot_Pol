using Telegram.Bot;
using Telegram.Bot.Types;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{

    public class CommandExecutor : ITelegramUpdateListener
    {
        public TelegramBotClient Client => Bot.GetTelegramBot();
        private List<IBotCommand> commands;
        private IListener? listener = null;

        public CommandExecutor()
        {
            commands = GetCommands();
        }

        private List<IBotCommand> GetCommands()
        {
            // Чтобы не добавлять команды вручную через конструктор, добавим их через рефлексию
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(type => typeof(IBotCommand)
                .IsAssignableFrom(type))
                .Where(type => type.IsClass);

            List<IBotCommand> commands = new List<IBotCommand>();
            foreach (var type in types)
            {
                IBotCommand? command;
                if (typeof(IListener).IsAssignableFrom(type))
                {
                    command = Activator.CreateInstance(type, this) as IBotCommand;
                }
                else
                {
                    command = Activator.CreateInstance(type) as IBotCommand;
                }

                if (command != null)
                {
                    commands.Add(command);
                }
            }
            return commands;
        }

        public async Task GetUpdate(Update update)
        {
            if (listener == null)
            {
                await ExecuteCommand(update);
            }
            else
            {
                await listener.GetUpdate(update);
            }
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        private async Task ExecuteCommand(Update update)
        {
            Message msg = update.Message;
            // Пробегаемся по списку команд, если находим нужную - выполняем ее. 
            foreach (var command in commands)
            {
                if (command.Name == msg.Text)
                {
                    await command.Execute(update);
                    return;
                }
            }
            // Если таой команды нет, выдаём стандартный ответ
            var standartAnswer = new StandartAnswerCommand();
            await standartAnswer.Execute(update);
        }

        /// <summary>
        /// Начать прослушивание
        /// </summary>
        /// <param name="newListener"></param>
        public void StartListen(IListener newListener)
        {
            listener = newListener;
        }

        /// <summary>
        /// Закончить прослушивание
        /// </summary>
        public void StopListen()
        {
            listener = null;
        }
    }
}