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
using System.Windows.Forms.DataVisualization;
using System.Collections;
using FileOperation;
using String_Caozuo;
using System.IO;
using System.Threading;
using System.ComponentModel;
using Microsoft.Win32;

namespace WarningSystem
{
    /// <summary>
    /// QuXian_View.xaml 的交互逻辑
    /// </summary>
    public partial class QuXian_View : UserControl
    {
        
        mychart mychart1 = new mychart();                 // 图表1
        mychart mycahrt2 = new mychart();                 // 图表2

        public static string[] all_line_old = null;
        public static string[] all_line_new = null;
        public static double value_old = 0;
        public static string jizhun = "";
        public static string select_save = "";
        public double pre_pos = -1;
        public int points_count = 0;
        public double sum_old = 0;
        public double sum_new = 0;


        bool Real_Time_Is = true;                        // 是否是实时显示

        // 计时器
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public QuXian_View()
        {
            
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            // 图表1的框
            chart1_formhost.Width = MainWindow.screen_width * 0.9;
            chart1_formhost.Height = MainWindow.scree_height * 0.4;
            chart1_formhost.Margin = new Thickness(MainWindow.screen_width * 0.05, MainWindow.scree_height * 0.0, 0, 0);
 
            // 图表1
            chart1_formhost.Child = mychart1;
            mychart1.Left = 0;
            mychart1.Top = 0;
            mychart1.Width = (int)chart1_formhost.Width+1;
            mychart1.Height = (int)chart1_formhost.Height+1;
            mychart1.Set_Series_Name("应变量");

            mychart1.chart1.ChartAreas[0].AxisY.Title = "应变量";

            // 图表2的框
            chart2_formhost.Width = MainWindow.screen_width * 0.9;
            chart2_formhost.Height = MainWindow.scree_height * 0.4;
            chart2_formhost.Margin = new Thickness(MainWindow.screen_width * 0.05, MainWindow.scree_height * 0.42, 0, 0);

            // 图表2
            chart2_formhost.Child = mycahrt2;
            mycahrt2.Left = 0;
            mycahrt2.Top = 0;
            mycahrt2.Width = (int)chart2_formhost.Width + 1;
            mycahrt2.Height = (int)chart2_formhost.Height + 1;
            mycahrt2.Set_Series_Name("位移量");

            mycahrt2.chart1.ChartAreas[0].AxisY.Title = "位移（毫米）";

            // 选择记录标签
            label_select_save.Margin = new Thickness(MainWindow.screen_width * 0.5, MainWindow.scree_height * 0.85, 0, 0);
            combo_select_save.Margin = new Thickness(MainWindow.screen_width * 0.6, MainWindow.scree_height * 0.85, 0, 0);

            // 选择基准标准
            label_select_jizhun.Margin = new Thickness(MainWindow.screen_width * 0.2, MainWindow.scree_height * 0.85, 0, 0);

            // 基准选择列表
            combo_select_jizhun.Margin = new Thickness(MainWindow.screen_width * 0.3, MainWindow.scree_height * 0.85, 0, 0);

            btn_save.Margin = new Thickness(MainWindow.screen_width * 0.5, MainWindow.scree_height * 0.85, 0, 0);

            // 计时器
            timer.Interval=2000;
            timer.Tick+=new EventHandler(Timer_Tick);
            timer.Enabled = true;

            show_real.Margin = new Thickness(MainWindow.screen_width * 0.05, MainWindow.scree_height * 0.85, 0, 0);
            show_shoudong.Margin = new Thickness(MainWindow.screen_width * 0.15, MainWindow.scree_height * 0.85, 0, 0);

            //Thread thread = new Thread(Draw_Lines);
            //thread.Start();
        }

        private void Draw_Lines()
        {
           
                Thread.Sleep(1000);
                //if (Real_Time_Is == false) return;

                // 显示时实数据
                string filename = "";
                try
                {
                    filename = MainWindow.path + jizhun + "\\" + select_save;
                }
                catch { }
                try
                {




                    ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + jizhun + "\\", "*.txt");
                    ArrayList timelist = new ArrayList();                                      // 时间列表
                    foreach (string name in filelist)
                    {
                        // 每个文件的的名称
                        string filename1 = string_caozuo.Get_Dian_String(name, 1);
                        string mydate = string_caozuo.Get_HengGang_String(filename1, 1);
                        string mytime = string_caozuo.Get_HengGang_String(filename1, 2);
                        string year = string_caozuo.Get_Xiahuaxian_String(mydate, 1);
                        string month = string_caozuo.Get_Xiahuaxian_String(mydate, 2);
                        string day = string_caozuo.Get_Xiahuaxian_String(mydate, 3);

                        string hour = string_caozuo.Get_Xiahuaxian_String(mytime, 1);
                        string min = string_caozuo.Get_Xiahuaxian_String(mytime, 2);
                        string sec = string_caozuo.Get_Xiahuaxian_String(mytime, 3);
                        DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec);
                        timelist.Add(nowtime);
                    }

