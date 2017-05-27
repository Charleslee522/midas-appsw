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

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void ClassGenerate(Point point)
        {
            GroupBox groupbox = new GroupBox();
            groupbox.Text = "Class";
            groupbox.BackColor = Color.LightGreen;
            groupbox.Controls.Add(this.splitContainer2);

            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 17);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.TabIndex = 0;
            
            Label Atribute = new Label();
            Atribute.Text = "Atribute";
            Atribute.Dock = DockStyle.Fill;
            Atribute.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel1.Controls.Add(Atribute);

            Label Method = new Label();
            Method.Text = "Method";
            Method.Dock = DockStyle.Fill;
            Method.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel2.Controls.Add(Method);

            RightPanel.Controls.Add(groupbox);
        }

        void MenuClick(object obj, EventArgs ea)
        {

            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            if (str == "Rename")
            {
                InputBox ib = new InputBox(target.Groups[0].Items[0]);
                ib.Show();
            }
            if (str == "Add Atribute")
            {
                ListViewItem newItem = new ListViewItem(target.Groups[0]);
                InputBox ib = new InputBox(newItem);
                ib.Show();
            }
            if (str == "Add Method")
            {

            }
            if (str == "Delete")
            {
                target.Dispose();
            }
        }
        
        ListView target;
        ListViewItem Item;

        void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                target = (ListView)sender;

                EventHandler handler = new EventHandler(MenuClick);
                MenuItem[] ami = {
                    new MenuItem("Rename", handler),
                    new MenuItem("Add Atribute", handler),
                    new MenuItem("Add Method", handler),
                    new MenuItem("-", handler),
                    new MenuItem("Delete", handler),
                };
                ContextMenu = new ContextMenu(ami);
            }
        }
        
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // 클릭 이벤트로 바꿔 줘야 함
            this.Cursor = Cursors.Hand;
            Item = (ListViewItem)e.Item;
        }

        private void RightPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            
            if (Item != null)
            {
                ClassGenerate(RightPanel.PointToClient(MousePosition));
                Item = null;
            }
        }
        
        private void Lable_MouseDoubleDown(object sender, MouseEventArgs e)
        {
            Label Dest = ((Label)sender);
            TextBox tempBox = new TextBox();

            tempBox.Multiline = true;
            tempBox.Dock = DockStyle.Fill;
            tempBox.Text = Dest.Text;
            tempBox.KeyPress += new KeyPressEventHandler(OutKey);
            tempBox.Leave += new EventHandler(lostFocus);

            Dest.Controls.Add(tempBox);
        }
        private void lostFocus(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Parent.Text = control.Text;
            control.Dispose();
        }

        private void OutKey(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            control.Parent.Text = control.Text;
            if (e.KeyChar == 27)  // esc Key
                control.Dispose();
        }
    }
}
class InputBox : Form
{
    TextBox tb;
    Label lb;
    Button yesButton;
    Button noButton;
    ListViewItem Item;

    public InputBox(ListViewItem Item)
    {
        this.Item = Item;
        this.Width = 170;
        this.Height = 95;
        FormBorderStyle = FormBorderStyle.FixedSingle;

        lb = new Label();
        lb.Location = new Point(0, 5);
        lb.Width = 70;
        lb.TextAlign = ContentAlignment.MiddleCenter;
        lb.Text = "Name Input";

        tb = new TextBox();
        tb.Location = new Point(80,5);
        tb.Width = 70;
        tb.Text = "내용 입력";

        yesButton = new Button();
        yesButton.Location = new Point(0, 30);
        yesButton.Text = "Ok";
        yesButton.Click += new EventHandler(this.button1_Click);

        noButton = new Button();
        noButton.Location = new Point(80, 30);
        noButton.Text = "Cancle";
        noButton.Click += new EventHandler(this.button2_Click);
        
        Controls.Add(lb);
        Controls.Add(tb);
        Controls.Add(yesButton);
        Controls.Add(noButton);
    }
    public void button1_Click(object sender, EventArgs e)
    {
        Item.Text = tb.Text;
        this.Dispose();
    }

    public void button2_Click(object sender, EventArgs e)
    {
        this.Dispose();
    }
}