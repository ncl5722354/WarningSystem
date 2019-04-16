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
using String_Caozuo;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// DataQushi.xaml 的交互逻辑
    /// </summary>
    public partial class DataQushi : UserControl
    {
        // 定义18个点
        TreeViewItem item0 = new TreeViewItem();
        TreeViewItem item11 = new TreeViewItem();
        TreeViewItem item21 = new TreeViewItem();
        TreeViewItem item31 = new TreeViewItem();
        TreeViewItem item41 = new TreeViewItem();
        TreeViewItem item51 = new TreeViewItem();
        TreeViewItem item61 = new TreeViewItem();
        TreeViewItem item71 = new TreeViewItem();
        TreeViewItem item81 = new TreeViewItem();
        TreeViewItem item91 = new TreeViewItem();
        TreeViewItem item101 = new TreeViewItem();
        TreeViewItem item111 = new TreeViewItem();
        TreeViewItem item121 = new TreeViewItem();
        TreeViewItem item131 = new TreeViewItem();
        TreeViewItem item141 = new TreeViewItem();
        TreeViewItem item151 = new TreeViewItem();
        TreeViewItem item161 = new TreeViewItem();
        TreeViewItem item171 = new TreeViewItem();
        

        public DataQushi()
        {
            InitializeComponent();
            init_view();                            // 画面的初始化
        }

        private void init_view()
        {
            // 选择基准标签
            label_select_jizhun.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.05, 0, 0);
            label_select_jizhun.Width = MainWindow.screen_width * 0.05;
            label_select_jizhun.Height = MainWindow.scree_height * 0.03;

            // 选择基准的下拉框
            cob_select_jizhun.Margin = new Thickness(MainWindow.screen_width * 0.07, MainWindow.scree_height * 0.05, 0, 0);
            cob_select_jizhun.Width = MainWindow.screen_width * 0.13;
            cob_select_jizhun.Height = MainWindow.scree_height * 0.03;

            // 选择树形图的外框
            treeviewscrollviewer.Margin = new Thickness(MainWindow.screen_width * 0.03, MainWindow.scree_height * 0.15, 0, 0);
            treeviewscrollviewer.Width = MainWindow.screen_width * 0.1;
            treeviewscrollviewer.Height = MainWindow.scree_height * 0.73;

            // 选择位置的树形图
            mytreeview.Margin = new Thickness(0, 0, 0, 0);
            mytreeview.Width = treeviewscrollviewer.Width;
            mytreeview.Height = treeviewscrollviewer.Height;
        }

        private void cob_select_jizhun_MouseEnter(object sender, MouseEventArgs e)
        {
            // 更新所有的数据信息
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path, "*.txt");
            cob_select_jizhun.Items.Clear();
            //combo_select_save.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    cob_select_jizhun.Items.Add(name);
                    //combo_select_save.Items.Add(name);
                }
            }
            catch { }

            
        }

        private void cob_select_jizhun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 更新树形图的信息

            // 0-10 的点
            item0 = new TreeViewItem();
            item0.Header = "0-10";

            // 11-20 的点
            item11 = new TreeViewItem();
            item11.Header = "11-20";

            // 21-30的点
            item21 = new TreeViewItem();
            item21.Header = "21-30";

            // 31-40的点
            item31 = new TreeViewItem();
            item31.Header = "31-40";

            // 41-50的点
            item41 = new TreeViewItem();
            item41.Header = "41-50";

            // 51-60的点
            item51 = new TreeViewItem();
            item51.Header = "51-60";

            // 61-70的点
            item61 = new TreeViewItem();
            item61.Header = "61-70";

            // 71-80的点
            item71 = new TreeViewItem();
            item71.Header = "71-80";

            // 81-90的点
            item81 = new TreeViewItem();
            item81.Header = "81-90";

            // 91-100的点
            item91 = new TreeViewItem();
            item91.Header = "91-100";

            // 101-110的点
            item101 = new TreeViewItem();
            item101.Header = "101-110";

            // 111-120的点
            item111 = new TreeViewItem();
            item111.Header = "111-120";

            // 121-130的点
            item121 = new TreeViewItem();
            item121.Header = "121-130";

            // 131-140的点
            item131 = new TreeViewItem();
            item131.Header = "131-140";

            // 141-150的点
            item141 = new TreeViewItem();
            item141.Header = "141-150";

            // 151-160的点
            item151 = new TreeViewItem();
            item151.Header = "151-160";

            // 161-170的点
            item161 = new TreeViewItem();
            item161.Header = "161-170";

            // 171-180的点
            item171 = new TreeViewItem();
            item171.Header = "171-180";

            
            
            mytreeview.Items.Clear();
            mytreeview.Items.Add(item0);
            mytreeview.Items.Add(item11);
            mytreeview.Items.Add(item21);
            mytreeview.Items.Add(item31);
            mytreeview.Items.Add(item41);
            mytreeview.Items.Add(item51);
            mytreeview.Items.Add(item61);
            mytreeview.Items.Add(item71);
            mytreeview.Items.Add(item81);
            mytreeview.Items.Add(item91);
            mytreeview.Items.Add(item101);
            mytreeview.Items.Add(item111);
            mytreeview.Items.Add(item121);
            mytreeview.Items.Add(item131);
            mytreeview.Items.Add(item141);
            mytreeview.Items.Add(item151);
            mytreeview.Items.Add(item161);
            mytreeview.Items.Add(item171);
            try
            {
                string filename = MainWindow.path + cob_select_jizhun.Items[cob_select_jizhun.SelectedIndex].ToString();

                // 将点加入曲线中
                string[] all_line = FileCaozuo.Read_All_Line(filename);
                foreach(string str in all_line)
                {
                    double position = double.Parse(string_caozuo.Get_Table_String(str, 1));
                    if (position >= 0 && position < 11)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item0.Items.Add(item);
                    }
                    if (position >= 11 && position < 21)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item11.Items.Add(item);
                    }
                    if (position >= 21 && position < 31)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item21.Items.Add(item);
                    }

                    if (position >= 31 && position < 41)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item31.Items.Add(item);
                    }

                    if (position >= 41 && position < 51)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item41.Items.Add(item);
                    }

                    if (position >= 51 && position < 61)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item51.Items.Add(item);
                    }
                    if (position >= 61 && position < 71)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item61.Items.Add(item);
                    }
                    if (position >= 71 && position < 81)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item71.Items.Add(item);
                    }

                    if (position >= 81 && position < 91)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item81.Items.Add(item);
                    }

                    if (position >= 91 && position < 101)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item91.Items.Add(item);
                    }

                    if (position >= 101 && position < 111)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item101.Items.Add(item);
                    }

                    if (position >= 111 && position < 121)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item111.Items.Add(item);
                    }

                    if (position >= 121 && position < 131)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item121.Items.Add(item);
                    }

                    if (position >= 131 && position < 141)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item131.Items.Add(item);
                    }

                    if (position >= 141 && position < 151)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item141.Items.Add(item);
                    }

                    if (position >= 151 && position < 161)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item151.Items.Add(item);
                    }

                    if (position >= 161 && position < 171)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item161.Items.Add(item);
                    }

                    if (position >= 171 && position < 181)
                    {
                        TreeViewItem item = new TreeViewItem();
                        item.Header = position.ToString();
                        item171.Items.Add(item);
                    }


                }
            }
            catch { }
        }
    }
}
