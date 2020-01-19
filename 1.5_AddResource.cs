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
    public partial class AddResource : Form
    {
        List<string> list = new List<string>();
        public AddResource()
        {
            InitializeComponent();
        }

        private void AddResource_Load(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                #region Populating the Type of Resources Combo Box
                var getType = (from x in context.Resource_Type
                               select x.resTypeName);
                HashSet<string> resouceType = new HashSet<string>();
                foreach (var item in getType)
                {
                    resouceType.Add(item);
                }
                typeBox.Items.AddRange(resouceType.ToArray());
                #endregion

                #region Populating Skill Allocation Checklist Box
                var getSkills = (from x in context.Skills
                                 select x.skillName);
                var skills = new HashSet<string>();
                foreach (var item in getSkills)
                {
                    skills.Add(item);
                }
                allocationBox.Items.AddRange(skills.ToArray());
                #endregion
            }
        }

        /// <summary>
        /// Redirects user back to Resource Management Page - 1.4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// This method is called when the Add button is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1Entities())
            {
                var checkResourceExistence = (from x in context.Resources
                                              where x.resName == resourceNameBox.Text
                                              select x).FirstOrDefault();

                var getNewID = (from x in context.Resources
                                orderby x.resId descending
                                select x.resId).First() + 1;

                //Check if intended new resource has a record in the database
                if (checkResourceExistence != null)
                {
                    MessageBox.Show("Resource already exist in Database!", "Duplicate Resource", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    //Check if the Type of Resource and and quantity is selected and keyed in properly
                    if (typeBox.SelectedItem == null || quantityBox.Text == null)
                    {
                        MessageBox.Show("Please check your entries again!", "Empty Field(s)", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                    }

                    //Check if there is any allocation if quantity is more than 0. Resource must have an allocation if quantity is more than 0
                    else if (Int32.Parse(quantityBox.Text) > 0 && allocationBox.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Resource must have at least 1 allocated skill!", "Allocation of resource not set", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                    }

                    //Check if user keyed in an invalid integer
                    else if (Int32.Parse(quantityBox.Text) < 0)
                    {
                        MessageBox.Show("Resource amount cannot be negative!", "Invalid Amount", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                    }

                    //Check if there are any allocation if the quantity is set to 0
                    else if (Int32.Parse(quantityBox.Text) == 0 && allocationBox.CheckedItems.Count > 0)
                    {
                        MessageBox.Show("Resource cannot be allocated if amount is 0", "Unable to allocate resource",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        //If quantity is 0, add everything keyed in except for skill allocation to DB
                        if (Int32.Parse(quantityBox.Text) == 0)
                        {
                            var getTypeID = (from x in context.Resource_Type
                                             where x.resTypeName == typeBox.SelectedItem.ToString()
                                             select x.resTypeId).First();
                            context.Resources.Add(new Resource()
                            {
                                resId = getNewID,
                                resName = resourceNameBox.Text,
                                remainingQuantity = Int32.Parse(quantityBox.Text),
                                resTypeIdFK = getTypeID
                            });

                        }

                        //If quantity more 0, add everything keyed in to DB
                        else if (Int32.Parse(quantityBox.Text) > 0)
                        {
                            var getTypeID = (from x in context.Resource_Type
                                             where x.resTypeName == typeBox.SelectedItem.ToString()
                                             select x.resTypeId).First();
                            context.Resources.Add(new Resource()
                            {
                                resId = getNewID,
                                resName = resourceNameBox.Text,
                                remainingQuantity = Int32.Parse(quantityBox.Text),
                                resTypeIdFK = getTypeID
                            });
                            if (list.Count() != 0)
                            {
                                foreach (var item in list)
                                {
                                    var getSkillID = (from x in context.Skills
                                                      where x.skillName == item
                                                      select x.skillId).First();
                                    context.Resource_Allocation.Add(new Resource_Allocation() { resIdFK = getNewID, skillIdFK = getSkillID });
                                }
                            }
                            

                        }


                        context.SaveChanges();
                        resourceNameBox.Text = "";
                        typeBox.SelectedItem = null;
                        quantityBox.Text = "";
                        allocationBox.SelectedItems.Clear();
                        list.Clear();
                    }
                }
            }
        }

        private void allocationBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When checked, will add the skill allocation to a global list for reference to save to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allocationBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = allocationBox.SelectedItem.ToString();
            if (e.NewValue == CheckState.Checked)
            {
                list.Add(item);
            }
            else
            {
                if (list.Contains(item))
                    list.Remove(item);
            }
        }
    }
}
