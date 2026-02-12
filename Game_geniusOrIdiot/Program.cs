using System.IO;
using System.Xml.Linq;

using System.Linq;
using System.Globalization;
using static Game_geniusOrIdiot.Program;
namespace Game_geniusOrIdiot
{

    internal class Program
    {
        public class User
        {
            public string Name { get; set; }
            public string Diagnosis { get; set; }
            public int CorrectAnswers = 0;
            public User(string name)
            {
                Name = name;
            }
        }
        public class Question
        {
            public string Text { get; set; }
            public string RightAnswer { get; set; }
            public Question(string text, string rightAnswer)
            {
                Text = text;
                RightAnswer = rightAnswer;
            }
        }

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
                //File.WriteAllText("records.txt", string.Empty);


                if (File.Exists(recordsFile))
                {
                    Console.WriteLine("================================== РЕКОРДЫ ==========================================");
                    Console.WriteLine();
                    Console.WriteLine(" Имя пользователя                 Диагноз              кол-во правильных ответов");
                    string[] records = File.ReadAllLines(recordsFile);
                    List<List<string>> strings = new List<List<string>>();


                    foreach (string record in records)
                    {
                        List<string> currentUserdata = new List<string>();
                        string[] str = record.Split('#');// мы храним данные так ИмяПользователя#Диагноз#кол-во правильных ответов
                        currentUserdata.Add(str[0]);
                        currentUserdata.Add(str[1]);
                        currentUserdata.Add(str[2]);
                        strings.Add(currentUserdata);
                    }
                    List<List<string>> sortedUsers = new List<List<string>>();
                    sortedUsers = strings.OrderByDescending(x => int.Parse(x[2])).ToList();
                    if (sortedUsers.Count < 10)
                    {
                        for (int i = 0; i < sortedUsers.Count; i++)
                        {
                            Console.WriteLine($"   {sortedUsers[i][0],-32}{sortedUsers[i][1],-30}{sortedUsers[i][2],-25}");
                        }
                    }
                    else if (sortedUsers.Count > 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"   {sortedUsers[i][0],-32}{sortedUsers[i][1],-30}{sortedUsers[i][2],-25}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Рекордов пока нет!");
                    }
                    return;
                }
            }



            


            string nameOfUser = Greeting();
            User user = new User(nameOfUser);


            while (true)
            {
                Random rng = new Random();

                List<Question> questions = new List<Question>();

                Question question1 = new Question("Сколько океанов на планете Земля?", "4");
                questions.Add(question1);
                Question question2 = new Question("Одно яйцо варится 3 минуты,сколько минут варятся три яйца?", "3");
                questions.Add(question2);
                Question question3 = new Question("Сколько будет два плюс два умножить на два?", "6");
                questions.Add(question3);
                Question question4 = new Question("Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?", "9");
                questions.Add(question4);
                Question question5 = new Question("Укол делают каждые полчаса.Сколько минут,сделать три укола?", "60");
                questions.Add(question5);



                
                int lenQuest = questions.Count;
                for (int i = 0;i < lenQuest;i++) 
                {
                    
                    int randoIndex = rng.Next(0,questions.Count);
                    Console.WriteLine(questions[randoIndex].Text);
                    string answer = Console.ReadLine();
                    if (answer == questions[randoIndex].RightAnswer)
                    {
                        user.CorrectAnswers++;
                        
                    }
                    questions.RemoveAt(randoIndex);

                }

                
                user.Diagnosis  = Diagnosis(user.CorrectAnswers, questions);
                Console.WriteLine($"Ваш диагноз:{nameOfUser}-{Diagnosis(user.CorrectAnswers, questions)}");
                Console.WriteLine();
                Console.WriteLine("Хотите сыграть заново?");
                SaveRecord(user.Diagnosis, user.CorrectAnswers, user.Name);
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


            static string Diagnosis(int cnt, List<Question> bank)
            {
                string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
                double rightAns = cnt;
                double questionsNumber = bank.Count;
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
             

            static string Greeting()
            {
                Console.WriteLine("Добро пожаловать в игру Гений-Идиот");
                Console.WriteLine();
                Console.WriteLine("Введите ваше имя:");
                string name = Console.ReadLine();
                return name;
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
            static void SaveRecord(string diagnos, int cnt, string nameOfUser)
            {
                string recordsFile = "records.txt";

                string formatRecord = $"{nameOfUser}#{diagnos}#{cnt}";
                if (File.Exists(recordsFile))
                {
                    File.AppendAllText(recordsFile, formatRecord + Environment.NewLine);
                }
                else
                {
                    File.WriteAllText(recordsFile, formatRecord + Environment.NewLine);
                }
            }
            static string WriteMe(string diagnos, int cnt, string nameOfUser)
            {
                string formatRecord = $"     {nameOfUser,-32}{diagnos,-30}{cnt,-25}";
                return formatRecord;

            }

        }
    }
}


