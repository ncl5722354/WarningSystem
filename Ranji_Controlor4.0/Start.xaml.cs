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
using ViewConfig;

namespace Ranji_Controlor4._0
{
    /// <summary>
    /// Start.xaml 的交互逻辑
    /// </summary>
    public partial class Start : Window
    {
        // 3秒后转后主界面
        System.Timers.Timer timer1;
        public Start()
        {
            InitializeComponent();
            this.Left = ViewCaoZuo.width / 2 - this.Width / 2;
            this.Top = ViewCaoZuo.height / 2 - this.Height / 2;
            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000;
            timer1.Elapsed += Jump_To_MainView;
            timer1.Start();
        }

        void Jump_To_MainView(object sender,System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(()=>{
                timer1.Stop();
                MainWindow view = new MainWindow();
                view.Show();
                this.Hide();
            }),null);
            
        }
    }
}
