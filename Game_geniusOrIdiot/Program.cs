using System.IO;
using static Game_geniusOrIdiot.Program;

namespace Game_geniusOrIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = WhichAction();
            if (action == "2")
            {
                AddNewQuestion();
            }
            else if (action == "3")
            {

                QuestionsStorage questionsStorageAll = new QuestionsStorage();
                List<Question> allQuestions = new List<Question>();

                allQuestions = questionsStorageAll.GetAll();
                for (int i = 0; i < allQuestions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {allQuestions[i].Text}");

                }

                Console.WriteLine();
                Console.WriteLine("Выберите номер вопроса, который хотите удалить");
                int deleteIndex = int.Parse(Console.ReadLine()) - 1;// от номера вопроса отнимаем один т.к нам нужен индекс


                QuestionsStorage questionsStorage = new QuestionsStorage();
                questionsStorage.Remove(deleteIndex);



                Console.WriteLine("Вопрос удален!");
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
                    List<List<string>> sortedUsersData = new List<List<string>>();
                    sortedUsersData = strings.OrderByDescending(x => int.Parse(x[2])).ToList();
                    if (sortedUsersData.Count < 10)
                    {
                        for (int i = 0; i < sortedUsersData.Count; i++)
                        {
                            Console.WriteLine($"   {sortedUsersData[i][0],-32}{sortedUsersData[i][1],-30}{sortedUsersData[i][2],-25}");
                        }
                    }
                    else if (sortedUsersData.Count > 10)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"   {sortedUsersData[i][0],-32}{sortedUsersData[i][1],-30}{sortedUsersData[i][2],-25}");
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

                QuestionsStorage questionsBank = new QuestionsStorage();
                List<Question> lines = questionsBank.GetAll();
                foreach (Question line in lines)
                {
                    
                    Question question = new Question(line.Text,line.RightAnswer);
                    questions.Add(question);
                }


                int lenQuest = questions.Count;
                for (int i = 0; i < lenQuest; i++)
                {

                    int randoIndex = rng.Next(0, questions.Count);
                    Console.WriteLine(questions[randoIndex].Text);

                    string answer = Console.ReadLine();
                    if (answer == questions[randoIndex].RightAnswer)
                    {
                        user.CorrectAnswers++;
                    }

                    questions.RemoveAt(randoIndex);
                }

                user.Diagnosis = SayDiagnosis(user.CorrectAnswers, lenQuest);

                Console.WriteLine($"Ваш диагноз:{user.Name}-{user.Diagnosis}");
                Console.WriteLine();
                Console.WriteLine("Хотите сыграть заново?");

                QuestionsStorage questionsStorage = new QuestionsStorage();
                questionsStorage.SaveRecord(user);

                string restart = Console.ReadLine();
                if (restart.ToLower() == "да")
                {
                    user.CorrectAnswers = 0;
                    user.Diagnosis = "";
                    continue;
                }
                else
                {

                    break;
                }

            }

            Console.WriteLine();
            Console.WriteLine("Игра завершена. Удачи в следующий раз");


            static string SayDiagnosis(int cnt, int len)
            {
                string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
                double rightAns = cnt;
                double questionsNumber = len;
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
        }

        private static void AddNewQuestion()
        {
            Console.WriteLine("Введите вопрос который хотите добавить:");
            string newQuestion = Console.ReadLine();

            Console.WriteLine("Введите ответ к нему:");
            string newAnswer = Console.ReadLine();

            QuestionsStorage questionsStorage = new QuestionsStorage();
            questionsStorage.Add(new Question(newQuestion, newAnswer));

            Console.WriteLine("Вопрос добавлен!");
        }
    }
}


