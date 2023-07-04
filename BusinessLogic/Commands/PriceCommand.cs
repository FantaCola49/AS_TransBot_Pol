﻿using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TransBotPol.BusinessLogic.Interfaces;

namespace TransBotPol.BusinessLogic.Commands
{
    public class PriceCommand : IBotCommand
    {
        public string Name => "/price";

        public TelegramBotClient Client => Bot.GetTelegramBot();

        public async Task Execute(Update update)
        {
            await Client.SendTextMessageAsync(update.Message.Chat.Id, "<b>Цены на наши перевозки!</b>",
                parseMode: ParseMode.Html,
                replyMarkup: GetKeyboard());
        }

        /// <summary>
        /// Создаст клавиатуру для ответа
        /// </summary>
        /// <returns></returns>
        private InlineKeyboardMarkup GetKeyboard()
        {
            InlineKeyboardButton goods = new InlineKeyboardButton("ДОСТАВКА ГРУЗОВ") { Url = "https://t.me/AS_Trans2/45/50" };
            InlineKeyboardButton homePets = new InlineKeyboardButton("ПЕРЕВОЗКА ДОМАШНИХ ЖИВОТНЫХ") { Url = "https://t.me/AS_Trans2/45/54" };
            InlineKeyboardButton cars = new InlineKeyboardButton("ПЕРЕГОН МАШИН") { Url = "https://t.me/AS_Trans2/45/56" };


            // Кнопки по рядам
            InlineKeyboardButton[][] buttons = new InlineKeyboardButton[][]
            {
                // Первый ряд
                new InlineKeyboardButton[] {goods},
                // Второй ряд
                new InlineKeyboardButton[] {homePets},
                // Третий ряд
                new InlineKeyboardButton[] {cars},
            };

            // Клавиатура
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(buttons);
            return keyboard;
        }
    }
}
