namespace Game_geniusOrIdiot
{
    public class User
    {
        public string Name;
        public string Diagnosis;
        public int CorrectAnswers = 0;

        public User(string name)
        {
            Name = name;
        }
        public User(string name, string diagnosis, int correctAnswers)
        {
            Name = name;
            Diagnosis = diagnosis;
            CorrectAnswers = correctAnswers;
        }
    }
}


