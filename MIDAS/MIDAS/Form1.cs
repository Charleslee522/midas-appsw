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
using Newtonsoft.Json;

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
                Dictionary<string, object> content =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(sr.ReadToEnd());
                int pointX = Convert.ToInt32(content["pointX"]);
                int pointY = Convert.ToInt32(content["pointY"]);
                int height = Convert.ToInt32(content["Height"]);
                int width = Convert.ToInt32(content["Width"]);
                string attribute = Convert.ToString(content["attribute"]);
                string method = Convert.ToString(content["method"]);
                string name = Convert.ToString(content["name"]);
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

            if (saveFileDiaglog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (saveFileDiaglog1.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDiaglog1.OpenFile();

                    switch (saveFileDiaglog1.FilterIndex)
                    {
                        case 1:
                            if (fs.CanWrite)
                            {
                                System.IO.StreamWriter file = new System.IO.StreamWriter(fs);
                                Dictionary<string, object> content = new Dictionary<string, object>();
                                foreach (Control panelControl in RightPanel.Controls)
                                {
                                    GroupBox box = (GroupBox)panelControl;
                                    content.Add("pointX", box.Location.X);
                                    content.Add("pointY", box.Location.Y);
                                    content.Add("Height", box.Size.Height);
                                    content.Add("Width", box.Size.Width);
                                    foreach (Control boxControl in box.Controls)
                                    {
                                        if (boxControl is SplitContainer)
                                        {
                                            SplitContainer sc = (SplitContainer)boxControl;
                                            foreach (Control attControl in sc.Panel1.Controls)
                                            {
                                                Label attLabel = (Label)attControl;
                                                content.Add("attribute", attLabel.Text);
                                            }
                                            foreach (Control methodControl in sc.Panel2.Controls)
                                            {
                                                Label methodLabel = (Label)methodControl;
                                                content.Add("method", methodLabel.Text);
                                            }
                                        }
                                        else if (boxControl is Label)
                                        {
                                            Label nameLabel = (Label)boxControl;
                                            content.Add("name", nameLabel.Text);
                                        }
                                    }
                                }

                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(file, content);
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
        
        private void ClassGenerate(Point point, String Kinds)
        {
            SplitContainer splitContainer2 = new SplitContainer();
            GroupBox groupbox = new GroupBox();
            groupbox.Text = Kinds;
            groupbox.Location = point;
            groupbox.BackColor = Color.White;
            groupbox.Controls.Add(splitContainer2);
            groupbox.MouseDown += new MouseEventHandler(groupbox_MouseDown);
            groupbox.MouseUp += new MouseEventHandler(groupbox_MouseUp);
            groupbox.MouseMove += new MouseEventHandler(groupbox_MouseMove);
            groupbox.Padding = new Padding(5);
            

            Label Name = new Label();
            Name.Text = "Number_";
            Name.Dock = DockStyle.Top;
            groupbox.Controls.Add(Name);

            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 50);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            
            Label Attribute = new Label();
            Attribute.Text = "Attribute";
            Attribute.Dock = DockStyle.Fill;
            Attribute.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel1.Controls.Add(Attribute);

            Label Method = new Label();
            Method.Text = "Method";
            Method.Dock = DockStyle.Fill;
            Method.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel2.Controls.Add(Method);

            RightPanel.Controls.Add(groupbox);
        }

        //void MenuClick(object obj, EventArgs ea)
        //{

        //    MenuItem mI = (MenuItem)obj;
        //    String str = mI.Text;

        //    if (str == "Rename")
        //    {
        //        InputBox ib = new InputBox(target.Groups[0].Items[0]);
        //        ib.Show();
        //    }
        //    if (str == "Add Attribute")
        //    {
        //        ListViewItem newItem = new ListViewItem(target.Groups[0]);
        //        InputBox ib = new InputBox(newItem);
        //        ib.Show();
        //    }
        //    if (str == "Add Method")
        //    {

        //    }
        //    if (str == "Delete")
        //    {
        //        target.Dispose();
        //    }
        //}
        //void RightClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        target = (ListView)sender;

        //        EventHandler handler = new EventHandler(MenuClick);
        //        MenuItem[] ami = {
        //            new MenuItem("Rename", handler),
        //            new MenuItem("Add Attribute", handler),
        //            new MenuItem("Add Method", handler),
        //            new MenuItem("-", handler),
        //            new MenuItem("Delete", handler),
        //        };
        //        ContextMenu = new ContextMenu(ami);
        //    }
        //}
        
        ListViewItem Item;

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
                ClassGenerate(RightPanel.PointToClient(MousePosition), Item.Text);
                Item = null;
            }
        }



        // 이하 GroupBox Move Resize
        bool isResize = false;
        bool isMove = false;
        Point prevPos;

        private void groupbox_MouseDown(object sender, MouseEventArgs e)
        {
            Control temp = (Control)sender;

            if (temp.Height - 5 <= e.Y && temp.Width - 5 <= e.X)
            {
                Cursor = Cursors.SizeNWSE;
                isResize = true;
            }
            else
            {
                prevPos = e.Location;
                Cursor = Cursors.NoMove2D;
                isMove = true;
            }
        }

        private void groupbox_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            isResize = false;
            isMove = false;
        }

        private void groupbox_MouseMove(object sender, MouseEventArgs e)
        {
            Control temp = (Control)sender;

            if (isResize)
            {
                temp.Height = temp.Top + e.Y - temp.Location.Y;
                temp.Width = temp.Left + e.X - temp.Location.X;
            }
            if (isMove)
            {
                temp.Left = e.X + temp.Left - prevPos.X;
                temp.Top = e.Y + temp.Top - prevPos.Y;
            }
        }


        // 이하 Lable TextBox
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
            tempBox.Select();
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