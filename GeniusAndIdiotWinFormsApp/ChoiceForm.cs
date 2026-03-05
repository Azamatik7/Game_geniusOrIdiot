using Game_geniusOrIdiot;
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
        User user;
        public ChoiceForm()
        {
            InitializeComponent();
        }
        public ChoiceForm(User User)
        {
            InitializeComponent();
            user = User;
        }



        private void playButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1(user);
            form1.ShowDialog();
            Show();
        }

        private void recordsButton_Click(object sender, EventArgs e)
        {
            
            Hide();
            RecordsForm recordsForm = new RecordsForm();
            recordsForm.ShowDialog();
            Show();

        }

        private void addQuestionbutton_Click(object sender, EventArgs e)
        {
            Hide();
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
            Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            DeleteForm deleteButton = new DeleteForm();
            deleteButton.ShowDialog();
            Show();
        }
    }
}
