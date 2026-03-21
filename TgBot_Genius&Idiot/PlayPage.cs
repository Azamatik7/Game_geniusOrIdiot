using Game_geniusOrIdiot;
using Telegram.Bot;
using Telegram.Bot.Types;
using static TgBot_Genius_Idiot.Program;

namespace TgBot_Genius_Idiot
{
    class PlayPage : Page
    {
        private List<Question> currentQuestions;
        private int randomInd;
        private int questionCount;
        private Dictionary<long, UserGameData> _userGames;
        private UserStorage users = new UserStorage();

        public PlayPage(List<Question> allQuestions, int totalQuestionsCount, Dictionary<long, UserGameData> userGames)
        {
            currentQuestions = new List<Question>(allQuestions);
            questionCount = totalQuestionsCount;
            _userGames = userGames;
        }

        public override async Task View(ITelegramBotClient botClient, Message message, UserState userState)
        {
            long userId = message.From.Id;

            if (!_userGames.ContainsKey(userId))
            {
                _userGames[userId] = new UserGameData();
            }
            var userGame = _userGames[userId];

            randomInd = new Random().Next(0, currentQuestions.Count);
            userGame.CurrentQuestion = currentQuestions[randomInd];
            userGame.IsWaitingForAnswer = true;
            userGame.CorrectAnswersCount = 0;

            await botClient.SendMessage(
                chatId: message.Chat.Id,
                text: $"⏳ Игра началась! ⏳\n\n" +
                      $"Вопрос 1 из {questionCount}:\n" +
                      $"{userGame.CurrentQuestion.Text}"
            );
        }

        public override async Task Handle(ITelegramBotClient botClient, Update update, UserState userState)
        {
            long userId = update.Message.From.Id;
            long chatId = update.Message.Chat.Id;
            string messageText = update.Message.Text;

            var userGame = _userGames[userId];

            if (messageText == userGame.CurrentQuestion.RightAnswer)
            {
                userGame.CorrectAnswersCount++;
                await botClient.SendMessage(chatId, "✅");
            }
            else
            {
                await botClient.SendMessage(chatId, $"❌ (Правильный ответ: {userGame.CurrentQuestion.RightAnswer})");
            }

            currentQuestions.Remove(userGame.CurrentQuestion);

            if (currentQuestions.Count == 0)
            {
                var currentUser = new Game_geniusOrIdiot.User
                {
                    Name = update.Message.From.Username ?? update.Message.From.FirstName,
                    CorrectAnswers = userGame.CorrectAnswersCount,
                    Diagnosis = SayDiagnosis(userGame.CorrectAnswersCount, questionCount)
                };

                await botClient.SendMessage(chatId,
                    $"Игра завершена! Правильных ответов: {userGame.CorrectAnswersCount} из {questionCount}\n" +
                    $"Ваш диагноз - {currentUser.Diagnosis}");

                users.SaveRecord(currentUser);
                _userGames[userId] = new UserGameData();
            }
            else
            {
                randomInd = new Random().Next(0, currentQuestions.Count);
                userGame.CurrentQuestion = currentQuestions[randomInd];
                await botClient.SendMessage(chatId,
                    $"Вопрос {questionCount - currentQuestions.Count + 1} из {questionCount}:\n" +
                    $"{userGame.CurrentQuestion.Text}");
            }
        }

        private string SayDiagnosis(int cnt, int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double percent = (double)cnt / len * 100;
            int index = (int)(percent / 20);

            if (index >= diagnosises.Length) index = diagnosises.Length - 1;
            return diagnosises[index];
        }
    }
}
