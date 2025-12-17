using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GeniusAndIdiotWinFormsApp
{
    public partial class Form1 : Form
    {
        private List<string> bankOfQuestions = new List<string>
        {
            "Сколько океанов на планете Земля?",
            "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?",
            "Сколько будет два плюс два умножить на два?",
            "Укол делают каждые полчаса.Сколько минут нужно,чтобы сделать три укола?",
            "Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?",
            "мяу?"
        };
        int lenBank;
        int i = 1;
        int rightAnswersCount = 0;

        private List<string> correctAnswers = new List<string> { "4", "3", "6", "60", "9", "мяу" };
        Random rng = new Random();
        int curentQuestionIndex;
        public Form1()
        {
            InitializeComponent();
            lenBank = bankOfQuestions.Count;


        }

        private void Submitbutton_Click(object sender, EventArgs e)
        {

            

            if (userAnswerTextBox.Text == correctAnswers[curentQuestionIndex])
            {
                rightAnswersCount++;
            }


            bankOfQuestions.RemoveAt(curentQuestionIndex);
            correctAnswers.RemoveAt(curentQuestionIndex);
            if (bankOfQuestions.Count == 0)
            {
                userAnswerTextBox.Text = "";
                questionLabel.Text = "Все!";
                MessageBox.Show($"Количество правильных ответов: {rightAnswersCount}");
                MessageBox.Show($"Ваш диагноз:{Diagnosis(rightAnswersCount, lenBank)}");
                Submitbutton.Enabled = false;
                return;
            }
            curentQuestionIndex = rng.Next(bankOfQuestions.Count());
            questionLabel.Text = bankOfQuestions[curentQuestionIndex];
            
            i++;
            questionNumberlabel.Text = $"Вопрос {i}";

            userAnswerTextBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            questionNumberlabel.Text = $"Вопрос {i}";

            curentQuestionIndex = rng.Next(bankOfQuestions.Count);
            questionLabel.Text = bankOfQuestions[curentQuestionIndex];
        }

        static string Diagnosis(int cnt,int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double rightAns = cnt;
            double questionsNumber = len;
            double percent = rightAns / questionsNumber * 100;
            if (percent == 0)
            {
                return diagnosises[0];
            }
            if (percent < 20)
            {
                return diagnosises[1];
            }
            if (percent < 40)
            {
                return diagnosises[2];
            }
            if (percent < 60)
            {
                return diagnosises[3];
            }
            if (percent < 80)
            {
                return diagnosises[4];
            }
            return diagnosises[5];


        }
    }
}
