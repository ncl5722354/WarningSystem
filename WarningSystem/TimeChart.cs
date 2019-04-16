using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarningSystem
{
    public partial class TimeChart : UserControl
    {
        
        public TimeChart()
        {
            InitializeComponent();
        }

        public void Clear_Chart()
        {
            chart1.Series[0].Points.Clear();
        }

        public void Insert(DateTime insert_time,double value)
        {
            chart1.Series[0].Points.AddXY(insert_time.ToOADate(), value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum).AddDays(1).ToOADate() <= DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).ToOADate())
                {
                    chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(-1).ToOADate();// chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(-1).ToOADate();
                    chart1.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum).AddDays(1).ToOADate();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(1).ToOADate();// chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(-1).ToOADate();
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum).AddDays(-1).ToOADate();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

               
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum).AddDays(-1).ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(-1).ToOADate();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum).AddDays(1).ToOADate();
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum).AddDays(1).ToOADate();
               
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (chart1.ChartAreas[0].AxisY.Minimum + 0.4 < chart1.ChartAreas[0].AxisY.Maximum)
                {
                    chart1.ChartAreas[0].AxisY.Maximum = chart1.ChartAreas[0].AxisY.Maximum - 0.3;
                }
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                
                    chart1.ChartAreas[0].AxisY.Maximum = chart1.ChartAreas[0].AxisY.Maximum + 1;
                
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisY.Maximum = chart1.ChartAreas[0].AxisY.Maximum + 1;
                chart1.ChartAreas[0].AxisY.Minimum = chart1.ChartAreas[0].AxisY.Minimum + 1;
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisY.Minimum = chart1.ChartAreas[0].AxisY.Minimum - 1;
                chart1.ChartAreas[0].AxisY.Maximum = chart1.ChartAreas[0].AxisY.Maximum - 1;
            }
            catch { }
        }

        
    }
}
