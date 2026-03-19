using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        public class StartPage : Page
        {
            public string Text = "👋 Добро пожаловать в игру Гений или Идиот!\nВыберите действие:";

            public override async Task View(ITelegramBotClient botClient, Message message, UserState userState)
            {
                var keyboard = new ReplyKeyboardMarkup(new[]
                {
            new KeyboardButton[] { "🎮 Начать игру" },
            new KeyboardButton[] { "📊 Показать результаты"}
        })
                {
                    ResizeKeyboard = true
                };

                
                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: Text,
                    replyMarkup: keyboard
                );
            }

            public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
            {

                if (update.Message?.Text == null)
                    return;

                
                if (update.Message.Text == "/start")
                {
                    await bot.SendMessage(update.Message.Chat.Id, "Выберете действие: ",
                        replyMarkup: new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Начать игру", "Показать результаты", "Добавить вопрос" } }) { ResizeKeyboard = true });
                    return;
                }
            }
        }
    }
}