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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                if (userBox.Text.Trim() == "")
                {
                    MessageBox.Show("User ID field is empty!", "Empty Fields", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                else if (passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Password field is empty!", "Empty Fields", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId.Equals(userBox.Text.Trim())
                                   join y in context.User_Type on x.userTypeIdFK equals y.userTypeId
                                   select new { Password = x.userPw, Name = x.userName, UserType = y.userTypeName }).FirstOrDefault();

                    if (!getUser.Password.Any())
                    {
                        MessageBox.Show("User does not exist!", "Invalid Account", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    else if (passwordBox.Text.Trim() != getUser.Password)
                    {
                        MessageBox.Show("Password is incorrect!", "Password Wrong", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    else if (getUser.UserType != "Resource Manager")
                    {
                        MessageBox.Show("Sorry, your account is not an account of a Resource Manager!", "Account invalid", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    else
                    {
                        MessageBox.Show($"Welcome {getUser.Name}!", "Welcome!", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                        this.Hide();
                        (new ResourceManagement()).ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Main()).ShowDialog();
            this.Close();
        }
    }
}
