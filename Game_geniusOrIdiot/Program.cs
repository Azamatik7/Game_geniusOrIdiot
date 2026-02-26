using System.IO;
using static Game_geniusOrIdiot.Program;

namespace Game_geniusOrIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WhichAction();
            string action =  Console.ReadLine();
            while (!FoolCheckAction(action))
            {
                Console.WriteLine("Вы ввели неправильную команду");
                Console.WriteLine("Попробуйте еще раз");
                action = Console.ReadLine();
            }

            if (action == "1")
            {
                Greeting();
                string userName = Console.ReadLine();
                User user = new User(userName);

                while (true)
                {
                    Random rng = new Random();

                    QuestionsStorage questionsBank = new QuestionsStorage();
                    List<Question> questions = questionsBank.GetAll();

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

                    UserStorage userRecord = new UserStorage();
                    userRecord.SaveRecord(user);

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
            }

            if (action == "2")
            {
                AddNewQuestion();
            }
            if (action == "3")
            {

                QuestionsStorage questionsStorage = new QuestionsStorage();
                List<Question> allQuestions = questionsStorage.GetAll();

                ShowAllQuestions(allQuestions);
                string deleteNumber = Console.ReadLine();

                while (!FoolCheckNumber(deleteNumber, allQuestions.Count)) // проверка корректности номера/индекса
                {
                    Console.WriteLine("Вы ввели неверный номер");
                    Console.WriteLine("Повторите действие");
                    deleteNumber = Console.ReadLine();
                }

                questionsStorage.Remove(int.Parse(deleteNumber) - 1);// удаление
                Console.WriteLine("Вопрос удален!");
            }
            if (action == "4")
            {
                //File.WriteAllText("records.txt", string.Empty);
                GetRecordsSample();

                UserStorage usersRecords = new UserStorage();
                List<User> userData = usersRecords.GetAll();

                GetSortedUsers(userData);
                return;
            }

            static string SayDiagnosis(int cnt, int len)
            {
                string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
                double rightAns = cnt;
                double questionsNumber = len;
                double percent = rightAns / questionsNumber * 100;

                return diagnosises[int.Parse((percent / 20d).ToString())];
            }


            static void Greeting()
            {
                Console.WriteLine("Добро пожаловать в игру Гений-Идиот");
                Console.WriteLine();
                Console.WriteLine("Введите ваше имя:");
                
            }

            static void WhichAction()
            {
                string[] actions = { "Играть", "Добавить вопрос", "Удалить вопрос", "Рекорды" };
                Console.WriteLine("Выберете номер действия:");
                for (int i = 0; i < actions.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {actions[i]}");
                }
                
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
        public static bool FoolCheckNumber(string checkNumber, int questionsQuantity)
        {
            if (int.TryParse(checkNumber, out int correctNumber))
            {
                if (correctNumber > 0 && correctNumber <= questionsQuantity)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool FoolCheckAction(string action)
        {
            if (int.TryParse(action, out int correctAction))
            {
                if (correctAction >= 1 && correctAction <= 4)
                {
                    return true;
                }
            }
            return false;
        }
        public static void GetRecordsSample()
        {
            Console.WriteLine("================================== РЕКОРДЫ ==========================================");
            Console.WriteLine();
            Console.WriteLine(" Имя пользователя                 Диагноз              кол-во правильных ответов");
        }

        public static void GetSortedUsers(List<User> userData)
        {
            List<User> sortedUsersData = new List<User>();
            sortedUsersData = userData.OrderByDescending(x => x.CorrectAnswers).ToList(); // сортировка пользователей по праваильным ответам

            for (int i = 0; i < sortedUsersData.Count; i++)
            {
                Console.WriteLine($"   {sortedUsersData[i].Name,-32}{sortedUsersData[i].Diagnosis,-30}{sortedUsersData[i].CorrectAnswers,-25}");
            }
        }
        public static void ShowAllQuestions(List<Question> currentQuestions)
        {
            for (int i = 0; i < currentQuestions.Count; i++)// Вывод всех вопросов
            {
                Console.WriteLine($"{i + 1}) {currentQuestions[i].Text}");
            }

            Console.WriteLine();
            Console.WriteLine("Выберите номер вопроса, который хотите удалить");
        }
    }
}


