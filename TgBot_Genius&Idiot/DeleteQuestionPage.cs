using Game_geniusOrIdiot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        public class DeleteQuestionPage : Page
        {

            public override async Task View(ITelegramBotClient botClient, Message message, UserState userState)
            {
                QuestionsStorage questionsStorage = new QuestionsStorage();
                var allQuestions = questionsStorage.GetAll();

                await bot.SendMessage(message.Chat.Id, "Введите номер вопрса который хотите удалить:");

                string data = string.Empty;
                for (int i = 0; i < allQuestions.Count; i++)
                {
                    data += $"{i + 1}) {allQuestions[i].Text}\n";
                }
                await bot.SendMessage(message.Chat.Id, data);
            }
            public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
            {
                int number = int.Parse(update.Message.Text);
                QuestionsStorage questionsStorage = new QuestionsStorage();
                questionsStorage.Remove(number - 1);
                await bot.SendMessage(update.Message.Chat.Id, "Вопрос успешно удален");

            }

            
        }

    }
}