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
        public User user;
        public faceForm()
        {
            InitializeComponent();
            User user = new User(userName);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            user = new User(userNameTextBox.Text);
            
            
            Hide();
            ChoiceForm choiceForm = new ChoiceForm(user);
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
