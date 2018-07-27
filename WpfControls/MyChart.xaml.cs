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
using System.Data.SqlClient;
using System.Data.Sql;
using SqlConnect;
using System.Collections;

namespace WpfControls
{
    /// <summary>
    /// MyChart.xaml 的交互逻辑
    /// </summary>
    public partial class MyChart : UserControl
    {

        /// <summary>
        /// 说明，每一个图表最多可对应四个变量，
        /// 对应的变量有一个历史记录表 按天来
        /// </summary>
        /// <param name="dr"></param>
        /// 
        double minvalue = 0;
        double maxvalue = 0;
        double interval = 0;

        DateTime starttime;
        double timespan = 0;
        double timeinterval = 0;

        double fixvalue = 5;
        double fixvalue_y = 30;
         
        int timelabelcount = 0;
        int label_count = 0;

        DataRow mydr = null;
        SQL_Connect_Builder mybuilder = null;
        System.Timers.Timer timer1 = new System.Timers.Timer();    // 绘制画的时钟

        ArrayList allline = new ArrayList();                       // 用来保存所有的线的方案

        public static ArrayList All_Used_Running_Table = new ArrayList();  // 用来保存所有的历史库

        bool Pressed = false;
        bool Vertical_Pressed = false;                                     // 竖起的滑块按下

        public MyChart(DataRow dr,SQL_Connect_Builder builder)
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(Draw);
            timer1.Enabled = true;

            // mytreeview.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(Jump_Window_Event);
            // 注册滑动块的路由事件
            
            
            this.drawgrid.AddHandler(Slider.MouseLeftButtonDownEvent, new RoutedEventHandler(this.slider_MouseLeftButtonDown));
            this.drawgrid.AddHandler(Slider.MouseMoveEvent, new RoutedEventHandler(this.slider_MouseMove));
            this.drawgrid.AddHandler(Slider.MouseLeftButtonUpEvent, new RoutedEventHandler(this.slider_MouseLeftButtonUp));
            
            //slider.Value = 5;

            try
            {
                if (dr == null || builder == null) return;

                // 变量传输
                mydr = dr;
                mybuilder = builder;

                this.Name = dr[0].ToString();
                this.Width = double.Parse(dr[3].ToString());
                this.Height = double.Parse(dr[4].ToString());

                // 横对齐解析
                switch (dr[5].ToString())
                {
                    case "Left":
                        HorizontalAlignment = HorizontalAlignment.Left;
                        break;
                    case "Right":
                        HorizontalAlignment = HorizontalAlignment.Right;
                        break;
                    case "Center":
                        HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case "Stretch":
                        HorizontalAlignment = HorizontalAlignment.Stretch;
                        break;
                    default:
                        HorizontalAlignment = HorizontalAlignment.Center;
                        break;
                }

                // 纵对齐解析
                switch (dr[6].ToString())
                {
                    case "Top":
                        VerticalAlignment = VerticalAlignment.Top;
                        break;
                    case "Bottom":
                        VerticalAlignment = VerticalAlignment.Bottom;
                        break;
                    case "Center":
                        VerticalAlignment = VerticalAlignment.Center;
                        break;
                    case "Stretch":
                        VerticalAlignment = VerticalAlignment.Stretch;
                        break;
                    default:
                        VerticalAlignment = VerticalAlignment.Center;
                        break;
                }

                double MarginLeft = double.Parse(dr[7].ToString());
                double MarginRight = double.Parse(dr[8].ToString());
                double MarginTop = double.Parse(dr[9].ToString());
                double MarginBottom = double.Parse(dr[10].ToString());

                this.Margin = new Thickness(MarginLeft, MarginTop, MarginRight, MarginBottom);


                // 通过 minvalue maxvalue 与 interval来决定纵坐标的数量与布局
                  // 如果没有布局相关就直接退出下面的设置
                if (dr[11].ToString() == "" || dr[12].ToString() == "" || dr[13].ToString() == "") return;
                try
                {
                    minvalue = double.Parse(dr[11].ToString());
                    maxvalue = double.Parse(dr[12].ToString());
                    interval = double.Parse(dr[13].ToString());
                    if (interval == 0) return;                                             // 除数是0 不成立
                    label_count = (int)((maxvalue - minvalue) / interval + 1);
                    for (int i = 0; i < label_count; i++)
                    {
                        Label newlabel = new Label();
                        newlabel.Content = minvalue + interval * i;

                        newlabel.Margin = new Thickness(100, subgrid.Margin.Top + subgrid.Height - (subgrid.Height / (label_count - 1)) * i - fixvalue, 0, 0);
                        drawgrid.Children.Add(newlabel);
                    }
                }

                
                catch { return; }

                // 解析线的情况
                   // 线01
                if(dr[17].ToString()!="" && dr[18].ToString()!="")
                {
                    myline_Struct line = new myline_Struct(dr[17].ToString(),dr[18].ToString());
                    allline.Add(line);
                }

                // 线02
                if (dr[19].ToString() != "" && dr[20].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[19].ToString(), dr[20].ToString());
                    allline.Add(line);
                }

