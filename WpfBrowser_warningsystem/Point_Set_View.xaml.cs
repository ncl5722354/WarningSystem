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

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// Point_Set_View.xaml 的交互逻辑
    /// </summary>
    public partial class Point_Set_View : Window
    {
        public static string myname = "";
        public static int rukou = 0;
        public static int chukou = 0;
        public Point_Set_View()
        {
            InitializeComponent();
            txt_name.Text = myname;
            txt_chukou.Text = chukou.ToString();
            txt_rukou.Text = rukou.ToString();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myname = txt_name.Text;
                rukou = int.Parse(txt_rukou.Text);
                chukou = int.Parse(txt_chukou.Text);
            }
            catch { return; }
            this.DialogResult = true;
            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
