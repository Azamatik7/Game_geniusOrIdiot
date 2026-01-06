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
    public partial class AddQuestionForm : Form
    {
        public AddQuestionForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            ChoiceForm choiceForm = new ChoiceForm();
            choiceForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string AddedQuestion = textBox1.Text;
            string AddedAnswer = textBox2.Text;
            if (string.IsNullOrEmpty(AddedQuestion) || string.IsNullOrEmpty(AddedAnswer))
            {
                MessageBox.Show("Напишите вопрос по-людски");
            }
            else
            {

                if (File.Exists("questions.txt"))
                {
                    File.AppendAllText("questions.txt", AddedQuestion+"&"+AddedAnswer + Environment.NewLine);
                    //File.WriteAllText("questions.txt", string.Empty);
                    MessageBox.Show("вопрос успешно добавлен");
                }
                else
                {
                    File.AppendAllText("questions.txt", AddedQuestion + "&" + AddedAnswer);
                    //File.WriteAllText("questions.txt", string.Empty);
                    MessageBox.Show("вопрос успешно добавлен" + Environment.NewLine);
                    
                }
            }
        }
    }
}
