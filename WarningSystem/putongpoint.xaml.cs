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

namespace WarningSystem
{
    /// <summary>
    /// putongpoint.xaml 的交互逻辑
    /// </summary>
    public partial class putongpoint : UserControl
    {
        public double pos_x = 0;
        public double pos_y = 0;
        public string key = "";
        public double weiyi = 0;
        public int mode = 0;
        public putongpoint(double x,double y)
        {
            InitializeComponent();
            
            pos_x = x;
            pos_y = y;
        }

        public void Set_Warn_is()
        {
            myimage.Source = new BitmapImage(new Uri(MyView.rootpath + "//redpoint.ico"));
            ScaleTransform scaleTransform = new ScaleTransform();
            this.RenderTransformOrigin = new Point(0.5, 0.5);
            if (mode == 0)
            {
                scaleTransform.ScaleX = 1 + MyView.suofang;
                scaleTransform.ScaleY = 1 + MyView.suofang;
            }
            if (mode == 1)
            {
                scaleTransform.ScaleX = 4 + MyView.suofang;
                scaleTransform.ScaleY = 4 + MyView.suofang;
            }
            this.RenderTransform = scaleTransform;
        }

       

        public void Set_Warn_is_not()
        {
            myimage.Source = new BitmapImage(new Uri(MyView.rootpath + "//bluedot.ico"));
            this.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform scaleTransform = new ScaleTransform();
            if (mode == 0)
            {
                scaleTransform.ScaleX = 1;
                scaleTransform.ScaleY = 1;
            }

            if (mode == 1)
            {
                scaleTransform.ScaleX = 4;
                scaleTransform.ScaleY = 4;
            }
            this.RenderTransform = scaleTransform;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ToolTip = "位置：" + key + " 位移：" + weiyi.ToString();
            ScaleTransform scaleTransform = new ScaleTransform();
            this.RenderTransformOrigin = new Point(0.5, 0.5);

            if (mode == 0)
            {
                scaleTransform.ScaleX = 1 + MyView.suofang;              //宽度放大一倍 

                scaleTransform.ScaleY = 1 + MyView.suofang;              //高度放大一倍
            }
            if (mode == 1)
            {
                scaleTransform.ScaleX = 4 + MyView.suofang;              //宽度放大一倍 

                scaleTransform.ScaleY = 4 + MyView.suofang;              //高度放大一倍
            }
            this.RenderTransform = scaleTransform;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleTransform scaleTransform = new ScaleTransform();
            this.RenderTransformOrigin = new Point(0.5, 0.5);

            if (mode == 0)
            {
                scaleTransform.ScaleX = 1 + 0.1 * MyView.suofang;              //宽度放大一倍 

                scaleTransform.ScaleY = 1 + 0.1 * MyView.suofang;              //高度放大一倍
            }
            if (mode == 1)
            {
                scaleTransform.ScaleX = 4 + 0.1 * MyView.suofang;              //宽度放大一倍 

                scaleTransform.ScaleY = 4 + 0.1 * MyView.suofang;              //高度放大一倍
            }
            this.RenderTransform = scaleTransform;
        }
    }
}
