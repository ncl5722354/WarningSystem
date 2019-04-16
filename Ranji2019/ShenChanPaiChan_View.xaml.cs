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
    /// ShenChanPaiChan_View.xaml 的交互逻辑
    /// </summary>
    public partial class ShenChanPaiChan_View : UserControl
    {
        public ShenChanPaiChan_View()
        {
            InitializeComponent();
            init_view();                               // 窗体的初始化
        }

        public static ArrayList all_paichan_tiao = new ArrayList();            // 所有的排产条

        // 窗体的初始化
        public  void init_view()
        {
            scrollviewer.Margin = new Thickness(0.02 * MainWindow.screen_width, 0.1 * MainWindow.scree_height, 0, 0);
            scrollviewer.Width = 0.75 * MainWindow.screen_width;
            scrollviewer.Height = 0.75 * MainWindow.scree_height;

            SolidColorBrush solidbrush=new SolidColorBrush();
            solidbrush.Color=Color.FromRgb(0,0,0);       // 黑色

            subgrid.Children.Clear();

            // 80个机缸的排产

            for (int i = 0; i < 80; i++)
            {
                ShengchanPaichan_Tiao tiao = new ShengchanPaichan_Tiao();
                tiao.Margin = new Thickness(50,  (MainWindow.scree_height * 0.1)*i + 100, 0, 0);
                tiao.Width = 23 * (MainWindow.screen_width * 0.1) + (MainWindow.screen_width * 0.1 / 6 * (4 + 1));
                tiao.Height = MainWindow.scree_height * 0.05;
                subgrid.Children.Add(tiao);
                all_paichan_tiao.Add(tiao);

               
                // 标签
                for (int j = 0; j < 6; j++)
                {
                    Label mylabel = new Label();
                    mylabel.Content = (i + 1).ToString() + "号机";
                    mylabel.Margin = new Thickness(50 + MainWindow.screen_width * 0.4 * j, (MainWindow.scree_height * 0.1) * i + 80, 0, 0);
                    subgrid.Children.Add(mylabel);

                }

                ShengchanPaichan_Item myitme = new ShengchanPaichan_Item("1111", DateTime.Parse("2018-11-1 00:12:20"), DateTime.Parse("2018-11-1 01:14:30"), ShengchanPaichan_Item.Panchan_State.ready);
                ArrayList list = new ArrayList();
                list.Add(myitme);
                tiao.all_items = list;
                tiao.Set_All_Item();
            }
            //
            // 24个刻度
            for (int i = 0; i < 24; i++)
            {
                // 小时刻度尺
                Rectangle Hour_Rectagnle = new Rectangle();
                Hour_Rectagnle.Width = 3;
                Hour_Rectagnle.Height = 20;
                Hour_Rectagnle.Fill = solidbrush;
                Hour_Rectagnle.HorizontalAlignment = HorizontalAlignment.Left;
                Hour_Rectagnle.VerticalAlignment = VerticalAlignment.Top;
                Hour_Rectagnle.Margin = new Thickness(i * (MainWindow.screen_width * 0.1 ) + 50, 5, 0, 0);
                //Thickness thic = Hour_Rectagnle.Margin;
                subgrid.Children.Add(Hour_Rectagnle);

                // 分钟刻度尺
                for (int j = 0; j < 5; j++)
                {
                    Rectangle Min_Rectagnle = new Rectangle();
                    Min_Rectagnle.Width = 1;
                    Min_Rectagnle.Height = 10;
                    Min_Rectagnle.Fill = solidbrush;
                    Min_Rectagnle.HorizontalAlignment = HorizontalAlignment.Left;
                    Min_Rectagnle.VerticalAlignment = VerticalAlignment.Top;
                    Min_Rectagnle.Margin = new Thickness(i * (MainWindow.screen_width * 0.1)+(MainWindow.screen_width*0.1/6*(j+1)) + 50, 5, 0, 0);
                    //Thickness thic = Hour_Rectagnle.Margin;
                    subgrid.Children.Add(Min_Rectagnle);
                }

                // 小时标签
                Label hourlabel = new Label();
                hourlabel.Width = 50;
                hourlabel.Height = 25;
                hourlabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                hourlabel.VerticalContentAlignment = VerticalAlignment.Center;
                hourlabel.HorizontalAlignment = HorizontalAlignment.Left;
                hourlabel.VerticalAlignment = VerticalAlignment.Top;
                hourlabel.Margin = new Thickness(i * (MainWindow.screen_width * 0.1) + 25, 25, 0, 0);
                hourlabel.Content = i.ToString().PadLeft(2, '0') + ":00";
                subgrid.Children.Add(hourlabel);

                // 分钟标签

                for (int j = 0; j < 5; j++)
                {
                    Label Min_Label = new Label();
                    Min_Label.Width = 50;
                    Min_Label.Height = 25;
                    Min_Label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    Min_Label.VerticalContentAlignment = VerticalAlignment.Center;
                    Min_Label.HorizontalAlignment = HorizontalAlignment.Left;
                    Min_Label.VerticalAlignment = VerticalAlignment.Top;
                    Min_Label.Margin = new Thickness(i * (MainWindow.screen_width * 0.1) + (MainWindow.screen_width * 0.1 / 6 * (j + 1)) + 25, 10, 0, 0);
                    //Thickness thic = Hour_Rectagnle.Margin;
                    subgrid.Children.Add(Min_Label);
                    Min_Label.Content = ((j + 1) * 10).ToString();
                }
            }
           
        }
    }
}
