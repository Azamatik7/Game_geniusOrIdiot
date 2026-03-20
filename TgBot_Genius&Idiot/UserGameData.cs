using Game_geniusOrIdiot;

namespace TgBot_Genius_Idiot
{
    public class UserGameData
    {
        public int CorrectAnswersCount { get; set; }
        public bool IsWaitingForAnswer { get; set; }
        public Question CurrentQuestion { get; set; }

        public UserGameData()
        {
            CorrectAnswersCount = 0;
            IsWaitingForAnswer = false;
            CurrentQuestion = null;
        }
    }
}