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
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double screen_width = SystemParameters.PrimaryScreenWidth;    // 屏幕宽度
        public static double scree_height = SystemParameters.PrimaryScreenHeight;   // 屏幕高度
        public static string User_Name = "";
        public static string User_QuanXian = "";

        string rootpath = Environment.CurrentDirectory;       //系统路径

        // 所有界面
        MyView myview = new MyView();                // 副界面中的主界面
        QuXian_View quxianview = new QuXian_View();  // 副界面中的曲线界面
        Value_Set valuesetview = new Value_Set();    // 副界面中的参数设置
        DataQushi dataqushi = new DataQushi();       // 副界面中的数据趋势
        Map_Set mapset = new Map_Set();              // 副界面中的标定界面
        ChaFenView chafenview = new ChaFenView();    // 副界面风中的差分画面
        Warning_List warn = new Warning_List();        // 副界面中的报警界面
        Report report = new Report();                  // 副界面中的报表界面

        ArrayList SubView = new ArrayList();         // 所有的副界面

        public static ArrayList Real_Data_List = new ArrayList();                                 // 实时数据列表
        public static ArrayList myreal_data_list = new ArrayList();

        public static ArrayList Dizhi_Index = new ArrayList();                                     // 地址索引表
                                                                                                  // 实时数据有这几项
                                                                                                   // 要先找到最新的文件夹
                                                                                                   // 最新的文件夹中时间最旧的，是基准

        private System.Windows.Forms.Timer datatimer = new System.Windows.Forms.Timer();         //更新数据的时钟

       // public static string path = @"\\FYJ-PC\\warnsystemconfig\\data\\";


         public static string path = @"\\TDA\bgdata\\";

        //public static string path = "D:\\bgdata\\";

        public static DateTime updatetime = new DateTime();         //更新时间

        public static IniFile Point_ini = null;                     // 地图配置文件

        public static IniFile warning_ini = null;                   // 报警文件

        public static string[] zhuzi_name = null;                   // 柱子数组
        public static int[] rukou = null;                        // 入口数组
        public static int[] chukou = null;                       // 出口数组

        public string old_update_file = "";                     // 上次更新的文件名

        //[DllImport("FreeConsole")]
        //public static extern bool FreeConsole();
        //[DllImport("FreeConsole")]
        //public static extern bool AllocConsole();

        public MainWindow()
        {
            //AllocConsole();
            InitializeComponent();
            // 屏幕参数
            this.Top = 0;
            this.Left = 0;
            this.Width = screen_width;
            this.Height = scree_height;
            init_view();
            All_Sub_Hide();      // 所有的界面隐藏起来

            // 登陆界面
            Page1 login = new Page1();
            bool? login_is = login.ShowDialog();
            if (login_is == true)
            {
                // 如果是登录
                if (Page1.UserName == "admin" && Page1.PassWord == "admin")
                {
                    // 超级管理员登录
                    User_Name = "admin";
                    User_QuanXian = "管理员";
                }
            }
            else
            {
                // 如果是取消，就退出程序
                System.Environment.Exit(0);
            }

            FileCaozuo.Create_File("D:\\config\\Map.ini");
            Point_ini = new IniFile("D:\\config\\Map.ini");



            // 读取柱子数组
            ArrayList list = MainWindow.Point_ini.ReadSections();
            zhuzi_name = new string[list.Count];       // 定义柱子数组
            rukou = new int[list.Count];            // 定义入口数组
            chukou = new int[list.Count];           // 定义出口数组

            for (int i = 0; i < list.Count;i++)
            {
                string name = (string)list[i];
                zhuzi_name[i] = name;
                rukou[i] = int.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
                chukou[i] = int.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
            }

              

                mygrid.Background = new ImageBrush
                {
                    
                    ImageSource = new BitmapImage(new Uri(rootpath + "\\bg.jpg"))
                };

            Show_SubView(myview);
            myview.Read_Real_Data();
            myview.Read_All_Point();
            
        }

        public static double Jisuan_Weiyi(double value)
        {
            value = Math.Abs(value);
            value = (value-value*Math.Sqrt(3)/2)/0.0482;       // 应变 *1000/0.0482
                                                 // 温度 *1000/1.12
                                                     
            return value ; 
        }

        private void Show_SubView(UserControl view)
        {
            All_Sub_Hide();
            view.Margin = new Thickness(0, 0, 0, 0);
            view.Width = Main_View_Grid.Width ;
            view.Height = Main_View_Grid.Height ;
            view.Visibility = Visibility.Visible;
            
        }

        public void All_Sub_Hide()
        {
            try
            {
                foreach (UserControl subview in SubView)
                {
                    subview.Visibility = Visibility.Hidden;
                    quxianview.Visibility = Visibility.Hidden;
                }
            }
            catch { }
            // 登录界面
           
        }

        public void init_view()
        {
            // 画面初始化
            // 按钮
            View_Select_Border.Margin = new Thickness(screen_width*0.005,scree_height*0.01,0,0);
            View_Select_Border.Width = screen_width * 0.1;
            View_Select_Border.Height = scree_height * 0.9;

            // 主界面
            Main_View.Margin = new Thickness(screen_width * 0.01, scree_height * 0.03, 0, 0);
            Main_View.Width = screen_width * 0.98;
            Main_View.Height = scree_height * 0.96; ;

              //主界面的Grid
            Main_View_Grid.Margin = new Thickness(0.5, 0.5, 0, 0);
            Main_View_Grid.Width = screen_width * 0.97;
            Main_View_Grid.Height = scree_height * 0.95;

            // 主界面按钮
            btn_mainview.Margin = new Thickness(screen_width * 0.01, scree_height * 0.015, 0, 0);
            btn_mainview.Width = screen_width * 0.09;
            btn_mainview.Height = scree_height * 0.05;

            // 曲线按钮
            btn_quxian.Margin = new Thickness(screen_width * 0.01, scree_height * 0.075, 0, 0);
            btn_quxian.Width = screen_width * 0.09;
            btn_quxian.Height = scree_height * 0.05;

            // 参数设置按钮
            btn_value_set.Margin = new Thickness(screen_width * 0.01, scree_height * 0.135, 0, 0);
            btn_value_set.Width = screen_width * 0.09;
            btn_value_set.Height = scree_height * 0.05;

            // 趋势曲线按钮、
            btn_Qushi.Margin = new Thickness(screen_width * 0.01, scree_height * 0.195, 0, 0);
            btn_Qushi.Width = screen_width * 0.09;
            btn_Qushi.Height = scree_height * 0.05;

            // 地图标定按钮
            btn_Set.Margin = new Thickness(screen_width * 0.01, scree_height * 0.255, 0, 0);
            btn_Set.Width = screen_width * 0.09;
            btn_Set.Height = scree_height * 0.05;

            // 所有的副页面
            SubView.Add(myview);
            Main_View_Grid.Children.Add(myview);

            SubView.Add(quxianview);
            Main_View_Grid.Children.Add(quxianview);

            SubView.Add(valuesetview);
            Main_View_Grid.Children.Add(valuesetview);

            SubView.Add(dataqushi);
            Main_View_Grid.Children.Add(dataqushi);

            SubView.Add(mapset);
            Main_View_Grid.Children.Add(mapset);

            SubView.Add(chafenview);
            Main_View_Grid.Children.Add(chafenview);

            SubView.Add(warn);
            Main_View_Grid.Children.Add(warn);

            SubView.Add(report);
            Main_View_Grid.Children.Add(report);

            //Show_SubView(myview);

            // 更新数据时钟
            datatimer.Interval = 30000;
            datatimer.Tick += new EventHandler(Data_Timer_Tick);
            datatimer.Enabled = true;

            Thread_Tick();
        }

        private void Data_Timer_Tick(object sender,EventArgs e)
        {
            // 更新数据
            // 读取文件的列表

            // 读取文件夹列表
            Thread thread = new Thread(Thread_Tick);
            thread.Start();
            
            
            //datasrtuct.
        }
        
        private void Thread_Tick()
        {
            try
            {
                

                DateTime newtime = new DateTime();
                DirectoryInfo[] dirs = FileCaozuo.Read_All_FilesDirect(path);

                ArrayList allpoints = Point_ini.ReadSections();            // 地图上所有的点
                bool is_exit = false;                                      // 是否在柱子上
                

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

                string newpath = path + "data" + newtime.ToString("yyyyMMddHHmm") + "\\";


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

                updatetime = maxtime;       //更新时间
                // 最新的文件就是maxtime的文件
                string nowfilename = maxtime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";
                string oldfilename = mintime.ToString("yyyy_MM_dd-HH_mm_ss") + ".txt";


                // 读取些文件信息
                // 最新值
                string[] all_line = FileCaozuo.Read_All_Line(newpath + nowfilename);

                

                double position = 0;
                double value = 0;

                // 标准值
                string[] all_line_old = FileCaozuo.Read_All_Line(newpath + oldfilename);
                double value_old = 0;


                //Real_Data_List.Clear();

                for (int i = 0; i < all_line.Length; i++)
                {
                    try
                    {
                        
                        string str_new = all_line[i];
                        string str_old = all_line_old[i];
                        position = double.Parse(string_caozuo.Get_Table_String(str_new, 1));
                        value = double.Parse(string_caozuo.Get_Table_String(str_new, 2));
                        value_old = double.Parse(string_caozuo.Get_Table_String(str_old, 2));

                        DataList.Data_Struct datasrtuct = new DataList.Data_Struct();
                        datasrtuct.位置 = position;
                        datasrtuct.位置X = 0;
                        datasrtuct.位置Y = 0;
                        datasrtuct.应变量 = double.Parse (Math.Abs(value - value_old).ToString("#0.0000"));
                        datasrtuct.位移量 = double.Parse(Jisuan_Weiyi(Math.Abs(value - value_old)).ToString("#0.0000"));
                        // 将值放入数据队列中
                        if (Real_Data_List.Count < all_line.Length)
                        {
                            Real_Data_List.Add(datasrtuct);
                            Dizhi_Index.Add(position);
                        }
                        else
                        {
                            Real_Data_List[i] = datasrtuct;
                            Dizhi_Index[i] = position;
                        }
                    }
                    catch { }
                  
                    //int a = 0;
                }
                myreal_data_list = Real_Data_List;
            }
            catch { }


            
        }



        private void btn_mainview_Click(object sender, RoutedEventArgs e)
        {
            // 主界面
            //MainView view = new MainView();
            Show_SubView(myview);
            
        }

        private void btn_quxian_Click(object sender, RoutedEventArgs e)
        {
            Show_SubView(quxianview);
        }

        private void btn_value_set_Click(object sender, RoutedEventArgs e)
        {
            Show_SubView(valuesetview);  //参数设置界面
        }

        private void btn_Qushi_Click(object sender, RoutedEventArgs e)
        {
            Show_SubView(dataqushi); //数据驱势界面
        }

        private void btn_Set_Click(object sender, RoutedEventArgs e)
        {
            Show_SubView(mapset);   // 地图标定
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Show_SubView(myview);
            myview.Read_Real_Data();
            myview.Read_All_Point();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Show_SubView(quxianview);
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            Show_SubView(mapset);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Show_SubView(mapset);
            mapset.Read_All_Point();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Show_SubView(chafenview);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Show_SubView(warn);
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Show_SubView(report);
        }
    }
}
