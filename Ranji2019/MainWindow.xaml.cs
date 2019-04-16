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
using FileOperation;

namespace Ranji2019
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    ///  80台机缸版本

    public partial class MainWindow : Window
    {
        public static double screen_width = SystemParameters.PrimaryScreenWidth;    // 屏幕宽度
        public static double scree_height = SystemParameters.PrimaryScreenHeight;   // 屏幕高度

        ArrayList all_subview = new ArrayList();                                    // 所有的副窗体
        public static ArrayList All_Vaule_Name = new ArrayList();                   // 所有的变量名

        // 所有自定义控件保存的文件
        public static IniFile Usercontrol_Config = new IniFile("D:\\ranji3.0 config\\usercontrol_config.ini");

        // 总貌窗体
        Zongmao zongmao = new Zongmao();

        // 数据设置窗体
        ValueConfig valueconfig = new ValueConfig();
        
        // 生产排产窗体
        ShenChanPaiChan_View shenchanpaichan_view = new ShenChanPaiChan_View();
        public MainWindow()
        {
            InitializeComponent();
            init_view();                // 画面初始化
            init_value();
            All_Hide();
        }

        // 初始化所有的变量
        private void init_value()
        {
            // 开关量
            All_Vaule_Name.Add("开始");
            All_Vaule_Name.Add("暂停");

            All_Vaule_Name.Add("升温");
            All_Vaule_Name.Add("降温");

            All_Vaule_Name.Add("进水一");
            All_Vaule_Name.Add("进水二");
            All_Vaule_Name.Add("进水三");
            All_Vaule_Name.Add("进水四");

            All_Vaule_Name.Add("出水一");
            All_Vaule_Name.Add("出水二");
            All_Vaule_Name.Add("出水三");
            All_Vaule_Name.Add("出水四");

            All_Vaule_Name.Add("溢流一");
            All_Vaule_Name.Add("溢流二");

            All_Vaule_Name.Add("疏水");

            All_Vaule_Name.Add("排气");

            All_Vaule_Name.Add("料缸进水");
            All_Vaule_Name.Add("料缸排水");
            All_Vaule_Name.Add("料缸回流");
            All_Vaule_Name.Add("料缸搅拌");
            All_Vaule_Name.Add("料缸进料大");
            All_Vaule_Name.Add("料缸进料小");

            // 模拟量
            All_Vaule_Name.Add("主缸温度");
            All_Vaule_Name.Add("主缸水位");
            All_Vaule_Name.Add("料缸水位");
            All_Vaule_Name.Add("运行时间");
            All_Vaule_Name.Add("工艺时间");
            All_Vaule_Name.Add("运行段号");
        }

        // 全部隐藏
        private void All_Hide()
        {
            foreach(UserControl control in all_subview)
            {
                control.Visibility = Visibility.Hidden;
            }
        }

        // 画面初始化
        private void init_view()
        {
            this.Left = 0;
            this.Top = 0;
            this.Width = screen_width;
            this.Height = scree_height;

            // 退出按钮
            btn_systemcolse.Margin = new Thickness(0.93 * screen_width, 0.03 * scree_height, 0, 0);
            btn_systemcolse.Width = 0.05 * screen_width;
            btn_systemcolse.Height = 0.03 * scree_height;

            // 主树形图
               // scrollerview  树形图容器
            maintreeview_scrollviewer.Margin = new Thickness(0.03 * screen_width, 0.08 * scree_height, 0, 0);
            maintreeview_scrollviewer.Width = 0.12 * screen_width;
            maintreeview_scrollviewer.Height = 0.9 * scree_height;

              // treeview 树形图
            maintreeview.Margin = new Thickness(0, 0, 0, 0);
            maintreeview.Width = maintreeview_scrollviewer.Width;
            maintreeview.Height = maintreeview_scrollviewer.Height;

            init_treeview();    // 主树形图的初始化

            // subviewgrid
            subviewgird.Margin = new Thickness(0.16 * screen_width, 0.08 * scree_height, 0, 0);
            subviewgird.Width = screen_width * 0.83;
            subviewgird.Height = scree_height * 0.9;

            // 标题
            label_title.Margin = new Thickness(0.18 * screen_width, 0.01 * scree_height, 0, 0);
            label_title.Width = screen_width * 0.5;
            label_title.Height = scree_height * 0.08;

            // 总貌窗体
            subviewgird.Children.Add(zongmao);
            all_subview.Add(zongmao);

            // 数据设置
            subviewgird.Children.Add(valueconfig);
            all_subview.Add(valueconfig);

            // 生产排产窗体
            subviewgird.Children.Add(shenchanpaichan_view);
            all_subview.Add(shenchanpaichan_view);
           
        }

        // 退出按钮
        private void btn_systemcolse_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("是否退出系统","退出系统",MessageBoxButton.OKCancel);
            if(result==MessageBoxResult.OK)
            {
                System.Environment.Exit(0);
            }
        }

        // 初始化主树形图
        private void init_treeview()
        {
            // 定义总貌的项
            TreeViewItem zongmao = new TreeViewItem();           // 总貌项
            zongmao.Header = "总貌";
            maintreeview.Items.Add(zongmao);

            // 总貌有十页
            for(int i=1;i<=10;i++)
            {
                TreeViewItem zongmao_n = new TreeViewItem();
                zongmao_n.Header = "总貌页" + i.ToString();
                zongmao.Items.Add(zongmao_n);
            }

            // 定义选择机台的项
            TreeViewItem jitai = new TreeViewItem();
            jitai.Header = "机台";
            maintreeview.Items.Add(jitai);

            // 机台一共有80个
            for (int i = 1; i <= 60; i++)
            {
                TreeViewItem jitai_n = new TreeViewItem();
                jitai_n.Header = "机台号"+i.ToString();
                jitai.Items.Add(jitai_n);
            }         

            // 定义数据设置
            TreeViewItem valueconfigitem = new TreeViewItem();
            valueconfigitem.Header = "数据设定";
            maintreeview.Items.Add(valueconfigitem);

            // 定义排产生产
            TreeViewItem paichanitem = new TreeViewItem();
            paichanitem.Header = "排产生产";
            maintreeview.Items.Add(paichanitem);
        }

        private void Show_View(UserControl view)
        {
            All_Hide();
            view.Margin = new Thickness(0, 0, 0, 0);
            view.Width = subviewgird.Width;
            view.Height = subviewgird.Height;
            view.Visibility = Visibility.Visible;
        }

        private void maintreeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = (TreeViewItem)maintreeview.SelectedItem;
            try
            {
                string select_string = (string)item.Header;
                if (select_string.Substring(0, 3) == "总貌页")
                {
                    string value = select_string.Substring(3, select_string.Length - 3);
                    int page = int.Parse(value);
                    Show_View(zongmao);
                    zongmao.Set_Page(page);
                }
                if (select_string == "数据设定")
                {
                   
                    Show_View(valueconfig);
                    valueconfig.init_view();
                }
                if(select_string=="排产生产")
                {
                    Show_View(shenchanpaichan_view);  // 生产排产窗体
                    shenchanpaichan_view.init_view();

                }
            }
            catch
            {

            }
        }
    }
}
