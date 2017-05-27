using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;  // Console

namespace MIDAS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();  // Console
        }

        [DllImport("kernel32.dll", SetLastError = true)]  // Console
        [return: MarshalAs(UnmanagedType.Bool)]  // Console
        static extern bool AllocConsole();  // Console

        private void newMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaglog1 = new SaveFileDialog();
            saveFileDiaglog1.Filter = "Model Class UML|*.mcu";
            saveFileDiaglog1.Title = "Save an mcu file";
            saveFileDiaglog1.ShowDialog();

            if(saveFileDiaglog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDiaglog1.OpenFile();

                switch(saveFileDiaglog1.FilterIndex)
                {
                    case 1:
                        if(fs.CanWrite)
                        {
                            System.IO.StreamWriter file = new System.IO.StreamWriter(fs);
                            file.WriteLine("Hello World!");
                            file.Close();
                        }
                        break;

                }
            }
        }

        private void importMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportItem_Click(object sender, EventArgs e)
        {

        }
    }
}
