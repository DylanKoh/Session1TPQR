﻿namespace Session1
{
    partial class AddResource
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.resourceNameBox = new System.Windows.Forms.TextBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.allocationBox = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resource Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resource Type: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Available Quantity: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Allocated Skill(s): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Add New Resource";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(3, 7);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(143, 73);
            this.backBtn.TabIndex = 5;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // resourceNameBox
            // 
            this.resourceNameBox.Location = new System.Drawing.Point(398, 130);
            this.resourceNameBox.Name = "resourceNameBox";
            this.resourceNameBox.Size = new System.Drawing.Size(524, 27);
            this.resourceNameBox.TabIndex = 6;
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(398, 189);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(369, 26);
            this.typeBox.TabIndex = 7;
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(398, 245);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(524, 27);
            this.quantityBox.TabIndex = 8;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(494, 516);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(179, 62);
            this.addBtn.TabIndex = 17;
            this.addBtn.Text = "Add Resource";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // allocationBox
            // 
            this.allocationBox.CheckOnClick = true;
            this.allocationBox.FormattingEnabled = true;
            this.allocationBox.Location = new System.Drawing.Point(398, 300);
            this.allocationBox.Name = "allocationBox";
            this.allocationBox.Size = new System.Drawing.Size(524, 158);
            this.allocationBox.TabIndex = 18;
            this.allocationBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.allocationBox_ItemCheck);
            this.allocationBox.SelectedIndexChanged += new System.EventHandler(this.allocationBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 85);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(895, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "ASEAN Skills 2020";
            // 
            // AddResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.allocationBox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.resourceNameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AddResource";
            this.Text = "ASEAN Skills 2020";
            this.Load += new System.EventHandler(this.AddResource_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.TextBox resourceNameBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.CheckedListBox allocationBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}