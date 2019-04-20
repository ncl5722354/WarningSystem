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
using System.Windows.Shapes;
using FileOperation;
using System.IO;
using String_Caozuo;
using System.Collections;
using SqlConnect;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WarningSystem
{
    /// <summary>
    /// PointChart.xaml 的交互逻辑
    /// </summary>
    public partial class PointChart : Window
    {
        TimeChart chart = new TimeChart();
        public PointChart()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            this.Width = MainWindow.screen_width * 0.7;
            this.Height = MainWindow.scree_height * 0.6;
            

            windowsformhost1.Margin = new Thickness(0, 0, 0, 0);
            windowsformhost1.Width = this.Width;
            windowsformhost1.Height = this.Height;

            
            windowsformhost1.Child = chart;
        }

        public void Reset_Position(double position)
        {
             
            // 读取所有的
            chart.Clear_Chart();
            this.Title = position.ToString() + "点位移趋势图";
            //DateTime newtime = new DateTime();
            //    DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect("D:\\data\\");

            //    ArrayList allpoints = MainWindow.Point_ini.ReadSections();            // 地图上所有的点
            //    bool is_exit = false;                                      // 是否在柱子上


            //    foreach (DirectoryInfo dir in dirs)
            //    {
            //        try
            //        {
            //            string nowtime_string = dir.Name;
            //            string nowtime_sub_string = nowtime_string.Substring(4, nowtime_string.Length - 4);
            //            string year = nowtime_sub_string.Substring(0, 4);
            //            string month = nowtime_sub_string.Substring(4, 2);
            //            string day = nowtime_sub_string.Substring(6, 2);
            //            string hour = nowtime_sub_string.Substring(8, 2);
            //            string min = nowtime_sub_string.Substring(10, 2);
            //            DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":00");
            //            if (nowtime > newtime) newtime = nowtime;
            //        }
            //        catch { }
            //    }


                // 基准
            string newpath = "D:\\data\\";


                

                ArrayList filelist = FileCaozuo.Read_All_Files(newpath, "*.txt");
                ArrayList timelist = new ArrayList();// 时间列表

                int read_index=0;
                double jizhun = 0; 
                int myindex = 0;




                DataTable dt = MainWindow.data_builder.Select_Table("position" + string_caozuo.Get_Dian_String(position.ToString(), 1) + string_caozuo.Get_Dian_String(position.ToString(), 2));
                 
                foreach(DataRow dr in dt.Rows)
                {
                    read_index++;
                    if (read_index == 1)
                    {
                        jizhun = double.Parse(dr[2].ToString());
                    }
                    if(read_index!=1)
                    {
                        double value = double.Parse(dr[2].ToString());
                        DateTime nowtime = DateTime.Parse(dr[1].ToString());
                        value = double.Parse(Jisuan_Weiyi(Math.Abs(value - jizhun)).ToString("#0.0000"));
                        chart.Insert(nowtime, value);
                    }
                }

                // 第一个文件就是基准
                //foreach (string name in filelist)
                //{
                //    // 每个文件的的名称
                //    // 基准里的每个点
                //    read_index++;
                //    string filename = string_caozuo.Get_Dian_String(name, 1);
                //    string mydate = string_caozuo.Get_HengGang_String(filename, 1);
                //    string mytime = string_caozuo.Get_HengGang_String(filename, 2);
                //    string year = string_caozuo.Get_Xiahuaxian_String(mydate, 1);
                //    string month = string_caozuo.Get_Xiahuaxian_String(mydate, 2);
                //    string day = string_caozuo.Get_Xiahuaxian_String(mydate, 3);

                //    string hour = string_caozuo.Get_Xiahuaxian_String(mytime, 1);
                //    string min = string_caozuo.Get_Xiahuaxian_String(mytime, 2);
                //    string sec = string_caozuo.Get_Xiahuaxian_String(mytime, 3);
                //    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec);
                //    //timelist.Add(nowtime);


                //    // 寻找每个文件中的某个点
                //    string myname = nowtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";    // 某个文件
                //    string[] all_line = FileCaozuo.Read_All_Line(newpath + myname);      // 读取文件中的所有项
                //    double myposition = 0;
                //    double value = 0;
                //    if(read_index!=1)
                //    {
                //        string str_new = all_line[myindex];
                //        //string str_old = all_line_old[i];
                //        myposition = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                //        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                //    }


                //    for (int i = 0; i < all_line.Length; i++)
                //    {
                //        if (read_index != 1) break;
                //        try
                //        {

                //            string str_new = all_line[i];
                //            //string str_old = all_line_old[i];
                //            myposition = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                //            value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                //            if(myposition.ToString("#0.000")==position.ToString("#0.000"))
                //            {
                //                myindex = i;
                //                break;
                //            }
                            

                //        }
                //        catch { }

                //        //int a = 0;
                //    }


                //    if(read_index==1)
                //    {
                //        jizhun = value;

                //    }
                //    else
                //    {
                //        value = double.Parse(Jisuan_Weiyi(Math.Abs(value - jizhun)).ToString("#0.0000"));
                //        chart.Insert(nowtime, value);
                //    }


                //}
        
        }
        public static double Jisuan_Weiyi(double value)
        {
            value = Math.Abs(value);
            value = (value - value * Math.Sqrt(3) / 2) / 0.0482;       // 应变 *1000/0.0482
            // 温度 *1000/1.12

            return value;
        }
    }
}
