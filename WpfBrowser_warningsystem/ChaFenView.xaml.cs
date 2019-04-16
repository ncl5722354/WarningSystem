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
using System.IO;
using System.Data;
using FileOperation;
using System.Collections;
using String_Caozuo;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// ChaFenView.xaml 的交互逻辑
    /// </summary>
    public partial class ChaFenView : UserControl
    {
        mychart chart = new mychart();
        
        public ChaFenView()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            windowsformshost.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            windowsformshost.Width = MainWindow.screen_width * 0.98;
            windowsformshost.Height = MainWindow.scree_height * 0.55;

            windowsformshost.Child = chart;
            chart.Left = 0;
            chart.Height = 0;
            chart.Width = (int)windowsformshost.Width + 1;
            chart.Height = (int)windowsformshost.Height + 1;

            grid1.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.6, 0, 0);
            grid1.Width = MainWindow.screen_width * 0.98;
            grid1.Height = MainWindow.scree_height * 0.1;

            grid2.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.7, 0, 0);
            grid2.Width = MainWindow.screen_width * 0.98;
            grid2.Height = MainWindow.scree_height * 0.1;

            grid3.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.8, 0, 0);
            grid3.Width = MainWindow.screen_width * 0.98;
            grid3.Height = MainWindow.scree_height * 0.1;

            grid4.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.9, 0, 0);
            grid4.Width = MainWindow.screen_width * 0.98;
            grid4.Height = MainWindow.scree_height * 0.1;

            chart.Set_Four();
        }

        private void line1_jizhun_mulu_combo_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void line1_jizhun_wenjian_combo_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void line1_mulu_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void line1_wenjian_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void button_line1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string line1_jizhun = MainWindow.path + line1_jizhun_mulu_combo.Text + "\\" + line1_jizhun_wenjian_combo.Items[line1_jizhun_wenjian_combo.SelectedIndex].ToString();
                string line1_string = MainWindow.path + line1_mulu.Text + "\\" + line1_wenjian.Items[line1_wenjian.SelectedIndex].ToString();

                string[] line1_jizhun_all_string = FileCaozuo.Read_All_Line(line1_jizhun);
                string[] line1_all_string = FileCaozuo.Read_All_Line(line1_string);

                chart.chart1.Series[0].Points.Clear();

                for (int i = 0; i < line1_jizhun_all_string.Length; i++)
                {
                    try
                    {
                        string str_new = line1_jizhun_all_string[i];
                        string str_old = line1_all_string[i];
                        double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        double value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        double value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue = Math.Abs(value - value_old) / 0.0482;
                       
                        chart.Insert_Point(position, MainWindow.Jisuan_Weiyi(myvalue));

                    }
                    catch { }
                }

            }
            catch { }
        }

        private void line1_jizhun_mulu_combo_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line1_jizhun_mulu_combo.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line1_jizhun_mulu_combo.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line1_jizhun_wenjian_combo_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line1_jizhun_mulu_combo.Text + "\\", "*.txt");
            line1_jizhun_wenjian_combo.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line1_jizhun_wenjian_combo.Items.Add(name);
                }
            }
            catch { }
        }

        private void line1_mulu_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line1_mulu.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line1_mulu.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line1_wenjian_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line1_mulu.Text + "\\", "*.txt");
            line1_wenjian.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line1_wenjian.Items.Add(name);
                }
            }
            catch { }
        }

        private void line2_jizhun_mulu_combo_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line2_jizhun_mulu_combo.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line2_jizhun_mulu_combo.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line2_jizhun_wenjian_combo_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line2_jizhun_mulu_combo.Text + "\\", "*.txt");
            line2_jizhun_wenjian_combo.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line2_jizhun_wenjian_combo.Items.Add(name);
                }
            }
            catch { }
        }

        private void line2_mulu_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line2_mulu.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line2_mulu.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line2_wenjian_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line2_mulu.Text + "\\", "*.txt");
            line2_wenjian.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line2_wenjian.Items.Add(name);
                }
            }
            catch { }
        }

        private void button_line2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string line1_jizhun = MainWindow.path + line2_jizhun_mulu_combo.Text + "\\" + line2_jizhun_wenjian_combo.Items[line2_jizhun_wenjian_combo.SelectedIndex].ToString();
                string line1_string = MainWindow.path + line2_mulu.Text + "\\" + line2_wenjian.Items[line2_wenjian.SelectedIndex].ToString();

                string[] line1_jizhun_all_string = FileCaozuo.Read_All_Line(line1_jizhun);
                string[] line1_all_string = FileCaozuo.Read_All_Line(line1_string);

                chart.chart1.Series[1].Points.Clear();

                for (int i = 0; i < line1_jizhun_all_string.Length; i++)
                {
                    try
                    {
                        string str_new = line1_jizhun_all_string[i];
                        string str_old = line1_all_string[i];
                        double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        double value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        double value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue = Math.Abs(value - value_old) / 0.0482;

                        chart.Insert_Point1(position, MainWindow.Jisuan_Weiyi(myvalue));

                    }
                    catch { }
                }

            }
            catch { }
        }

        private void line3_jizhun_mulu_combo_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line3_jizhun_mulu_combo.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line3_jizhun_mulu_combo.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line3_jizhun_wenjian_combo_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line3_jizhun_mulu_combo.Text + "\\", "*.txt");
            line3_jizhun_wenjian_combo.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line3_jizhun_wenjian_combo.Items.Add(name);
                }
            }
            catch { }
        }

        private void line3_mulu_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                line3_mulu.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    line3_mulu.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void line3_wenjian_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + line3_mulu.Text + "\\", "*.txt");
            line3_wenjian.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    line3_wenjian.Items.Add(name);
                }
            }
            catch { }
        }

        private void button_line3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string line1_jizhun = MainWindow.path + line3_jizhun_mulu_combo.Text + "\\" + line3_jizhun_wenjian_combo.Items[line3_jizhun_wenjian_combo.SelectedIndex].ToString();
                string line1_string = MainWindow.path + line3_mulu.Text + "\\" + line3_wenjian.Items[line3_wenjian.SelectedIndex].ToString();

                string[] line1_jizhun_all_string = FileCaozuo.Read_All_Line(line1_jizhun);
                string[] line1_all_string = FileCaozuo.Read_All_Line(line1_string);

                chart.chart1.Series[1].Points.Clear();

                for (int i = 0; i < line1_jizhun_all_string.Length; i++)
                {
                    try
                    {
                        string str_new = line1_jizhun_all_string[i];
                        string str_old = line1_all_string[i];
                        double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        double value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        double value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue = Math.Abs(value - value_old) / 0.0482;

                        chart.Insert_Point2(position, MainWindow.Jisuan_Weiyi(myvalue));

                    }
                    catch { }
                }

            }
            catch { }
        }
      
    }
}
