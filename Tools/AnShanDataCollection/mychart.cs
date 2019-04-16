using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnShanDataCollection
{
    public partial class mychart : UserControl
    {
        public mychart()
        {
            InitializeComponent();
            ReSet_Chart_Position();
        }

        public void Set_Series_Name(string name)
        {
            chart1.Series[0].Name = name;
        }

        public void ReSet()
        {
            chart1.Series[0].Points.Clear();
        }

        public void Insert_Point(double x,double y)
        {
            chart1.Series[0].Points.AddXY(x, y);    
        }

        public void ReSet_Chart_Position()
        {
            chart1.Left = 0;
            chart1.Top = 0;
            chart1.Width = this.Width;
            chart1.Height = this.Height;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.Add(0, 1000);
        }

        private void mychart_Resize(object sender, EventArgs e)
        {
            ReSet_Chart_Position();
        }
    }
}