                // 线03
                if (dr[21].ToString() != "" && dr[22].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[21].ToString(), dr[22].ToString());
                    allline.Add(line);
                }

                // 线04
                if (dr[23].ToString() != "" && dr[24].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[23].ToString(), dr[24].ToString());
                    allline.Add(line);
                }

                // 线05
                if (dr[25].ToString() != "" && dr[26].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[25].ToString(), dr[26].ToString());
                    allline.Add(line);
                }

                // 线06
                if (dr[27].ToString() != "" && dr[28].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[27].ToString(), dr[28].ToString());
                    allline.Add(line);
                }

                // 线07
                if (dr[29].ToString() != "" && dr[30].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[29].ToString(), dr[30].ToString());
                    allline.Add(line);
                }

                // 线08
                if (dr[31].ToString() != "" && dr[32].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[31].ToString(), dr[32].ToString());
                    allline.Add(line);
                }

                // 线09
                if (dr[33].ToString() != "" && dr[34].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[33].ToString(), dr[34].ToString());
                    allline.Add(line);
                }

                // 线10
                if (dr[35].ToString() != "" && dr[36].ToString() != "")
                {
                    myline_Struct line = new myline_Struct(dr[35].ToString(), dr[36].ToString());
                    allline.Add(line);
                }
                // 通过TimeSpan Timeinterval 和 StartTime来决定横坐标的数量与布局
                if (dr[14].ToString() == "" || dr[15].ToString() == "") return;
                try
                {
                    timespan = double.Parse(dr[14].ToString());
                    timeinterval = double.Parse(dr[15].ToString());
                    if(dr[16].ToString()=="")
                    {
                        starttime = DateTime.Now;
                        string where_cmd = "ChartName='" + dr[0].ToString() + "'";
                        string[] update_cmd = new string[1];
                        update_cmd[0] = "StartTime='"+starttime.ToString("yyyy-MM-dd HH:mm:ss")+"'";
                        builder.Updata("ALLMyChart", where_cmd, update_cmd);
                    }
                    else
                    {
                        starttime = DateTime.Parse(dr[16].ToString());
                    }

                    timelabelcount = (int)(timespan / timeinterval + 1);
                    for (int i = 0; i < timelabelcount; i++)
                    {
                        Label newlabel = new Label();
                        newlabel.Content = (starttime + TimeSpan.FromMinutes(timeinterval * i)).ToString("yyyy/MM/dd \n HH:mm:ss") ;
                        newlabel.Margin = new Thickness(subgrid.Margin.Left + (subgrid.Width / (timelabelcount - 1)) * i-fixvalue_y, 250, 0, 0);
                        drawgrid.Children.Add(newlabel);
                    }
                }
                catch { return; }
            }
            catch { }
            
        }

        private void Draw(object sender,System.Timers.ElapsedEventArgs e)
        {
            // 绘制
            // new Action(() => { label.Content = " " + result1 + " "; })); continue;
            subgrid.Dispatcher.BeginInvoke(new Action(() =>
            {
                subgrid.Children.Clear();                        // 去掉所有的元素

                if (mydr == null || mybuilder == null) return;
                // 画标记位置的虚线
                #region
                DoubleCollection dc = new DoubleCollection();
                dc.Add(2);
                dc.Add(2);
                for (int i = 0; i < timelabelcount; i++)
                {
                    // 画竖起的虚线
                    Line newline = new Line();
                    newline.X1 = (subgrid.Width / (timelabelcount - 1)) * i ;
                    newline.X2 = (subgrid.Width / (timelabelcount - 1)) * i ;
                    if (newline.X1 < 0 || newline.X1 > subgrid.Width) continue;
                    newline.Y1 = 0;
                    newline.Y2 = subgrid.Height;
                    newline.StrokeDashArray = dc;
                    newline.Stroke = System.Windows.Media.Brushes.Black;
                    newline.StrokeThickness = 1;
                    subgrid.Children.Add(newline);
                }

                for (int i = 0; i < label_count; i++)
                {
                    Line newline = new Line();
                    newline.X1 = 0;
                    newline.X2 = subgrid.Width;
                    newline.Y1 = subgrid.Height - (subgrid.Height / (label_count - 1)) * i;
                    newline.Y2 = subgrid.Height - (subgrid.Height / (label_count - 1)) * i;
                    newline.StrokeDashArray = dc;
                    newline.Stroke = System.Windows.Media.Brushes.Black;
                    newline.StrokeThickness = 1;
                    subgrid.Children.Add(newline);
                }
                #endregion

                // 读取相应时间段内的数据库表
                DateTime temp_start_time=starttime;
                DateTime endtime = starttime.AddMinutes(timespan);
                
                while(endtime.Year!=temp_start_time.Year || endtime.Month!=temp_start_time.Month || endtime.Day!=temp_start_time.Day)
                {
                    // 日期不同，说明跨了日期

                    string table_name ="runtimetable"+ temp_start_time.ToString("yyyyMMdd");
                    
                    DataTable dt = null;

                    bool exits = false;                                                             // 在内存中是否存在这样的一个表
                    foreach(object mydatatable in All_Used_Running_Table)
                    {
                        DataTable mydt = (DataTable)mydatatable;
                        if (mydt.TableName == table_name)
                        {
                            dt = mydt;
                            exits = true;
                            break;
                        }
                    }
                    if (exits == false)
                    {
                        dt = mybuilder.Select_Table(table_name, "Time>'" + temp_start_time.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                        dt.TableName = table_name;
                        All_Used_Running_Table.Add(dt);
                    }

                    if (dt == null) return;
                    if (dt.Rows.Count == 0) return;
                    dt.Columns[1].ColumnName = "Value_Name";
                    
                    // 绘图 共可以绘制10条图案
                    foreach(object lineobject in allline)
                    {
                        myline_Struct line_struct = (myline_Struct)lineobject;
                        string linename = line_struct.LineName;
                        string color = line_struct.LineColor;                 // 颜色
                        DataRow[] linerows = null;
                        try
                        {
                            linerows = dt.Select("Value_Name='" + linename + "'");
                        }
                        catch { return; }
                        if (linerows == null) return;
                        for (int i = 0; i < linerows.Length - 1; i++)
                        {
                            double value = double.Parse(linerows[i][3].ToString());
                            DateTime value_time=DateTime.Parse(linerows[i][2].ToString());
                            double nextvalue = double.Parse(linerows[i + 1][3].ToString());
                            DateTime next_time=DateTime.Parse(linerows[i+1][2].ToString());
                            Line newline = new Line();
                            TimeSpan ts1 = value_time - starttime;
                            TimeSpan ts2 = next_time - starttime;
                            newline.X1 = ts1.TotalMinutes / (timespan) * subgrid.Width;
                            newline.X2 = ts2.TotalMinutes / (timespan) * subgrid.Width;
                            newline.Y1 = subgrid.Height - value / (maxvalue - minvalue) * subgrid.Height;
                            newline.Y2 = subgrid.Height - nextvalue / (maxvalue - minvalue) * subgrid.Height;
                            newline.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
                            subgrid.Children.Add(newline);
                        }
                    }
                    
                    temp_start_time = DateTime.Parse(temp_start_time.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00");
                }
                
                // 再绘制新当天的图
                string todaytable_name = "runtimetable" + temp_start_time.ToString("yyyyMMdd");
               // DataTable todaydt = mybuilder.Select_Table(todaytable_name, "Time>'" + temp_start_time.ToString("yyyy-MM-dd HH:mm:ss") + "' and Time<'"+endtime.ToString("yyyy-MM-dd HH:mm:ss")+"'");

                DataTable todaydt = null;

                bool exits2 = false;                                                             // 在内存中是否存在这样的一个表
                foreach (object mydatatable in All_Used_Running_Table)
                {
                    DataTable mydt = (DataTable)mydatatable;
                    if (mydt.TableName == todaytable_name)
                    {
                        todaydt = mydt;
                        exits2 = true;
                        break;
                    }
                }
                if (exits2 == false)
                {
                    todaydt = mybuilder.Select_Table(todaytable_name, "Time>'" + temp_start_time.ToString("yyyy-MM-dd HH:mm:ss") + "' and Time<'" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    if (todaydt == null) return;
                    if (todaydt.Rows.Count == 0) return;
                    todaydt.TableName = todaytable_name;
                    All_Used_Running_Table.Add(todaydt);
                }

               
                // 绘图
                todaydt.Columns[1].ColumnName = "Value_Name";

                // 绘图 共可以绘制10条图案
                foreach (object lineobject in allline)
                {
                    myline_Struct line_struct = (myline_Struct)lineobject;
                    string linename = line_struct.LineName;
                    string color = line_struct.LineColor;                 // 颜色
                    DataRow[] linerows = null;
                    try
                    {
                        linerows = todaydt.Select("Value_Name='" + linename + "'");
                    }
                    catch { return; }
                    if (linerows == null) return;
                    for (int i = 0; i < linerows.Length - 1; i++)
                    {
                        double value = double.Parse(linerows[i][3].ToString());
                        DateTime value_time = DateTime.Parse(linerows[i][2].ToString());
                        double nextvalue = double.Parse(linerows[i + 1][3].ToString());
                        DateTime next_time = DateTime.Parse(linerows[i + 1][2].ToString());
                        
                        Line newline = new Line();
                        TimeSpan ts1 = value_time - starttime;
                        TimeSpan ts2 = next_time - starttime;
                        newline.X1 = ts1.TotalMinutes / (timespan) * subgrid.Width;
                        newline.X2 = ts2.TotalMinutes / (timespan) * subgrid.Width;
                        newline.Y1 = subgrid.Height - value / (maxvalue - minvalue) * subgrid.Height;
                        newline.Y2 = subgrid.Height - nextvalue / (maxvalue - minvalue) * subgrid.Height;
                        newline.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
                        subgrid.Children.Add(newline);
                    }
                }

            }));
            
        }

        private void slider_DragOver(object sender, DragEventArgs e)
        {

        }

        private void slider_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            // 按下
            Grid grid = (Grid)sender;
            Point point = Mouse.GetPosition(grid);
           // MessageBox.Show("x is " + point.Y + " slider left is " + slider.Margin.Top + "width is "+slider.Height);
            if (point.X >= slider.Margin.Left && point.X <= slider.Margin.Left + slider.Width && point.Y >= slider.Margin.Top && point.Y <= slider.Margin.Top + slider.Height)
            {
                double pointx = point.X;
                
                slider.Value = (pointx - slider.Margin.Left) * slider.Maximum / (slider.Width);
                line.X1 = pointx - (slider.Value - 5) * 1;
                line.X2 = pointx - (slider.Value - 5) * 1;
                // 变换时期显示
                label_time.Content = starttime.AddMinutes(slider.Value / slider.Maximum * timespan).ToString("yyyy-MM-dd HH:mm:ss");
                Pressed = true;
            }
        }

        private void slider_MouseMove(object sender, RoutedEventArgs e)
        {
            if(Pressed==true)
            {
                Grid grid = (Grid)sender;
                Point point = Mouse.GetPosition(grid);
                if (point.X >= slider.Margin.Left && point.X <= slider.Margin.Left + slider.Width && point.Y >= slider.Margin.Top && point.Y <= slider.Margin.Top + slider.Height)
                {
                    double pointx = point.X;
                    
                    slider.Value = (pointx - slider.Margin.Left) * slider.Maximum / (slider.Width);
                    line.X1 = pointx - (slider.Value - 5) * 1;
                    line.X2 = pointx - (slider.Value - 5) * 1;
                    label_time.Content = starttime.AddMinutes(slider.Value / slider.Maximum * timespan).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        private void slider_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Pressed = false;
        }

        private void Vertical_slider_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            // 按下
            MessageBox.Show("Press!");
            Grid grid = (Grid)sender;
            Point point = Mouse.GetPosition(grid);
            
            // MessageBox.Show("x is " + point.Y + " slider left is " + slider.Margin.Top + "width is "+slider.Height);
            if (point.X >= Vertical_slider.Margin.Left && point.X <= Vertical_slider.Margin.Left + Vertical_slider.Width && point.Y >= Vertical_slider.Margin.Top && point.Y <= Vertical_slider.Margin.Top + Vertical_slider.Height)
            {
                double pointy = point.Y;

                Vertical_slider.Value = (pointy - Vertical_slider.Margin.Top) * Vertical_slider.Maximum / (slider.Height);
                Vertical_line.Y1 = pointy - (Vertical_slider.Value - 5);
                Vertical_line.Y2 = pointy - (Vertical_slider.Value - 5);
                //line.X1 = pointx - (slider.Value - 5) * 1;
                //line.X2 = pointx - (slider.Value - 5) * 1;
                // 变换时期显示
                //label_time.Content = starttime.AddMinutes(slider.Value / slider.Maximum * timespan).ToString("yyyy-MM-dd HH:mm:ss") + " " + slider.Value;
                Vertical_Pressed = true;
            }
        }

        private void Vertical_slider_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Vertical_Pressed = false;
        }

        private void Vertical_slider_MouseMove(object sender, MouseEventArgs e)
        {
            if (Vertical_Pressed == true)
            {
                Grid grid = (Grid)sender;
                Point point = Mouse.GetPosition(grid);
                if (point.X >= Vertical_slider.Margin.Left && point.X <= Vertical_slider.Margin.Left + Vertical_slider.Width && point.Y >= Vertical_slider.Margin.Top && point.Y <= Vertical_slider.Margin.Top + Vertical_slider.Height)
                {
                    double pointy = point.Y;

                    Vertical_slider.Value = (pointy - Vertical_slider.Margin.Top) * Vertical_slider.Maximum / (Vertical_slider.Height);
                    Vertical_line.Y1 = pointy - (Vertical_slider.Value - 5);
                    Vertical_line.Y2 = pointy - (Vertical_slider.Value - 5);
                    //line.X1 = pointx - (slider.Value - 5) * 1;
                    //line.X2 = pointx - (slider.Value - 5) * 1;
                    //label_time.Content = starttime.AddMinutes(slider.Value / slider.Maximum * timespan).ToString("yyyy-MM-dd HH:mm:ss") + " " + slider.Value;
                }
            }
        }

        private void Vertical_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //MessageBox.Show("Value_Change");
            Vertical_line.Y1 = Vertical_slider.Height - Vertical_slider.Value*Vertical_slider.Height/Vertical_slider.Maximum+Vertical_slider.Margin.Top + (Vertical_slider.Value - 5);
            Vertical_line.Y2 = Vertical_line.Y1;
            label_value.Content =(int)(minvalue + Vertical_slider.Value / Vertical_slider.Maximum * maxvalue);
        } 
    }

    class myline_Struct
    {
        public string LineName = "";                              // 曲线的名字
        public string LineColor = "";                             // 曲线的颜色
        public myline_Struct(string linename,string linecolor)
        {
            LineName = linename;
            LineColor = linecolor;
        }
    }
}
