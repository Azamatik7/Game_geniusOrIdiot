using Game_geniusOrIdiot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TgBot_Genius_Idiot
{
    internal class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");

        private static List<Question> questions;
        static int randomInd;
        static long chatId;
        static int correctAnswersCount;
        static int questionCount;
        static bool isWaitingForAnswer = false;
        static Question currentQuestion;
        static UserStorage users;
        static Game_geniusOrIdiot.User currentUser;

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

            chatId = update.Message.Chat.Id;

            if (update.Message.Text == "/start")
            {
                await bot.SendMessage(chatId, "Выберете действие: ",
                    replyMarkup: new ReplyKeyboardMarkup(new[] { new KeyboardButton[] { "Начать игру","Показать результаты","Добавить вопрос"} }) { ResizeKeyboard = true });
                return;
            }

            if (update.Message.Text == "Начать игру")
            {
                // Сброс игры
                correctAnswersCount = 0;
                questions = new QuestionsStorage().GetAll();
                questionCount = questions.Count;

                
                randomInd = new Random().Next(0, questions.Count);
                currentQuestion = questions[randomInd];
                await bot.SendMessage(chatId, $"Вопрос 1 из {questionCount}:\n{currentQuestion.Text}");
                isWaitingForAnswer = true;
                return;
            }

            
            if (isWaitingForAnswer && currentQuestion != null)
            {
                if (update.Message.Text == currentQuestion.RightAnswer)
                {
                    correctAnswersCount++;
                    await bot.SendMessage(chatId, "✅ +");
                }
                else
                {
                    await bot.SendMessage(chatId, $"❌ - (Правильный ответ: {currentQuestion.RightAnswer})");
                }

                // Удаляем отвеченный вопрос
                questions.Remove(currentQuestion);

                // Проверяем, остались ли вопросы
                if (questions.Count == 0)
                {
                    currentUser.Name = update.Message.From.Username;
                    currentUser.CorrectAnswers = correctAnswersCount;
                    currentUser.Diagnosis = SayDiagnosis(correctAnswersCount, questionCount);
                    
                    await bot.SendMessage(chatId, $"Игра завершена! Правильных ответов: {correctAnswersCount} из {questionCount}\nВаш диагноз - {SayDiagnosis(correctAnswersCount, questionCount)}");                    isWaitingForAnswer = false;
                    
                    users.SaveRecord(currentUser);

                    currentUser = null;
                    currentQuestion = null;
                }
                else
                {
                    // Следующий вопрос
                    randomInd = new Random().Next(0, questions.Count);
                    currentQuestion = questions[randomInd];
                    await bot.SendMessage(chatId, $"Вопрос {questionCount - questions.Count + 1} из {questionCount}:\n{currentQuestion.Text}");
                }
            }
            if (update.Message.Text == "Показать результаты")
            {
                var allUsers = users.GetAll();

                //Москва тоже не сразу строилась
            }

            if (update.Message.Text == "Добавить вопрос")
            {

            }    
                
        }
        static string SayDiagnosis(int cnt, int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double rightAns = cnt;
            double questionsNumber = len;
            double percent = rightAns / questionsNumber * 100;

            return diagnosises[(int)(percent / 20d)];
        }
    }
}