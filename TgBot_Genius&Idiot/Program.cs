using Game_geniusOrIdiot;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static TgBot_Genius_Idiot.Program;

namespace TgBot_Genius_Idiot
{
    internal partial class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");

        private static List<Question> questions;
        static int questionCount;
        static UserStorage users = new UserStorage();
        


        private static Dictionary<long, UserGameData> _userGames = new Dictionary<long, UserGameData>();
        private static Dictionary<long, UserState> _userStates = new Dictionary<long, UserState>();

        private static Dictionary<long, PlayPage> _playPages = new Dictionary<long, PlayPage>();

        private static Dictionary<long, AddQuestionPage> _addQuestionPages = new Dictionary<long, AddQuestionPage>();
        private static Dictionary<long, DeleteQuestionPage> _deleteQuestionPages = new Dictionary<long, DeleteQuestionPage>();

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
                if (update.Message.From.Username == null)
                {
                    ResultsPage resultsPage = new ResultsPage(update.Message.From.FirstName);
                    await resultsPage.View(bot, update.Message, userState);
                    return;

                }
                else
                {

                    ResultsPage resultsPage = new ResultsPage(update.Message.From.Username);
                    await resultsPage.View(bot, update.Message, userState);
                    return;
                }
                    
            }

            if (messageText == "🎮 Начать игру")
            {

                _playPages[userId] = new PlayPage(questions, questionCount, _userGames);
                userState.CurrentPage = "PlayPage";
                await _playPages[userId].View(bot, update.Message, userState);
                return;
            }

            if (messageText == "Добавить вопрос")
            {
                _addQuestionPages[userId] = new AddQuestionPage();
                userState.CurrentPage = "AddQuestionPage";
                await _addQuestionPages[userId].View(bot, update.Message, userState);
                return;
            }

            if (messageText == "Удалить вопрос")
            {
                _deleteQuestionPages[userId] = new DeleteQuestionPage();
                userState.CurrentPage = "DeleteQuestionPage";
                await _deleteQuestionPages[userId].View(bot, update.Message, userState);
                return;
            }


            if (userState.CurrentPage == "PlayPage")
            {
                if (_playPages.ContainsKey(userId))
                {
                    await _playPages[userId].Handle(bot, update, userState);
                }
                return;
            }

            if (userState.CurrentPage == "AddQuestionPage")
            {
                if (_addQuestionPages.ContainsKey(userId))
                {
                    await _addQuestionPages[userId].Handle(bot, update, userState);
                }
                return;
            }

            if (userState.CurrentPage == "DeleteQuestionPage")
            {
                if (_deleteQuestionPages.ContainsKey(userId))
                {
                    await _deleteQuestionPages[userId].Handle(bot, update, userState);
                }
                return;
            }
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