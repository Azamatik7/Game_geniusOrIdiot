using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GeniusAndIdiotWinFormsApp
{
    public partial class Form1 : Form
    {
        
        int lenBank;
        int i = 1;
        int rightAnswersCount = 0;
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();



        Random rng = new Random();
        int curentQuestionIndex;
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Submitbutton_Click(object sender, EventArgs e)
        {



            if (userAnswerTextBox.Text == answers[curentQuestionIndex])
            {
                rightAnswersCount++;
            }


            questions.RemoveAt(curentQuestionIndex);
            answers.RemoveAt(curentQuestionIndex);
            if (questions.Count == 0)
            {
                userAnswerTextBox.Text = "";
                questionLabel.Text = "Все!";
                MessageBox.Show($"Количество правильных ответов: {rightAnswersCount}");
                MessageBox.Show($"Ваш диагноз:{Diagnosis(rightAnswersCount, lenBank)}");
                DialogResult decision = MessageBox.Show($"Будем играть еще?", "", MessageBoxButtons.YesNo);
                File.AppendAllText("records.txt", $"{faceForm.userName}#{Diagnosis(rightAnswersCount, lenBank)}#{rightAnswersCount}"+Environment.NewLine);
                if (decision == DialogResult.Yes)
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
            curentQuestionIndex = rng.Next(questions.Count());
            questionLabel.Text = questions[curentQuestionIndex];

            i++;
            questionNumberlabel.Text = $"Вопрос {i}";

            userAnswerTextBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("questions.txt"))
            {
                string[] lines = File.ReadAllLines("questions.txt");
                foreach (string line in lines)
                {
                    string[] questionAns = line.Split("&");
                    questions.Add(questionAns[0]);
                    answers.Add(questionAns[1]);
                }
            }
            lenBank = questions.Count;

            questionNumberlabel.Text = $"Вопрос {i}";

            curentQuestionIndex = rng.Next(questions.Count);
            questionLabel.Text = questions[curentQuestionIndex];
        }

        static string Diagnosis(int cnt, int len)
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
