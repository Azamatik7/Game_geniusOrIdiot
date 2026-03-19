using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        public class ResultsPage : Page
        {
            public string Text = "🏆 ТАБЛИЦА РЕКОРДОВ 🏆\n\n";


            public override async Task View(ITelegramBotClient botClient, Message message, UserState userState)
            {
                var allUsers = users.GetAll();

                await bot.SendMessage(message.Chat.Id, GetSortedUsers(allUsers), parseMode: ParseMode.Html);
            }


            public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
            { }
        }
        
    }
}