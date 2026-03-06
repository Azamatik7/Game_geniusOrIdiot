using Game_geniusOrIdiot;
using Telegram.Bot;

namespace TgBot_Genius_Idiot
{
    internal class Program
    {
        static TelegramBotClient bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");

        static int randomInd;
        static async Task Main(string[] args)
        {
            var bot = new TelegramBotClient("8709825825:AAF5GH_GzfchJZKaSlngaC4b-PVNe-He8U0");
            var me = await bot.GetMe();
            Console.WriteLine($"Bot name is {me.FirstName}.");


            Question question1 = new Question("скики", "мниги");
            Question question2 = new Question("Ты мужик?", "да");
            Question question3 = new Question("2=2*2?", "6");

            List<Question> questions = new List<Question>();
            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);

            bot.OnUpdate += Bot_OnUpdate;

            Console.ReadKey();
        }

        private static async Task Bot_OnUpdate(Telegram.Bot.Types.Update update)
        {
            Question question1 = new Question("скики", "мниги");
            Question question2 = new Question("Ты мужик?", "да");
            Question question3 = new Question("2=2*2?", "6");

            List<Question> questions = new List<Question>();
            questions.Add(question1);
            questions.Add(question2);
            questions.Add(question3);

            Random rnd = new Random();
            int randomInd = rnd.Next(0, questions.Count);

            if (update.Message.Text == "/start")
            {
                randomInd = new Random().Next(0, questions.Count);

                await bot.SendMessage(update.Message.Chat.Id, questions[randomInd].Text);
            }
            else
            {
                if (update.Message.Text == questions[randomInd].RightAnswer)
                {
                    await bot.SendMessage(update.Message.Chat.Id, update.Message.Text = "Базару нет");
                }
                else
                {
                    await bot.SendMessage(update.Message.Chat.Id, update.Message.Text = "ну неправильно бр");
                }
            }

        }
        
    }
}
