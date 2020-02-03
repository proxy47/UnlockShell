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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
        }
    }
}
