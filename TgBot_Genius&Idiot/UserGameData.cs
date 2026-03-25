using Game_geniusOrIdiot;

namespace TgBot_Genius_Idiot
{
    public class UserGameData
    {
        public Question CurrentQuestion { get; set; }
        public bool IsWaitingForAnswer { get; set; }
        public int CorrectAnswersCount { get; set; }
        public List<Question> RemainingQuestions { get; set; } = new List<Question>();
        public int TotalQuestions { get; set; }

        public UserGameData()
        {
            CorrectAnswersCount = 0;
            IsWaitingForAnswer = false;
            CurrentQuestion = null;
        }
    }
}