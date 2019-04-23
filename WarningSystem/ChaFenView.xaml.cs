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
using System.Threading;

namespace WarningSystem
{
    /// <summary>
    /// ChaFenView.xaml 的交互逻辑
    /// 差分需要修改为选择数据组，选择前一次和后一次的日期，然后进行对比
    /// </summary>
    public partial class ChaFenView : UserControl
    {
        mychart chart = new mychart();
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public static MessageBox messagebox;
        string path = "";


        string line1_jizhun = "";
        string[] line1_jizhun_all_string = null;
        string[] line1_all_string = null;
        string[] line2_jizhun_all_string = null;
        string[] line2_all_string = null;
        int allcount = 0;

        public static chulizhong chulizhongview = new chulizhong();

        string line1_string = "";
        //string line2_jizhun = "";
        string line2_string = "";
        
        ArrayList kuang1 = new ArrayList();
        ArrayList kuang2 = new ArrayList();
        
        public ChaFenView()
        {
            InitializeComponent();
            init();
        }




        public void Show_yuzhi()
        {
            txt_yuzhi.Text = MainWindow.Report_Config.IniReadValue("yuzhi", "yuzhi");
            chart.Set_Yuzhi(MainWindow.yuzhi);
        }

        private void Tick(object sender,EventArgs e)
        {
            Thread thread = new Thread(Update_Kuang);
            thread.Start();
        }


        private void Update_Kuang()
        {

            path = Get_Newest_MuLu();
            ArrayList filelist = FileCaozuo.Read_All_Files(path + "\\", "*.txt");

            try
            {
                //path = Get_Newest_MuLu();
                line1_jizhun = path + "\\" + Get_JiZhun();
                line1_jizhun_all_string = FileCaozuo.Read_All_Line(line1_jizhun);
                
                
           }
            catch { }

            try
            {
                foreach (string name in filelist)
                {
                    if (kuang1.IndexOf(name) == -1)
                    {
                        kuang1.Add(name);
                    }
                    if (kuang2.IndexOf(name) == -1)
                    {
                        kuang2.Add(name);
                    }
                   

                }
               
            }
            catch { }

            

          
        }

        private void init()
        {

            timer1.Interval = 15000;
            timer1.Tick += new EventHandler(Tick);
            timer1.Enabled = true;
           

            windowsformshost.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            windowsformshost.Width = MainWindow.screen_width * 0.98;
            windowsformshost.Height = MainWindow.scree_height * 0.7;

            windowsformshost.Child = chart;
            chart.Left = 0;
            chart.Height = 0;
            chart.Width = (int)windowsformshost.Width + 1;
            chart.Height = (int)windowsformshost.Height + 1;

            chart.Set_Series_Name("1号变化量mm");
            chart.Set_Series_Name1("2号变化量mm");


            grid1.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.75, 0, 0);
            grid1.Width = MainWindow.screen_width * 0.98;
            grid1.Height = MainWindow.scree_height * 0.1;

            grid2.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.8, 0, 0);
            grid2.Width = MainWindow.screen_width * 0.98;
            grid2.Height = MainWindow.scree_height * 0.1;

