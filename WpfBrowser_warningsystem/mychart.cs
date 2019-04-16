using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfBrowser_warningsystem
{
    public partial class mychart : UserControl
    {
        double shu_max = 0;                              // 最大值
        double shu_chaju = 0;
        double shu_min = 0;

        double heng_max = 4000;
        double heng_min = 1600;

        

        public void Set_Single()
        {
            chart1.Series[1].Enabled = false;
            chart1.Series[2].Enabled = false;
            chart1.Series[3].Enabled = false;
        }

        public void Set_Four()
        {
            chart1.Series[1].Enabled = true;
            chart1.Series[2].Enabled = true;
            chart1.Series[3].Enabled = true;
        }

        public mychart()
        {
            InitializeComponent();
            ReSet_Chart_Position();
            Get_Value();               //获取当前属性
        }

        private void Get_Value()
        {
            // 图表变化之后
            shu_max = chart1.ChartAreas[0].AxisY.Maximum;
            shu_chaju = chart1.ChartAreas[0].AxisY.Maximum - chart1.ChartAreas[0].AxisY.Minimum;
            shu_min = chart1.ChartAreas[0].AxisY.Minimum;


        }

        public void Set_Series_Name(string name)
        {
            chart1.Series[0].Name = name;
        }

        public void ReSet()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
        }

        public void Insert_Point(double x,double y)
        {
            chart1.Series[0].Points.AddXY(x, y);    
        }

        public void Insert_Point1(double x,double y)
        {
            chart1.Series[1].Points.AddXY(x, y);
        }

        public void Insert_Point2(double x, double y)
        {
            chart1.Series[2].Points.AddXY(x, y);
        }

        public void Insert_Point3(double x, double y)
        {
            chart1.Series[3].Points.AddXY(x, y);
        }

        
        public void ReSet_Chart_Position()
        {
            chart1.Left = 0;
            chart1.Top = 0;
            chart1.Width = (int)(this.Width*0.9);
            chart1.Height = (int)(this.Height*0.75);
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.Add(0, 1000);

            

            // 纵方向移动
            label_yidong.Left = (int)(this.Width * 0.9);
            label_yidong.Top = (int)(this.Height * 0.01);

            
            trackBar_shu_yidong.Left = (int)(this.Width * 0.9);
            trackBar_shu_yidong.Top = (int)(this.Height * 0.1);
            trackBar_shu_yidong.Height = (int)(this.Height * 0.89);

            // 纵方向放缩
            label_shu_fangsuo.Left = (int)(this.Width * 0.95);
            label_shu_fangsuo.Top = (int)(this.Height * 0.01);

            trackBar_shu_fangsuo.Left = (int)(this.Width * 0.95);
            trackBar_shu_fangsuo.Top = (int)(this.Height * 0.1);
            trackBar_shu_fangsuo.Height = (int)(this.Height * 0.89);

            // 复位按钮
            button1.Left = (int)(this.Width * 0.05);
            button1.Top = (int)(this.Height * 0.9);

            // 横方向移动
            label_heng_yidong.Left = (int)(this.Width * 0.2);
            label_heng_yidong.Top = (int)(this.Height * 0.79);

            trackBar_heng_yidong.Left = (int)(this.Width * 0.25);
            trackBar_heng_yidong.Top = (int)(this.Height * 0.79);
            trackBar_heng_yidong.Width = (int)(this.Width * 0.65);

            // 横方向放缩

            label_heng_fangsuo.Left = (int)(this.Width * 0.2);
            label_heng_fangsuo.Top = (int)(this.Height * 0.9);

            trackBar_heng_fangsuo.Left = (int)(this.Width * 0.25);
            trackBar_heng_fangsuo.Top = (int)(this.Height * 0.9);
            trackBar_heng_fangsuo.Width = (int)(this.Width * 0.65);

            
        }

        private void mychart_Resize(object sender, EventArgs e)
        {
            ReSet_Chart_Position();
        }

        private void mychart_Load(object sender, EventArgs e)
        {

        }

        private void trackBar_shu_yidong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisY.Maximum = shu_max + (shu_max - shu_min) * 0.3 * trackBar_shu_fangsuo.Value + trackBar_shu_yidong.Value;
                chart1.ChartAreas[0].AxisY.Minimum = shu_min - (shu_max - shu_min) * 0.3 * trackBar_shu_fangsuo.Value + trackBar_shu_yidong.Value;
            }
            catch { }
        }

        private void trackBar_shu_fangsuo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisY.Maximum = shu_max + (shu_max - shu_min) * 0.3 * trackBar_shu_fangsuo.Value + trackBar_shu_yidong.Value;
                chart1.ChartAreas[0].AxisY.Minimum = shu_min - (shu_max - shu_min) * 0.3 * trackBar_shu_fangsuo.Value + trackBar_shu_yidong.Value;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 纵坐标复位
            trackBar_shu_fangsuo.Value = 1;
            trackBar_shu_yidong.Value = 0;
            trackBar_heng_fangsuo.Value = 1000;
            trackBar_heng_yidong.Value = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        private void trackBar_heng_yidong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.Maximum = heng_max * ((double)trackBar_heng_fangsuo.Value / 1000) + ((double)trackBar_heng_yidong.Value/100)*heng_max;
                chart1.ChartAreas[0].AxisX.Minimum = 0 + ((double)trackBar_heng_yidong.Value / 100) * heng_max;
            }
            catch { }
        }

        private void trackBar_heng_yidong_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar_shu_fangsuo_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar_heng_fangsuo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.Maximum = heng_max * ((double)trackBar_heng_fangsuo.Value / 1000) + ((double)trackBar_heng_yidong.Value / 100) * heng_max;
                chart1.ChartAreas[0].AxisX.Minimum = 0 + ((double)trackBar_heng_yidong.Value / 100) * 1600;
            }
            catch { }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            int _currentPointX = e.X;
            int _currentPointY = e.Y;
            chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);
            chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(_currentPointX, _currentPointY), true);

            label1.Text = "X:" + chart1.ChartAreas[0].CursorX.Position.ToString("#0.00") + " Y:" + chart1.ChartAreas[0].CursorY.Position.ToString("#0.00");
        }
    }
}
