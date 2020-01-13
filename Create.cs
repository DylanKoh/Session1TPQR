﻿using System;
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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            HashSet<string> vs = new HashSet<string>();
            using (var context  = new Session1QREntities())
            {
                var getType = (from x in context.User_Type
                               select x.userTypeName);
                foreach (var item in getType)
                {
                    vs.Add(item);
                }
                typeUserBox.Items.AddRange(vs.ToArray());
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Main()).ShowDialog();
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1QREntities())
            {
                if (userIdBox.TextLength < 8)
                {
                    MessageBox.Show("ID needs to be at least 8 characters");
                }
                else if (passwordBox.Text != rePasswordBox.Text)
                {
                    MessageBox.Show("Passwords must be the same!");

                }
                else if (typeUserBox.SelectedItem == null)
                {
                    MessageBox.Show("Please choose user type!");
                }
                else
                {
                    var getUserTypeID = (from x in context.User_Type
                                         where x.userTypeName == typeUserBox.SelectedItem.ToString()
                                         select x.userTypeId).First();
                    context.Users.Add(new User()
                    {
                        userName = userNameBox.Text,
                        userId = userIdBox.Text,
                        userPw = passwordBox.Text,
                        userTypeIdFK = getUserTypeID
                    });
                    context.SaveChanges();
                    this.Hide();
                    (new Main()).ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
