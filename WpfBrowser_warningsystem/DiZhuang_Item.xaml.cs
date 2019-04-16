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


namespace WpfBrowser_warningsystem
{
    /// <summary>
    /// DiZhuang_Item.xaml 的交互逻辑
    /// </summary>
    public partial class DiZhuang_Item : UserControl
    {

        private bool move_enable = false;
        public string Key = "";
        public int left = 0;
        public int right = 0;
        public double pos_x = 0;
        public double pos_y = 0;
        public bool edit_able = true;
        public static int rukou = 0;
        public static int chukou = 0;

        public bool show_dialog = false;                  // 是否显示了柱状对话框

        public bool check_is = false;      //是否选中

        public static bool selected = false; // 是否已经选中了某点

        WarnInfo view = null;
        string rootpath = Environment.CurrentDirectory;

        

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public DiZhuang_Item()
        {
            InitializeComponent();
           
            timer.Interval = 2000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Tick);
            
            label_center.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(rootpath+"\\position.png"))
            };
        }

        private void Tick(object sender,EventArgs e)
        {
            // 时钟事件
            
        }

        public void Reset_View()
        {
            try
            {
                rukou = int.Parse(MainWindow.Point_ini.IniReadValue(Key, "rukou"));
                chukou = int.Parse(MainWindow.Point_ini.IniReadValue(Key, "chukou"));

                ArrayList all_warn_list = new ArrayList();

                foreach (DataList.Data_Struct data_struct in MainWindow.Real_Data_List)
                {
                    if (data_struct.位置 >= rukou && data_struct.位置 <= chukou)
                    {
                        all_warn_list.Add(data_struct);
                    }
                }
                view.Set_WarnInfo(all_warn_list);

            }
            catch { }
        }

        public void Set_Center(string name)
        {
            label_center.Content = name;
            Key = name;
        }

        public void Set_Left(int name)
        {
            label_left.Content = name.ToString();
            left = name;
        }

        public void Set_Right(int name)
        {
            label_right.Content = name.ToString();
            right = name;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                move_enable = true;
            }

            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount==1)
            {
                if (edit_able == false)
                {
                    // 在地图界面上点击固定
                    if (check_is==false)
                    {
                        // 确认显示点
                        check_is = true;
                        selected = true;
                    }
                    else
                    {
                        check_is = false;
                        selected = false;
                    }
                }
            }

            if(e.RightButton==MouseButtonState.Pressed)
            {
                if (edit_able == false)
                {
                    try
                    {
                        rukou = int.Parse(MainWindow.Point_ini.IniReadValue(Key, "rukou"));
                        chukou = int.Parse(MainWindow.Point_ini.IniReadValue(Key, "chukou"));

                        ArrayList all_warn_list = new ArrayList();

                        foreach (DataList.Data_Struct data_struct in MainWindow.Real_Data_List)
                        {
                            if (data_struct.位置 >= rukou && data_struct.位置 <= chukou)
                            {
                                all_warn_list.Add(data_struct);
                            }
                        }

                        view = null;
                        show_dialog = true;

                        
                        view = new WarnInfo(all_warn_list);

                        Reset_View();
                        view.ShowDialog();

                        show_dialog = false;

                    }
                    catch { show_dialog = false; return; }
                    return;
                }
                // 右键
               MessageBoxResult resut = MessageBox.Show("是否删除此点","删除",MessageBoxButton.OKCancel);
               if (resut == MessageBoxResult.OK)
               {
                   // 删除此点
                   try
                   {
                       Map_Set.all_dizhuang_list.Remove(this);
                       MainWindow.Point_ini.IniWriteValue(label_center.Content.ToString(), "enable", "false");
                       Grid mygrid = (Grid)this.Parent;
                       mygrid.Children.Remove(this);
                   }
                   catch { }
               }
            }


        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            move_enable = false;
            MainWindow.Point_ini.IniWriteValue(Key, "X", pos_x.ToString());
            MainWindow.Point_ini.IniWriteValue(Key, "Y", pos_y.ToString());
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(move_enable==true && edit_able==true)
            {
                this.Margin = new Thickness(this.Margin.Left + e.GetPosition(this).X-this.Width/2, this.Margin.Top + e.GetPosition(this).Y-this.Height/2, 0, 0);
                pos_x = (this.Margin.Left - Map_Set.border_pos_x - Map_Set.myimage_left + this.Width / 2) / Map_Set.suofang;
                pos_y = (this.Margin.Top - Map_Set.border_pos_y - Map_Set.myimage_top + this.Height / 2) / Map_Set.suofang;
            }
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //点的设定
            if (edit_able == true)
            {
                try
                {
                    Point_Set_View.rukou = int.Parse(label_left.Content.ToString());
                    //Point_Set_View view = new Point_Set_View();
                }
                catch { Point_Set_View.rukou = 0; }
                try
                {
                    Point_Set_View.chukou = int.Parse(label_right.Content.ToString());
                }
                catch { Point_Set_View.chukou = 0; }
                Point_Set_View.myname = label_center.Content.ToString();
                Point_Set_View view = new Point_Set_View();
                bool? result = view.ShowDialog();
                if (result == true)
                {
                    MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "enable", "true");
                    MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "rukou", Point_Set_View.rukou.ToString());
                    MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "chukou", Point_Set_View.chukou.ToString());
                    MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "X", pos_x.ToString());
                    MainWindow.Point_ini.IniWriteValue(Point_Set_View.myname, "Y", pos_y.ToString());
                    Set_Left(Point_Set_View.rukou);
                    Set_Right(Point_Set_View.chukou);
                    Set_Center(Point_Set_View.myname);
                }
            }
            if(edit_able==false)
            {
                
            }

        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (check_is == false && selected==false)
            {
                ScaleTransform scaleTransform = new ScaleTransform();

                 
                   
                 //img.RenderTransformOrigin = new Point(0.5, 0.5);
                 this.RenderTransformOrigin = new Point(0.5, 0.5);

                scaleTransform.ScaleX = 2;              //宽度放大一倍 

                scaleTransform.ScaleY = 2;              //高度放大一倍
                this.RenderTransform = scaleTransform;

                // 只有没有选中时才可以

                MyView.show_point_name = Key;
            }
            
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (check_is == false && selected==false)
            {
                ScaleTransform scaleTransform = new ScaleTransform();
                this.RenderTransformOrigin = new Point(0.5, 0.5);

                scaleTransform.ScaleX = 1;              //宽度放大一倍 

                scaleTransform.ScaleY = 1;              //高度放大一倍
                this.RenderTransform = scaleTransform;

                MyView.show_point_name = "";
            }


           
        }
    }
}
