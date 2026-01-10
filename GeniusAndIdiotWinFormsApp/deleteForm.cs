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
    public partial class deleteForm : Form
    {
        public deleteForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteForm_Load(object sender, EventArgs e)
        {
            if (File.Exists("questions.txt"))
            {
                string[] lines = File.ReadAllLines("questions.txt");
                foreach (string line in lines)
                {

                    string[] data = line.Split("&");

                    deleteDataGridView.Rows.Add(data[0]);
                }
                

            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ChoiceForm choiceForm = new ChoiceForm();
            choiceForm.ShowDialog();
        }

        private void deleteQuestionbutton1_Click(object sender, EventArgs e)
        {
            if (File.Exists("questions.txt"))
            {
                
                List<string> lines = File.ReadAllLines("questions.txt").ToList();
                if (lines.Count < 5)
                {
                    MessageBox.Show("Вопрос итак мало,в данный момент вы не можете удалить еще один");
                }
                string deleteQuestion = deletedquestionTextBox.Text;
                bool flag = false;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains(deleteQuestion))
                    {
                        flag = true;
                        lines.RemoveAt(i);
                    }
                }
                if (flag)
                {
                    File.WriteAllLines("questions.txt", lines);
                    MessageBox.Show("Вопрос удален!");
                }
                else
                {
                    MessageBox.Show("Данного вопроса нет в списке,будьте внимательнее!");
                }
                
            }
            


        }
    }
}
