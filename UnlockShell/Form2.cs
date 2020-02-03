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
    public partial class Form2 : Form
    {
        public string[] stringarray;

        public Form2()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Form2(string[] stringarray)
        {
            this.stringarray = stringarray;
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (stringarray != null)
            {
                textBox1.Text = stringarray[0].ToString();
                textBox2.Text = stringarray[1].ToString();
                textBox3.Text = stringarray[2].ToString();
                textBox4.Text = stringarray[3].ToString();
                textBox5.Text = stringarray[4].ToString();
            }
            else
            {
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox5.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (((textBox1.Text != null) && (textBox1.Text != String.Empty)) &&
                ((textBox5.Text != null) && (textBox5.Text != String.Empty)))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox1.Text.ToString());
                sb.Append(';');
                sb.Append((textBox2.Text.ToString() != String.Empty)?textBox2.Text.ToString():" ");
                sb.Append(';');
                sb.Append((textBox3.Text.ToString() != String.Empty) ? textBox3.Text.ToString() : " ");
                sb.Append(';');
                sb.Append((textBox4.Text.ToString() != String.Empty) ? textBox4.Text.ToString() : " ");
                sb.Append(';');
                sb.Append(textBox5.Text.ToString());
            }
        }
    }
}
