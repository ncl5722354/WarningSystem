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
    /// Report.xaml 的交互逻辑
    /// </summary>
    public partial class Report : UserControl
    {
        //myreportview reportview = new myreportview();
        public Report()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            this.Margin = new Thickness(0, 0, 0, 0);
            windowsformhost.Margin = new Thickness(0, 0, 0, 0);
            windowsformhost.Width = this.Width;
            windowsformhost.Height = this.Height*0.5;

           

            //windowsformhost.Child = //reportview;

            //reportview.Left = 0;
            //reportview.Top = 0;
            //reportview.Width = (int)windowsformhost.Width;
            //reportview.Height = (int)(windowsformhost.Height * 0.7);
        }
    }
}
