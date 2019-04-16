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
    /// Zongmao_Subview.xaml 的交互逻辑
    /// </summary>
    public partial class Zongmao_Subview : UserControl
    {
        public int machine_num = 0;
        public Zongmao_Subview()
        {
            InitializeComponent();
            init_view();                // 初始化界面
        }

        private MyLabel Label_Wendu = new MyLabel(MainWindow.Usercontrol_Config);                    // 温度字符标签
        private MyLabel Label_Wendu_Show = new MyLabel(MainWindow.Usercontrol_Config);               // 温度显示

        private MyLabel Label_Shuiwei = new MyLabel(MainWindow.Usercontrol_Config);                  // 主缸水位标签
        private MyLabel Label_Shuiwei_Show = new MyLabel(MainWindow.Usercontrol_Config);             // 主缸水位显示

        public void Set_Machine_Num(int mynum)
        {
            machine_num = mynum;
            label_machine_num.Content = mynum.ToString() + "机号";

            // 标签值的设定

            // 主标温度标签名称
            Label_Wendu_Show.Value_Name = "主缸温度"+machine_num.ToString();

            // 主缸水位标签名称
            Label_Shuiwei_Show.Value_Name = "主缸水位"+machine_num.ToString();

        }

        // 初始化界面
        public void init_view()
        {
            // 机号标签
            label_machine_num.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            label_machine_num.Width = MainWindow.screen_width * 0.1;
            label_machine_num.Height = MainWindow.scree_height * 0.04;


            label_machine_num_frame.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            label_machine_num_frame.Width = MainWindow.screen_width * 0.1;
            label_machine_num_frame.Height = MainWindow.scree_height * 0.04;

            // 主缸温度
            maingrid.Children.Add(Label_Wendu);
            Label_Wendu.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.1, 0, 0);
            Label_Wendu.Width = MainWindow.screen_width * 0.05;
            Label_Wendu.Height = MainWindow.scree_height * 0.04;
            Label_Wendu.mode = 0;
            Label_Wendu.Set_Text("主缸温度");

            maingrid.Children.Add(Label_Wendu_Show);
            Label_Wendu_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.1, 0, 0);
            Label_Wendu_Show.Width = MainWindow.screen_width * 0.05;
            Label_Wendu_Show.Height = MainWindow.scree_height * 0.04;
            Label_Wendu_Show.mode = 1;

            // 主缸水位
            maingrid.Children.Add(Label_Shuiwei);
            Label_Shuiwei.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.15, 0, 0);
            Label_Shuiwei.Width = MainWindow.screen_width * 0.05;
            Label_Shuiwei.Height = MainWindow.scree_height * 0.04;
            Label_Shuiwei.mode = 0;
            Label_Shuiwei.Set_Text("主缸水位");

            maingrid.Children.Add(Label_Shuiwei_Show);
            Label_Shuiwei_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.15, 0, 0);
            Label_Shuiwei_Show.Width = MainWindow.screen_width * 0.05;
            Label_Shuiwei_Show.Height = MainWindow.scree_height * 0.04;
            Label_Shuiwei_Show.mode = 1;



        }
    }
}
