using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using xephinh1.Properties;

namespace xephinh1
{
    

    public partial class Form1 : Form
    {
        //graphic
        Bitmap bm;
        Graphics g;
        Graphics gp1;
        SolidBrush myBrush;
        SolidBrush myBrush1;
        Pen myPen = new Pen(Color.Red, 1);
        Pen pen = new Pen(Color.Red, 2);
        Color myColor1;
        Color myColor;

        Point pos, pos2;
        Point p1, p2, p3, p4;           
        List<clsDrawObject> lstObject = new List<clsDrawObject>(); //danh sach vat the 
        clsDrawObject obj;

        int[,] check = new int[15, 23]; //mảng 2 chiều để xác định vị trí vật thể có đi xuống đưuọc hay không
        int score = 0; //điểm
        int ran; //sinh ngẫu nhiên vật thể
        bool time=true;
        bool restart = false;
        int huongvatthe = 1; //có 4 hướng, mặc định là 1.
        public Form1()
        {
            InitializeComponent();

            g = pictureBox1.CreateGraphics();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gp1 = Graphics.FromImage(bm);                
            
            myColor = Color.Indigo; //màu vật thể đứng yên
            myColor1 = Color.Blue; //màu vật đang di chuyển
            myBrush = new SolidBrush(myColor);
            myBrush1 = new SolidBrush(myColor1);
            pos.X = 210; pos.Y = 0; //vị trí đầu tiên chính giữa  
            button1.TabStop = false;
            for (int i = 0; i < 15; i++) //mảng 2 chiều ban đầu chưa có vật nào đều bằng 0
                for (int j = 0; j < 22; j++) check[i, j] = 0;
            for (int i = 0; i < 15; i++) check[i, 22] = 1;


        }         
       
        public bool testdown(Point p1, Point p2, Point p3, Point p4)
        {
            if (check[p1.X,p1.Y + 1] == 0 && check[p2.X, p2.Y + 1] == 0 && check[p3.X, p3.Y + 1] == 0 && check[p4.X, p4.Y + 1] == 0)
                return true;
            else return false;
        }
        public bool testleft(Point p1, Point p2, Point p3, Point p4)
        {
            if (p1.X != 0 && p2.X!=0 && p3.X!=0 && p4.X!=0)
                if (p1.X * p2.X * p3.X * p4.X != 0)
                    if (check[p1.X-1, p1.Y] == 0 && check[p2.X-1, p2.Y ] == 0 && check[p3.X-1, p3.Y ] == 0 && check[p4.X-1, p4.Y] == 0)
                        return true;
            else return false;
            return false;
        }
        public bool testright(Point p1, Point p2, Point p3, Point p4)
        {
            if (p1.X != 13 && p2.X != 13 && p3.X != 13 && p4.X != 13)
            if (check[p1.X+1, p1.Y] == 0 && check[p2.X+1, p2.Y ] == 0 && check[p3.X+1, p3.Y] == 0 && check[p4.X+1, p4.Y] == 0)
                return true;
            else return false;
            return false;
        }
        public clsDrawObject khoitao()
        {
            Random rand = new Random();
            ran = rand.Next(1, 6);
            switch (ran)
            {
                case 1:
                    obj = new clsLine();                    
                    p1.X = 7; p1.Y = 0; p2.X = 8; p2.Y = 0; p3.X = 9; p3.Y = 0; p4.X = 10; p4.Y = 0;
                    break;
                case 2:
                    obj = new clsRect();
                    p1.X = 7; p1.Y = 0; p2.X = 8; p2.Y = 0; p3.X = 7; p3.Y = 1; p4.X = 8; p4.Y = 1;
                    break;
                case 3:
                    obj = new clsCot();
                    p1.X = 7; p1.Y = 0; p2.X = 7; p2.Y = 1; p3.X = 7; p3.Y = 2; p4.X = 7; p4.Y = 3;
                    break;
                case 4:
                    obj = new clsTamgiac();
                    p1.X = 7; p1.Y = 0; p2.X = 7; p2.Y = 1; p3.X = 6; p3.Y = 1; p4.X = 8; p4.Y = 1;
                    break;
                case 5:
                    obj = new clsChuL();
                    p1.X = 7; p1.Y = 0; p2.X = 7; p2.Y = 1; p3.X = 7; p3.Y = 2; p4.X = 8; p4.Y = 2;
                    break;
            }
            obj.pos = pos;         
            return obj;
            
        }

