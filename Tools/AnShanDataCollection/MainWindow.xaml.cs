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


namespace AnShanDataCollection
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double screen_width = SystemParameters.PrimaryScreenWidth;    // 屏幕宽度
        public static double scree_height = SystemParameters.PrimaryScreenHeight;   // 屏幕高度
        private mychart chart = new mychart();                                      // 新建立的图表

        // 数据表格
        


        public MainWindow()
        {
            InitializeComponent();
            init_view();            // 初始化画面
        }

        private void init_view()
        {
            // 最大化屏幕
            this.Left = 0;
            this.Top = 0;
            this.Width = screen_width;
            this.Height = scree_height;

            // 数据采集框
            datashow_rectangle.Margin = new Thickness(0.01 * screen_width, 0.01 * scree_height, 0, 0);
            datashow_rectangle.Width = 0.45 * screen_width;
            datashow_rectangle.Height = 0.92 * scree_height;

            // 数据显示标题
            DataCollect_Title.Margin = new Thickness(0 * screen_width, 0.02 * scree_height, 0, 0);

            // 八个站的站名

            Station1_title.Margin = new Thickness(0.01 * screen_width, 0.1 * scree_height, 0, 0);
            Station2_title.Margin = new Thickness(0.01 * screen_width, 0.2 * scree_height, 0, 0);
            Station3_title.Margin = new Thickness(0.01 * screen_width, 0.3 * scree_height, 0, 0);
            Station4_title.Margin = new Thickness(0.01 * screen_width, 0.4 * scree_height, 0, 0);
            Station5_title.Margin = new Thickness(0.01 * screen_width, 0.5 * scree_height, 0, 0);
            Station6_title.Margin = new Thickness(0.01 * screen_width, 0.6 * scree_height, 0, 0);
            Station7_title.Margin = new Thickness(0.01 * screen_width, 0.7 * scree_height, 0, 0);
            Station8_title.Margin = new Thickness(0.01 * screen_width, 0.8 * scree_height, 0, 0);

            // 一号站数据名称
            station1_data1.Margin = new Thickness(0.13 * screen_width, 0.08 * scree_height, 0, 0);
            station2_data1.Margin = new Thickness(0.13 * screen_width, 0.18 * scree_height, 0, 0);
            station3_data1.Margin = new Thickness(0.13 * screen_width, 0.28 * scree_height, 0, 0);
            station4_data1.Margin = new Thickness(0.13 * screen_width, 0.38 * scree_height, 0, 0);
            station5_data1.Margin = new Thickness(0.13 * screen_width, 0.48 * scree_height, 0, 0);
            station6_data1.Margin = new Thickness(0.13 * screen_width, 0.58 * scree_height, 0, 0);
            station7_data1.Margin = new Thickness(0.13 * screen_width, 0.68 * scree_height, 0, 0);
            station8_data1.Margin = new Thickness(0.13 * screen_width, 0.78 * scree_height, 0, 0);

            // 二号站数据名称

            station1_data2.Margin = new Thickness(0.2 * screen_width, 0.08 * scree_height, 0, 0);
            station2_data2.Margin = new Thickness(0.2 * screen_width, 0.18 * scree_height, 0, 0);
            station3_data2.Margin = new Thickness(0.2 * screen_width, 0.28 * scree_height, 0, 0);
            station4_data2.Margin = new Thickness(0.2 * screen_width, 0.38 * scree_height, 0, 0);
            station5_data2.Margin = new Thickness(0.2 * screen_width, 0.48 * scree_height, 0, 0);
            station6_data2.Margin = new Thickness(0.2 * screen_width, 0.58 * scree_height, 0, 0);
            station7_data2.Margin = new Thickness(0.2 * screen_width, 0.68 * scree_height, 0, 0);
            station8_data2.Margin = new Thickness(0.2 * screen_width, 0.78 * scree_height, 0, 0);

            // 三号站数据名称

            station1_data3.Margin = new Thickness(0.27 * screen_width, 0.08 * scree_height, 0, 0);
            station2_data3.Margin = new Thickness(0.27 * screen_width, 0.18 * scree_height, 0, 0);
            station3_data3.Margin = new Thickness(0.27 * screen_width, 0.28 * scree_height, 0, 0);
            station4_data3.Margin = new Thickness(0.27 * screen_width, 0.38 * scree_height, 0, 0);
            station5_data3.Margin = new Thickness(0.27 * screen_width, 0.48 * scree_height, 0, 0);
            station6_data3.Margin = new Thickness(0.27 * screen_width, 0.58 * scree_height, 0, 0);
            station7_data3.Margin = new Thickness(0.27 * screen_width, 0.68 * scree_height, 0, 0);
            station8_data3.Margin = new Thickness(0.27 * screen_width, 0.78 * scree_height, 0, 0);

            // 四号站数据名称

            station1_data4.Margin = new Thickness(0.34 * screen_width, 0.08 * scree_height, 0, 0);
            station2_data4.Margin = new Thickness(0.34 * screen_width, 0.18 * scree_height, 0, 0);
            station3_data4.Margin = new Thickness(0.34 * screen_width, 0.28 * scree_height, 0, 0);
            station4_data4.Margin = new Thickness(0.34 * screen_width, 0.38 * scree_height, 0, 0);
            station5_data4.Margin = new Thickness(0.34 * screen_width, 0.48 * scree_height, 0, 0);
            station6_data4.Margin = new Thickness(0.34 * screen_width, 0.58 * scree_height, 0, 0);
            station7_data4.Margin = new Thickness(0.34 * screen_width, 0.68 * scree_height, 0, 0);
            station8_data4.Margin = new Thickness(0.34 * screen_width, 0.78 * scree_height, 0, 0);

            // 一号站数据

            data1_1.Margin = new Thickness(0.13 * screen_width, 0.12 * scree_height, 0, 0);
            data2_1.Margin = new Thickness(0.13 * screen_width, 0.22 * scree_height, 0, 0);
            data3_1.Margin = new Thickness(0.13 * screen_width, 0.32 * scree_height, 0, 0);
            data4_1.Margin = new Thickness(0.13 * screen_width, 0.42 * scree_height, 0, 0);
            data5_1.Margin = new Thickness(0.13 * screen_width, 0.52 * scree_height, 0, 0);
            data6_1.Margin = new Thickness(0.13 * screen_width, 0.62 * scree_height, 0, 0);
            data7_1.Margin = new Thickness(0.13 * screen_width, 0.72 * scree_height, 0, 0);
            data8_1.Margin = new Thickness(0.13 * screen_width, 0.82 * scree_height, 0, 0);

            // 二号站数据

            data1_2.Margin = new Thickness(0.2 * screen_width, 0.12 * scree_height, 0, 0);
            data2_2.Margin = new Thickness(0.2 * screen_width, 0.22 * scree_height, 0, 0);
            data3_2.Margin = new Thickness(0.2 * screen_width, 0.32 * scree_height, 0, 0);
            data4_2.Margin = new Thickness(0.2 * screen_width, 0.42 * scree_height, 0, 0);
            data5_2.Margin = new Thickness(0.2 * screen_width, 0.52 * scree_height, 0, 0);
            data6_2.Margin = new Thickness(0.2 * screen_width, 0.62 * scree_height, 0, 0);
            data7_2.Margin = new Thickness(0.2 * screen_width, 0.72 * scree_height, 0, 0);
            data8_2.Margin = new Thickness(0.2 * screen_width, 0.82 * scree_height, 0, 0);

            // 三号站数据

            data1_3.Margin = new Thickness(0.27 * screen_width, 0.12 * scree_height, 0, 0);
            data2_3.Margin = new Thickness(0.27 * screen_width, 0.22 * scree_height, 0, 0);
            data3_3.Margin = new Thickness(0.27 * screen_width, 0.32 * scree_height, 0, 0);
            data4_3.Margin = new Thickness(0.27 * screen_width, 0.42 * scree_height, 0, 0);
            data5_3.Margin = new Thickness(0.27 * screen_width, 0.52 * scree_height, 0, 0);
            data6_3.Margin = new Thickness(0.27 * screen_width, 0.62 * scree_height, 0, 0);
            data7_3.Margin = new Thickness(0.27 * screen_width, 0.72 * scree_height, 0, 0);
            data8_3.Margin = new Thickness(0.27 * screen_width, 0.82 * scree_height, 0, 0);

            // 四号站数据

            data1_4.Margin = new Thickness(0.34 * screen_width, 0.12 * scree_height, 0, 0);
            data2_4.Margin = new Thickness(0.34 * screen_width, 0.22 * scree_height, 0, 0);
            data3_4.Margin = new Thickness(0.34 * screen_width, 0.32 * scree_height, 0, 0);
            data4_4.Margin = new Thickness(0.34 * screen_width, 0.42 * scree_height, 0, 0);
            data5_4.Margin = new Thickness(0.34 * screen_width, 0.52 * scree_height, 0, 0);
            data6_4.Margin = new Thickness(0.34 * screen_width, 0.62 * scree_height, 0, 0);
            data7_4.Margin = new Thickness(0.34 * screen_width, 0.72 * scree_height, 0, 0);
            data8_4.Margin = new Thickness(0.34 * screen_width, 0.82 * scree_height, 0, 0);

            // 八个站的设定按键
            button_config1.Margin = new Thickness(0.39 * screen_width, 0.12 * scree_height, 0, 0);
            button_config2.Margin = new Thickness(0.39 * screen_width, 0.22 * scree_height, 0, 0);
            button_config3.Margin = new Thickness(0.39 * screen_width, 0.32 * scree_height, 0, 0);
            button_config4.Margin = new Thickness(0.39 * screen_width, 0.42 * scree_height, 0, 0);
            button_config5.Margin = new Thickness(0.39 * screen_width, 0.52 * scree_height, 0, 0);
            button_config6.Margin = new Thickness(0.39 * screen_width, 0.62 * scree_height, 0, 0);
            button_config7.Margin = new Thickness(0.39 * screen_width, 0.72 * scree_height, 0, 0);
            button_config8.Margin = new Thickness(0.39 * screen_width, 0.82 * scree_height, 0, 0);

            // 图标背景
            datachart.Margin = new Thickness(0.48* screen_width, 0.03 * scree_height, 0, 0);
            datachart.Width = screen_width * 0.49;
            datachart.Height = scree_height * 0.55;
            datachart.Child = chart;
            chart.Left = 0;
            chart.Top = 0;
            chart.Width = (int)datachart.Width;
            chart.Height = (int)datachart.Height;


        }
    }
}
