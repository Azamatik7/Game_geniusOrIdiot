using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        public class ResultsPage : Page
        {
            public string Text = "🏆 ВАШИ РЕКОРДЫ 🏆\n\n";
            public string UserName;
            public ResultsPage(string userName)
            {
                UserName = userName;
            }
            
                

                


            public override async Task View(ITelegramBotClient botClient,Message message, UserState userState)
            {
                var allUsers = users.GetAll();

                List<Game_geniusOrIdiot.User> correctUsers = new  List < Game_geniusOrIdiot.User>();

                foreach(var user in allUsers)
                {
                    if (user.Name == UserName)
                    {
                        correctUsers.Add(user);
                    }

                }

                await bot.SendMessage(message.Chat.Id, GetSortedUsers(correctUsers), parseMode: ParseMode.Html);
            }


            public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
            {
            }
        }
        
    }
}