        //Button Pause
        private void button1_Click(object sender, EventArgs e)
        {
            if (time == true)
            {
                timer1.Stop(); //dung timer
                time = false;
                button1.Text = "Continue"; //doi text
            }

            else
            {
                time = true;
                timer1.Start(); //bat dau lai timer
                button1.Text = "Pause"; //doi text
            }
            pictureBox1.Select(); //focus lai picturebBox de bắt sự kiện

        }
        //Button Start
        private void button2_Click(object sender, EventArgs e)
        {
            if (restart == false)
            {
                //xác định mức để set timer1.Interval
                string selected = comboBox1.SelectedItem.ToString();
                if (selected.CompareTo("Easy") == 0)
                    this.timer1.Interval = 500;
                else if (selected == "Normal")
                    this.timer1.Interval = 200;
                else this.timer1.Interval = 100;

                button1.Enabled = true;

                this.timer1.Start();
                pictureBox1.Select();
                restart = true;
                button2.Text = "Restart";
                obj = khoitao(); //khởi tạo vật thể đầu tiên
            }
            else
            {
                Application.Restart();
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            button2.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (testleft(p1, p2, p3, p4) == true)
                    {
                        this.pos.X = this.pos.X - 30;
                        p1.X -= 1;
                        p2.X -= 1;
                        p3.X -= 1;
                        p4.X -= 1;
                    }

                    break;
                case Keys.Right:
                    if (testright(p1, p2, p3, p4) == true)
                    {
                        p1.X += 1;
                        p2.X += 1;
                        p3.X += 1;
                        p4.X += 1;
                        this.pos.X = this.pos.X + 30;
                    }
                
                    break;
                case Keys.Up:
                    if (huongvatthe < 4)
                        huongvatthe += 1;
                    else huongvatthe = 1;
                    break;
                case Keys.Down:
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(xephinh1.Properties.Resources.jump);                    
                    sound.Play();
                    obj.pos = pos;
                    //Nếu bấm xuống thì coi như timer tick thêm 1 lần
                    //game over
                    for (int i = 0; i < 14; i++) if (check[i, 0] == 1)
                        {
                            timer1.Stop();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            break;
                        }

                    gp1.Clear(Color.Black);

                    //co the di xuong
                    if (testdown(p1, p2, p3, p4) == true)
                    {
                        gp1.Clear(Color.Black);
                        pos.Y = pos.Y + 30;
                        p1.Y += 1; p2.Y += 1; p3.Y += 1; p4.Y += 1;
                        for (int i = 0; i < 15; i++)
                            for (int j = 0; j < 22; j++)
                            {
                                if (check[i, j] == 1)
                                {
                                    gp1.FillRectangle(myBrush, i * 30, j * 30, 30, 30);
                                    gp1.DrawRectangle(pen, i * 30, j * 30, 30, 30);
                                }
                            }
                        if (huongvatthe == 1)
                        {
                            obj.Draw(this.gp1, this.myBrush1, this.myPen);
                        }
                        else if (huongvatthe == 2)
                        {

                            obj.Draw2(this.gp1, this.myBrush1, this.myPen);
                            p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                        }
                        else if (huongvatthe == 3)
                        {
                            p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                            obj.Draw3(this.gp1, this.myBrush1, this.myPen);
                        }
                        else
                        {
                            p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                            obj.Draw4(this.gp1, this.myBrush1, this.myPen);
                        }
                    }
                    // neu khong the di xuong thi danh dau vi tri bang 1 va them vai list vat the
                    else
                    {
                        check[p1.X, p1.Y] = 1; check[p2.X, p2.Y] = 1; check[p3.X, p3.Y] = 1; check[p4.X, p4.Y] = 1;
                        pos.X = 210; pos.Y = 0;

                        //ve vat the dang dung yen
                        for (int i = 0; i < 15; i++)
                            for (int j = 0; j < 22; j++)
                            {
                                if (check[i, j] == 1)
                                {
                                    gp1.DrawRectangle(pen, i * 30, j * 30, 30, 30);
                                    gp1.FillRectangle(myBrush, i * 30, j * 30, 30, 30);
                                }
                            }

                        obj = khoitao();

                        huongvatthe = 1;
                    }

                    //Score
                    for (int j = 0; j < 22; j++)
                    {
                        int tong = 0;
                        for (int i = 0; i < 14; i++)
                        {
                            tong += check[i, j];
                        }
                        if (tong == 14)
                        {
                            System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(xephinh1.Properties.Resources.score);
                            sound2.Play();
                            score += 10;
                            for (int m = 0; m < 14; m++)
                                for (int n = j; n > 0; n--)
                                {
                                    check[m, n] = check[m, n - 1];
                                }
                        }
                        for (int i = 0; i < 15; i++)
                            for (int j_ = 0; j_ < 22; j_++)
                            {
                                if (check[i, j_] == 1)
                                {
                                    gp1.DrawRectangle(pen, i * 30, j_ * 30, 30, 30);
                                    gp1.FillRectangle(myBrush, i * 30, j_ * 30, 30, 30);
                                }
                            }
                    }
                    lbscore.Text = Convert.ToString(score);
                    g.DrawImage(bm, 0, 0);
                    break;
                default:
                    break;
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer sound = new System.Media.SoundPlayer("tick.wav");
            //if (play ==true)
               // sound.Play();


            //game over
            obj.pos = pos; //pos là vị trí ban đầu, obj là vật thể khởi tạo ra
            for (int i = 0; i < 14; i++) if (check[i, 0] == 1)
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    label1.Visible = true; //label Game OVER
                    break;
                }

            gp1.Clear(Color.Black);

            //co the di xuong
            if (testdown(p1, p2, p3, p4) == true) //kiểm tra vật có xuống được không
            {
                gp1.Clear(Color.Black);
                pos.Y = pos.Y + 30;
                p1.Y += 1; p2.Y += 1; p3.Y += 1; p4.Y += 1;
                for (int i = 0; i < 15; i++)
                    for (int j = 0; j < 22; j++)
                    {
                        if (check[i, j] == 1)
                        {
                            gp1.FillRectangle(myBrush, i * 30, j * 30, 30, 30);
                            gp1.DrawRectangle(pen, i * 30, j * 30, 30, 30);
                        }
                    }
                //tùy theo hướng mà vẽ vật thể đang di chuyển
                if (huongvatthe == 1)
                {
                    obj.Draw(this.gp1, this.myBrush1, this.myPen);
                }
                else if (huongvatthe == 2)
                {

                    obj.Draw2(this.gp1, this.myBrush1, this.myPen);
                    p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                }
                else if (huongvatthe == 3)
                {
                    p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                    obj.Draw3(this.gp1, this.myBrush1, this.myPen);
                }
                else
                {
                    p1 = obj.p1; p2 = obj.p2; p3 = obj.p3; p4 = obj.p4;
                    obj.Draw4(this.gp1, this.myBrush1, this.myPen);
                }
            }
            //neu khong the di xuong thi danh dau vi tri bang 1 va them vào list vat the
            else
            {
                check[p1.X, p1.Y] = 1; check[p2.X, p2.Y] = 1; check[p3.X, p3.Y] = 1; check[p4.X, p4.Y] = 1;
                pos.X = 210; pos.Y = 0;

                //ve vat the dang dung yen
                for (int i = 0; i < 15; i++)
                    for (int j = 0; j < 22; j++)
                    {
                        if (check[i, j] == 1)
                        {
                            gp1.DrawRectangle(pen, i * 30, j * 30, 30, 30);
                            gp1.FillRectangle(myBrush, i * 30, j * 30, 30, 30);
                        }
                    }

                obj = khoitao(); //khi đã dừng thì khởi tạo lại vật thể tiếp theo
                huongvatthe = 1; //cho hướng vật quay về mặc định
            }
    
            //Score, kiểm tra nếu cả 1 hàng của mảng 2 chiều đều bằng 1
            for (int j = 0; j < 22; j++)
            {
                int tong = 0;
                for (int i = 0; i < 14; i++)
                {
                    tong += check[i, j];
                }
                if (tong == 14)
                {
                    System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(xephinh1.Properties.Resources.score);
                    sound2.Play();
                    score += 10; //tăng điểm
                    for (int m = 0; m < 14; m++)
                        for (int n = j; n > 0; n--) //trong mảng 2 chiều, phần nào ở trên sẽ di chuyển xuống 1 bậc, để đưa vật trên rơi xuống và xóa vật đã thắng
                        {
                            check[m, n] = check[m, n - 1];
                        }                    
                }
                //vẽ lại các vật đứng yên
                for (int i = 0; i < 15; i++)
                    for (int j_ = 0; j_ < 22; j_++)
                    {
                        if (check[i, j_] == 1)
                        {
                            gp1.DrawRectangle(pen, i * 30, j_* 30, 30, 30);
                            gp1.FillRectangle(myBrush, i * 30, j_ * 30, 30, 30);
                        }
                    }
            }
            lbscore.Text = Convert.ToString(score); //label hiển thị điểm
            g.DrawImage(bm, 0, 0);
            

        }

    }

}
