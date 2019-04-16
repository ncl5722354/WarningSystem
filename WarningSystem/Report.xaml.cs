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
using System.Collections;
using String_Caozuo;

namespace WarningSystem
{
    /// <summary>
    /// Report.xaml 的交互逻辑
    /// </summary>
    public partial class Report : UserControl
    {
        /// <summary>
        /// 报表内容，每10米做一个汇报，
        /// 汇报内容，平均位移，最大位移，最大位移点，平均位移与上日之差
        /// 1.875-939          875-885 || 885-895  || 895-905  || 905-915 || 915-925|| 925-939
        /// 2.994-1069         994-1004 || 1004-1014  ||  1014-1024  || 1024-1034  || 1034-1044  ||  1044-1054  ||  1054-1069
        /// 3.742-810          742-752  || 752-762  || 762-772 || 772-782 || 782-792 || 792-802 || 802-810
        /// 4.602-672          602-612  || 612-622  || 622-632 || 632-642 || 642-652 || 652-662 || 662-672
        /// 5.2164-2317        2164-2174 || 2174-2184 || 2184-2194 || 2194-2204 || 2204-2214 || 2214-2224 || 2224-2234 || 2234-2244 || 2244-2254 || 2254-2264 || 2264-2274 || 2274-2284 || 2284-2294 || 2294-2304 || 2304-2314
        /// 6.2411-2558        2411-2421 || 2421-2431 || 2431-2441 || 2441-2451 || 2451-2461 || 2461-2471 || 2471-2481 || 2481-2491 || 2491-2501 || 2501-2511 || 2511-2521 || 2521-2531 || 2531-2541 || 2541-2558
        /// 7.2934-3074        2934-2944 || 2944-2954 || 2954-2964 || 2964-2974 || 2974-2984 || 2984-2994 || 2994-3004 || 3004-3014 || 3014-3024 || 3024-3034 || 3034-3044 || 3044-3054 || 3054-3064 || 3064-3074
        /// 
        /// </summary>
        myreportview reportview = new myreportview();

        string nowname = "";                 // 现在的名称
        double nowallvalue = 0;              // 现在的总数
        double nowcounts = 0;                // 总数
        double maxvalue = 0;                 // 最大值 
        double maxposition = 0;              // 最大值的位置
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Report()
        {
            InitializeComponent();
            timer.Interval = 40000;
            timer.Tick += new EventHandler(Show_Report);
            timer.Enabled = true;
            init_view();
        }




        private void init_view()
        {
            this.Margin = new Thickness(0, 0, 0, 0);
            windowsformhost.Margin = new Thickness(0, 0, 0, 0);
            windowsformhost.Width = this.Width;
            windowsformhost.Height = this.Height * 0.5;



            windowsformhost.Child = reportview;
           
            //loadReport();
        }

