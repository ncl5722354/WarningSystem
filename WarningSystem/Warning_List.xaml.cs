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
using System.Data;
using FileOperation;
using String_Caozuo;
using System.IO;
using System.Collections;


namespace WarningSystem
{
    /// <summary>
    /// Warning_List.xaml 的交互逻辑
    /// </summary>
    public partial class Warning_List : UserControl
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public List<WarnData> Data_List = new List<WarnData>();    //实时数据的列表

       // mychart mychart1 = new mychart();                 // 图表1

        // 创建数据结构
        public struct WarnData
        {
            public string 报警段 { get; set; }          // 报警到来的时间

            public double 地点 { get; set; }                  //  地点

            //public double 地点Y坐标 { get; set; }                  // 报警地点的Y坐标

            public double 位移 { get; set; }                      // 位移
        }
        public List<WarnData> warnlist=new List<WarnData>();

        public void Set_Table(ArrayList list)
        {
            try
            {
                datagridview1.ItemsSource = null;
                Data_List.Clear();
                foreach (WarnData mystruct in list)
                {
                    Data_List.Add(mystruct);
                }

                datagridview1.ItemsSource = Data_List;

            }
            catch { }

        }

        
        public Warning_List()
        {
            InitializeComponent();
            init_view();
            timer1.Interval = 1200;
            timer1.Tick += new EventHandler(Timer_tick);          // 初始化时钟
            timer1.Enabled = false;
        }

       

        public void Start()
        {
            timer1.Enabled = true;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            init_view();
        }

        private void init_view()
        {



            // 界面初始化

            scrollviewer.Margin = new Thickness(0, MainWindow.scree_height*0.05, 0, 0);
            scrollviewer.Width = MainWindow.screen_width * 0.2;
            scrollviewer.Height = MainWindow.scree_height * 0.85;

            datagridview1.Margin = new Thickness(0, 0, 0, 0);
            datagridview1.Width = scrollviewer.Width;
            datagridview1.Height = scrollviewer.Height;
            //datagridview1.Items.

            //label_wenjianjia.Margin = new Thickness(0.22 * MainWindow.screen_width, MainWindow.scree_height * 0.05, 0, 0);
            //label_wenjian.Margin = new Thickness(0.22 * MainWindow.screen_width, MainWindow.scree_height * 0.1, 0, 0);

            //combobox_wenjianjia.Margin = new Thickness(0.3 * MainWindow.screen_width, MainWindow.scree_height * 0.05, 0, 0);
            //combobox_wenjian.Margin = new Thickness(0.3 * MainWindow.screen_width, MainWindow.scree_height * 0.1, 0, 0);

            mywindowsformshost.Margin = new Thickness(0.22 * MainWindow.screen_width, MainWindow.scree_height * 0.3, 0, 0);
            mywindowsformshost.Width = MainWindow.screen_width * 0.7;
            mywindowsformshost.Height = MainWindow.scree_height * 0.65;


            //mywindowsformshost.Child = mychart1;
            //mychart1.Left = 0;
            //mychart1.Top = 0;
            //mychart1.Width = (int)mywindowsformshost.Width + 1;
            //mychart1.Height = (int)mywindowsformshost.Height + 1;
            //mychart1.Set_Series_Name("位移量");

            //mychart1.chart1.ChartAreas[0].AxisY.Title = "位移量(毫米)";
            //mychart1.Visible = false;

        }

        private void Timer_tick(object sender,EventArgs e)
        {
            //WarnData data = new WarnData();
            //data.报警时间 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //data.地点X坐标 = DateTime.Now.Minute;
            //data.地点Y坐标 = DateTime.Now.Second;
            //data.报警类型 = 0;
            //warnlist.Add(data);
            //datagridview1.ItemsSource = null;

            //if(warnlist.Count>=10)
            //{
            //    warnlist.RemoveAt(0);
            //}
            //datagridview1.ItemsSource = warnlist;

        }

        private void datagridview1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combobox_wenjianjia_DropDownOpened(object sender, EventArgs e)
        {
            // 刷新基准 与 日期
            try
            {
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(MainWindow.path);
                //combobox_wenjianjia.Items.Clear();
                //for (int i = 0; i < dirs.Length; i++)
                //{
                //    combobox_wenjianjia.Items.Add(dirs[i].Name);
                //}
            }
            catch { }
        }

        private void combobox_wenjian_DropDownOpened(object sender, EventArgs e)
        {
            //ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + combobox_wenjianjia.Text + "\\", "*.txt");

            //combobox_wenjian.Items.Clear();
            try
            {
                //foreach (string name in filelist)
                //{
                //    //combobox_wenjian.Items.Add(name);
                //}
            }
            catch { }
        }

        private void combobox_wenjian_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // 最新

                ArrayList Warn_List = new ArrayList();
                //string filename = MainWindow.path + combobox_wenjianjia.Text + "\\" + combobox_wenjian.Items[combobox_wenjian.SelectedIndex].ToString();

                // 将点加入曲线中
                //string[] all_line = FileCaozuo.Read_All_Line(filename);
                double position = 0;
                double value = 0;


                // 最早的点
                //string newpath = path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";


