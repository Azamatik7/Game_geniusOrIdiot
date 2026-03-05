using Newtonsoft.Json;
using System.IO;

namespace Game_geniusOrIdiot
{
    public class UserStorage
    {
        private string path = "@\"..\\..\\..\\records.json";


        public void SaveRecord(User user)
        {
            // Читаем существующих пользователей
            List<User> users = GetAll();

            // Добавляем нового пользователя
            users.Add(user);

            // Сериализуем список в JSON с форматированием
            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);

            // Записываем в файл
            File.WriteAllText(path, jsonString);
        }

        public List<User> GetAll()
        {
            // Проверяем, существует ли файл
            if (!File.Exists(path))
            {
                return new List<User>();
            }

            // Читаем JSON из файла
            string jsonString = File.ReadAllText(path);

            // Десериализуем JSON в список пользователей
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonString);

            // Возвращаем результат (если null, то возвращаем пустой список)
            return users ?? new List<User>();
        }
    }
}


