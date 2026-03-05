using System.IO;
using Newtonsoft.Json;

namespace Game_geniusOrIdiot
{
    public class QuestionsStorage
    {
        private string path = @"..\..\..\question.json";

        
        public List<Question> GetAll()
        {
            if (!File.Exists(path))
            {
                // Если файла нет - создаем с дефолтными вопросами
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(path, json);
                return defaultQuestions;
            }

            string jsonContent = File.ReadAllText(path);

            // Если файл пустой или содержит только пробелы
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(path, json);
                return defaultQuestions;
            }

            // Десериализуем JSON в список вопросов
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(jsonContent) ?? new List<Question>();

            // Если список пустой после десериализации
            if (questions.Count == 0)
            {
                List<Question> defaultQuestions = GetDefaultQuestions();
                string json = JsonConvert.SerializeObject(defaultQuestions);
                File.WriteAllText(path, json);
                return defaultQuestions;
            }

            return questions;
        }

        public void Add(Question question)
        {
            var questions = new List<Question>();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();
            }

            questions.Add(question);

            string updatedJson = JsonConvert.SerializeObject(questions); 
            File.WriteAllText(path, updatedJson);
        }

        public void Remove(int index)
        {
            string json = File.ReadAllText(path);
            var questions = JsonConvert.DeserializeObject<List<Question>>(json) ?? new List<Question>();  
            questions.RemoveAt(index);

            string updatedJson = JsonConvert.SerializeObject(questions);  
            File.WriteAllText(path, updatedJson);
        }

        public List<Question> GetDefaultQuestions()
        {
            List<Question> defaultQuestions = new List<Question>();

            Question default1 = new Question("Сколько океанов на планете Земля?", "4");
            Question default2 = new Question("Одно яйцо варится 3 минуты,сколько минут варятся три яйца?", "3");
            Question default3 = new Question("Сколько будет два плюс два умножить на два?", "6");
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


