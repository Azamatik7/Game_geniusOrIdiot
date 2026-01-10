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

    public partial class ChoiceForm : Form
    {
        public ChoiceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddQuestionForm addQuestionForm = new AddQuestionForm();
            addQuestionForm.ShowDialog();


        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void recordsButton_Click(object sender, EventArgs e)
        {
            RecordsForm recordsForm = new RecordsForm();
            Hide();
            recordsForm.Show();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            deleteForm deleteForm = new deleteForm();
            deleteForm.Show();

        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
            Hide();
            deleteForm deleteForm = new deleteForm();
            deleteForm.Show();

        }

        private void ChoiceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
