using System.IO;
using System.Xml.Linq;

using System.Linq;
namespace Game_geniusOrIdiot
{

    internal class Program
    {

        static void Main(string[] args)
        {
            string questionsFile = "question.txt";


            string[] bankOfQuestions =
                {
                "Сколько океанов на планете Земля?",
                "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?",
                "Сколько будет два плюс два умножить на два?",
                "Укол делают каждые полчаса.Сколько минут,сделать три укола?",
                "Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?",
                "мяу?"
                };
            string[] correctAnswers = { "4", "3", "6", "60", "9", "мяу" };

            if (File.Exists(questionsFile))
            {
                string[] lines = File.ReadAllLines(questionsFile);
                List<string> questionsList = new List<string>();
                List<string> answersList = new List<string>();

                for (int i = 0; i < lines.Length; i += 2)
                {
                    questionsList.Add(lines[i]);
                    answersList.Add(lines[i + 1]);

                }
                bankOfQuestions = questionsList.ToArray();
                correctAnswers = answersList.ToArray();
            }








            string action = WhichAction();
            if (action == "2")
            {
                Console.WriteLine("Введите вопрос который хотите добавить:");
                string newQuestion = Console.ReadLine();
                Console.WriteLine("Введите ответ к нему:");
                string newAnswer = Console.ReadLine();

                
                List<string> newQuestions = new List<string>(bankOfQuestions);
                List<string> newAnswers = new List<string>(correctAnswers);

                newQuestions.Add(newQuestion);
                newAnswers.Add(newAnswer);

                bankOfQuestions = newQuestions.ToArray();
                correctAnswers = newAnswers.ToArray();

                
                SaveToFile(questionsFile, bankOfQuestions, correctAnswers);

                Console.WriteLine("Вопрос добавлен!");
            }
            else if (action == "3")
            {
                Console.WriteLine("Напишите вопрос, который хотите удалить:");
                string delQues = Console.ReadLine();

                
                for (int i = 0; i < bankOfQuestions.Length; i++)
                {
                    if (bankOfQuestions[i] == delQues)
                    {
                        
                        List<string> newQuestions = new List<string>(bankOfQuestions);
                        List<string> newAnswers = new List<string>(correctAnswers);

                        newQuestions.RemoveAt(i);
                        newAnswers.RemoveAt(i);

                        bankOfQuestions = newQuestions.ToArray();
                        correctAnswers = newAnswers.ToArray();

                        
                        SaveToFile(questionsFile, bankOfQuestions, correctAnswers);

                        Console.WriteLine("Вопрос удален!");
                        break;
                    }
                }
            }
            else if (action == "4")
            {
                string recordsFile = "records.txt";

                if (File.Exists(recordsFile))
                {
                    Console.WriteLine("=== РЕКОРДЫ ===");
                    Console.WriteLine();
                    string[] records = File.ReadAllLines(recordsFile);
                    foreach (string record in records)
                    {
                        Console.WriteLine(record);
                    }
                }
                else
                {
                    Console.WriteLine("Рекордов пока нет!");
                }
                return;
            }



            Dictionary<string, string> queANs = GiveDictionary(bankOfQuestions, correctAnswers);


            string nameOfUser = Greeting();


            while (true)
            {
                Random rng = new Random();
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
                string diagnos = Diagnosis(cnt, bankOfQuestions);
                Console.WriteLine($"Ваш диагноз:{nameOfUser}-{Diagnosis(cnt, bankOfQuestions)}");
                Console.WriteLine();
                Console.WriteLine("Хотите сыграть заново?");
                SaveRecord(diagnos, cnt, nameOfUser);
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
        }


        static string Diagnosis(int cnt, string[] bank)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double rightAns = cnt;
            double questionsNumber = bank.Length;
            double percent = rightAns / questionsNumber * 100;
            if (percent == 0)
            {
                return diagnosises[0];
            }
            if (percent < 20)
            {
                return diagnosises[1];
            }
            if (percent < 40)
            {
                return diagnosises[2];
            }
            if (percent < 60)
            {
                return diagnosises[3];
            }
            if (percent < 80)
            {
                return diagnosises[4];
            }
            return diagnosises[5];


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

        static string Greeting()
        {
            Console.WriteLine("Добро пожаловать в игру Гений-Идиот");
            Console.WriteLine();
            Console.WriteLine("Введите ваше имя:");
            string name = Console.ReadLine();
            return name;
        }

        static Dictionary<string, string> GiveDictionary(string[] bankOfQuestions, string[] correctAnswers)
        {
            Dictionary<string, string> queAns = new Dictionary<string, string>();
            for (int i = 0; i < bankOfQuestions.Length; i++)
            {
                queAns[bankOfQuestions[i]] = correctAnswers[i];
            }
            return queAns;
        }
        static string WhichAction()
        {
            string[] actions = { "Играть", "Добавить вопрос", "Удалить вопрос", "Рекорды" };
            Console.WriteLine("Выберете номер действия:");
            for (int i = 0; i < actions.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {actions[i]}");
            }
            string choice = Console.ReadLine();
            return choice;

        }
        static void SaveToFile(string filename, string[] questions, string[] answers)
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < questions.Length; i++)
            {
                lines.Add(questions[i]);
                lines.Add(answers[i]);
            }

            File.WriteAllLines(filename, lines);
            Console.WriteLine("Вопросы сохранены!");
        }
        static void SaveRecord(string diagnos, int cnt,string nameOfUser)
        {
            string recordsFile = "records.txt";
            string formatRecord = $"Пользователь -- {nameOfUser}-{diagnos} - с рекордом : {cnt}";
            if (File.Exists(recordsFile))
            {
                File.AppendAllText(recordsFile, formatRecord + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(recordsFile, formatRecord + Environment.NewLine);
            }
        }

    }
}
