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
                    ChoiceForm choiceForm = new ChoiceForm();
                    Hide();
                    choiceForm.ShowDialog();

                }
                else
                {
                    Close();
                }
                Submitbutton.Enabled = false;

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
            questionNumberlabel.Text = $"Вопрос {i}";

            curentQuestionIndex = rng.Next(questions.Count);
            questions = questionsStorage.GetAll();
            questionLabel.Text = questions[curentQuestionIndex].Text;
            
            lenBank = questions.Count;
        }

        static string SayDiagnosis(int cnt, int len)
        {
            string[] diagnosises = { "Идиот", "Бездарь", "Дурак", "Человек Разумный", "Талант", "Гений" };
            double rightAns = cnt;
            double questionsNumber = len;
            double percent = rightAns / questionsNumber * 100;

            return diagnosises[int.Parse((percent / 20d).ToString())];
        }


    }
}
