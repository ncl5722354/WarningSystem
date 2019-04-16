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
    /// line.xaml 的交互逻辑
    /// </summary>
    public partial class myline : UserControl
    {
        public double pos_x = 0;
        public double pos_y = 0;
        public double mywidth = 0;
        public double myheight = 0;

        public double myx1 = 0;
        public double myx2 = 0;
        public double myy1 = 0;
        public double myy2 = 0;

        public string Key = "";

        public static int rukou = 0;
        public static int chukou = 0;

        public bool show_dialog = false;                  // 是否显示了柱状对话框

        public bool check_is = false;      //是否选中

        public static bool selected = false; // 是否已经选中了某点

        public double[] x_arr = null;
        public double[] y_arr = null;

        WarnInfo view = null;
        string rootpath = Environment.CurrentDirectory;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public  bool warn_is = false;
        public double kuan = 2;

        public myline(double[] x_arraylist,double[] y_arraylist)
        {
            InitializeComponent();
            x_arr = x_arraylist;
            y_arr = y_arraylist;
            timer.Interval = 10000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Tick);
           
            init_view();
        }

        public void init_view()
        {
            if (myx2 != myx1)
            {
                this.Width = Math.Abs(myx2 - myx1);
            }
            else
            {
                this.Width = 2;
            }

            if (myy1 != myy2)
            {
                this.Height = Math.Abs(myy2 - myy1);
            }
            else
            {
                this.Height = 2;
            }
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            kuan = 2;
            Draw_Line();
            
        }

        void Tick(object sender, EventArgs e)
        {
            // 时钟事件
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

        public void Draw_Line()
        {
            canvas.Children.Clear();

            
            // 重写画线函数

            if (x_arr == null || y_arr == null) return;
            if (x_arr.Length != y_arr.Length) return;     // 点个数不对
            try
            {
                for (int i = 0; i < x_arr.Length - 1; i++)
                {
                    Line line = new Line();
                    line.X1 = x_arr[i];
                    line.Y1 = y_arr[i];
                    line.X2 = x_arr[i + 1];
                    line.Y2 = y_arr[i + 1];
                    line.StrokeThickness = kuan;
                    if (warn_is == false)
                        line.Stroke = Brushes.Blue;
                    if (warn_is == true)
                        line.Stroke = Brushes.Red;
                    canvas.Children.Add(line);
                }
            }
            catch { }
            //if ((myx1 < myx2 && myy1 < myy2) ||(myx2<myx1 && myy2<myy1))
            //{
            //    // 从左上角到右下角
            //    Line line = new Line();
            //    line.X1 = 0;
            //    line.Y1 = 0;
            //    line.X2 = this.Width;
            //    line.Y2 = this.Height;
            //    if(warn_is==false)
            //        line.Stroke = Brushes.Blue;
            //    if (warn_is == true)
            //        line.Stroke = Brushes.Red;
            //    line.StrokeThickness = kuan;
            //    canvas.Children.Add(line);
            //}

            //if ((myx1 < myx2 && myy1 > myy2) || (myx1 > myx2 && myy1 < myy2))
            //{
            //    Line line = new Line();
            //    line.X1 = 0;
            //    line.Y1 = this.Height;
            //    line.X2 = this.Width;
            //    line.Y2 = 0;
            //    if (warn_is == false)
            //        line.Stroke = Brushes.Blue;
            //    if (warn_is == true)
            //        line.Stroke = Brushes.Red;
            //    line.StrokeThickness = kuan;
            //    canvas.Children.Add(line);
            //}

            //if (myx1 == myx2 && myy1 != myy2)
            //{
            //    Line line = new Line();
            //    line.X1 = 0;
            //    line.Y1 = 0;
            //    line.X2 = 0;
            //    line.Y2 = this.Height;
            //    if (warn_is == false)
            //        line.Stroke = Brushes.Blue;
            //    if (warn_is == true)
            //        line.Stroke = Brushes.Red;
            //    line.StrokeThickness = kuan;
            //    canvas.Children.Add(line);
            //}

            //if (myx1 != myx2 && myy1 == myy2)
            //{
            //    Line line = new Line();
            //    line.X1 = 0;
            //    line.Y1 = 0;
            //    line.X2 = this.Width;
            //    line.Y2 = 0;
            //    if (warn_is == false)
            //        line.Stroke = Brushes.Blue;
            //    if (warn_is == true)
            //        line.Stroke = Brushes.Red;
            //    line.StrokeThickness = kuan;
            //    canvas.Children.Add(line);
            //}
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = this.Width;
            canvas.Height = this.Height;
            //kuan = 4;
            Draw_Line();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Cross;
            if (check_is == false && selected == false)
            {
                kuan = 4;
                Draw_Line();
                

                // 只有没有选中时才可以

                MyView.show_point_name = Key;
            }
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            if (check_is == false && selected == false)
            {
             
                kuan = 2;
                Draw_Line();
                MyView.show_point_name = "";
            }
           
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 1)
            {
               
                    // 在地图界面上点击固定
                    if (check_is == false)
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

            if (e.RightButton == MouseButtonState.Pressed)
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
                        view.ShowDialog();
                        show_dialog = false;
                        //return;
                    }
                    catch { show_dialog = false; return; }
                   
                
               
            }
        }
    }
}
