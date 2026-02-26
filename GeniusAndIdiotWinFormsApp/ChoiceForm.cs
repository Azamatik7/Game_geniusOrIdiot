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
            form1.Show();
        }

        private void recordsButton_Click(object sender, EventArgs e)
        {
            RecordsForm recordsForm = new RecordsForm();
            Hide();
            recordsForm.Show();

        }

        private void addQuestionbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
