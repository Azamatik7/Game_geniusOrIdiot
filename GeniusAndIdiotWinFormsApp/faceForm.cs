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
        public faceForm()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(userNameTextBox.Text + " проверим Гений ты или Идиот?", "", MessageBoxButtons.OK);
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
