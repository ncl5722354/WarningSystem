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
    /// ValueConfig.xaml 的交互逻辑
    /// </summary>
    public partial class ValueConfig : UserControl
    {
        public ValueConfig()
        {
            InitializeComponent();
            //init_view();         
        }



        // 初始化界面
        public void init_view()
        {
            //maingrid.Children.Clear();

            maingrid.Margin = new Thickness(0, 0, 0, 0);
            maingrid.Width = this.Width;
            maingrid.Height = this.Height;

            mainscrollviewer.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            mainscrollviewer.Width = MainWindow.screen_width * 0.55;
            mainscrollviewer.Height = MainWindow.scree_height * 0.92;

            subgrid.Margin = new Thickness(0, 0, 0, 0);
            subgrid.Width = MainWindow.screen_width * 3;
            subgrid.Height = MainWindow.scree_height * 3;
            

            //subgrid.Margin=new Thickness(0,0,0,0);
            subgrid.Children.Clear();

            for(int i=0;i<=MainWindow.All_Vaule_Name.Count;i++)
            {
                ValueConfig_Item item = new ValueConfig_Item(MainWindow.Usercontrol_Config, MainWindow.All_Vaule_Name[i].ToString());
                subgrid.Children.Add(item);
                item.Margin = new Thickness(MainWindow.screen_width * 0.01, 2 + (MainWindow.scree_height * 0.06 + 2) * i, 0, 0);
                item.Width = MainWindow.screen_width * 0.6;
                item.Height = MainWindow.scree_height * 0.06;
            }
             //增加数据设置的列表
               
                
                //ValueConfig_Item item = new ValueConfig_Item(MainWindow.Usercontrol_Config, MainWindow.All_Vaule_Name[0].ToString());
                //maingrid.Children.Add(item);
                //item.Margin = new Thickness(MainWindow.screen_width * 0.01, 2, 0, 0);
                //item.Width = MainWindow.screen_width * 0.4;
                //item.Height = MainWindow.scree_height * 0.04;

                //ValueConfig_Item item1 = new ValueConfig_Item(MainWindow.Usercontrol_Config, MainWindow.All_Vaule_Name[1].ToString());
                //maingrid.Children.Add(item1);
                //item1.Margin = new Thickness(MainWindow.screen_width * 0.01, 2 + MainWindow.scree_height * 0.04 + 2, 0, 0);
                //item1.Width = MainWindow.screen_width * 0.4;
                //item1.Height = MainWindow.scree_height * 0.04;

                //ValueConfig_Item item2 = new ValueConfig_Item(MainWindow.Usercontrol_Config, MainWindow.All_Vaule_Name[2].ToString());
                //maingrid.Children.Add(item2);
                //item2.Margin = new Thickness(MainWindow.screen_width * 0.01, 2 + (MainWindow.scree_height * 0.04 +2)* 2 ,0, 0);
                //item2.Width = MainWindow.screen_width * 0.4;
                //item2.Height = MainWindow.scree_height * 0.04;

           
        }
    }
}