                //ArrayList filelist = FileCaozuo.Read_All_Files(MainWindow.path + combobox_wenjianjia.Text + "\\", "*.txt");
                ArrayList timelist = new ArrayList();                                      // 时间列表
                //foreach (string name in filelist)
                //{
                //    // 每个文件的的名称
                //    string filename1 = string_caozuo.Get_Dian_String(name, 1);
                //    string mydate = string_caozuo.Get_HengGang_String(filename1, 1);
                //    string mytime = string_caozuo.Get_HengGang_String(filename1, 2);
                //    string year = string_caozuo.Get_Xiahuaxian_String(mydate, 1);
                //    string month = string_caozuo.Get_Xiahuaxian_String(mydate, 2);
                //    string day = string_caozuo.Get_Xiahuaxian_String(mydate, 3);

                //    string hour = string_caozuo.Get_Xiahuaxian_String(mytime, 1);
                //    string min = string_caozuo.Get_Xiahuaxian_String(mytime, 2);
                //    string sec = string_caozuo.Get_Xiahuaxian_String(mytime, 3);
                //    DateTime nowtime = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec);
                //    timelist.Add(nowtime);
                //}

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
                //string[] all_line_old = FileCaozuo.Read_All_Line(MainWindow.path + combobox_wenjianjia.Text + "\\" + oldfilename);
                double value_old = 0;

                //mychart1.ReSet();
              

                //for (int i = 0; i < all_line.Length; i++)
                //{
                //    try
                //    {
                //        string str_new = all_line[i];
                //        string str_old = all_line_old[i];
                //        position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                //        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                //        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                //        double myvalue = Math.Abs(value - value_old);

                //        if (myvalue >= 2)
                //        {
                //            WarnData warndata = new WarnData();
                //            warndata.报警时间 = str_new;
                //            warndata.地点 = position;
                //            warndata.位移 = myvalue;
                            

                //            ArrayList list = MainWindow.Point_ini.ReadSections();
                //            //
                //            foreach (string name in list)
                //            {
                //                try
                //                {
                //                    int rukou = int.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
                //                    int chukou = int.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
                //                    if (position >= rukou && position <= chukou && myvalue >= 2)
                //                    {
                //                        Warn_List.Add(warndata);
                //                        mychart1.Insert_Point(position, myvalue);
                //                    }
                //                }
                //                catch { }
                //            }
                //        }

                //    }
                //    catch { }

                //    Set_Table(Warn_List);


                   
               // }
            }
            catch { }
        }

        private void combobox_riqi_DropDownOpened(object sender, EventArgs e)
        {
            // 更新combobox_riqi
            combobox_riqi.Items.Clear();            // 清空列表

            try
            {
                ArrayList list = FileCaozuo.Read_All_Files("D:\\config\\warning\\","*.txt");
                foreach(string  name in list)
                {
                    string data = string_caozuo.Get_KongGe_String(name, 1) + " " + string_caozuo.Get_KongGe_String(name, 2) + " " + string_caozuo.Get_KongGe_String(name, 3);
                    if(combobox_riqi.Items.Contains(data)==false)
                    {
                        combobox_riqi.Items.Add(data);
                    }
                }
                

            }
            catch { }
        }

        private void combobox_shijian_DropDownOpened(object sender, EventArgs e)
        {
            combobox_shijian.Items.Clear();
            try
            {
                ArrayList list = FileCaozuo.Read_All_Files("D:\\config\\warning\\", "*.txt");
                foreach (string name in list)
                {
                    try
                    {
                        string data = string_caozuo.Get_KongGe_String(name, 1) + " " + string_caozuo.Get_KongGe_String(name, 2) + " " + string_caozuo.Get_KongGe_String(name, 3);
                        string time = string_caozuo.Get_KongGe_String(name, 4) + " " + string_caozuo.Get_KongGe_String(name, 5) + " " + string_caozuo.Get_KongGe_String(name, 6);
                        if (combobox_shijian.Items.Contains(time) == false && data != "" && data == combobox_riqi.Text)
                        {

                            combobox_shijian.Items.Add(time);
                        }
                    }
                    catch { }
                }
                
            }
            catch { }
        }

        private void combobox_shijian_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 选择的文件
           

        }

        private void combobox_shijian_DropDownClosed(object sender, EventArgs e)
        {
            ArrayList table_list = new ArrayList();                                        // 表格的数据
            try
            {
                string name = combobox_riqi.Text + " " + combobox_shijian.Text;           // 名称
                string[] lines = FileCaozuo.Read_All_Line("D:\\config\\warning\\" + name);
                //mychart1.ReSet();
                foreach (string line in lines)
                {
                    try
                    {
                        string zhu_name = string_caozuo.Get_KongGe_String(line, 1);
                        double position = double.Parse(string_caozuo.Get_KongGe_String(line, 2));
                        double value = double.Parse(string_caozuo.Get_KongGe_String(line, 3));
                        WarnData warndata = new WarnData();
                        warndata.报警段 = zhu_name;
                        warndata.地点 = position;
                        warndata.位移 = value;
                        table_list.Add(warndata);
                        //mychart1.Insert_Point(position,value);
                    }
                    catch { }
                }

                Set_Table(table_list);

            }
            catch { }
        }
    }
}
