using Game_geniusOrIdiot;
using System;
using System.Collections;
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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            QuestionsStorage questionsStorage = new QuestionsStorage();
            List<Question> questions = questionsStorage.GetAll();
            for (int i = 0; i < questions.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1, questions[i].Text);
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string deleteNumber = NumberDeleteTextBox.Text;
            

            QuestionsStorage questionsStorage = new QuestionsStorage();
            if (!FoolCheckNumber(deleteNumber, questionsStorage.GetAll().Count))
            {
                NumberDeleteTextBox.Text = "";
                MessageBox.Show("Введите корректный номер!");
                NumberDeleteTextBox.Focus();
                return;

            }
            questionsStorage.Remove(int.Parse(deleteNumber)-1);
            MessageBox.Show("Вопрос удален!");

        }
        public static bool FoolCheckNumber(string checkNumber, int questionsQuantity)
        {
            if (int.TryParse(checkNumber, out int correctNumber))
            {
                if (correctNumber > 0 && correctNumber <= questionsQuantity)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
