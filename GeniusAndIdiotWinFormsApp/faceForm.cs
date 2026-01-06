using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusAndIdiotWinFormsApp
{
    public partial class faceForm : Form
    {
        public static string userName;
        public faceForm()
        {
            InitializeComponent();
            if (File.Exists("questions.txt"))
            {

            }
            else
            {
                for (int i = 0; i < bankOfQuestions.Count; i++)
                {
                    File.AppendAllText("questions.txt", bankOfQuestions[i] + "&" + correctAnswers[i] + Environment.NewLine);
                }
            }

            
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            MessageBox.Show(userNameTextBox.Text + " Добро пожаловать в игру!Удачи!", "", MessageBoxButtons.OK);
            Hide();
            ChoiceForm choiceForm = new ChoiceForm();
            choiceForm.Show();


        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private List<string> bankOfQuestions = new List<string>
        {
            "Сколько океанов на планете Земля?",
            "Одно яйцо варится 3 минуты,сколько минут варятся три яйца?",
            "Сколько будет два плюс два умножить на два?",
            "Укол делают каждые полчаса.Сколько минут нужно,чтобы сделать три укола?",
            "Бревно нужно распилить на 10 частей.Сколько распилов нужно сделать?",
            "мяу?"
        };
        private List<string> correctAnswers = new List<string> { "4", "3", "6", "60", "9", "мяу" };
    }
}
