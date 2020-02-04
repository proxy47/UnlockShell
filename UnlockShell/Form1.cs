using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace UnlockShell
{
    public partial class MainForm : Form
    {
        #region Variables
        public List<string[]> array_LE;
        public StringBuilder my_sb = new StringBuilder();
        private LoadFromFile lff = new LoadFromFile();
        #endregion

        #region Constructors
        public MainForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        #endregion

        #region Form Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            lff.LoadValues();
            array_LE = lff.GetLoadedValues();

            listView1.FullRowSelect = true;
            listView1.Items.Clear();
            foreach (var le in array_LE)
            {
                listView1.Items.Add(new ListViewItem(le));
            }
        }
        #endregion

        #region Methods
        private void AddElemBtn_Click(object sender, EventArgs e)
        {
            AddRemoveElemForm f2 = new AddRemoveElemForm();
            f2.ShowDialog();

            while (f2.valueSet_b != true)
            {
                System.Threading.Thread.Sleep(1000);
            }
            my_sb = f2.ReturnStringBuilt();

            array_LE.Add(my_sb.ToString().Split(';'));

            listView1.Items.Clear();
            foreach (var le in array_LE)
            {
                listView1.Items.Add(new ListViewItem(le));
            }

            listView1.Sort();
            listView1.Refresh();
            lff.WriteValues(array_LE);
        }

        private void EditElemBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                AddRemoveElemForm f2 = new AddRemoveElemForm(array_LE.ElementAt(index));
                f2.ShowDialog();

                while (f2.valueSet_b != true)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                my_sb = f2.ReturnStringBuilt();

                array_LE.RemoveAt(index);
                array_LE.Add(my_sb.ToString().Split(';'));
                
                listView1.Items.Clear();
                foreach (var le in array_LE)
                {
                    listView1.Items.Add(new ListViewItem(le));
                }

                listView1.Sort();
                listView1.Refresh();
                lff.WriteValues(array_LE);
            }
        }

        private void RemoveElemBtn_Click(object sender, EventArgs e)
        {
            lff.WriteValues(this.array_LE);
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
                lff.WriteValues(array_LE);
            }
        }

        private void LaunchElemBtn_Click(object sender, EventArgs e)
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
        #endregion
    }

    public class LoadFromFile
    {
        #region Variables
        private const char   SeparatorElems      = ';';
        private const char   SeparatorPartNo     = ',';
        private const string database_ini_file_s = @".\database.txt";
        private List<string[]> loadedValues_aLE = new List<string[]>();
        #endregion

        #region Methods
        public void LoadValues()
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
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception caught: " + e.ToString());
            }
        }

        public List<string[]> GetLoadedValues()
        {
            return this.loadedValues_aLE;
        }

        public void WriteValues(List<string[]> listWrite)
        {
            try
            {
                // Delete contents of database
                System.IO.File.WriteAllText(database_ini_file_s, string.Empty);
                System.IO.StreamWriter file = new System.IO.StreamWriter(database_ini_file_s);
                // Write contents of current database
                foreach (string[] string_elem in listWrite)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string elem in string_elem)
                    {
                        sb.Append(elem);
                        sb.Append(";");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    file.WriteLine(sb.ToString());
                    file.Flush();
                }
                file.Close();                
            } catch (Exception e)
            {
                System.Console.WriteLine("Exception caught: " + e.ToString());
            }
        }
        #endregion
    }
}
