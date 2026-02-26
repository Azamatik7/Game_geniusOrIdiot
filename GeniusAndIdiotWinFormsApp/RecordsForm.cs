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
            UserStorage userStorage = new UserStorage();
            List<User> users = userStorage.GetAll();
            foreach (User user in users)
            {
                dataGridView1.Rows.Add(user.Name, user.Diagnosis, user.CorrectAnswers);
            }
            
        }
    }
}
