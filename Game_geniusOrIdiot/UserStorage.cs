namespace Game_geniusOrIdiot
{
    public class UserStorage
    {
        private string path = "records.txt";

        public void SaveRecord(User user)
        {

            string formatRecord = $"{user.Name}#{user.Diagnosis}#{user.CorrectAnswers}";
            if (File.Exists(path))
            {
                File.AppendAllText(path, formatRecord + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(path, formatRecord + Environment.NewLine);
            }
        }
        public List<User> GetAll()
        {
            string[] records = File.ReadAllLines(path);
            List<User> users = new List<User>();

            foreach (string record in records)
            {
                string[] userdata = record.Split("#");
                User user = new User(userdata[0], userdata[1], int.Parse(userdata[2]));
                users.Add(user);
            }
            return users;           
        }

    }
}


