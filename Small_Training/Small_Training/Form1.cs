using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;  // Console

namespace Small_Training
{
    public partial class Form1 : Form
    {
        Shape shape;
        public Form1()
        {
            InitializeComponent();
            shape = new Shape(pictureBox1);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            AllocConsole();  // Console
        }

        [DllImport("kernel32.dll", SetLastError = true)]  // Console
        [return: MarshalAs(UnmanagedType.Bool)]  // Console
        static extern bool AllocConsole();  // Console

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            shape.MouseDown(MousePosition);
            Console.WriteLine("Mouse Down : " + shape.mousePrev);  // Console
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            shape.MouseUp(MousePosition);
            Console.WriteLine("Mouse Up : " + shape.mouseNext);  // Consoles
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            shape = new Shape(pictureBox1);
            // picktureBox 사이즈가 바뀌면 다시 등록
        }
    }
}
