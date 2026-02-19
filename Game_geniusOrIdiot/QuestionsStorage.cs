namespace Game_geniusOrIdiot
{
    public class QuestionsStorage
    {
        private string path = "question.txt";
        public List<Question> GetAll()
        {
            string[] check = File.ReadAllLines(path);
            if (File.Exists(path) && check.Length != 0) // доделать 
            {
                List<Question> list = new List<Question>();

                foreach (string line in check)
                {
                    Question question = new Question(line.Split("#")[0], line.Split("#")[1]);
                    list.Add(question);
                }
                return list;
            }
            else if (File.Exists(path) && check.Length == 0)
            {

                FillFile();

                string[] lines = File.ReadAllLines(path);



                List<Question> questions = new List<Question>();
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] QuestionAnswer = lines[i].Split("#");
                    Question question = new Question(QuestionAnswer[0], QuestionAnswer[1]);
                    questions.Add(question);
                }
                return questions;



            }
            else
            {
                throw new Exception("Ошибка брат");
            }
            
        }

        public void Add(Question question)
        {
            File.AppendAllText(path, question.Text + "#" + question.RightAnswer + Environment.NewLine);
        }

        public void Remove(int index)
        {
            var withoutDeleted = File.ReadAllLines(path).ToList();
            withoutDeleted.RemoveAt(index);
            File.WriteAllLines(path, withoutDeleted);
        }

        public void SaveRecord(string nameOfUser, string diagnos, int cnt)
        {
            string formatRecord = $"{nameOfUser}#{diagnos}#{cnt}";
            if (File.Exists(path))
            {
                File.AppendAllText(path, formatRecord + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(path, formatRecord + Environment.NewLine);
            }
        }
        public void FillFile()
        {
            string[] bankOfQuestions =
                    {
                            "Сколько океанов на планете Земля?",
                            "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?",
                            "Сколько будет два плюс два умножить на два?",
                            "Укол делают каждые полчаса.Сколько минут,сделать три укола?",
                            "Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?",

                        };
            string[] correctAnswers = { "4", "3", "6", "60", "9"};
            for (int i = 0; i < bankOfQuestions.Length; i++)
            {
                File.AppendAllText(path, bankOfQuestions[i] + "#" + correctAnswers[i] + Environment.NewLine);
            }
        }
    }
}