        public void Show_Report(object sender,EventArgs e)
        {
            if (DateTime.Now.Hour != 9 || DateTime.Now.Minute != 35) return;
            try
            {
                ArrayList allline = MainWindow.Report_Config.ReadSections();  // 所有的报表项
                
                for(int i=0;i<MainWindow.Real_Data_List.Count;i++)
                {
                    try
                    {
                        DataList.Data_Struct mystruct = (DataList.Data_Struct)MainWindow.Real_Data_List[i];
                        foreach (string linename in allline)
                        {
                            double start = double.Parse(string_caozuo.Get_Xiahuaxian_String(linename, 1));
                            double end = double.Parse(string_caozuo.Get_Xiahuaxian_String(linename, 2));
                            
                            if (mystruct.位置 >= start && mystruct.位置 <= end)
                            {
                                if (nowname == "" || nowname==linename)
                                {
                                    nowname = linename;
                                    nowallvalue = nowallvalue + mystruct.位移量;     //累加
                                    if (mystruct.位移量 >= maxvalue)
                                    {
                                        maxvalue = mystruct.位移量;       //最大值
                                        maxposition = mystruct.位置;  // 最大值的位置
                                    }
                                    nowcounts++;

                                }
                                if (nowname != linename && nowname!="")
                                {

                                    string report_name = "report" + DateTime.Now.ToString("yyyyMMdd");
                                    SqlConnect.CreateSqlValueType[] create_report = new SqlConnect.CreateSqlValueType[6];
                                    create_report[0] = new SqlConnect.CreateSqlValueType("nvarchar(50)", "Line_Name", true, false);
                                    create_report[1] = new SqlConnect.CreateSqlValueType("nvarchar(50)", "mylinename");
                                    create_report[2] = new SqlConnect.CreateSqlValueType("nvarchar(50)","Agv_Value");
                                    create_report[3] = new SqlConnect.CreateSqlValueType("nvarchar(50)","Max_Value");
                                    create_report[4] = new SqlConnect.CreateSqlValueType("nvarchar(50)","Max_Position");
                                    create_report[5] = new SqlConnect.CreateSqlValueType("nvarchar(50)","Last_Cha");

                                    MainWindow.builder.Create_Table(report_name, create_report);

                                    string[] insert_string = new string[6];
                                    insert_string[0] = nowname;
                                    insert_string[1] = MainWindow.Report_Config.IniReadValue(nowname, "position_name");
                                    insert_string[2] = (nowallvalue / nowcounts).ToString();
                                    insert_string[3] = maxvalue.ToString();
                                    insert_string[4] = maxposition.ToString();
                                    insert_string[5] = "";

                                    string[] update_string=new string[6];
                                    update_string[0] = "Line_Name='" + nowname + "'";
                                    update_string[1] = "mylinename='" + MainWindow.Report_Config.IniReadValue(nowname, "position_name") + "'";
                                    update_string[2] = "Agv_Value='" + (nowallvalue / nowcounts).ToString() + "'";
                                    update_string[3] = "Max_Value='" + maxvalue.ToString() + "'";
                                    update_string[4] = "Max_Position='" + maxposition.ToString() + "'";
                                    update_string[5] = "Last_Cha=''";
                                    try
                                    {
                                        MainWindow.builder.Insert(report_name, insert_string);
                                    }
                                    catch
                                    {
                                        MainWindow.builder.Updata(report_name, "Line_Name='" + nowname + "'", update_string);
                                    }

                                    nowname = linename;
                                    nowallvalue =  mystruct.位移量;     //累加
                                    maxvalue = 0;
                                    if (mystruct.位移量 >= maxvalue)
                                    {
                                        maxvalue = mystruct.位移量;       //最大值
                                        maxposition = mystruct.位置;  // 最大值的位置
                                    }
                                    nowcounts = 1;
                                    //MainWindow.builder.Create_Table(DateTime.Now.ToString("ReportyyyyMMddHHmmss"));
                                }

                            }
                        }
                    }
                    catch { }
                    
                }
            }
            catch { }
            
        }
        public void loadReport()
        {
            DataTable dt = new DataTable();
            //定义本地数据表的列，名称应跟之前所建的testDataTable表中列相同。
            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(string));
            dt.Columns.Add("Column3", typeof(string));
            dt.Columns.Add("Column4", typeof(string));

            //动态生成一些测试用数据
            for (int i = 0; i < 50; i++)
            {
                DataRow row = dt.NewRow();
                row[0] = "Test01-" + i.ToString();
                row[1] = "Test02-" + i.ToString();
                row[2] = "Test03-" + i.ToString();
                row[3] = "Test04-" + i.ToString();
                dt.Rows.Add(row);
            }

            //设置本地报表，使程序与之前所建的testReport.rdlc报表文件进行绑定。
            // this.reportview.LocalReport.ReportPath = "testReport.rdlc";
            //this.reportview.DataBindingsLocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetName",dt));
            reportview.Reset_Report(dt);

        }
    }
}
