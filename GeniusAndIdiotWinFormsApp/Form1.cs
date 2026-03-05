using Game_geniusOrIdiot;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GeniusAndIdiotWinFormsApp
{
public partial class Form1 : Form
    {
        
        int lenBank;
        int i = 1;
        User user;

        
        Random rng = new Random();
        int curentQuestionIndex;

        QuestionsStorage questionsStorage = new QuestionsStorage();
        List<Question> questions = new List<Question>();
        
        UserStorage userStorage = new UserStorage();

        public Form1()
        {
            InitializeComponent();
        }   
        public Form1(User fromChoice)
        {
            InitializeComponent();
            user = fromChoice;
        }

        private void Submitbutton_Click(object sender, EventArgs e)
        {



            if (userAnswerTextBox.Text == questions[curentQuestionIndex].RightAnswer)
            {
                user.CorrectAnswers++;
            }
            userAnswerTextBox.Focus();


            
            questions.RemoveAt(curentQuestionIndex);

            if (questions.Count == 0)
            {
                userAnswerTextBox.Text = "";
                questionLabel.Text = "Все!";
                MessageBox.Show($"Количество правильных ответов: {user.CorrectAnswers}");
                MessageBox.Show($"Ваш диагноз:{SayDiagnosis(user.CorrectAnswers, lenBank)}");
                DialogResult decision =  MessageBox.Show($"Будем играть еще?", "", MessageBoxButtons.YesNo);
                
                user.Diagnosis = SayDiagnosis(user.CorrectAnswers, lenBank);
                
                userStorage.SaveRecord(user);
                if ( decision == DialogResult.Yes )
                {
                    StartGame();
                }
                else
                {
                    Close();
                }
                

                return;
            }
            curentQuestionIndex = rng.Next(questions.Count);
            
            
            questionLabel.Text = questions[curentQuestionIndex].Text;

            i++;
            questionNumberlabel.Text = $"Вопрос {i}";

            userAnswerTextBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            user.CorrectAnswers = 0;
            user.Diagnosis = "";
            i = 1;

            questionNumberlabel.Text = $"Вопрос {i}";

            questions = questionsStorage.GetAll();
            lenBank = questions.Count;

            curentQuestionIndex = rng.Next(questions.Count);
            questionLabel.Text = questions[curentQuestionIndex].Text;
        }

        static string SayDiagnosis(int cnt, int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double rightAns = cnt;
            double questionsNumber = len;
            double percent = rightAns / questionsNumber * 100;

            return diagnosises[(int)(percent / 20d)];
        }
    }
}