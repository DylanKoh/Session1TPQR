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
                //Checks for empty User ID field
                if (userBox.Text.Trim() == "")
                {
                    MessageBox.Show("User ID field is empty!", "Empty Fields", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                //Checks for empty Password field
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
                                   select new { Password = x.userPw, Name = x.userName, UserType = y.userTypeName, ID = x.userId }).FirstOrDefault();

                    //Checks if User account exist in DB. Else prompts error message
                    if (!getUser.ID.Any())
                    {
                        MessageBox.Show("User does not exist!", "Invalid Account", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    //Check if entered ID has password matching with what is keyed into the password field
                    else if (passwordBox.Text.Trim() != getUser.Password)
                    {
                        MessageBox.Show("Password is incorrect!", "Password Wrong", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    //Checks for User type as application only let Resource Managers in
                    else if (getUser.UserType != "Manager")
                    {
                        MessageBox.Show("Sorry, your account is not an account of a Resource Manager!", "Account invalid", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }

                    //Allow login if all check passes
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
