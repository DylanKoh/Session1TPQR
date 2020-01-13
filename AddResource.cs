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
            using (var context = new Session1QREntities())
            {
                var getType = (from x in context.Resource_Type
                               select x.resTypeName);
                HashSet<string> resouceType = new HashSet<string>();
                foreach (var item in getType)
                {
                    resouceType.Add(item);
                }
                typeBox.Items.AddRange(resouceType.ToArray());
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session1QREntities())
            {
                var checkResourceExistence = (from x in context.Resources
                                              where x.resName == resourceNameBox.Text
                                              select x).FirstOrDefault();

                var getNewID = (from x in context.Resources
                                orderby x.resId descending
                                select x.resId).First() + 1;

                if (checkResourceExistence != null)
                {
                    MessageBox.Show("Resource already exist in Database!", "Duplicate Resource", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (typeBox.SelectedItem == null || quantityBox.Text == null)
                    {
                        MessageBox.Show("Please check your entries again!", "Empty Field(s)", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                    }
                    else if (Int32.Parse(quantityBox.Text) > 0 && allocationBox.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Resource must have at least 1 allocated skill!", "Allocation of resource not set", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                    }
                    else if (Int32.Parse(quantityBox.Text) < 0)
                    {
                        MessageBox.Show("Resource amount cannot be negative!", "Invalid Amount", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                    }
                    else
                    {
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
                                resTypeIdFK = getNewID
                            });

                        }

                        else if (Int32.Parse(quantityBox.Text) > 0 && allocationBox.SelectedItems != null)
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
                            #region Trial edits
                            foreach (var item in list)
                            {
                                var getSkillID = (from x in context.Skills
                                                  where x.skillName == item
                                                  select x.skillId).First();
                                context.Resource_Allocation.Add(new Resource_Allocation() { resIdFK = getNewID, skillIdFK = getSkillID });
                            }
                            #endregion

                        }
                        else if (Int32.Parse(quantityBox.Text) > 0 )
                        {

                            /*foreach (var item in allocationBox.CheckedItems)
                            {
                                var getSkillID = (from x in context.Skills
                                                  where x.skillName == item.ToString()
                                                  select x.skillId).First();
                                context.Resource_Allocation.Add(new Resource_Allocation() { resIdFK = getNewID, skillIdFK = getSkillID });
                            }*/
                            


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
