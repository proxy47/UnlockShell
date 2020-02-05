namespace UnlockShell
{
    partial class MainForm
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
            this.EditElemBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveElemBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LaunchElemBtn = new System.Windows.Forms.Button();
            this.AddElemBtn = new System.Windows.Forms.Button();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditElemBtn
            // 
            this.EditElemBtn.Location = new System.Drawing.Point(127, 352);
            this.EditElemBtn.Name = "EditElemBtn";
            this.EditElemBtn.Size = new System.Drawing.Size(119, 29);
            this.EditElemBtn.TabIndex = 1;
            this.EditElemBtn.Text = "Edit";
            this.EditElemBtn.UseVisualStyleBackColor = true;
            this.EditElemBtn.Click += new System.EventHandler(this.EditElemBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(636, 343);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Model";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Manufacturer";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Destination";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Part No.";
            this.columnHeader4.Width = 231;
            // 
            // RemoveElemBtn
            // 
            this.RemoveElemBtn.Location = new System.Drawing.Point(252, 352);
            this.RemoveElemBtn.Name = "RemoveElemBtn";
            this.RemoveElemBtn.Size = new System.Drawing.Size(119, 29);
            this.RemoveElemBtn.TabIndex = 3;
            this.RemoveElemBtn.Text = "Remove";
            this.RemoveElemBtn.UseVisualStyleBackColor = true;
            this.RemoveElemBtn.Click += new System.EventHandler(this.RemoveElemBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LaunchElemBtn);
            this.panel1.Controls.Add(this.AddElemBtn);
            this.panel1.Controls.Add(this.RemoveElemBtn);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.EditElemBtn);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 386);
            this.panel1.TabIndex = 4;
            // 
            // LaunchElemBtn
            // 
            this.LaunchElemBtn.Location = new System.Drawing.Point(519, 352);
            this.LaunchElemBtn.Name = "LaunchElemBtn";
            this.LaunchElemBtn.Size = new System.Drawing.Size(119, 29);
            this.LaunchElemBtn.TabIndex = 5;
            this.LaunchElemBtn.Text = "Launch";
            this.LaunchElemBtn.UseVisualStyleBackColor = true;
            this.LaunchElemBtn.Click += new System.EventHandler(this.LaunchElemBtn_Click);
            // 
            // AddElemBtn
            // 
            this.AddElemBtn.Location = new System.Drawing.Point(3, 352);
            this.AddElemBtn.Name = "AddElemBtn";
            this.AddElemBtn.Size = new System.Drawing.Size(119, 29);
            this.AddElemBtn.TabIndex = 4;
            this.AddElemBtn.Text = "Add";
            this.AddElemBtn.UseVisualStyleBackColor = true;
            this.AddElemBtn.Click += new System.EventHandler(this.AddElemBtn_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "EEPROM";
            this.columnHeader5.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 407);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Unlock Shell";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EditElemBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button RemoveElemBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddElemBtn;
        private System.Windows.Forms.Button LaunchElemBtn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

