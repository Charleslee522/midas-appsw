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
            // 기존 open된 파일 경로가 default로 저장되어있어야 함.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Model Class UML|*.mcu";
            openFileDialog1.Title = "Select a mcu file";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaglog1 = new SaveFileDialog();
            saveFileDiaglog1.Filter = "Model Class UML|*.mcu";
            saveFileDiaglog1.Title = "Save a mcu file";

            if(saveFileDiaglog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                if (saveFileDiaglog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDiaglog1.OpenFile();

                    switch (saveFileDiaglog1.FilterIndex)
                    {
                        case 1:
                            if (fs.CanWrite)
                            {
                                System.IO.StreamWriter file = new System.IO.StreamWriter(fs);
                                file.WriteLine("Hello World!");
                                file.Close();
                            }
                            break;
                        default:
                            break;

                    }
                }
            }

        }

        private void importMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
