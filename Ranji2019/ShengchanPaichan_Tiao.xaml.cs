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
using System.Collections;

namespace Ranji2019
{
    /// <summary>
    /// ShengchanPaichan_Tiao.xaml 的交互逻辑
    /// </summary>
    /// 每个工单有工单号，起始时间，持续时间，工作状态
    /// 
    public partial class ShengchanPaichan_Tiao : UserControl
    {
        public ArrayList all_items = new ArrayList();                    // 所有的生产排产项
        public ShengchanPaichan_Tiao(ArrayList items=null)
        {
            InitializeComponent();
            all_items = items;
            Set_All_Item();                                              // 根据所有的排产项，在条形上进行排产
        }

        // 所有的排产项
        public void Set_All_Item()
        {
            subgrid.Children.Clear();
            if (all_items == null) return;
            foreach(ShengchanPaichan_Item item in all_items)
            {
                int start_secs = item.start_time.Hour * 3600 + item.start_time.Minute * 60 + item.start_time.Second;
                int end_secs = item.end_time.Hour * 3600 + item.end_time.Minute * 60 + item.end_time.Second;

                double start_pos = (double)start_secs / (3600 * 24);
                double end_pos = (double)end_secs / (3600 * 24);

                item.Margin = new Thickness(start_pos * this.Width, 0, 0, 0);
                item.Height = this.Height;
                item.Width = (end_pos - start_pos) * this.Width;
                
                subgrid.Children.Add(item);
            }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            //int a = 0;
        }
    }
}
