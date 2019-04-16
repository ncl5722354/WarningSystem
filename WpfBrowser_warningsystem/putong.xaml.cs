using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// putong.xaml 的交互逻辑
    /// </summary>
    public partial class putong : UserControl
    {
        public double[] x_arraylist = null;
        public double[] y_arraylist = null;
        public putong(double[] x_arr,double[] y_arr)
        {
            InitializeComponent();
            x_arraylist = x_arr;
            y_arraylist = y_arr;
            init_view();
        }

        private void init_view()
        {
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            Draw_Line();                 // 画线
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = this.Width;
            canvas.Height = this.Height;
        }

        public void Draw_Line()
        {
            // 画线
            canvas.Children.Clear();
            if (x_arraylist == null || y_arraylist == null) return;
            if (x_arraylist.Length != y_arraylist.Length) return;     // 点个数不对
            try
            {
                for (int i = 0; i < x_arraylist.Length - 1; i++)
                {
                    Line line = new Line();
                    line.X1 = x_arraylist[i];
                    line.Y1 = y_arraylist[i];
                    line.X2 = x_arraylist[i + 1];
                    line.Y2 = y_arraylist[i + 1];
                    line.StrokeThickness = 2;
                    line.Stroke = Brushes.Yellow;
                    canvas.Children.Add(line);
                }
            }
            catch { }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }
    }
}
