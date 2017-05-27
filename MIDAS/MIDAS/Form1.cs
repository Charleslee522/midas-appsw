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
            SaveFileDialog exportImageDialog = new SaveFileDialog();
            exportImageDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            exportImageDialog.Title = "Save an Image File";

            if (exportImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                if (String.IsNullOrWhiteSpace(exportImageDialog.FileName))
                {
                    MessageBox.Show("파일 이름이 비어있습니다.");
                }
                else
                {
                    System.IO.FileStream fs = (System.IO.FileStream)exportImageDialog.OpenFile();
                    using (Bitmap bitmap = new Bitmap(RightPanel.ClientSize.Width, RightPanel.ClientSize.Height))
                    {
                        RightPanel.DrawToBitmap(bitmap, RightPanel.ClientRectangle);
                        switch (exportImageDialog.FilterIndex)
                        {
                            case 1:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;

                            case 2:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;

                            case 3:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                                break;

                            case 4:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                    }
                    fs.Close();
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("클릭!!");
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ClassGenerate(Point point)
        {
            ListView Class = new ListView();
            ListViewGroup GroupName = new ListViewGroup("NameGroup", "Name");
            Class.Groups.Add(GroupName);
            ListViewGroup GroupAtribute = new ListViewGroup("AtributeGroup", "Atribute");
            Class.Groups.Add(GroupAtribute);
            ListViewGroup GroupMethod = new ListViewGroup("MethodGroup", "Method");
            Class.Groups.Add(GroupMethod);

            Class.Groups.AddRange(new ListViewGroup[] { GroupName, GroupAtribute, GroupMethod });
            ListViewItem ItemName = new ListViewItem(GroupName);
            ListViewItem ItemAtribute = new ListViewItem(GroupAtribute);
            ListViewItem ItemMethod = new ListViewItem(GroupMethod);

            Class.Items.AddRange(new ListViewItem[] { ItemName, ItemAtribute, ItemMethod });
            Class.Location = new Point(67, 74);
            Class.Name = "listView2";
            Class.Size = new Size(154, 131);
            Class.TabIndex = 1;
            Class.UseCompatibleStateImageBehavior = false;
            Class.View = View.SmallIcon;
            Class.Location = point;

            RightPanel.Controls.Add(Class);
        }

        Object Item;

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            Item = e.Item;
            Console.WriteLine("Mouse Down " + Item);
        }

        private void RightPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;

            if (Item != null)
            {
                ClassGenerate(RightPanel.PointToClient(MousePosition));
                Item = null;
                Console.WriteLine("Object Create" + Item);
            }
        }
    }
}