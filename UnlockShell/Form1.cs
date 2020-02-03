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
    public partial class Form1 : Form
    {
        public List<ListEntry> array_LE;
        public String database_name_s = @".\database.ini";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFromFile lff = new LoadFromFile();
            array_LE = lff.loadValues();

        }
    }

    public class ListEntry
    {
        public  String model_s;
        public  String manufacturer_s;
        public  String destination_s;
        private String exePath_s;
        public  String partNo_ls;

        public ListEntry()
        {
            this.model_s = String.Empty;
            this.manufacturer_s = String.Empty;
            this.destination_s = String.Empty;
            this.exePath_s = String.Empty;
            this.partNo_ls = null;
        }

        public ListEntry(String model_s, String manufacturer_s, String destination_s, String exePath_s, String partNo_ls)
        {
            this.model_s = model_s;
            this.manufacturer_s = manufacturer_s;
            this.destination_s = destination_s;
            this.exePath_s = exePath_s;
            this.partNo_ls = partNo_ls;
        }

        public String getExePath()
        {
            return this.exePath_s;
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
        private const char SeparatorElems  = ';';
        private const char SeparatorPartNo = ','; 
        private List<ListEntry> loadedValues_aLE = new List<ListEntry>();

        public LoadFromFile()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@".\database.ini");

                foreach (string line in lines)
                {
                    string[] elems_of_line = line.Split(SeparatorElems);
                    if (elems_of_line != null)
                    {
                        this.loadedValues_aLE.Add(new ListEntry(elems_of_line[(int)My_enum.MODEL_NAME],
                                                                elems_of_line[(int)My_enum.MANUFACTURER_NAME],
                                                                elems_of_line[(int)My_enum.DESTINATION_NAME],
                                                                elems_of_line[(int)My_enum.EXECUTABLE_PATH],
                                                                elems_of_line[(int)My_enum.PART_NO_LIST])
                                                 );
                    }

                    // debug message
                    System.Console.WriteLine(line);                    
                }
            } catch(Exception e)
            {
                System.Console.WriteLine("Exception caught: " + e.ToString());
            }
        }

        public List<ListEntry> loadValues()
        {
            return this.loadedValues_aLE;
        }
    }
}
