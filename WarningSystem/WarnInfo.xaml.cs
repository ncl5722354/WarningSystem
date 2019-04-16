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

namespace WarningSystem
{
    /// <summary>
    /// WarnInfo.xaml 的交互逻辑
    /// </summary>
    public partial class WarnInfo : Window
    {
        ArrayList thislist = new ArrayList();
        ZhuZi zhuzi = null;
        int mymode =0;
        string myname = "";
        public WarnInfo(ArrayList mylist,int mode,string name)
        {
            InitializeComponent();
            thislist = mylist;
            mymode = mode;
            myname = name;
            //ZhuZi zhuzi = new ZhuZi(thislist);
            init();
        }

        public void Set_WarnInfo(ArrayList mylist)
        {
            //

            //if (this.Visibility == Visibility.Hidden) return;
            thislist = mylist;
            zhuzi.ReSet(mylist);
        }

        private void init()
        {
            zhuzi = new ZhuZi(thislist,mymode,myname);
            zhuzi.Margin = new Thickness(0, 0, 0, 0);
            zhuzi.VerticalAlignment = VerticalAlignment.Stretch;
            zhuzi.HorizontalAlignment = HorizontalAlignment.Stretch;
            
            maingrid.Children.Add(zhuzi);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}
