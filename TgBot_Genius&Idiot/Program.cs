using Game_geniusOrIdiot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");

        private static List<Question> questions;
        static int randomInd;
        static int questionCount;
        static UserStorage users = new UserStorage();

        
        private static Dictionary<long, UserGameData> _userGames = new Dictionary<long, UserGameData>();
        private static Dictionary<long, UserState> _userStates = new Dictionary<long, UserState>();

        static async Task Main(string[] args)
        {
            var me = await bot.GetMe();
            Console.WriteLine($"Bot name is {me.FirstName}.");

            QuestionsStorage questionsStorage = new QuestionsStorage();
            questions = questionsStorage.GetAll();
            questionCount = questions.Count;

            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static async Task Bot_OnUpdate(Telegram.Bot.Types.Update update)
        {
            if (update.Message == null)
                return;

            long chatId = update.Message.Chat.Id;
            long userId = update.Message.From.Id;
            string messageText = update.Message.Text;

            
            if (!_userStates.ContainsKey(userId))
            {
                _userStates[userId] = new UserState(userId);
            }
            var userState = _userStates[userId];

            
            if (!_userGames.ContainsKey(userId))
            {
                _userGames[userId] = new UserGameData();
            }
            var userGame = _userGames[userId];

            
            if (messageText == "/start")
            {
                Page page = new StartPage();
                await page.View(bot, update.Message, userState);
                userState.CurrentPage = "StartPage";

                _userGames[userId] = new UserGameData();
                return;
            }

            
            if (messageText == "📊 Показать результаты")
            {
                ResultsPage resultsPage = new ResultsPage();
                await resultsPage.View(bot, update.Message, userState);
                return;
            }

            
            if (userGame.IsWaitingForAnswer && userGame.CurrentQuestion != null)
            {
                if (messageText == userGame.CurrentQuestion.RightAnswer)
                {
                    userGame.CorrectAnswersCount++;
                    await bot.SendMessage(chatId, "✅");
                }
                else
                {
                    await bot.SendMessage(chatId, $"❌ (Правильный ответ: {userGame.CurrentQuestion.RightAnswer})");
                }
                
                questions.Remove(userGame.CurrentQuestion);
                
                if (questions.Count == 0)
                {
                    
                    var currentUser = new Game_geniusOrIdiot.User
                    {
                        Name = update.Message.From.Username ?? update.Message.From.FirstName,
                        CorrectAnswers = userGame.CorrectAnswersCount,
                        Diagnosis = SayDiagnosis(userGame.CorrectAnswersCount, questionCount)
                    };

                    await bot.SendMessage(chatId,
                        $"Игра завершена! Правильных ответов: {userGame.CorrectAnswersCount} из {questionCount}\n" +
                        $"Ваш диагноз - {currentUser.Diagnosis}");

                    users.SaveRecord(currentUser);

                    
                    _userGames[userId] = new UserGameData();
                }
                else
                {
                    
                    randomInd = new Random().Next(0, questions.Count);
                    userGame.CurrentQuestion = questions[randomInd];
                    await bot.SendMessage(chatId,
                        $"Вопрос {questionCount - questions.Count + 1} из {questionCount}:\n" +
                        $"{userGame.CurrentQuestion.Text}");
                }
            }
        }

        static string SayDiagnosis(int cnt, int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double percent = (double)cnt / len * 100;
            int index = (int)(percent / 20);
            
            if (index >= diagnosises.Length) index = diagnosises.Length - 1;
            return diagnosises[index];
        }

        public static string GetSortedUsers(List<Game_geniusOrIdiot.User> userData)
        {
            var sortedUsersData = userData.OrderByDescending(x => x.CorrectAnswers).ToList();

            string message = $"<pre>{"Name",-25}{"Diagnosis",-20}{"CorrectAnswers",-10}\n";

            foreach (var user in sortedUsersData)
            {
                message += $"{user.Name,-27}{user.Diagnosis,-20}{user.CorrectAnswers,-20}\n";
            }
            message += "</pre>";

            return message;
        }
    }
}