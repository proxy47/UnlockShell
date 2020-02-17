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
        private const char Separator = ';';
        #region Variables
        // Working List - Loaded written to database
        public List<ListElement> array_LE;
        // View List    - Represented in ListView, filtered or unfiltered
        public List<ListElement> viewArray_LE = new List<ListElement>();
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
            viewArray_LE.Clear();

            foreach (var elem_in_array in array_LE)
                viewArray_LE.Add(elem_in_array);

            listView1.FullRowSelect = true;
            listView1.Items.Clear();
            foreach (var le in viewArray_LE)
                // Add newly created item
                listView1.Items.Add(new ListViewItem(ConvertListElemToStringArray(le)));
        }
        #endregion

        #region Methods
        private string[] ConvertListElemToStringArray(ListElement le)
        {
            StringBuilder ret_sb = new StringBuilder();
            ret_sb.Append(le.model_s + Separator);
            ret_sb.Append(le.manufacturer_s + Separator);
            ret_sb.Append(le.destination_s + Separator);
            
            // Re-compose PartNumber for ListViewEntry
            StringBuilder sb = new StringBuilder();
            foreach (var partNo_s in le.partNumber_s)
                sb.Append(partNo_s + ",");

            sb.Remove(sb.Length - 1, 1);
            ret_sb.Append(sb.ToString() + Separator);

            ret_sb.Append(le.eeprom_s + Separator);
            ret_sb.Append(le.executablePath_s);

            return ret_sb.ToString().Split(Separator);
        }

        private ListElement ConvertStringArrayToListElem(string[] stringArray)
        {
            ListElement le = new ListElement();

            le.model_s          = stringArray[(int)DatabaseIndexes.DB_MODEL_INDEX];
            le.manufacturer_s   = stringArray[(int)DatabaseIndexes.DB_MANUFACTURER_INDEX];
            le.destination_s    = stringArray[(int)DatabaseIndexes.DB_DESTINATION_INDEX];
            le.eeprom_s         = stringArray[(int)DatabaseIndexes.DB_EEPROM_INDEX];
            le.executablePath_s = stringArray[(int)DatabaseIndexes.DB_EXECUTABLE_PATH_INDEX];

            string[] partNoList = stringArray[(int)DatabaseIndexes.DB_PARTNUMBER_INDEX].Split(',');

            foreach (var partNo_s in partNoList)
                le.partNumber_s.Add(partNo_s);

            return le;
        }

        private void AddElemBtn_Click(object sender, EventArgs e)
        {
            AddRemoveElemForm f2 = new AddRemoveElemForm();
            f2.ShowDialog();

            my_sb = f2.ReturnStringBuilt();

            if (!my_sb.ToString().Equals(String.Empty)) {
                array_LE.Add(ConvertStringArrayToListElem(my_sb.ToString().Split(Separator)));
                array_LE.Sort();
                viewArray_LE.Clear();

                foreach (var elem_in_array in array_LE)
                    viewArray_LE.Add(elem_in_array);

                listView1.Items.Clear();
                foreach (var le in viewArray_LE)
                    listView1.Items.Add(new ListViewItem(ConvertListElemToStringArray(le)));

                listView1.Sort();
                listView1.Refresh();
                lff.WriteValues(array_LE);
            }
        }

        private void EditElemBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                AddRemoveElemForm f2 = new AddRemoveElemForm(ConvertListElemToStringArray(array_LE.ElementAt(index)));
                f2.ShowDialog();

                my_sb = f2.ReturnStringBuilt();

                if (!my_sb.ToString().Equals(string.Empty))
                {
                    array_LE.RemoveAt(index);
                    array_LE.Add(ConvertStringArrayToListElem(my_sb.ToString().Split(Separator)));
                    array_LE.Sort();
                    viewArray_LE.Clear();

                    foreach (var elem_in_array in array_LE)
                        viewArray_LE.Add(elem_in_array);

                    listView1.Items.Clear();
                    foreach (var le in viewArray_LE)
                    {
                        listView1.Items.Add(new ListViewItem(ConvertListElemToStringArray(le)));
                    }

                    listView1.Sort();
                    listView1.Refresh();
                    lff.WriteValues(array_LE);
                }
            }
        }

        private void RemoveElemBtn_Click(object sender, EventArgs e)
        {
            lff.WriteValues(this.array_LE);
            if (listView1.SelectedIndices.Count != 0)
            {
                int index = listView1.SelectedIndices[0];
                
                foreach (var elem_MarkedForDeletion in array_LE)
                {
                    if (elem_MarkedForDeletion == viewArray_LE[index])
                    {
                        array_LE.Remove(elem_MarkedForDeletion);
                        break;
                    }
                }

                viewArray_LE.RemoveAt(index);
                viewArray_LE.Sort();

                listView1.Items.Clear();
                foreach (var le in viewArray_LE)
                    listView1.Items.Add(new ListViewItem(ConvertListElemToStringArray(le)));

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
                        myProcess.StartInfo.FileName = viewArray_LE[index].executablePath_s;
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

        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            viewArray_LE.Clear();

            foreach (var elem_in_array in array_LE)
                viewArray_LE.Add(elem_in_array);

            foreach (ListElement listElement in array_LE)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string partNo_s in listElement.partNumber_s)
                    sb.Append(partNo_s + '|');

                if (!listElement.model_s.ToUpper().Contains(this.FilterTextBox.Text.ToUpper()) && !sb.ToString().ToUpper().Contains(this.FilterTextBox.Text.ToUpper()))
                    if (viewArray_LE.Contains(listElement))
                        viewArray_LE.Remove(listElement);

                if (viewArray_LE.Count == 0)
                    break;
            }

            listView1.Items.Clear();
            if (viewArray_LE.Count != 0)
            {
                foreach (var le in viewArray_LE)
                    listView1.Items.Add(new ListViewItem(ConvertListElemToStringArray(le)));
            }
            listView1.Sort();
            listView1.Refresh();
        }
    }

    public class LoadFromFile
    {
        #region Variables
        private const char   SeparatorElems      = ';';
        private const char   SeparatorPartNo     = ',';
        private const string database_ini_file_s = @".\database.txt";
        private List<ListElement> loadedValues_aLE = new List<ListElement>();
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
                string[] database_lines_s = System.IO.File.ReadAllLines(database_ini_file_s);

                foreach (string current_line in database_lines_s)
                {
                    string[] line_elements = current_line.Split(SeparatorElems);
                    string[] partNoList = line_elements[(int)DatabaseIndexes.DB_PARTNUMBER_INDEX].Split(SeparatorPartNo);
                    List<string> PartNumber_ls = new List<string>(partNoList);

                    loadedValues_aLE.Add(new ListElement(line_elements[(int)DatabaseIndexes.DB_MODEL_INDEX],
                                                         line_elements[(int)DatabaseIndexes.DB_MANUFACTURER_INDEX],
                                                         line_elements[(int)DatabaseIndexes.DB_DESTINATION_INDEX],
                                                         line_elements[(int)DatabaseIndexes.DB_EXECUTABLE_PATH_INDEX],
                                                         line_elements[(int)DatabaseIndexes.DB_EEPROM_INDEX],
                                                         PartNumber_ls));
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception caught: " + e.ToString());
            }
        }

        public List<ListElement> GetLoadedValues()
        {
            return this.loadedValues_aLE;
        }

        public void WriteValues(List<ListElement> listWrite)
        {
            try
            {
                // Delete contents of database
                System.IO.File.WriteAllText(database_ini_file_s, string.Empty);
                System.IO.StreamWriter file = new System.IO.StreamWriter(database_ini_file_s);
                
                // Write contents of current database
                foreach (ListElement listElement in listWrite)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append(listElement.model_s + ";");
                    sb.Append(listElement.manufacturer_s + ";");
                    sb.Append(listElement.destination_s + ";");
                    
                    foreach (string partNoEntries in listElement.partNumber_s)
                    {
                        sb.Append(partNoEntries + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(";");

                    sb.Append(listElement.eeprom_s + ";");
                    sb.Append(listElement.executablePath_s);

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

    public class ListElement:IComparable<ListElement>
    {
        #region Variables
        public string       model_s;
        public string       manufacturer_s;
        public string       destination_s;
        public string       executablePath_s;
        public string       eeprom_s;
        public List<string> partNumber_s;
        #endregion

        #region Constructors
        public ListElement()
        {
            this.model_s          = string.Empty;
            this.manufacturer_s   = string.Empty;
            this.destination_s    = string.Empty;
            this.executablePath_s = string.Empty;
            this.eeprom_s         = string.Empty;
            this.partNumber_s     = new List<string>();
        }

        public ListElement(string model_s, string manufacturer_s, string destination_s, string executablePath_s, string eeprom_s, List<string> partNumber_s)
        {
            this.model_s = model_s ?? throw new ArgumentNullException(nameof(model_s));
            this.manufacturer_s = manufacturer_s ?? throw new ArgumentNullException(nameof(manufacturer_s));
            this.destination_s = destination_s ?? throw new ArgumentNullException(nameof(destination_s));
            this.executablePath_s = executablePath_s ?? throw new ArgumentNullException(nameof(executablePath_s));
            this.eeprom_s = eeprom_s ?? throw new ArgumentNullException(nameof(eeprom_s));
            this.partNumber_s = partNumber_s ?? throw new ArgumentNullException(nameof(partNumber_s));
        }
        #endregion

        #region Methods
        public int CompareTo(ListElement le)
        {
            return model_s.CompareTo(le.model_s);
        }
        #endregion
    }

    public enum DatabaseIndexes
    {
        DB_MODEL_INDEX        = 0,
        DB_MANUFACTURER_INDEX    ,
        DB_DESTINATION_INDEX     ,
        DB_PARTNUMBER_INDEX      ,
        DB_EEPROM_INDEX          ,
        DB_EXECUTABLE_PATH_INDEX ,
        DB_INDEX_NB
    }
}
