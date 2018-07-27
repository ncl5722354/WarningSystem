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
using SqlConnect;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using WpfControls;
using System.Collections;

namespace WPFDataStruct
{
    /// <summary>
    /// 解析窗体类
    /// </summary>
    public class WindowParsing
    {
        // 解析主窗体
        public static void ParseWindow(Window mywindow,SQL_Connect_Builder sql_builder,Grid MainGrid)
        {
            //  解析所有的Grid
            #region
            string where_cmd="ParentWindow='"+mywindow.Name+"'";
            DataTable allgriddt = sql_builder.Select_Table("ALLGrid", where_cmd);
            if (allgriddt != null)
            {
                if (allgriddt.Rows.Count > 0)
                {
                    foreach (DataRow dr in allgriddt.Rows)
                    {
                        Grid grid = new Grid();

                        // 水平对齐
                        if (dr[3].ToString() == "Left")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Left;
                        }
                        if (dr[3].ToString() == "Center")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Center;
                        }
                        if (dr[3].ToString() == "Right")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Right;
                        }
                        if (dr[3].ToString() == "Stretch")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
                        }

                        // 垂直对齐
                        if (dr[4].ToString() == "Bottom")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Bottom;
                        }
                        if (dr[4].ToString() == "Center")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Center;
                        }
                        if (dr[4].ToString() == "Stretch")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Stretch;
                        }
                        if (dr[4].ToString() == "Top")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Top;
                        }

                        int marginLeft = int.Parse(dr[5].ToString());
                        int marginRight = int.Parse(dr[6].ToString());
                        int marginTop = int.Parse(dr[7].ToString());
                        int marginBottom = int.Parse(dr[8].ToString());

                        grid.Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom);
                        grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[9].ToString()));
                        grid.Name = dr[0].ToString();

                        if (dr[10].ToString() != "")
                        {
                            grid.Width = double.Parse(dr[10].ToString());
                        }
                        if (dr[11].ToString() != "")
                        {
                            grid.Height = double.Parse(dr[11].ToString());
                        }
                        if(dr[2].ToString()=="MainGrid")
                        {
                            // 在主页面下
                            
                            MainGrid.Children.Add(grid);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach(UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if(mygrid.Name==dr[2].ToString())
                                    {
                                        mygrid.Children.Add(grid);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion
            //  解析所有的MyTreeView
            #region
            where_cmd = "ParentWindow='" + mywindow.Name + "'";
            DataTable allMyTreeView = sql_builder.Select_Table("ALLMyTreeView", where_cmd);
            if (allMyTreeView != null)
            {
                if (allMyTreeView.Rows.Count > 0)
                {
                    foreach(DataRow dr in allMyTreeView.Rows)
                    {
                        DataTable TreeViewItemsdt = sql_builder.Select_Table(dr[0].ToString());
                        MyTreeView treeview = new MyTreeView(TreeViewItemsdt);
                        treeview.Name = dr[0].ToString();
                        if (dr[3].ToString() == "Left")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Left;
                        }
                        if (dr[3].ToString() == "Center")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Center;
                        }
                        if (dr[3].ToString() == "Right")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Right;
                        }
                        if (dr[3].ToString() == "Stretch")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Stretch;
                        }

                        // 垂直对齐
                        if (dr[4].ToString() == "Bottom")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Bottom;
                        }
                        if (dr[4].ToString() == "Center")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Center;
                        }
                        if (dr[4].ToString() == "Stretch")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Stretch;
                        }
                        if (dr[4].ToString() == "Top")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Top;
                        }

                        int marginLeft = int.Parse(dr[5].ToString());
                        int marginRight = int.Parse(dr[6].ToString());
                        int marginTop = int.Parse(dr[7].ToString());
                        int marginBottom = int.Parse(dr[8].ToString());

                        treeview.Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom);
                        treeview.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[9].ToString()));
                        treeview.Name = dr[0].ToString();

                        if (dr[10].ToString() != "")
                        {
                            treeview.Width = double.Parse(dr[10].ToString());
                        }
                        if (dr[11].ToString() != "")
                        {
                            treeview.Height = double.Parse(dr[11].ToString());
                        }
                        if (dr[2].ToString() == "MainGrid")
                        {
                            // 在主页面下

                            MainGrid.Children.Add(treeview);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach (UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if (mygrid.Name == dr[2].ToString())
                                    {
                                        mygrid.Children.Add(treeview);
                                        break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion



        }
        
        // 读取所有的副窗体
        public static void Read_All_SubWindow(SQL_Connect_Builder sql_builder,ArrayList window_arraylist,Running_Data data)
        {
            string where_cmd = "WindowName <> 'MainWindow'";
            DataTable dt = sql_builder.Select_Table("ALLWindow",where_cmd);
            if(dt!=null)
            {
                if(dt.Rows.Count>0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        SubWindow subwindow = new SubWindow(data);
                        subwindow.Name = dr[0].ToString();
                        Parse_SubWindow(subwindow, sql_builder, subwindow.MainGrid,data);
                        window_arraylist.Add(subwindow);
                    }
                }
            }
        }

        //解析副窗体
        public static void Parse_SubWindow(UserControl subwindow,SQL_Connect_Builder sql_builder,Grid MainGrid,Running_Data data)
        {
            // 解析所有的Grid
            #region
            string where_cmd = "ParentWindow='" + subwindow.Name + "'";
            DataTable allgriddt = sql_builder.Select_Table("ALLGrid", where_cmd);
            if (allgriddt != null)
            {
                if (allgriddt.Rows.Count > 0)
                {
                    foreach (DataRow dr in allgriddt.Rows)
                    {
                        Grid grid = new Grid();

                        // 水平对齐
                        if (dr[3].ToString() == "Left")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Left;
                        }
                        if (dr[3].ToString() == "Center")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Center;
                        }
                        if (dr[3].ToString() == "Right")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Right;
                        }
                        if (dr[3].ToString() == "Stretch")
                        {
                            grid.HorizontalAlignment = HorizontalAlignment.Stretch;
                        }

                        // 垂直对齐
                        if (dr[4].ToString() == "Bottom")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Bottom;
                        }
                        if (dr[4].ToString() == "Center")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Center;
                        }
                        if (dr[4].ToString() == "Stretch")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Stretch;
                        }
                        if (dr[4].ToString() == "Top")
                        {
                            grid.VerticalAlignment = VerticalAlignment.Top;
                        }

                        int marginLeft = int.Parse(dr[5].ToString());
                        int marginRight = int.Parse(dr[6].ToString());
                        int marginTop = int.Parse(dr[7].ToString());
                        int marginBottom = int.Parse(dr[8].ToString());

                        grid.Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom);
                        grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[9].ToString()));
                        grid.Name = dr[0].ToString();

                        if (dr[10].ToString() != "")
                        {
                            grid.Width = double.Parse(dr[10].ToString());
                        }
                        if (dr[11].ToString() != "")
                        {
                            grid.Height = double.Parse(dr[11].ToString());
                        }
                        if (dr[2].ToString() == "MainGrid")
                        {
                            // 在主页面下

                            MainGrid.Children.Add(grid);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach (UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if (mygrid.Name == dr[2].ToString())
                                    {
                                        mygrid.Children.Add(grid);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion

            //  解析所有的MyTreeView
            #region
            where_cmd = "ParentWindow='" + subwindow.Name + "'";
            DataTable allMyTreeView = sql_builder.Select_Table("ALLMyTreeView", where_cmd);
            if (allMyTreeView != null)
            {
                if (allMyTreeView.Rows.Count > 0)
                {
                    foreach (DataRow dr in allMyTreeView.Rows)
                    {
                        DataTable TreeViewItemsdt = sql_builder.Select_Table(dr[0].ToString());
                        MyTreeView treeview = new MyTreeView(TreeViewItemsdt);
                        treeview.Name = dr[0].ToString();
                        if (dr[3].ToString() == "Left")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Left;
                        }
                        if (dr[3].ToString() == "Center")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Center;
                        }
                        if (dr[3].ToString() == "Right")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Right;
                        }
                        if (dr[3].ToString() == "Stretch")
                        {
                            treeview.HorizontalAlignment = HorizontalAlignment.Stretch;
                        }

                        // 垂直对齐
                        if (dr[4].ToString() == "Bottom")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Bottom;
                        }
                        if (dr[4].ToString() == "Center")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Center;
                        }
                        if (dr[4].ToString() == "Stretch")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Stretch;
                        }
                        if (dr[4].ToString() == "Top")
                        {
                            treeview.VerticalAlignment = VerticalAlignment.Top;
                        }

                        int marginLeft = int.Parse(dr[5].ToString());
                        int marginRight = int.Parse(dr[6].ToString());
                        int marginTop = int.Parse(dr[7].ToString());
                        int marginBottom = int.Parse(dr[8].ToString());

                        treeview.Margin = new Thickness(marginLeft, marginTop, marginRight, marginBottom);
                        treeview.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[9].ToString()));
                        treeview.Name = dr[0].ToString();

                        if (dr[10].ToString() != "")
                        {
                            treeview.Width = double.Parse(dr[10].ToString());
                        }
                        if (dr[11].ToString() != "")
                        {
                            treeview.Height = double.Parse(dr[11].ToString());
                        }
                        if (dr[2].ToString() == "MainGrid")
                        {
                            // 在主页面下

                            MainGrid.Children.Add(treeview);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach (UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if (mygrid.Name == dr[2].ToString())
                                    {
                                        mygrid.Children.Add(treeview);
                                        break;
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion

            // 解析所有的MyLabel
            #region
            DataTable AllMyLabeldt = sql_builder.Select_Table("AllMyLabel", where_cmd);
            if (AllMyLabeldt != null)
            {
                if (AllMyLabeldt.Rows.Count > 0)
                {
                    foreach(DataRow dr in AllMyLabeldt.Rows)
                    {
                        MyLabel mylabel = new MyLabel(dr,sql_builder,data);
                        if (dr[2].ToString() == "MainGrid")
                        {
                            // 在主页面下

                            MainGrid.Children.Add(mylabel);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach (UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if (mygrid.Name == dr[2].ToString())
                                    {
                                        mygrid.Children.Add(mylabel);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion

            // 解析所有的MyChart
            #region
            DataTable AllMyChart = sql_builder.Select_Table("ALLMyChart",where_cmd);
            if(AllMyChart!=null)
            {
                if(AllMyChart.Rows.Count>0)
                {
                    foreach(DataRow dr in AllMyChart.Rows)
                    {
                        MyChart mychart = new MyChart(dr,sql_builder);
                        if (dr[2].ToString() == "MainGrid")
                        {
                            // 在主页面下

                            MainGrid.Children.Add(mychart);
                        }
                        else
                        {
                            // 不在主页面下
                            string GridName = dr[2].ToString();
                            foreach (UIElement element in MainGrid.Children)
                            {
                                try
                                {
                                    Grid mygrid = (Grid)element;
                                    if (mygrid.Name == dr[2].ToString())
                                    {
                                        mygrid.Children.Add(mychart);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            #endregion

            // 解析所有的MyDataGridView
            // 表格分种类
            #region
            DataTable AllDataGridView = sql_builder.Select_Table("AllDataGrid",where_cmd);
            if (AllDataGridView != null)
            {
                if (AllDataGridView.Rows.Count > 0)
                {
                    foreach(DataRow dr in AllDataGridView.Rows)
                    {
                        // 顺序表
                        if (dr[1].ToString() == "OrderTable")
                        {
                            // 读取表格
                            DataTable gongyibiao = sql_builder.Select_Table(dr[0].ToString());
                            if (gongyibiao == null) return;

                            MyOrderDataGridView datagridview = new MyOrderDataGridView(gongyibiao,dr);
                            if(dr[3].ToString()=="MainGrid")
                            {
                                // 在主页面下
                                MainGrid.Children.Add(datagridview);
                            }
                            else
                            {
                                // 不在主页面下
                                string GridName = dr[3].ToString();
                                foreach (UIElement element in MainGrid.Children)
                                {
                                    try
                                    {
                                        Grid mygrid = (Grid)element;
                                        if (mygrid.Name == dr[2].ToString())
                                        {
                                            mygrid.Children.Add(datagridview);
                                        }
                                    }
                                    catch { }
                                }

                            }
                        }
                    }
                }
            }
            #endregion
        }
 
    }
}