                    DateTime maxtime = new DateTime();
                    DateTime mintime = DateTime.Now;
                    // 找出最近的时候
                    foreach (DateTime time in timelist)
                    {
                        if (time >= maxtime)
                        {
                            maxtime = time;
                        }
                        if (time < mintime)
                        {
                            mintime = time;
                        }
                    }

                    //updatetime = maxtime;       //更新时间
                    // 最新的文件就是maxtime的文件
                    string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
                    string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";


                    // 读取些文件信息
                    // 最新值


                    // 标准值
                    all_line_old = FileCaozuo.Read_All_Line(MainWindow.path + jizhun + "\\" + oldfilename);
                    all_line_new = FileCaozuo.Read_All_Line(MainWindow.path + jizhun + "\\" + nowfilename);
                    value_old = 0;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            

        }

        private void Timer_Tick(object sender,EventArgs e)
        {
                //Real_Data_List.Clear();
            if (Real_Time_Is == false) return;
            Thread thread = new Thread(Draw_Lines);
            thread.Start();

            mychart1.ReSet();  //图表1清除所有点
            mycahrt2.ReSet();  //图表2清除所有点

            //Draw_Lines();

            // 基准
            try
            {
                jizhun = combo_select_jizhun.Text;
                select_save = combo_select_save.Items[combo_select_save.SelectedIndex].ToString();
            }
            catch { }

            if (all_line_new == null) return;
                for (int i = 0; i < all_line_new.Length; i++)
                {
                    try
                    {
                        //if (i % 10 != 0) continue;
                        string str_new = all_line_new[i];
                        string str_old = all_line_old[i];
                        double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        double  value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                       
                        // 新的点的情况
                        
                                double  value1 = value;
                                double  value_old1 = value_old;
                                double myvalue = Math.Abs(value1 - value_old1);
                                if (MainWindow.Jisuan_Weiyi(myvalue) >= 0.05)
                                {
                                    mychart1.Insert_Point(position, myvalue);
                                    mycahrt2.Insert_Point(position, MainWindow.Jisuan_Weiyi(myvalue));
                                }
                           
                            
                        
                       
                    }
                    catch { }
                }

                for (int i = 1; i < mycahrt2.chart1.Series[0].Points.Count - 1;i++ )
                {

                    //mycahrt2.chart1.Series[0].Points[i].YValues[0] = (mycahrt2.chart1.Series[0].Points[i - 1].YValues[0] + mycahrt2.chart1.Series[0].Points[i + 1].YValues[0]) / 2;
                }
                    GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
           

        }

