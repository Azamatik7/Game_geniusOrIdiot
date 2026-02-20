namespace Game_geniusOrIdiot
{
    public class QuestionsStorage
    {
        private string path = "question.txt";

        public List<Question> GetAll()
        {
            if (!File.Exists(path))
            {
                throw new Exception("Ошибка брат");
            }

            string[] check = File.ReadAllLines(path);
            if (check.Length != 0)
            {
                List<Question> list = new List<Question>();

                foreach (string line in check)
                {
                    string[] lineData = line.Split("#");
                    Question question = new Question(lineData[0], lineData[1]);
                    list.Add(question);
                }
                return list;
            }

            List<Question> defaultQuestions = GetDefaultQuestions();
            foreach (Question defaultQuestion in defaultQuestions)
            {
                Add(defaultQuestion);
            }
            
            return defaultQuestions;
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

        public List<Question> GetDefaultQuestions()
        {
            List<Question> defaultQuestions = new List<Question>();

            Question default1 = new Question("Сколько океанов на планете Земля?", "4");
            Question default2 = new Question("Одно яйцо варится 3 минуты,сколько минут варятся три яйца?", "3");
            Question default3 = new Question("Сколько будет два плюс два умножить на два?","6");
            Question default4 = new Question("Укол делают каждые полчаса.Сколько минут,сделать три укола?", "60");
            Question default5 = new Question("Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?", "9");

            defaultQuestions.Add(default1);
            defaultQuestions.Add(default2);
            defaultQuestions.Add(default3);
            defaultQuestions.Add(default4);
            defaultQuestions.Add(default5);

            return defaultQuestions;

        }
    }
}


