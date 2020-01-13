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
    public partial class Update : Form
    {
        int _resID;
        List<string> _list = new List<string>();
        public Update(int resID)
        {
            InitializeComponent();
            _resID = resID;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            using (var context = new Session1QREntities())
            {
                var getSkills = (from x in context.Skills
                                 select x.skillName);
                var skills = new HashSet<string>();
                foreach (var item in getSkills)
                {
                    skills.Add(item);
                }
                clbAllocation.Items.AddRange(skills.ToArray());

                var getResourceName = (from x in context.Resources
                                       where x.resId == _resID
                                       select x.resName).First();
                lblResourceName.Text = getResourceName;

                var getResourceType = (from x in context.Resources
                                       where x.resId == _resID
                                       select x.Resource_Type.resTypeName).First();
                lblResourceType.Text = getResourceType;

                var getResourceAmount = (from x in context.Resources
                                         where x.resId == _resID
                                         select x.remainingQuantity).First();
                txtQuantityBox.Text = getResourceAmount.ToString();

                var checkAllocatedSkills = (from x in context.Resource_Allocation
                                            where x.resIdFK == _resID
                                            select x).FirstOrDefault();

                if (checkAllocatedSkills != null)
                {
                    var getAllocatedSkills = (from x in context.Resource_Allocation
                                              where x.resIdFK == _resID
                                              select x.Skill.skillName);
                    foreach (var item in getAllocatedSkills)
                    {
                        _list.Add(item);

                        clbAllocation.SetItemChecked(clbAllocation.Items.IndexOf(item), true);


                    }
                    var getAllocatedSkillsToDelete = (from x in context.Resource_Allocation
                                                      where x.resIdFK == _resID
                                                      select x);
                    foreach (var item in getAllocatedSkillsToDelete)
                    {
                        context.Resource_Allocation.Remove(item);
                        context.SaveChanges();
                    }
                }




            }
        }

        private void txtQuantityBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var amount = Int32.Parse(txtQuantityBox.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter a valid integer that is 0 or more!", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clbAllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void clbAllocation_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = clbAllocation.SelectedItem.ToString();
            if (e.NewValue == CheckState.Checked)
            {
                _list.Add(item);
            }
            else
            {
                _list.Remove(item);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var context = new Session1QREntities())
            {

                if (txtQuantityBox.Text == null)
                {
                    MessageBox.Show("Please check your entries again!", "Empty Field(s)", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                }
                else if (Int32.Parse(txtQuantityBox.Text) > 0 && clbAllocation.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Resource must have at least 1 allocated skill!", "Allocation of resource not set", MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                }
                else if (Int32.Parse(txtQuantityBox.Text) < 0)
                {
                    MessageBox.Show("Resource amount cannot be negative!", "Invalid Amount", MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (Int32.Parse(txtQuantityBox.Text) == 0 && clbAllocation.CheckedItems.Count > 0)
                    {
                        MessageBox.Show("Resource cannot be allocated if amount is 0", "Unable to allocate resource",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (Int32.Parse(txtQuantityBox.Text) == 0 && clbAllocation.CheckedItems.Count == 0)
                    {
                        var updateResource = (from x in context.Resources
                                              where x.resId == _resID
                                              select x).First();
                        updateResource.remainingQuantity = Int32.Parse(txtQuantityBox.Text);
                    }
                    else if (Int32.Parse(txtQuantityBox.Text) > 0)
                    {
                        var updateResource = (from x in context.Resources
                                              where x.resId == _resID
                                              select x).First();
                        updateResource.remainingQuantity = Int32.Parse(txtQuantityBox.Text);
                        if (_list.Count() != 0)
                        {
                            foreach (var item in _list)
                            {
                                var getSkillID = (from x in context.Skills
                                                  where x.skillName == item
                                                  select x.skillId).First();
                                context.Resource_Allocation.Add(new Resource_Allocation() { resIdFK = _resID, skillIdFK = getSkillID });
                            }
                        }


                    }


                    context.SaveChanges();
                    this.Hide();
                    (new ResourceManagement()).ShowDialog();
                    this.Close();
                }

            }
        }
    }
}
