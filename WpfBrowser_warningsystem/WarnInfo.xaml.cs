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
using System.Windows.Shapes;
using System.Collections;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// WarnInfo.xaml 的交互逻辑
    /// </summary>
    public partial class WarnInfo : Window
    {
        ArrayList thislist = new ArrayList();
        ZhuZi zhuzi = null;
        public WarnInfo(ArrayList mylist)
        {
            InitializeComponent();
            thislist = mylist;
            //ZhuZi zhuzi = new ZhuZi(thislist);
            init();
        }

        public void Set_WarnInfo(ArrayList mylist)
        {
            //
            thislist = mylist;
            zhuzi.ReSet(mylist);
        }

        private void init()
        {
            zhuzi = new ZhuZi(thislist);
            zhuzi.Margin = new Thickness(0, 0, 0, 0);
            zhuzi.VerticalAlignment = VerticalAlignment.Top;
            zhuzi.HorizontalAlignment = HorizontalAlignment.Left;
            zhuzi.Width = 600;
            maingrid.Children.Add(zhuzi);
        }
    }
}
