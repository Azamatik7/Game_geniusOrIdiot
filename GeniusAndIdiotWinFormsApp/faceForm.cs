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
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            MessageBox.Show(userNameTextBox.Text + " проверим Гений ты или Идиот?", "", MessageBoxButtons.OK);
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
    }
}
