﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
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

        private SaveFile sf = new SaveFile();

        private void Changed()
        {
            this.sf.isChanged = true;
            this.Text = "Midas UML -- * " + this.sf.targetFileName;
        }
        private void saveFile(string filePath, string fileName)
        {
            this.sf.targetFileName = fileName;
            this.sf.targetFilePath = filePath;
            this.Text = "MIDAS UML -- " + fileName;
        }

        private void SaveMessagebox(object sender, EventArgs e)
        {
            const string message = "Do you want to save the changes you made?";
            const string caption = "Save Changes";
            DialogResult result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                RightPanel.Controls.Clear();
                this.sf.targetFileName = "";
                this.sf.targetFilePath = "";
            }
            else if (result == DialogResult.Yes)
            {
                saveMenuItem_Click(sender, e);
            }
            else // DialogResult.Cancel
            {
                // do nothing
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            if (this.sf.isChanged)
            {
                SaveMessagebox(sender, e);
            }
            else
            {
                RightPanel.Controls.Clear();
                this.sf.targetFileName = "";
                this.sf.targetFilePath = "";
            }

        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            // 기존 open된 파일 경로가 default로 저장되어있어야 함.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Model Class UML|*.mcu";
            openFileDialog1.Title = "Select a mcu file";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RightPanel.Controls.Clear();
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                List<Dictionary<string, object>> contentList =
                JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(sr.ReadToEnd());

                foreach (Dictionary<string, object> content in contentList) {
                    string kind = Convert.ToString(content["kind"]);
                    string name = Convert.ToString(content["name"]);
                    string attribute = Convert.ToString(content["attribute"]);
                    string method = Convert.ToString(content["method"]);

                    int pointX = Convert.ToInt32(content["pointX"]);
                    int pointY = Convert.ToInt32(content["pointY"]);
                    Point point = new Point(pointX, pointY);

                    int width = Convert.ToInt32(content["Width"]);
                    int height = Convert.ToInt32(content["Height"]);
                    Size size = new Size(width, height);

                    ClassGenerate(kind, name, attribute, method, point, size);
                }
                sr.Close();
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if(this.sf.isChanged)
            {
                if (String.IsNullOrWhiteSpace(this.sf.targetFileName))
                {
                    saveAsMenuItem_Click(sender, e);
                }
                else
                {
                    using (FileStream fs = new FileStream(this.sf.targetFilePath, FileMode.Create))
                    {
                        saveTo(fs);
                        fs.Close();
                    }

                    saveFile(this.sf.targetFilePath, this.sf.targetFileName);
                }
            }
            else
            {
                // do nothing
            }
        }

        private void saveTo(System.IO.FileStream fs)
        {
            if (fs.CanWrite)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(fs);
                List<Dictionary<string, object>> contentList = new List<Dictionary<string, object>>();
                foreach (Control panelControl in RightPanel.Controls)
                {
                    Dictionary<string, object> content = new Dictionary<string, object>();
                    GroupBox box = (GroupBox)panelControl;
                    content.Add("kind", box.Text);
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
                    contentList.Add(content);
                }

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, contentList);
                file.Close();
                contentList.Clear();
            }
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaglog1 = new SaveFileDialog();
            saveFileDiaglog1.Filter = "Model Class UML|*.mcu";
            saveFileDiaglog1.Title = "Save a mcu file";

            if (saveFileDiaglog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (! String.IsNullOrWhiteSpace(saveFileDiaglog1.FileName))
                {
                    using (System.IO.FileStream fs = (System.IO.FileStream)saveFileDiaglog1.OpenFile())
                    {
                        switch (saveFileDiaglog1.FilterIndex)
                        {
                            case 1:
                                if (fs.CanWrite)
                                {
                                    saveTo(fs);
                                }
                                break;
                            default:
                                break;

                        }
                        fs.Close();
                    }
                }

                saveFile(saveFileDiaglog1.FileName, Path.GetFileName(saveFileDiaglog1.FileName));
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

        private void ClassGenerate(string Kinds, string name, string attribute, string method, Point point, Size size)
        {
            SplitContainer splitContainer2 = new SplitContainer();
            GroupBox groupbox = new GroupBox();
            groupbox.Text = Kinds;
            groupbox.Location = point;
            groupbox.Size = size;
            groupbox.BackColor = Color.White;
            groupbox.Controls.Add(splitContainer2);
            groupbox.MouseDown += new MouseEventHandler(groupbox_MouseDown);
            groupbox.MouseUp += new MouseEventHandler(groupbox_MouseUp);
            groupbox.MouseMove += new MouseEventHandler(groupbox_MouseMove);
            groupbox.Padding = new Padding(5);


            Label Name = new Label();
            Name.Text = name;
            Name.Dock = DockStyle.Top;
            groupbox.Controls.Add(Name);

            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 50);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;

            Label Attribute = new Label();
            Attribute.Text = attribute;
            Attribute.Dock = DockStyle.Fill;
            Attribute.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel1.Controls.Add(Attribute);

            Label Method = new Label();
            Method.Text = method;
            Method.Dock = DockStyle.Fill;
            Method.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
            splitContainer2.Panel2.Controls.Add(Method);

            RightPanel.Controls.Add(groupbox);
        }
        
        private void ClassGenerate(Point point, String Kinds)
        {
            SplitContainer splitContainer2 = new SplitContainer();
            GroupBox groupbox = new GroupBox();
            groupbox.Text = Kinds;
            groupbox.Location = point;
            groupbox.BackColor = Color.White;
            groupbox.Padding = new Padding(5);
            groupbox.Controls.Add(splitContainer2);
            groupbox.MouseDown += new MouseEventHandler(groupbox_MouseDown);
            groupbox.MouseUp += new MouseEventHandler(groupbox_MouseUp);
            groupbox.MouseMove += new MouseEventHandler(groupbox_MouseMove);

            Label Name = new Label();
            Name.Text = "Number_";
            Name.Dock = DockStyle.Top;
            Name.MouseDoubleClick += new MouseEventHandler(Lable_MouseDoubleDown);
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
        
        ListViewItem Item;

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // 클릭 이벤트로 바꿔 줘야 함
            this.Cursor = Cursors.Hand;
            Item = (ListViewItem)e.Item;
            if (Item.Text == "Line")
            {
                isLine = true;
                Item = null;
                //Console.WriteLine(Item.Text);
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //// 클릭 이벤트로 바꿔 줘야 함
            //this.Cursor = Cursors.Hand;
            //Item = (ListViewItem)e.Item;
            //if (Item.Text == "Line")
            //{
            //    isLine = true;
            //    Item = null;
            //    //Console.WriteLine(Item.Text);
            //}
        }

        private void RightPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            isLine = false;

            if (Item != null)
            {
                ClassGenerate(RightPanel.PointToClient(MousePosition), Item.Text);
                Changed();
                Item = null;
            }
        }
        
        // 이하 GroupBox Move Resize
        bool isResize = false;
        bool isMove = false;
        bool isLine = false;

        List<Control> fromControl = new List<Control>();
        List<Control> toControl = new List<Control>();

        Point prevPos;
        Control prevControl;

        private void colorChange(Control sender)
        {
            if (prevControl == null)
            {
                sender.BackColor = Color.Gray;
                prevControl = sender;
                return;
            }
            else
            {
                prevControl.BackColor = Color.White;
                sender.BackColor = Color.Gray;
                prevControl = sender;
            }
        }
        
        private void groupbox_MouseDown(object sender, MouseEventArgs e)
        {
            Control temp = (Control)sender;
            colorChange(temp);

            if (isLine)
            {
                if (toControl.Count == fromControl.Count)
                {
                    fromControl.Add(temp);
                }
                else if (toControl.Count < fromControl.Count)
                {
                    toControl.Add(temp);
                    isLine = false;
                }
            }
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
            Control temp = (Control)sender;
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
<<<<<<< HEAD
            BasicDrawLine();
=======
            if(isResize || isMove)
            {
                Changed();
            }
            DrawLine();
>>>>>>> 60d5f7acc6e291632fbba5780b74a10b58b3049d
        }
        
        // 이하 Lable TextBox
        private void Lable_MouseDoubleDown(object sender, MouseEventArgs e)
        {
            Label Dest = ((Label)sender);
            TextBox tempBox = new TextBox();

            tempBox.Multiline = true;
            tempBox.Dock = DockStyle.Fill;
            tempBox.Text = Dest.Text;
            tempBox.Leave += new EventHandler(tempBox_lostFocus);
            tempBox.KeyPress += new KeyPressEventHandler(tempBox_OutKey);

            Dest.Controls.Add(tempBox);
            Changed();
            tempBox.Select();
        }

        private void tempBox_lostFocus(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Parent.Text = control.Text;
            control.Dispose();
        }

        private void tempBox_OutKey(object sender, KeyPressEventArgs e)
        {
            Control control = (Control)sender;
            control.Parent.Text = control.Text;
            if (e.KeyChar == 27)  // esc Key
                control.Dispose();
        }

