using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace UnlockShell
{
    public partial class Form1 : Form
    {
        public List<string[]> array_LE;
        public StringBuilder my_sb = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFromFile lff = new LoadFromFile();
            array_LE = lff.loadValues();

            listView1.FullRowSelect = true;
            listView1.Items.Clear();
            foreach (var le in array_LE)
            {
                listView1.Items.Add(new ListViewItem(le));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            while (f2.valueSet_b != true)
            {
                System.Threading.Thread.Sleep(1000);
            }
            my_sb = f2.returnStringBuilt();

            array_LE.Add(my_sb.ToString().Split(';'));

            listView1.Items.Clear();
            foreach (var le in array_LE)
            {
                listView1.Items.Add(new ListViewItem(le));
            }

            listView1.Sort();
            listView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                Form2 f2 = new Form2(array_LE.ElementAt(index));
                f2.ShowDialog();

                while (f2.valueSet_b != true)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                my_sb = f2.returnStringBuilt();

                array_LE.RemoveAt(index);
                array_LE.Add(my_sb.ToString().Split(';'));
                
                listView1.Items.Clear();
                foreach (var le in array_LE)
                {
                    listView1.Items.Add(new ListViewItem(le));
                }

                listView1.Sort();
                listView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                
                array_LE.RemoveAt(index);
                
                listView1.Items.Clear();
                foreach (var le in array_LE)
                {
                    listView1.Items.Add(new ListViewItem(le));
                }

                listView1.Sort();
                listView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                
                try
                {
                    using (Process myProcess = new Process())
                    {
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.FileName = array_LE[index][4];
                        myProcess.StartInfo.CreateNoWindow = false;
                        myProcess.Start();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }

    public enum My_enum{
        MODEL_NAME        = 0,
        MANUFACTURER_NAME    ,
        DESTINATION_NAME     ,
        EXECUTABLE_PATH      ,
        PART_NO_LIST         ,
        INI_FILE_MAX_NB
    };

    public class LoadFromFile
    {
        private const char   SeparatorElems      = ';';
        private const char   SeparatorPartNo     = ',';
        private const string database_ini_file_s = @".\database.txt";
        private List<string[]> loadedValues_aLE = new List<string[]>();

        public LoadFromFile()
        {
            try
            {
                if (!System.IO.File.Exists(database_ini_file_s))
                {
                    System.IO.File.Create(database_ini_file_s);
                }
                string[] lines = System.IO.File.ReadAllLines(database_ini_file_s);

                foreach (string line in lines)
                {
                    loadedValues_aLE.Add(line.Split(SeparatorElems));
                }
            } catch(Exception e)
            {
                System.Console.WriteLine("Exception caught: " + e.ToString());
            }
        }

        public List<string[]> loadValues()
        {
            return this.loadedValues_aLE;
        }
    }
}
