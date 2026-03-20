namespace TgBot_Genius_Idiot
{
    public class UserState
    {
        public long UserId { get; set; }
        public string CurrentPage { get; set; }

        public UserState(long userId)
        {
            UserId = userId;
        }
    }
}