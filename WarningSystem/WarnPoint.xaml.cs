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
    /// WarnPoint.xaml 的交互逻辑
    /// </summary>
    public partial class WarnPoint : UserControl
    {
        string rootpath = Environment.CurrentDirectory;
        public double x = 0;
        public double y = 0;
        public string key = "";
        public WarnPoint()
        {
            InitializeComponent();
            myimage.Source = new BitmapImage(new Uri(rootpath + "//warning_point.png", UriKind.RelativeOrAbsolute));
        }
    }
}
