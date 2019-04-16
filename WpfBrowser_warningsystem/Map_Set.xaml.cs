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

namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// Map_Set.xaml 的交互逻辑
    /// </summary>
    public partial class Map_Set : UserControl
    {
        string rootpath = Environment.CurrentDirectory;

        public static ArrayList all_dizhuang_list = new ArrayList();                   // 所有的地标标志

        public bool ready_parse = false;                                 // 是否准备粘贴

        private bool move_enable = false;

        private double pre_pos_x = 0;                      // 前一次的坐标
        private double pre_pos_y = 0;

        private double now_pos_x = 0;                      // 后一次的坐标
        private double now_pos_y = 0;

        public static double border_pos_x = 0;
        public static double border_pos_y = 0;

        public static double myimage_left = 0;
        public static double myimage_top = 0;

        public  static  double  suofang = 1;
        public Map_Set()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            Imageborder.Margin = new Thickness(0.02 * MainWindow.screen_width, 0.05 * MainWindow.scree_height, 0, 0);
            Imageborder.Width = 0.75 * MainWindow.screen_width;
            Imageborder.Height = 0.65 * MainWindow.scree_height;

            ImageScrollviewer.Margin = new Thickness(0.01, 0.01, 0, 0);
            ImageScrollviewer.Width = 0.75 * MainWindow.screen_width;
            Imageborder.Height = 0.65 * MainWindow.scree_height;

            myimage.Margin = new Thickness(0, 0, 0, 0);
            myimage.Width = 0.75 * MainWindow.screen_width;
            myimage.Height = 0.65 * MainWindow.scree_height;

            myimage.Source = new BitmapImage(new Uri(rootpath + "//pic.png", UriKind.RelativeOrAbsolute));

            add_dizhuang.Margin = new Thickness(MainWindow.screen_width * 0.1, MainWindow.scree_height * 0.75, 0, 0);

            border_pos_x = Imageborder.Margin.Left;
            border_pos_y = Imageborder.Margin.Top;

            myimage_left = myimage.Margin.Left;
            myimage_top = myimage.Margin.Top;

            //MainWindow.Point_ini.Read_All_Section();
        }

        public void Read_All_Point()
        {
            // 读取所有的点
            //ArrayList list = MainWindow.Point_ini.ReadSections();
            
            //// 去掉点
            //foreach(DiZhuang_Item item in all_dizhuang_list)
            //{
            //    maingrid.Children.Remove(item);
            //}
            //all_dizhuang_list.Clear();

            //foreach(string name in list)
            //{
            //    //  加入点
            //    DiZhuang_Item item = new DiZhuang_Item();
               

            //    double x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X"));
            //    double y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y"));
            //    try
            //    {
            //        item.Set_Center(name);
            //        item.Set_Left(int.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou")));
            //        item.Set_Right(int.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou")));
            //        item.pos_x = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X"));
            //        item.pos_y = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y"));
            //    }
            //    catch { }
            //    item.Margin = new Thickness(x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2, y * suofang + myimage.Margin.Top + Imageborder.Margin.Top - item.Height / 2, 0, 0);
                
            //    maingrid.Children.Add(item);
            //    all_dizhuang_list.Add(item);
            //}

        }
        private void add_dizhuang_Click(object sender, RoutedEventArgs e)
        {
            ready_parse = true;                         // 准备加入木桩
            this.Cursor = Cursors.Cross;
        }

        private void maingrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void maingrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // int a = 0;
        }

        private void myimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            if (ready_parse == true)
            {
                ready_parse = false;
                this.Cursor = Cursors.Arrow;
                if (e.ChangedButton == MouseButton.Left)
                {
                    //int b = 0;
                    // 添加地桩
                    if(e.GetPosition(Imageborder).X>= 0 && e.GetPosition(Imageborder).X<Imageborder.Width && e.GetPosition(Imageborder).Y>=0 && e.GetPosition(Imageborder).Y<=Imageborder.Height)
                    {
                        //int a = 0;
                        // 加入地桩
                        DiZhuang_Item item = new DiZhuang_Item();
                        maingrid.Children.Add(item);
                        item.Margin = new Thickness(e.GetPosition(Imageborder).X + Imageborder.Margin.Left, e.GetPosition(Imageborder).Y + Imageborder.Margin.Top,0,0);

                        double pos_x = e.GetPosition(Imageborder).X;
                        double pos_y = e.GetPosition(Imageborder).Y;

                        item.pos_x = (pos_x - myimage.Margin.Left - Imageborder.Margin.Left + item.Width / 2) / suofang;
                        item.pos_y = (pos_y - myimage.Margin.Top - Imageborder.Margin.Top + item.Height / 2) / suofang;
                        
                        all_dizhuang_list.Add(item);

                        // 在配置文件中加入地桩

                        
                        Point_Set_View view = new Point_Set_View();
                        bool? ok_is = view.ShowDialog();
                        if (ok_is == true)
                        {
                            MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname,"enable","true");
                            MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname,"rukou",Point_Set_View.rukou.ToString());
                            MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "chukou", Point_Set_View.chukou.ToString());
                            MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "X", item.pos_x.ToString());
                            MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "Y", item.pos_y.ToString());
                            item.Set_Left(Point_Set_View.rukou);
                            item.Set_Right(Point_Set_View.chukou);
                            item.Set_Center(Point_Set_View.myname);
                        }

                        
                    }
                    //DiZhuang_Item item = new DiZhuang_Item();



                    //maingrid.Children.Add(item);


                }
            }
            else
            {
                move_enable = true;
                pre_pos_x = e.GetPosition(Imageborder).X;
                pre_pos_y = e.GetPosition(Imageborder).Y;
            }
            
        }

        private void ImageScrollviewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //int a = 0;
        }

        private void Imageborder_MouseWheel(object sender, MouseWheelEventArgs e)
        {
           // int a = 0;
        }

        private void myimage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // int a = 0;
            //int a = e.Delta;
            if (e.Delta > 0)
            {
                if (suofang <= 20)
                {
                    suofang = suofang + 0.06;
                }
                if (suofang > 20)
                {
                    suofang = 5;
                }
            }

            if (e.Delta < 0)
            {
                if (suofang >= 1)
                {
                    suofang = suofang - 0.03;
                }
                if (suofang <1)
                {
                    suofang = 1;
                }
            }

            Image_Suofang(suofang);
        }

        private void Image_Suofang(double suofang)
        {

            myimage.Width = MyView.origin_width * suofang;
            myimage.Height = MyView.origin_height * suofang;
            Reset_All_Point();
        }

        private void Reset_All_Point()
        {
            foreach(DiZhuang_Item item in all_dizhuang_list)
            {
                item.Margin = new Thickness(item.pos_x * suofang + myimage.Margin.Left + Imageborder.Margin.Left - item.Width / 2, item.pos_y * suofang + Imageborder.Margin.Top + myimage.Margin.Top - item.Height / 2, 0, 0);

            }
        }

        private void myimage_MouseMove(object sender, MouseEventArgs e)
        {
            if (move_enable == true)
            {
                // 这一次的坐标
                now_pos_x = e.GetPosition(Imageborder).X;
                now_pos_y = e.GetPosition(Imageborder).Y;

                double move_x = now_pos_x - pre_pos_x;
                double move_y = now_pos_y - pre_pos_y;

                // 移动图片

                myimage.Margin = new Thickness(myimage.Margin.Left + move_x, myimage.Margin.Top + move_y, 0, 0);
                pre_pos_x = now_pos_x;
                pre_pos_y = now_pos_y;
                myimage_left = myimage.Margin.Left;
                myimage_top = myimage.Margin.Top;
                Reset_All_Point();

                //myimage.Top = myimage.Margin.Top + move_y;
            }
        }

        private void ImageScrollviewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
           

        }

        private void myimage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            move_enable = false;
            
        }
    }
}