<<<<<<< HEAD
        private void BasicDrawLine()
        {
            Graphics graphic = RightPanel.CreateGraphics();
            graphic.Clear(RightPanel.BackColor);
            Pen pen = new Pen(Color.Black);
            Point p1, p2;
            for (int i = 0; i < fromControl.Count && i < toControl.Count; i++)
            {
                p1 = new Point(fromControl[i].Left + fromControl[i].Width / 2, fromControl[i].Top + fromControl[i].Height / 2);
                p2 = new Point(toControl[i].Left + toControl[i].Width / 2, toControl[i].Top + toControl[i].Height / 2);

                if (fromControl[i] == toControl[i])
                {
                    graphic.DrawLine(pen, p1, new Point(p1.X + fromControl[i].Width, p2.Y));

                    graphic.DrawLine(pen, new Point(p1.X + fromControl[i].Width, p2.Y),
                        new Point(p1.X + fromControl[i].Width, p2.Y - fromControl[i].Height));

                    graphic.DrawLine(pen, new Point(p1.X + fromControl[i].Width, p2.Y - fromControl[i].Height),
                        new Point(p1.X, p2.Y - fromControl[i].Height));

                    graphic.DrawLine(pen, new Point(p1.X, p2.Y - fromControl[i].Height),
                        new Point(p1.X, fromControl[i].Top));
                }
                else
                    graphic.DrawLine(pen, p1, p2);
            }
        }

        private void DependencyDrawLine()
