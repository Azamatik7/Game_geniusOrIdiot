using System.ComponentModel.Design;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        public abstract  class Page
        {
            public virtual string Text { get; set; }


            public abstract Task View(ITelegramBotClient botClient, Message message, UserState userState);
            public abstract Task Handle(ITelegramBotClient botClient, Update update, UserState userState);
        }
    }
}