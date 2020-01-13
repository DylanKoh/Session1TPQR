namespace Session1
{
    partial class Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResourceName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQuantityBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.clbAllocation = new System.Windows.Forms.CheckedListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 83);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(693, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 24);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(88, 43);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 16F);
            this.label2.Location = new System.Drawing.Point(317, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Update Resources";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resource Name: ";
            // 
            // lblResourceName
            // 
            this.lblResourceName.AutoSize = true;
            this.lblResourceName.Location = new System.Drawing.Point(349, 140);
            this.lblResourceName.Name = "lblResourceName";
            this.lblResourceName.Size = new System.Drawing.Size(58, 18);
            this.lblResourceName.TabIndex = 3;
            this.lblResourceName.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Resource Type: ";
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.Location = new System.Drawing.Point(349, 176);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(58, 18);
            this.lblResourceType.TabIndex = 5;
            this.lblResourceType.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Available Quantity: ";
            // 
            // txtQuantityBox
            // 
            this.txtQuantityBox.Location = new System.Drawing.Point(349, 213);
            this.txtQuantityBox.Name = "txtQuantityBox";
            this.txtQuantityBox.Size = new System.Drawing.Size(100, 27);
            this.txtQuantityBox.TabIndex = 7;
            this.txtQuantityBox.TextChanged += new System.EventHandler(this.txtQuantityBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "Allocated Skill(s): ";
            // 
            // clbAllocation
            // 
            this.clbAllocation.FormattingEnabled = true;
            this.clbAllocation.Location = new System.Drawing.Point(349, 257);
            this.clbAllocation.Name = "clbAllocation";
            this.clbAllocation.Size = new System.Drawing.Size(255, 158);
            this.clbAllocation.TabIndex = 9;
            this.clbAllocation.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbAllocation_ItemCheck);
            this.clbAllocation.SelectedIndexChanged += new System.EventHandler(this.clbAllocation_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(322, 482);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(189, 45);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update Resource";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 595);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.clbAllocation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuantityBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblResourceType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResourceName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Update";
            this.Text = "Update Resource";
            this.Load += new System.EventHandler(this.Update_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResourceName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResourceType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQuantityBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clbAllocation;
        private System.Windows.Forms.Button btnUpdate;
    }
}