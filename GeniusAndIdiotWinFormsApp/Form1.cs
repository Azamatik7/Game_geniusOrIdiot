namespace GeniusAndIdiotWinFormsApp
{
    public partial class Form1 : Form
    {
        string[] bankOfQuestions =
                {
                "—колько океанов на планете «емл€?",
                "ќдно €йцо варитс€ 3 минуты,сколько минут вар€тс€ три €йца?",
                "—колько будет два плюс два умножить на два?",
                "”кол делают каждые полчаса.—колько минут,сделать три укола?",
                "Ѕревно нужно распилить на 10 частей.—колько распилов нужно сделать?",
                "м€у?"
                };
        string[] correctAnswers = { "4", "3", "6", "60", "9", "м€у" };
        public Form1()
        {
            InitializeComponent();
        }

        private void questionNumberlabel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