        private void maingrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            init_view();
        }

        private void combo_select_save_Drop(object sender, DragEventArgs e)
        {
            
        }

        private void combo_select_save_MouseEnter(object sender, MouseEventArgs e)
        {
            // 重新刷新文件列表
           
           


            
        }

        private void combo_select_save_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // 最新
                if (Real_Time_Is == true) return;
                string filename = MainWindow.path + combo_select_jizhun.Text + "\\" + combo_select_save.Items[combo_select_save.SelectedIndex].ToString();

                // 将点加入曲线中
                string[] all_line = FileCaozuo.Read_All_Line(filename);
                double position = 0;
                double value = 0;


                // 最早的点
                //string newpath = path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";


                ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + combo_select_jizhun.Text + "\\", "*.txt");
                ArrayList timelist = new ArrayList();                                      // 时间列表
                foreach (string name in filelist)
                {
                    // 每个文件的的名称
                    string filename1 = string_caozuo.Get_Dian_String(name, 1);
                    string mydate = string_caozuo.Get_HengGang_String(filename1, 1);
                    string mytime = string_caozuo.Get_HengGang_String(filename1, 2);
                    string year = string_caozuo.Get_Xiahuaxian_String(mydate, 1);
                    string month = string_caozuo.Get_Xiahuaxian_String(mydate, 2);
                    string day = string_caozuo.Get_Xiahuaxian_String(mydate, 3);

                    string hour = string_caozuo.Get_Xiahuaxian_String(mytime, 1);
                    string min = string_caozuo.Get_Xiahuaxian_String(mytime, 2);
                    string sec = string_caozuo.Get_Xiahuaxian_String(mytime, 3);
                    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec);
                    timelist.Add(nowtime);
                }

                DateTime maxtime = new DateTime();
                DateTime mintime = DateTime.Now;
                // 找出最近的时候
                foreach (DateTime time in timelist)
                {
                    if (time >= maxtime)
                    {
                        maxtime = time;
                    }
                    if (time < mintime)
                    {
                        mintime = time;
                    }
                }

                //updatetime = maxtime;       //更新时间
                // 最新的文件就是maxtime的文件
                string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
                string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";


                // 读取些文件信息
                // 最新值


                // 标准值
                string[] all_line_old = FileCaozuo.Read_All_Line(MainWindow.path + combo_select_jizhun.Text + "\\" + oldfilename);
                double value_old = 0;


                //Real_Data_List.Clear();
                mychart1.ReSet();  //图表1清除所有点
                mycahrt2.ReSet();  //图表2清除所有点

                for (int i = 0; i < all_line.Length; i++)
                {
                    try
                    {
                        string str_new = all_line[i];
                        string str_old = all_line_old[i];
                        position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue = Math.Abs(value - value_old);
                        //DataList.Data_Struct datasrtuct = new DataList.Data_Struct();
                        //datasrtuct.位置 = position;
                        //datasrtuct.位置X = 0;
                        //datasrtuct.位置Y = 0;
                        //datasrtuct.应变量 = Math.Abs(value - value_old);
                        //datasrtuct.位移量 = Jisuan_Weiyi(Math.Abs(value - value_old));
                        //Real_Data_List.Add(datasrtuct);
                        //try
                        //{
                        //    position = double.Parse(string_caozuo.Get_Table_String(str, 1));
                        //    value = double.Parse(string_caozuo.Get_Table_String(str, 2));
                        //}
                        //catch { }



                        
                            mychart1.Insert_Point(position, myvalue);
                            mycahrt2.Insert_Point(position, MainWindow.Jisuan_Weiyi(myvalue));
                        

                    }
                    catch { }

                    //

                   
                    //foreach (string str in all_line)
                    //{
                    //    try
                    //    {
                    //        position = double.Parse(string_caozuo.Get_Table_String(str, 1));
                    //        value = double.Parse(string_caozuo.Get_Table_String(str, 2));
                    //    }
                    //    catch { }




                    //    mychart1.Insert_Point(position, value);
                    //    mycahrt2.Insert_Point(position, MainWindow.Jisuan_Weiyi(value));

                    //}
                }
            }
            catch { }
        }

        private void combo_select_jizhun_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void combo_select_jizhun_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void show_real_Click(object sender, RoutedEventArgs e)
        {
            Real_Time_Is = true;
        }

        private void show_shoudong_Click(object sender, RoutedEventArgs e)
        {
            Real_Time_Is = false;
        }

        private void combo_select_jizhun_DropDownOpened(object sender, EventArgs e)
        {
            // 刷新基准 与 日期
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                combo_select_jizhun.Items.Clear();
                for (int i = 0; i < dirs.Length; i++)
                {
                    combo_select_jizhun.Items.Add(dirs[i].Name);
                }
            }
            catch { }
        }

        private void combo_select_save_DropDownOpened(object sender, EventArgs e)
        {
            ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + combo_select_jizhun.Text + "\\", "*.txt");
            combo_select_save.Items.Clear();
            try
            {
                foreach (string name in filelist)
                {
                    combo_select_save.Items.Add(name);
                }
            }
            catch { }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
          
                saveFile.Filter = "文本文件(*.txt)|*.txt";
                if (saveFile.ShowDialog() == true)
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(saveFile.FileName, true);
                        string[] lines = FileCaozuo.Read_All_Line(MainWindow.path + combo_select_jizhun.Text + "\\" + combo_select_save.Text);

                        foreach (string line in lines)
                        {
                            sw.WriteLine(line);
                        }

                        sw.Close();
                        MessageBox.Show("文件保存成功！", "温馨提示");
                    }
                    catch { MessageBox.Show("文件保存失败！","温馨提示"); }
                    //filePath = saveFile.FileName;
                }

                //if (textFileName.Equals(""))
                //{
                //    FileInfo fileInfo = new FileInfo(saveFile.FileName);
                //    //Text = fileInfo.Name;
                //    //textFileName = fileInfo.Name;
                //}
                //else
                //{

                //    //Text = textFileName;
                //}



        }


    }
}
