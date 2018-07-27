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
using ViewConfig;
using WPFDataStruct;
using WpfControls;
using SqlConnect;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Ranji_Controlor4._0
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static string DataBase_Name = "Ranji4.0";
        public static SQL_Connect_Builder database_builder = new SQL_Connect_Builder(".", DataBase_Name, 0, 100);
        public static Running_Data running_data = null;                                                      // 运行时结构
        
        public static ArrayList AllSubWindow = new ArrayList();                                              // 保存所有的窗体

        public static DataTable AllValue_Table = null;                                                       // 在内存中的所有值的表
        public static DataTable RunTime_Save_Table = null;                                                   // 在内存中的所有的保存的表
        public static DataTable AllStation_Table = null;                                                     // 在内存中的所有站的信息

        System.Timers.Timer savetimer = new System.Timers.Timer();                                           // 用来记录数据的时钟
        CreateSqlValueType[] runtime_create_sql_value_type = new CreateSqlValueType[4];                      // 保存实时数据的表结构

        public MainWindow()
        {
            InitializeComponent();
            // 解析主界面
            // 解析所有的Grid
            this.Left = 0;
            this.Top = 0;
            this.Width = ViewCaoZuo.width;
            this.Height = ViewCaoZuo.height;
            this.Name = "MainWindow";
            DataTable dt = database_builder.Select_Table("Station_Info");
            running_data = new Running_Data(dt);

            // 解析所有表

            DataPrase.Parse_All_Table_Struct(database_builder);


            DataPrase.Parse_All_Data_Grid(database_builder);

            WPFDataStruct.WindowParsing.ParseWindow(this, database_builder, MainGrid);

            WPFDataStruct.WindowParsing.Read_All_SubWindow(database_builder, AllSubWindow,running_data);

            Add_Event();
            // 读取所有的窗体

            Read_All_Value();
            Read_All_RunTime_Table();
            Read_All_Station();

            // 初始化建立实时历史数据库的命令
            runtime_create_sql_value_type[0] = new CreateSqlValueType("nvarchar(50)", "TimeAndName", true);
            runtime_create_sql_value_type[1] = new CreateSqlValueType("nvarchar(50)","Value_Name");
            runtime_create_sql_value_type[2] = new CreateSqlValueType("DateTime","Time");
            runtime_create_sql_value_type[3] = new CreateSqlValueType("nvarchar(50)","Value");
            // 初始化时钟
            savetimer.Interval = 10000;
            savetimer.Elapsed += new System.Timers.ElapsedEventHandler(Save_RunTimeValue_Tick);
            savetimer.Enabled = true;

           
            //解析所有的保存数据
         
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Add_Event()
        {
            
            string where_cmd = "ParentWindow='MainWindow'";
            DataTable dt = database_builder.Select_Table("ALLGrid", where_cmd);
            foreach(UIElement element in MainGrid.Children)
            {
                Type type = element.GetType();
                if (type.ToString() == "System.Windows.Controls.Grid")
                {
                    Grid subgrid = (Grid)element;
                    foreach(UIElement subelement in subgrid.Children)
                    {
                        Type subtype = subelement.GetType();
                        if(subtype.ToString()=="WpfControls.MyTreeView")
                        {
                            MyTreeView mytreeview = (MyTreeView)subelement;
                            mytreeview.JumpWindow += new EventHandler(Jump_Window);
                        }
                    }
                }
            }
        }

        public void Jump_Window(object sender,EventArgs e)
        {
            MyTreeView mytreeview = (MyTreeView)sender;
            TreeView selected_treeview = mytreeview.Get_Treeview();
            TreeViewItem item = (TreeViewItem)selected_treeview.SelectedItem;
            string index = item.Name;
            string where_cmd = "Node_ID='" + index + "'";
            DataTable dt = database_builder.Select_Table(mytreeview.Name, where_cmd);
            if(dt!=null)
            {
                if(dt.Rows.Count>0)
                {
                    DataRow dr = dt.Rows[0];
                    if(dr[3].ToString()=="jumpwindow")
                    {
                        Show_SubWindow_in_Grid(dr[5].ToString(),dr[4].ToString());
                    }
                }
            }
        }

        private void Show_SubWindow_in_Grid(string windowname,string grid)
        {
            foreach(UIElement element in MainGrid.Children)
            {
                
                if (element.GetType().ToString() == "System.Windows.Controls.Grid")
                {
                    
                    Grid mygrid = (Grid)element;
                    if (mygrid.Name == grid)
                    {
                        foreach (SubWindow subwindow in AllSubWindow)
                        {
                            if (subwindow.Name == windowname)
                            {
                                //subwindow.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[9].ToString()));
                                mygrid.Children.Clear();
                                if (subwindow.Parent != null)
                                {
                                    subwindow.Parent.SetValue(ContentPresenter.ContentProperty, null);
                                }
                                //subwindow.Background
                                mygrid.Children.Add(subwindow);
                                break;
                            }
                            
                        }
                        break;
                    }
                }
            }
        }

        private void Read_All_Value()
        {
            AllValue_Table = database_builder.Select_Table("Value_Table");
            AllValue_Table.Columns[0].ColumnName = "Value_Name";

        }

        private void Read_All_RunTime_Table()
        {
            RunTime_Save_Table = database_builder.Select_Table("RunTimeSaveTable");
        }

        private void Read_All_Station()
        {
            AllStation_Table = database_builder.Select_Table("Station_Info");
            AllStation_Table.Columns[0].ColumnName = "Station_Name";
        }

        private void Save_RunTimeValue_Tick(object sender,System.Timers.ElapsedEventArgs e)
        {
            string Table_Name = "runtimetable" + DateTime.Now.ToString("yyyyMMdd");
            database_builder.Create_Table(Table_Name, runtime_create_sql_value_type);
            // 将所有的值插入进去
            if (RunTime_Save_Table == null) return;
            if (AllValue_Table == null) return;
            if (RunTime_Save_Table.Rows.Count == 0) return;
            if (AllValue_Table.Rows.Count == 0) return;
            if (AllStation_Table == null) return;
            if (AllStation_Table.Rows.Count == 0) return;
            foreach(DataRow dr in RunTime_Save_Table.Rows)
            {
                string value_name = dr[0].ToString();
                // 在变量表中找出值
                DataRow[] valuerows = AllValue_Table.Select("Value_Name='" + value_name + "'");
                DataRow valuerow = valuerows[0];

                string value_type = valuerow[1].ToString();
                int value_address = int.Parse(valuerow[3].ToString());
                string return_value="";

                for (int i = 0; i < running_data.Station_Info_List.Count; i++)
                {
                    Running_Data_Struct mystruct = (Running_Data_Struct)running_data.Station_Info_List[i];
                    if (mystruct.Get_Name() == valuerow[2].ToString())
                    {
                        if (value_type == "Int")
                        {
                            int[] int_array = mystruct.Get_IntData();
                            return_value = int_array[value_address].ToString();
                        }
                        if (value_type == "Bool")
                        {
                            bool[] bool_array = mystruct.Get_SwitchData();
                            return_value = bool_array[value_address].ToString();
                        }
                        if (value_type == "String")
                        {
                            double[] double_array = mystruct.Get_DoubleData();
                            return_value = double_array[value_address].ToString();
                        }
                        // 插入表中

                        string[] insert_cmd=new string[4];
                        insert_cmd[0] = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + value_name;
                        insert_cmd[1] = value_name;
                        insert_cmd[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        insert_cmd[3] = return_value;
                        database_builder.Insert(Table_Name, insert_cmd);

                        // 插入到列表中
                        foreach (object mydatatable in MyChart.All_Used_Running_Table)
                        {
                            DataTable mydt = (DataTable)mydatatable;
                            if (mydt.TableName == Table_Name)
                            {
                                DataRow newdr = mydt.NewRow();
                                newdr[0] = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + value_name;
                                newdr[1] = value_name;
                                newdr[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                newdr[3] = return_value;
                                mydt.Rows.Add(newdr);
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
