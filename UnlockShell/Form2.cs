using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnlockShell
{
    public partial class AddRemoveElemForm : Form
    {
        #region Variables
        private StringBuilder sb = new StringBuilder();
        public string[] stringarray;
        #endregion

        #region Constructors
        public AddRemoveElemForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public AddRemoveElemForm(string[] stringarray)
        {
            this.stringarray = stringarray;
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        #endregion

        #region Form Events
        private void AddRemoveElemForm_Load(object sender, EventArgs e)
        {
            if (stringarray != null)
            {
                textBox1.Text = stringarray[0].ToString();
                textBox2.Text = stringarray[1].ToString();
                textBox3.Text = stringarray[2].ToString();
                textBox4.Text = stringarray[3].ToString();
                textBox5.Text = stringarray[4].ToString();
                textBox6.Text = stringarray[5].ToString();
            }
            else
            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
                textBox6.Text = String.Empty;
            }
        }

        private void AddRemoveElemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sb.Equals(String.Empty))
            {
                sb.Append(" ; ; ; ; ; ");
            }
        }
        #endregion

        #region Methods
        public StringBuilder ReturnStringBuilt()
        {
            return sb;
        }

        private void BrowseExeLocBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox6.Text = openFileDialog1.FileName;
            }
        }

        private void SaveEntryBtn_Click(object sender, EventArgs e)
        {
            if (((textBox1.Text != null) && (textBox1.Text != String.Empty)) &&
                ((textBox6.Text != null) && (textBox6.Text != String.Empty)))
            {
                sb.Append(textBox1.Text.ToString() + ';');
                sb.Append(((textBox2.Text.ToString() != String.Empty) ? textBox2.Text.ToString() : " ") + ';');
                sb.Append(((textBox3.Text.ToString() != String.Empty) ? textBox3.Text.ToString() : " ") + ';');
                sb.Append(((textBox4.Text.ToString() != String.Empty) ? textBox4.Text.ToString() : " ") + ';');
                sb.Append(((textBox5.Text.ToString() != String.Empty) ? textBox5.Text.ToString() : " ") + ';');
                sb.Append(textBox6.Text.ToString());
            }

            this.Close();
        }
        #endregion
    }
}
