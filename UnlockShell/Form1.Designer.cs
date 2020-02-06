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
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveElemBtn = new System.Windows.Forms.Button();
            this.LaunchElemBtn = new System.Windows.Forms.Button();
            this.AddElemBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FilterTextBoxLabel = new System.Windows.Forms.Label();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditElemBtn
            // 
            this.EditElemBtn.Location = new System.Drawing.Point(6, 54);
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
            this.listView1.Location = new System.Drawing.Point(6, 19);
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
            // columnHeader5
            // 
            this.columnHeader5.Text = "EEPROM";
            this.columnHeader5.Width = 100;
            // 
            // RemoveElemBtn
            // 
            this.RemoveElemBtn.Location = new System.Drawing.Point(6, 89);
            this.RemoveElemBtn.Name = "RemoveElemBtn";
            this.RemoveElemBtn.Size = new System.Drawing.Size(119, 29);
            this.RemoveElemBtn.TabIndex = 3;
            this.RemoveElemBtn.Text = "Remove";
            this.RemoveElemBtn.UseVisualStyleBackColor = true;
            this.RemoveElemBtn.Click += new System.EventHandler(this.RemoveElemBtn_Click);
            // 
            // LaunchElemBtn
            // 
            this.LaunchElemBtn.Location = new System.Drawing.Point(6, 377);
            this.LaunchElemBtn.Name = "LaunchElemBtn";
            this.LaunchElemBtn.Size = new System.Drawing.Size(119, 29);
            this.LaunchElemBtn.TabIndex = 5;
            this.LaunchElemBtn.Text = "Launch";
            this.LaunchElemBtn.UseVisualStyleBackColor = true;
            this.LaunchElemBtn.Click += new System.EventHandler(this.LaunchElemBtn_Click);
            // 
            // AddElemBtn
            // 
            this.AddElemBtn.Location = new System.Drawing.Point(6, 19);
            this.AddElemBtn.Name = "AddElemBtn";
            this.AddElemBtn.Size = new System.Drawing.Size(119, 29);
            this.AddElemBtn.TabIndex = 4;
            this.AddElemBtn.Text = "Add";
            this.AddElemBtn.UseVisualStyleBackColor = true;
            this.AddElemBtn.Click += new System.EventHandler(this.AddElemBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FilterTextBox);
            this.groupBox1.Controls.Add(this.FilterTextBoxLabel);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 412);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // FilterTextBoxLabel
            // 
            this.FilterTextBoxLabel.AutoSize = true;
            this.FilterTextBoxLabel.Location = new System.Drawing.Point(3, 368);
            this.FilterTextBoxLabel.Name = "FilterTextBoxLabel";
            this.FilterTextBoxLabel.Size = new System.Drawing.Size(126, 13);
            this.FilterTextBoxLabel.TabIndex = 0;
            this.FilterTextBoxLabel.Text = "Filter by Model or PartNo:";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Location = new System.Drawing.Point(6, 384);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(251, 20);
            this.FilterTextBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LaunchElemBtn);
            this.groupBox2.Controls.Add(this.RemoveElemBtn);
            this.groupBox2.Controls.Add(this.EditElemBtn);
            this.groupBox2.Controls.Add(this.AddElemBtn);
            this.groupBox2.Location = new System.Drawing.Point(667, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 412);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Unlock Shell";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Button AddElemBtn;
        private System.Windows.Forms.Button LaunchElemBtn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox FilterTextBox;
        private System.Windows.Forms.Label FilterTextBoxLabel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

