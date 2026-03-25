using Game_geniusOrIdiot;
using Newtonsoft.Json;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {

        public class AddQuestionPage : Page
        {
            private Dictionary<long, string> tempQuestion = new Dictionary<long, string>();
            private Dictionary<long, int> step = new Dictionary<long, int>();

            private string path = "@\"..\\..\\..\\question.json";

            public AddQuestionPage()
            {
            }
            public override async Task View(ITelegramBotClient botClient, Message message, UserState userState)
            {
                long userId = message.From.Id;
                step[userId] = 0;


                await botClient.SendMessage(
                    chatId: message.Chat.Id,
                    text: "📝 Введите текст вопроса:"

                );



            }
            public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
            {
                if (update.Message == null) return;

                long userId = update.Message.From.Id;
                long chatId = update.Message.Chat.Id;
                string messageText = update.Message.Text;

                if (!step.ContainsKey(userId))
                {
                    step[userId] = 0;
                }


                if (step[userId] == 0)
                {
                    tempQuestion[userId] = messageText;
                    step[userId] = 1;

                    await botClient.SendMessage(
                        chatId: chatId,
                        text: "✅ Теперь введите правильный ответ на вопрос:"
                    );
                }

                else if (step[userId] == 1)
                {
                    string questionText = tempQuestion[userId];
                    string answer = messageText;

                    Question newQuestion = new Question(questionText, answer);

                    step.Remove(userId);
                    tempQuestion.Remove(userId);
                    userState.CurrentPage = "StartPage";

                    QuestionsStorage questionsStorage = new QuestionsStorage();

                    questionsStorage.Add(newQuestion);

                    var questions = new List<Question>();

                  await botClient.SendMessage(
                        chatId: chatId,
                        text: $"✅ Вопрос успешно добавлен!\n\n📝 Вопрос: {questionText}\n🔑 Ответ: {answer}");
                }


            }

            public void AddQuestion(Question question)
            {

                var questions = new List<Question>();

                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();
                }

                questions.Add(question);

                string updatedJson = JsonConvert.SerializeObject(questions);
                File.WriteAllText(path, updatedJson);

            }
        }
    }
}