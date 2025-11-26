using System.Xml;

namespace Game_geniusOrIdiot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bankOfQuestions = { "Сколько океанов на планете Земля?", "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?", "Сколько будет два плюс два умножить на два?", "Укол делают каждые полчаса.Сколько минут,сделать три укола?","Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?"};
            string[] correctAnswers = { "4", "3", "6", "60","9"};
            int cnt = 0;
            List<string> mark = new List<string>();
            Console.WriteLine("Добро пожаловать в игру Гений-Идиот");
            Console.WriteLine();
            for (int i = 0; i < bankOfQuestions.Length; i++)
            {
                Console.WriteLine(bankOfQuestions[i]);
                string answer = Console.ReadLine();
                if (answer == correctAnswers[i])
                {
                    cnt++;
                    mark.Add("+");
                }
                else
                {
                    mark.Add("-");
                }
            }
            Console.WriteLine($"Ваше количество правильных ответов : {cnt}");
            Console.WriteLine("Результаты:");
            for (int i = 0; i < correctAnswers.Length; i++)
            {
                Console.WriteLine($"{i + 1}){mark[i]}");
            }
            Console.WriteLine($"Ваш диагноз:{Diagnosis(cnt)}");
            
        }
        static string Diagnosis(int cnt)
        {
            string[] diagnosises = {"Идиот", "Бездарь", "Человек Разумный", "Талант", "Гений" };
            if (cnt == 0)
            {
                return diagnosises[0];
            }
            return diagnosises[cnt-1];

        }
    }
}
