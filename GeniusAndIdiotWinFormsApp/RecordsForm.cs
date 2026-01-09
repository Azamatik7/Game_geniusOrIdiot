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
    public partial class RecordsForm : Form
    {
        public RecordsForm()
        {
            InitializeComponent();

        }

        private void RecordsForm_Load(object sender, EventArgs e)
        {
            //File.WriteAllText("records.txt", string.Empty);
            if (File.Exists("records.txt"))
            {
                string[] lines = File.ReadAllLines("records.txt");
                foreach (string line in lines)
                {

                    string[] data = line.Split("#");

                    dataGridView1.Rows.Add(data[0], data[1], data[2]);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backRecordsButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ChoiceForm choiceForm = new ChoiceForm();
            choiceForm.ShowDialog();
        }
    }
}
