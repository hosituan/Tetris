using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace xephinh1
{
    public class clsChuL : clsDrawObject
    {
        public override void Draw(Graphics gp, Brush myBrush, Pen myPen)
        {
            p1.X = pos.X / 30; p1.Y = pos.Y / 30;
            p2.X = pos.X / 30; p2.Y = pos.Y / 30 + 1;
            p3.X = pos.X / 30; p3.Y = pos.Y / 30 + 2;
            p4.X = pos.X / 30 + 1; p4.Y = pos.Y / 30 + 2;
            gp.FillRectangle(myBrush, pos.X, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 30, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 60, 30, 30);
            gp.FillRectangle(myBrush, pos.X + 30, pos.Y + 60, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 30, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 60, 30, 30);
            gp.DrawRectangle(myPen, pos.X + 30, pos.Y + 60, 30, 30);
        }
        public override void Draw2(Graphics gp, Brush myBrush, Pen myPen)
        {
            p1.X = pos.X / 30; p1.Y = pos.Y / 30;
            p2.X = pos.X / 30; p2.Y = pos.Y / 30 + 1;
            p3.X = pos.X / 30; p3.Y = pos.Y / 30 + 2;
            p4.X = pos.X / 30 - 1; p4.Y = pos.Y / 30 +2;
            gp.FillRectangle(myBrush, pos.X, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 30, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 60, 30, 30);
            gp.FillRectangle(myBrush, pos.X - 30, pos.Y + 60, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 30, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 60, 30, 30);
            gp.DrawRectangle(myPen, pos.X - 30, pos.Y + 60, 30, 30);
        }
        public override void Draw3(Graphics gp, Brush myBrush, Pen myPen)
        {
            p1.X = pos.X / 30; p1.Y = pos.Y / 30;
            p2.X = pos.X / 30+1; p2.Y = pos.Y / 30;
            p3.X = pos.X / 30; p3.Y = pos.Y / 30 + 1;
            p4.X = pos.X / 30; p4.Y = pos.Y / 30 + 2;
            gp.FillRectangle(myBrush, pos.X, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X + 30, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 30, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 60, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X+30, pos.Y , 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 30, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 60, 30, 30);
        }
        public override void Draw4(Graphics gp, Brush myBrush, Pen myPen)
        {
            p1.X = pos.X / 30; p1.Y = pos.Y / 30;
            p2.X = pos.X / 30; p2.Y = pos.Y / 30 + 1;
            p3.X = pos.X / 30+1; p3.Y = pos.Y / 30;
            p4.X = pos.X / 30 + 2; p4.Y = pos.Y / 30;
            gp.FillRectangle(myBrush, pos.X, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X, pos.Y + 30, 30, 30);
            gp.FillRectangle(myBrush, pos.X + 30, pos.Y, 30, 30);
            gp.FillRectangle(myBrush, pos.X + 60, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X, pos.Y + 30, 30, 30);
            gp.DrawRectangle(myPen, pos.X+30, pos.Y, 30, 30);
            gp.DrawRectangle(myPen, pos.X + 60, pos.Y, 30, 30);
        }
    }
}
