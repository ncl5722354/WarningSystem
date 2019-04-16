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
    /// Zongmao.xaml 的交互逻辑
    /// </summary>
    public partial class Zongmao : UserControl
    {

        private int page=0;
        public Zongmao()
        {
            InitializeComponent();
            init_view();             // 初始化界面
        }

        // 用来设定页码
        public void Set_Page(int mypage)
        {
            page = mypage;                   // 设
            zongmao1.Set_Machine_Num((mypage - 1) * 8 + 1);
            zongmao2.Set_Machine_Num((mypage - 1) * 8 + 2);
            zongmao3.Set_Machine_Num((mypage - 1) * 8 + 3);
            zongmao4.Set_Machine_Num((mypage - 1) * 8 + 4);
            zongmao5.Set_Machine_Num((mypage - 1) * 8 + 5);
            zongmao6.Set_Machine_Num((mypage - 1) * 8 + 6);
            zongmao7.Set_Machine_Num((mypage - 1) * 8 + 7);
            zongmao8.Set_Machine_Num((mypage - 1) * 8 + 8);
        }

        // 初始化界面
        private void init_view()
        {
            // 总貌1副界面
            zongmao1.Margin = new Thickness(MainWindow.screen_width * 0.005, MainWindow.scree_height * 0.01, 0, 0);
            zongmao1.Width = MainWindow.screen_width * 0.2;
            zongmao1.Height = MainWindow.scree_height * 0.4;

            // 总貌2副界面
            zongmao2.Margin = new Thickness(MainWindow.screen_width * 0.21, MainWindow.scree_height * 0.01, 0, 0);
            zongmao2.Width = MainWindow.screen_width * 0.2;
            zongmao2.Height = MainWindow.scree_height * 0.4;

            // 总貌3副界面
            zongmao3.Margin = new Thickness(MainWindow.screen_width * 0.415, MainWindow.scree_height * 0.01, 0, 0);
            zongmao3.Width = MainWindow.screen_width * 0.2;
            zongmao3.Height = MainWindow.scree_height * 0.4;

            // 总貌4副界面
            zongmao4.Margin = new Thickness(MainWindow.screen_width * 0.62, MainWindow.scree_height * 0.01, 0, 0);
            zongmao4.Width = MainWindow.screen_width * 0.2;
            zongmao4.Height = MainWindow.scree_height * 0.4;

            // 总貌5副界面
            zongmao5.Margin = new Thickness(MainWindow.screen_width * 0.005, MainWindow.scree_height * 0.45, 0, 0);
            zongmao5.Width = MainWindow.screen_width * 0.2;
            zongmao5.Height = MainWindow.scree_height * 0.4;

            // 总貌6副界面
            zongmao6.Margin = new Thickness(MainWindow.screen_width * 0.21, MainWindow.scree_height * 0.45, 0, 0);
            zongmao6.Width = MainWindow.screen_width * 0.2;
            zongmao6.Height = MainWindow.scree_height * 0.4;

            // 总貌7副界面
            zongmao7.Margin = new Thickness(MainWindow.screen_width * 0.415, MainWindow.scree_height * 0.45, 0, 0);
            zongmao7.Width = MainWindow.screen_width * 0.2;
            zongmao7.Height = MainWindow.scree_height * 0.4;

            // 总貌8副界面
            zongmao8.Margin = new Thickness(MainWindow.screen_width * 0.62, MainWindow.scree_height * 0.45, 0, 0);
            zongmao8.Width = MainWindow.screen_width * 0.2;
            zongmao8.Height = MainWindow.scree_height * 0.4;
        }
    }
}