            grid3.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.8, 0, 0);
            grid3.Width = MainWindow.screen_width * 0.98;
            grid3.Height = MainWindow.scree_height * 0.1;

            grid4.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.8, 0, 0);
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
                        if (i % 10 == 0)
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


        private string Get_JiZhun()
        {
            DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);   // 所有的目录
            bool is_exit = false;                                      // 是否在柱子上
            DateTime newtime = new DateTime();

            foreach (DirectoryInfo dir in dirs)
            {
                try
                {
                    string nowtime_string = dir.Name;
                    string nowtime_sub_string = nowtime_string.Substring(4, nowtime_string.Length - 4);
                    string year = nowtime_sub_string.Substring(0, 4);
                    string month = nowtime_sub_string.Substring(4, 2);
                    string day = nowtime_sub_string.Substring(6, 2);
                    string hour = nowtime_sub_string.Substring(8, 2);
                    string min = nowtime_sub_string.Substring(10, 2);
                    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":00");
                    if (nowtime > newtime) newtime = nowtime;
                }
                catch { }
            }

            string newpath = MainWindow.path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";

            ArrayList filelist = FileCaozuo.Read_All_Files(newpath, "*.txt");
            ArrayList timelist = new ArrayList();                                      // 时间列表
            foreach (string name in filelist)
            {
                // 每个文件的的名称
                string filename = string_caozuo.Get_Dian_String(name, 1);
                string mydate = string_caozuo.Get_HengGang_String(filename, 1);
                string mytime = string_caozuo.Get_HengGang_String(filename, 2);
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

            MainWindow.updatetime = maxtime;       //更新时间
            // 最新的文件就是maxtime的文件
            string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
            string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
            return oldfilename;
        }

        private string  Get_Newest_MuLu()
        {
            DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);   // 所有的目录
            bool is_exit = false;                                      // 是否在柱子上
            DateTime newtime = new DateTime();

            foreach (DirectoryInfo dir in dirs)
            {
                try
                {
                    string nowtime_string = dir.Name;
                    string nowtime_sub_string = nowtime_string.Substring(4, nowtime_string.Length - 4);
                    string year = nowtime_sub_string.Substring(0, 4);
                    string month = nowtime_sub_string.Substring(4, 2);
                    string day = nowtime_sub_string.Substring(6, 2);
                    string hour = nowtime_sub_string.Substring(8, 2);
                    string min = nowtime_sub_string.Substring(10, 2);
                    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":00");
                    if (nowtime > newtime) newtime = nowtime;
                }
                catch { }
            }

            string newpath = MainWindow.path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";
            return newpath;
        }


            //ArrayList filelist = FileCaozuo.Read_All_Files(newpath, "*.txt");
            //ArrayList timelist = new ArrayList();                                      // 时间列表
            //foreach (string name in filelist)
            //{
            //    // 每个文件的的名称
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
            //    timelist.Add(nowtime);
            //}

            //DateTime maxtime = new DateTime();
            //DateTime mintime = DateTime.Now;
            //// 找出最近的时候
            //foreach (DateTime time in timelist)
            //{
            //    if (time >= maxtime)
            //    {
            //        maxtime = time;
            //    }
            //    if (time < mintime)
            //    {
            //        mintime = time;
            //    }
            //}

            //MainWindow.updatetime = maxtime;       //更新时间
            //// 最新的文件就是maxtime的文件
            //string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
            //string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";


            //// 读取些文件信息
            //// 最新值
            //string[] all_line = FileCaozuo.Read_All_Line(newpath + nowfilename);



            //double position = 0;
            //double value = 0;

            //// 标准值
            //string[] all_line_old = FileCaozuo.Read_All_Line(newpath + oldfilename);
            //double value_old = 0;


            ////MainWindow.Real_Data_List.Clear();

            //for (int i = 0; i < all_line.Length; i++)
            //{
            //    try
            //    {

            //        string str_new = all_line[i];
            //        string str_old = all_line_old[i];
            //        position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
            //        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
            //        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

            //        DataList.Data_Struct datasrtuct = new DataList.Data_Struct();
            //        datasrtuct.位置 = position;
            //        datasrtuct.位置X = 0;
            //        datasrtuct.位置Y = 0;
            //        datasrtuct.应变量 = double.Parse(Math.Abs(value - value_old).ToString("#0.0000"));
            //        datasrtuct.位移量 = double.Parse(Jisuan_Weiyi(Math.Abs(value - value_old)).ToString("#0.0000"));
            //        // 将值放入数据队列中
            //        if (MainWindow.Real_Data_List.Count < all_line.Length)
            //        {
            //            MainWindow.Real_Data_List.Add(datasrtuct);
            //            MainWindow.Dizhi_Index.Add(position);
            //        }
            //        else
            //        {
            //            MainWindow.Real_Data_List[i] = datasrtuct;
            //            MainWindow.Dizhi_Index[i] = position;
            //        }

            //    }
            //    catch { }

            //    //int a = 0;
            //}
        


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

            //string path = Get_Newest_MuLu();
            //ArrayList filelist = FileCaozuo.Read_All_Files(path + "\\", "*.txt");
            line1_wenjian.Items.Clear();
            try
            {
                foreach (string name in kuang1)
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
            //string path = Get_Newest_MuLu();
            //ArrayList filelist = FileCaozuo.Read_All_Files(path + "\\", "*.txt");
            line2_wenjian.Items.Clear();
            try
            {
                foreach (string name in kuang2)
                {
                    line2_wenjian.Items.Add(name);
                }
            }
            catch { }
        }

        private void Show_Thread1()
        {

            
            
           line1_all_string = FileCaozuo.Read_All_Line(line1_string);
            
            // 组二
            //try
            //{
            //    //line2_jizhun = path + "\\" + Get_JiZhun();
                

            //    //line2_jizhun_all_string = FileCaozuo.Read_All_Line(line2_jizhun);

            //    allcount = line2_jizhun_all_string.Length;
            //}
            //catch { }
           // chulizhongview.Close();
        }

        private void Show_Thread2()
        {
            line2_all_string = FileCaozuo.Read_All_Line(line2_string);
        }

        private void button_line2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                chart.chart1.Series[0].Points.Clear();
                chart.chart1.Series[1].Points.Clear();
                try
                {





                    allcount = line1_jizhun_all_string.Length;
                }
                catch { }
                //MessageBox.Show()
               
                // 读最大的文件
                
               
                // 组一
                //Thread thread = new Thread(Show_Thread1);
                //thread.Start();
                //chulizhongview.ShowDialog();
                try
                {
                    line1_string = path + "\\" + line1_wenjian.Items[line1_wenjian.SelectedIndex].ToString();
                    line1_all_string = FileCaozuo.Read_All_Line(line1_string);
                }
                catch { }
                try
                {
                    line2_string = path + "\\" + line2_wenjian.Items[line2_wenjian.SelectedIndex].ToString();

                    line2_all_string = FileCaozuo.Read_All_Line(line2_string);
                }
                catch { }

                for (int i = 0; i < allcount; i++)
                {
                    try
                    {

                        // 一号组
                        
                        string str_new = line1_jizhun_all_string[i];
                        string str_old = line1_all_string[i];
                        double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        double value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        double value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue = Math.Abs(value - value_old) ;

                        if (i % 10 == 0)
                        {
                            
                            chart.Insert_Point(position,  MainWindow.Jisuan_Weiyi( myvalue));
                            //chart.Insert_Point(position, myvalue2);
                        }
                    }
                    catch{}
                    try{
                       // if (i % 10 == 0)
                            //chart.Insert_Point(position, MainWindow.Jisuan_Weiyi(myvalue));
                        // 二号组
                        
                        string str_new2 = line1_jizhun_all_string[i];
                        string str_old2 = line2_all_string[i];
                        double position2 = double.Parse(string_caozuo.Get_Table_String(str_new2, 1));
                        double value2 = double.Parse(string_caozuo.Get_Table_String(str_new2, 2));
                        double value_old2 = double.Parse(string_caozuo.Get_Table_String(str_old2, 2));

                        //string str_new = line1_jizhun_all_string[i];
                        //string str_old = line1_all_string[i];
                        //double position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        //double value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        //double value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        double myvalue2 = Math.Abs(value2 - value_old2) ;
                        if (i % 10 == 0)
                        {
                           // chart.Insert_Point1(position, myvalue);
                            chart.Insert_Point1(position2, MainWindow.Jisuan_Weiyi(myvalue2));
                        }


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
                        if (i % 10 == 0)
                            chart.Insert_Point2(position, MainWindow.Jisuan_Weiyi(myvalue));

                    }
                    catch { }
                }

            }
            catch { }
        }

        private void btn_yuzhi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Report_Config.IniWriteValue("yuzhi", "yuzhi", txt_yuzhi.Text);
            try
            {
                MainWindow.yuzhi = double.Parse(txt_yuzhi.Text);
                chart.Set_Yuzhi(MainWindow.yuzhi);
            }
            catch { }
        
        }
      
    }
}
