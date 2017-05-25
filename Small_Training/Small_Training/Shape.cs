using System;
using System.Drawing;
using System.Windows.Forms;

namespace Small_Training
{
    public class Shape
    {
        PictureBox pictureBox1;
        Graphics graphics;  // pictureBox
        public Point mousePrev, mouseNext, formPos;
        Pen pen = new Pen(Color.White, 2.5f);
        SolidBrush myBrush = new SolidBrush(Color.Red);

        public Shape(PictureBox pictureBox1)
        {
            this.pictureBox1 = pictureBox1;
            this.graphics = pictureBox1.CreateGraphics();  // pictureBox
        }

        public Point SubPoint(Point v1, Point v2)
        {
            return new Point(v1.X - v2.X, v1.Y - v2.Y);
        }

        public void MouseDown(Point MousePosition)
        {
            formPos = pictureBox1.PointToScreen(pictureBox1.Location);  // PictureBox 컨트롤의 좌표
            mousePrev = SubPoint(MousePosition, formPos);
        }

        public void MouseUp(Point MousePosition)
        {
            formPos = pictureBox1.PointToScreen(pictureBox1.Location);  // PictureBox 컨트롤의 좌표
            mouseNext = SubPoint(MousePosition, formPos);

            // shape.DrawLine(mousePrev.X, mousePrev.Y, mouseNext.X, mouseNext.Y);
            // shape.DrawRect(mousePrev.X, mousePrev.Y, mouseNext.X, mouseNext.Y);
            // shape.DrawCircle(mousePrev.X, mousePrev.Y, mouseNext.X, mouseNext.Y);
            // shape.DrawFillRect(Color.Red, mousePrev.X, mousePrev.Y, mouseNext.X, mouseNext.Y);
            DrawFirllCircle(Color.Blue, mousePrev.X, mousePrev.Y, mouseNext.X, mouseNext.Y);
        }

        public void DrawLine(int X1, int Y1, int X2, int Y2)
        {
            // graphics.DrawString("선분 생성", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));

            graphics.DrawLine(pen, X1, Y1, X2, Y2);
        }

        public void DrawRect(int X1, int Y1, int X2, int Y2)
        {
            // graphics.DrawString("사각형 생성", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));

            int Witdh = Math.Abs(X1 - X2);
            int Height = Math.Abs(Y1 - Y2);

            
            if (X1 <= X2 && Y1 <= Y2)
                graphics.DrawRectangle(pen, X1, Y1, Witdh, Height);
            else if (X1 >= X2 && Y1 <= Y2)
                graphics.DrawRectangle(pen, X2, Y1, Witdh, Height);
            else if (X1 <= X2 && Y1 >= Y2)
                graphics.DrawRectangle(pen, X1, Y2, Witdh, Height);
            else if (X1 >= X2 && Y1 >= Y2)
                graphics.DrawRectangle(pen, X2, Y2, Witdh, Height);

            // 사각형 생성 위치를 각각 상황에 맞춰 주어야 한다.
        }
        public void DrawFillRect(Color color, int X1, int Y1, int X2, int Y2)
        {
            // graphics.DrawString("사각형 생성", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));

            int Witdh = Math.Abs(X1 - X2);
            int Height = Math.Abs(Y1 - Y2);

            
            if (X1 <= X2 && Y1 <= Y2)
                graphics.FillRectangle(myBrush, X1, Y1, Witdh, Height);
            else if (X1 >= X2 && Y1 <= Y2)
                graphics.FillRectangle(myBrush, X2, Y1, Witdh, Height);
            else if (X1 <= X2 && Y1 >= Y2)
                graphics.FillRectangle(myBrush, X1, Y2, Witdh, Height);
            else if (X1 >= X2 && Y1 >= Y2)
                graphics.FillRectangle(myBrush, X2, Y2, Witdh, Height);

            // 사각형 생성 위치를 각각 상황에 맞춰 주어야 한다.
        }
        public void DrawCircle(int X1, int Y1, int X2, int Y2)
        {
            // graphics.DrawString("삼각형 생성", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));

            int Witdh = Math.Abs(X1 - X2);
            int Height = Math.Abs(Y1 - Y2);

            
            if (X1 <= X2 && Y1 <= Y2)
                graphics.DrawEllipse(pen, new Rectangle(X1, Y1, Witdh, Height));
            else if (X1 >= X2 && Y1 <= Y2)
                graphics.DrawEllipse(pen, new Rectangle(X2, Y1, Witdh, Height));
            else if (X1 <= X2 && Y1 >= Y2)
                graphics.DrawEllipse(pen, new Rectangle(X1, Y2, Witdh, Height));
            else if (X1 >= X2 && Y1 >= Y2)
                graphics.DrawEllipse(pen, new Rectangle(X2, Y2, Witdh, Height));
        }
        public void DrawFirllCircle(Color color, int X1, int Y1, int X2, int Y2)
        {
            // graphics.DrawString("삼각형 생성", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(30, 30));

            int Witdh = Math.Abs(X1 - X2);
            int Height = Math.Abs(Y1 - Y2);

            
            if (X1 <= X2 && Y1 <= Y2)
                graphics.FillEllipse(myBrush, new Rectangle(X1, Y1, Witdh, Height));
            else if (X1 >= X2 && Y1 <= Y2)
                graphics.FillEllipse(myBrush, new Rectangle(X2, Y1, Witdh, Height));
            else if (X1 <= X2 && Y1 >= Y2)
                graphics.FillEllipse(myBrush, new Rectangle(X1, Y2, Witdh, Height));
            else if (X1 >= X2 && Y1 >= Y2)
                graphics.FillEllipse(myBrush, new Rectangle(X2, Y2, Witdh, Height));
        }
    }
}
