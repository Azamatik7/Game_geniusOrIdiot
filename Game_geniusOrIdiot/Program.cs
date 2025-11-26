using System.Xml;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Game_geniusOrIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bankOfQuestions = { "Сколько океанов на планете Земля?", "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?", "Сколько будет два плюс два умножить на два?", "Укол делают каждые полчаса.Сколько минут,сделать три укола?", "Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?" };
            string[] correctAnswers = { "4", "3", "6", "60", "9" };

            Dictionary<string, string> queANs = GiveMeDictionary(bankOfQuestions, correctAnswers);

            Greeting();
            string nameOfUser = Console.ReadLine();
            Random rng = new Random();

            while (true)
            {
                // Перемешиваем вопросы прямо здесь
                var shuffledQuestions = queANs
                    .OrderBy(x => rng.Next())
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                int cnt = 0;
                List<string> mark = new List<string>();

                foreach (string s in shuffledQuestions.Keys)
                {
                    Console.WriteLine(s);
                    string answer = Console.ReadLine();
                    if (answer == shuffledQuestions[s])
                    {
                        cnt++;
                        mark.Add("+");
                    }
                    else
                    {
                        mark.Add("-");
                    }
                }

                Result(cnt, mark, correctAnswers);
                Console.WriteLine($"Ваш диагноз:{nameOfUser}-{Diagnosis(cnt)}");
                Console.WriteLine();
                Console.WriteLine("Хотите сыграть заново?");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "да")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Игра завершена. Удачи в следующий раз");

            static string Diagnosis(int cnt)
            {
                string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
                return diagnosises[cnt];
            }

            static void Result(int cnt, List<string> mark, string[] correctAnswers)
            {
                Console.WriteLine($"Ваше количество правильных ответов : {cnt}");
                Console.WriteLine("Результаты:");
                for (int i = 0; i < mark.Count; i++)
                {
                    Console.WriteLine($"{i + 1}){mark[i]}");
                }
            }

            static void Greeting()
            {
                Console.WriteLine("Добро пожаловать в игру Гений-Идиот");
                Console.WriteLine();
                Console.WriteLine("Введите ваше имя:");
            }

            static Dictionary<string, string> GiveMeDictionary(string[] bankOfQuestions, string[] correctAnswers)
            {
                Dictionary<string, string> queAns = new Dictionary<string, string>();
                for (int i = 0; i < bankOfQuestions.Length; i++)
                {
                    queAns[bankOfQuestions[i]] = correctAnswers[i];
                }
                return queAns;
            }
        }
    }
}
