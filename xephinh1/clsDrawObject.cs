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
    public abstract class clsDrawObject
    {
        public Point pos;
        public Point p1, p2, p3, p4;
        public abstract void Draw(Graphics gp, Brush myBrush, Pen pen);
        public abstract void Draw2(Graphics gp, Brush myBrush, Pen myPen);
        public abstract void Draw3(Graphics gp, Brush myBrush, Pen myPen);
        public abstract void Draw4(Graphics gp, Brush myBrush, Pen myPen);
    };
}
