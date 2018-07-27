using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShape
{
    public partial class Line : PictureBox
    {

        public string create_date = "";
        public string map_name = "";
        public bool selected_point1 = false;
        public bool selected_point2 = false;


        public Line(string mymap_name,Panel inputpanel)
        {
            
            InitializeComponent();
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            create_date = DateTime.Now.ToString("yyyyMMddHHmmss")+DateTime.Now.Millisecond.ToString();
            map_name = mymap_name;
            inputpanel.Controls.Add(this);
            this.Parent = inputpanel;
            this.BackColor = Color.Transparent;
            this.BringToFront();
        }

        protected override void OnPrint(PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Transparent);
            g.DrawLine(new Pen(Color.Red, 5), new Point(point1.Left, point2.Top), new Point(point2.Left, point2.Top));
            base.OnPrint(e);
        }

        private void Line_Load(object sender, EventArgs e)
        {
            ReSize_And_Draw();
        }

        private void ReSize_And_Draw()
        {
            int left = 0;
            int right = 0;
            int top = 0;
            int down = 0;
            // 取得最左边坐标，最右坐标，最上坐标，最下坐标
            if(point1.Left<=point2.Left)
            {
                left = point1.Left;
                right = point2.Left + point2.Width;
            }
            else
            {
                left = point2.Left;
                right = point1.Left + point1.Width;
            }
            if(point1.Top<=point2.Top)
            {
                top = point1.Top;
                down = point2.Top + point2.Height;
            }
            else
            {
                top = point2.Top;
                down = point1.Top + point1.Height;
            }
            // 变形需求：
            // 保持上下左右的宽度不变
            int width = right - left;
            int height = down - top;

            this.Width = width;
            this.Height = height;

            this.Left = this.Left + left;
            this.Top = this.Top + top;
          

            

            if (point1.Left <= point2.Left && point1.Top <= point2.Top)
            {
                
                point1.Left = 0;
                point1.Top = 0;
                point2.Left = this.Width - point2.Width;
                point2.Top = this.Height - point2.Height;
            }
            if(point1.Left>point2.Left && point1.Top<=point2.Top)
            {
                point1.Left = this.Width - point1.Width;
                point1.Top = 0;
                point2.Left = 0;
                point2.Top = this.Height - point2.Height;
            }
            
            if(point1.Left<=point2.Left && point1.Top>point2.Top)
            {
                point1.Left = 0;
                point1.Top = this.Height - point1.Height;
                point2.Left = this.Width - point2.Width;
                point2.Top = 0;
            }
            if (point1.Left > point2.Left && point1.Top > point2.Top)
            {
                point1.Left = this.Width-point1.Width;
                point1.Top = this.Height - point1.Height;
                point2.Top = 0;
                point2.Top = 0;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            base.OnPaint(pe);
        }

        private void point1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void point1_MouseDown(object sender, MouseEventArgs e)
        {
            selected_point1 = true;
        }

        private void point1_MouseUp(object sender, MouseEventArgs e)
        {
            selected_point1 = false;
        }

        private void point1_MouseMove(object sender, MouseEventArgs e)
        {
            if(selected_point1==true)
            {
                point1.Top = point1.Top + e.Y;
                point1.Left = point1.Left + e.X;
                // 针对操作点的不同，有相应不同的变形策略
                ReSize_And_Draw();
            }
        }

        private void point2_Click(object sender, EventArgs e)
        {

        }

        private void point2_MouseDown(object sender, MouseEventArgs e)
        {
            selected_point2 = true;
        }

        private void point2_MouseUp(object sender, MouseEventArgs e)
        {
            selected_point2 = false;
        }

        private void point2_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected_point2 == true)
            {
                point2.Top = point2.Top + e.Y;
                point2.Left = point2.Left + e.X;
                // 针对操作点的不同，有相应不同的变形策略
                ReSize_And_Draw();
            }
        }

        private void Line_Resize(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
