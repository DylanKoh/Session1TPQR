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
    public partial class ResourceManagement : Form
    {
        public ResourceManagement()
        {
            InitializeComponent();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void ResourceManagement_Load(object sender, EventArgs e)
        {
            using (var context = new Session1QREntities())
            {
                HashSet<string> type = new HashSet<string>();
                var getTypes = (from x in context.Resource_Type
                                select x.resTypeName);
                foreach (var types in getTypes)
                {
                    type.Add(types);
                }
                typeBox.Items.AddRange(type.ToArray());

                HashSet<string> skill = new HashSet<string>();
                var getSkills = (from x in context.Skills
                                 select x.skillName);
                foreach (var skills in getSkills)
                {
                    skill.Add(skills);
                }
                skilBox.Items.AddRange(skill.ToArray());
            }
            GridRefresh();
        }

        /// <summary>
        /// To load Datagridview components
        /// </summary>
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Type";
            dataGridView1.Columns[2].Name = "No. of Skills";
            dataGridView1.Columns[3].Name = "Allocated Skill(s)";
            dataGridView1.Columns[4].Name = "Available Quantity";
            dataGridView1.Columns[5].Name = "Resource ID";
            dataGridView1.Columns[5].Visible = false;

            using (var context = new Session1QREntities())
            {
                if (typeBox.SelectedItem != null && skilBox.SelectedItem != null)
                {
                    var getTypeID = (from x in context.Resource_Type
                                     where x.resTypeName == typeBox.SelectedItem.ToString()
                                     select x.resTypeId).First();

                    var getSkillID = (from x in context.Skills
                                      where x.skillName == skilBox.SelectedItem.ToString()
                                      select x.skillId).First();
                    var getResources = (from x in context.Resources
                                        join y in context.Resource_Allocation on x.resId equals y.resIdFK
                                        where y.skillIdFK == getSkillID && x.resTypeIdFK == getTypeID
                                        orderby x.remainingQuantity descending
                                        select x).ToList();

                    foreach (var resources in getResources)
                    {
                        List<string> rows = new List<string>()
                        {
                            resources.resName, resources.Resource_Type.resTypeName, resources.Resource_Allocation.Count().ToString()
                        };
                        string skillsAllocated = "";
                        foreach (var skills in resources.Resource_Allocation)
                        {
                            if (skillsAllocated != "")
                            {
                                skillsAllocated += ", " + skills.Skill.skillName;
                            }
                            else if (skillsAllocated == "")
                            {
                                skillsAllocated += skills.Skill.skillName;
                            }
                            else if (skills.Skill == null)
                            {
                                skillsAllocated += "NIL";
                            }
                        }
                        rows.Add(skillsAllocated);
                        var checkQuantity = (from x in context.Resources
                                             where x.resId == resources.resId
                                             select x.remainingQuantity).FirstOrDefault();

                        if (checkQuantity == 0) rows.Add("Not Available");
                        else if (checkQuantity <= 5 && checkQuantity >= 1) rows.Add("Low Stock");
                        else rows.Add("Sufficient");
                        rows.Add(resources.resId.ToString());
                        dataGridView1.Rows.Add(rows.ToArray());
                    }
                }

                else if (typeBox.SelectedItem != null)
                {
                    var getTypeID = (from x in context.Resource_Type
                                     where x.resTypeName == typeBox.SelectedItem.ToString()
                                     select x.resTypeId).First();

                    var getResources = (from x in context.Resources
                                        where x.resTypeIdFK == getTypeID
                                        orderby x.remainingQuantity descending
                                        select x).ToList();

                    foreach (var resources in getResources)
                    {
                        List<string> rows = new List<string>()
                        {
                            resources.resName, resources.Resource_Type.resTypeName, resources.Resource_Allocation.Count().ToString()
                        };
                        string skillsAllocated = "";
                        foreach (var skills in resources.Resource_Allocation)
                        {
                            if (skillsAllocated != "")
                            {
                                skillsAllocated += ", " + skills.Skill.skillName;
                            }
                            else if (skillsAllocated == "")
                            {
                                skillsAllocated += skills.Skill.skillName;
                            }
                            else if (skills.Skill == null)
                            {
                                skillsAllocated += "NIL";
                            }
                        }
                        rows.Add(skillsAllocated);
                        var checkQuantity = (from x in context.Resources
                                             where x.resId == resources.resId
                                             select x.remainingQuantity).FirstOrDefault();

                        if (checkQuantity == 0) rows.Add("Not Available");
                        else if (checkQuantity <= 5 && checkQuantity >= 1) rows.Add("Low Stock");
                        else rows.Add("Sufficient");
                        rows.Add(resources.resId.ToString());
                        dataGridView1.Rows.Add(rows.ToArray());
                    }
                }

                else if (skilBox.SelectedItem != null)
                {

                    var getSkillID = (from x in context.Skills
                                      where x.skillName == skilBox.SelectedItem.ToString()
                                      select x.skillId).First();

                    var getResources = (from x in context.Resources
                                        join y in context.Resource_Allocation on x.resId equals y.resIdFK
                                        where y.skillIdFK == getSkillID
                                        orderby x.remainingQuantity descending
                                        select x).ToList();

                    foreach (var resources in getResources)
                    {
                        List<string> rows = new List<string>()
                        {
                            resources.resName, resources.Resource_Type.resTypeName, resources.Resource_Allocation.Count().ToString()
                        };
                        string skillsAllocated = "";
                        foreach (var skills in resources.Resource_Allocation)
                        {
                            if (skillsAllocated != "")
                            {
                                skillsAllocated += ", " + skills.Skill.skillName;
                            }
                            else if (skillsAllocated == "")
                            {
                                skillsAllocated += skills.Skill.skillName;
                            }
                            else if (skills.Skill == null)
                            {
                                skillsAllocated += "NIL";
                            }
                        }
                        rows.Add(skillsAllocated);
                        var checkQuantity = (from x in context.Resources
                                             where x.resId == resources.resId
                                             select x.remainingQuantity).FirstOrDefault();

                        if (checkQuantity == 0) rows.Add("Not Available");
                        else if (checkQuantity <= 5 && checkQuantity >= 1) rows.Add("Low Stock");
                        else rows.Add("Sufficient");
                        rows.Add(resources.resId.ToString());

                        dataGridView1.Rows.Add(rows.ToArray());
                    }
                }
                else
                {
                    var getResources = (from x in context.Resources
                                        orderby x.remainingQuantity descending
                                        select x).ToList();

                    foreach (var resources in getResources)
                    {
                        List<string> rows = new List<string>()
                        {
                            resources.resName, resources.Resource_Type.resTypeName, resources.Resource_Allocation.Count().ToString()
                        };
                        string skillsAllocated = "";
                        foreach (var skills in resources.Resource_Allocation)
                        {
                            if (skillsAllocated != "")
                            {
                                skillsAllocated += ", " + skills.Skill.skillName;
                            }
                            else if (skillsAllocated == "")
                            {
                                skillsAllocated += skills.Skill.skillName;
                            }
                            else if (skills.Skill == null)
                            {
                                skillsAllocated += "NIL";
                            }
                        }
                        rows.Add(skillsAllocated);
                        var checkQuantity = (from x in context.Resources
                                             where x.resId == resources.resId
                                             select x.remainingQuantity).FirstOrDefault();

                        if (checkQuantity == 0) rows.Add("Not Available");
                        else if (checkQuantity <= 5 && checkQuantity >= 1) rows.Add("Low Stock");
                        else rows.Add("Sufficient");

                        rows.Add(resources.resId.ToString());

                        dataGridView1.Rows.Add(rows.ToArray());
                    }
                }
            }

            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                if (rows.Cells[4].Value.ToString() == "Not Available")
                {
                    rows.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void skilBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a resource to delete!", "No resource selected", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                var getResourceID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);

                using (var context = new Session1QREntities())
                {
                    var getResourceDelete = (from x in context.Resources
                                             where x.resId == getResourceID
                                             select x).First();
                    var getAllocationDelete = (from x in context.Resource_Allocation
                                               where x.resIdFK == getResourceID
                                               select x);

                    context.Resources.Remove(getResourceDelete);

                    foreach (var item in getAllocationDelete)
                    {
                        context.Resource_Allocation.Remove(item);
                    }

                    context.SaveChanges();
                    var getRowToDelete = dataGridView1.CurrentRow.Index;

                    dataGridView1.Rows.RemoveAt(getRowToDelete);
                }
            }
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            (new AddResource()).ShowDialog();
            dataGridView1.Rows.Clear();
            GridRefresh();
        }
    }
}
