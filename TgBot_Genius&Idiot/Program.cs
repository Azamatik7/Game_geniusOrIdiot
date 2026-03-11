using Game_geniusOrIdiot;
using Telegram.Bot;

namespace TgBot_Genius_Idiot
{
    internal class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");

        private static List<Question> questions;
        static int randomInd;
        static int chatId = 1025006977;
        static int correctAnswersCount;
        static int questionCount;
        static async Task Main(string[] args)
        {
            var bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");
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

            if (update.Message.Text == "/start")
            {
                if ((int)update.Message.Chat.Id == chatId)
                {
                    randomInd = new Random().Next(0, questions.Count);

                    await bot.SendMessage(update.Message.Chat.Id, questions[randomInd].Text);

                }
                else
                {
                    randomInd = new Random().Next(0, questions.Count);

                    await bot.SendMessage(update.Message.Chat.Id, questions[randomInd].Text);


                    chatId = (int)update.Message.Chat.Id;
                }
            }
            else
            {                
                if (update.Message.Text == questions[randomInd].RightAnswer)
                {
                    correctAnswersCount++;
                    await bot.SendMessage(chatId, "Базару нет");
                    questions.RemoveAt(randomInd);
                }
                else
                {
                    await bot.SendMessage(chatId, "ну неправильно бр");
                    questions.RemoveAt(randomInd);
                }

                randomInd = new Random().Next(0, questions.Count);
                if (questions.Count == 0)
                {

                    
                    await bot.SendMessage(chatId, $"Игра завершена! Ваш диагноз - {SayDiagnosis(correctAnswersCount, questionCount)}");
                    correctAnswersCount = 0;
                    return;
                }
                await bot.SendMessage(update.Message.Chat.Id, questions[randomInd].Text);

                
                
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
}