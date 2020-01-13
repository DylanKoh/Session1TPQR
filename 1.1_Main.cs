using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session1
{
    /// <summary>
    /// This Form is for Question 1.1
    /// </summary>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Upon clicking the login button, it will redirect users to 
        /// RM Login page - 1.3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Upon clicking create account, it will redirect user to
        /// RM account creation page - 1.2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Create()).ShowDialog();
            this.Close();
        }
    }
}
