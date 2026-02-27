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
    public partial class AddForm : Form
    {
        public string newText;
        public string newAnswer;
        public AddForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionsStorage questionsStorage = new QuestionsStorage();
            newText = newQuestionTextBox.Text;
            newAnswer = newAnswerTextBox.Text;
            Question question = new Question(newText,newAnswer);
            questionsStorage.Add(question);
            MessageBox.Show("Вопрос добавлен!");
            Hide();
            ChoiceForm choiceForm = new ChoiceForm();
            choiceForm.ShowDialog();
        }
    }
}
