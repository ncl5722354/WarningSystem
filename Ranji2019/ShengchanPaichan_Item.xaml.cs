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

namespace Ranji2019
{
    /// <summary>
    /// ShengchanPaichan_Item.xaml 的交互逻辑
    /// </summary>
    public partial class ShengchanPaichan_Item : UserControl
    {
        public enum Panchan_State{
            ready,
            doing,
            done
        }
        public string DingDan_ID = "";                                           // 订单号
        public DateTime start_time = new DateTime();                             // 起始时间
        public DateTime end_time = new DateTime();                               // 结束时间
        public Panchan_State panchan_state;                                      // 状态
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();                    // 计时器

        public ShengchanPaichan_Item(string id,DateTime start,DateTime end,Panchan_State state)
        {
            InitializeComponent();
            DingDan_ID = id;
            start_time = start;
            end_time = end;
            panchan_state = state;

            // 计时器
            timer.Interval = 100;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (panchan_state == Panchan_State.ready) this.Background = new SolidColorBrush(Colors.LightBlue);
            if (panchan_state == Panchan_State.doing) this.Background = new SolidColorBrush(Colors.Yellow);
            if (panchan_state == Panchan_State.done) this.Background = new SolidColorBrush(Colors.Red);
        }

        public  void UserControl_MouseEnter(object sender, RoutedEventArgs e)
        {
            int a = 0;
        }

       
    }
}