=======
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.sf.isChanged)
            {
                if (String.IsNullOrWhiteSpace(this.sf.targetFileName))
                {
                    saveAsMenuItem_Click(sender, e);
                }
                else
                {
                    using (FileStream fs = new FileStream(this.sf.targetFilePath, FileMode.Create))
                    {
                        saveTo(fs);
                        fs.Close();
                    }

                    saveFile(this.sf.targetFilePath, this.sf.targetFileName);
                }
            }
            else
            {
                // do nothing
            }
        }

        private void DrawLine()
>>>>>>> 60d5f7acc6e291632fbba5780b74a10b58b3049d
        {
            Graphics graphic = RightPanel.CreateGraphics();
            graphic.Clear(RightPanel.BackColor);
            Pen pen = new Pen(Color.Black);
            Point p1, p2;
            for (int i = 0; i < fromControl.Count && i < toControl.Count; i++)
            {
                p1 = new Point(fromControl[i].Left + fromControl[i].Width / 2, fromControl[i].Top + fromControl[i].Height / 2);
                p2 = new Point(toControl[i].Left + toControl[i].Width / 2, toControl[i].Top + toControl[i].Height / 2);
                
                if (fromControl[i] == toControl[i])
                {
                    graphic.DrawLine(pen, p1, new Point(p1.X + fromControl[i].Width, p2.Y));

                    graphic.DrawLine(pen, new Point(p1.X + fromControl[i].Width, p2.Y),
                        new Point(p1.X + fromControl[i].Width, p2.Y - fromControl[i].Height));

                    graphic.DrawLine(pen, new Point(p1.X + fromControl[i].Width, p2.Y - fromControl[i].Height),
                        new Point(p1.X, p2.Y - fromControl[i].Height));

                    graphic.DrawLine(pen, new Point(p1.X, p2.Y - fromControl[i].Height),
                        new Point(p1.X, fromControl[i].Top));
                }
                else
                    graphic.DrawLine(pen, p1, p2);
            }
        }

    }
}