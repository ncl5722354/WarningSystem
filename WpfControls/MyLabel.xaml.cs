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
using System.Collections;
using System.Threading;
using SqlConnect;


namespace WpfControls
{
    /// <summary>
    /// MyLabel.xaml 的交互逻辑
    /// 定义MyLable:
    /// 1.标签上的字符
    ///   标签字符的形式：
    ///   0 模式：直接显示模式
    ///   1 模式：条件显示模式
    ///     条件显示模式根据值可以设置三种条件，三种条件不可冲突，可以设置以下几种条件：
    ///     0 等于 1 小于 2 大于 3 小于等于 4 大于等于 5 不等于
    /// 2.标签的颜色
    ///   0 模式：直接指定背景颜色
    ///   1 模式：条件显示背景颜色
    ///     条件显示模式根据值可以设置三种条件，三种条件不可冲突，可以设置以下几种条件：
    ///     0 等于 1 小于 2 大于 3 小于等于 4 大于等于 5 不等于
    /// </summary>
    public partial class MyLabel : UserControl
    {
        
        private string ParentWindow = "";
        private string ParentGrid = "";
        private double MarginLeft = 0;
        private double MarginRight = 0;
        private double MarginTop = 0;
        private double MarginBottom = 0;
        
        private string Value_Name = "";
        private static SQL_Connect_Builder sqlbuilder = null;

        public static ArrayList ALLMyLabel_List = new ArrayList();                 // 保存所有的Label

       static Timer Timer_Gengxing_AllLabel = new Timer(gengxinTest,null,0,100);

        static Running_Data mydata = null;

        private static bool  gengxin = false;

        static DataTable ValueTable = null;


        private static void gengxinTest(object sender)
        {
            if (mydata != null)
            {
                int a = DateTime.Now.Minute;
                for (int i = 1; i <= 20; i++)
                {
                    mydata.Set_Value_Int("Station" + i.ToString(), 45, a);
                    mydata.Set_Value_Int("Station" + i.ToString(), 59, 30 + a);
                }
            }
        }
        private static void Gengxin_Tick(object sender,EventArgs e)
        {
           
                // 将来要改成事件驱动的变化，就是相应的时实库变化，本数据也发生变化
                if (gengxin == false)
                {
                    gengxin = true;
                    try
                    {
                        foreach (object mylabel in ALLMyLabel_List)
                        {
                            try
                            {
                                MyLabel label = (MyLabel)mylabel;
                                string Value_Name = label.Value_Name;
                                string where_cmd = "Value_Name = '" + Value_Name + "'";

                                //DataTable dt = sqlbuilder.Select_Table("Value_Table", where_cmd);
                                DataRow[] rows = ValueTable.Select(where_cmd);

                                DataRow dr = rows[0];
                                string value_type = dr[1].ToString();
                                string mode = dr[4].ToString();
                                // 0 模式 直接显示文字模式
                                #region
                                if (mode == "0")
                                {
                                    // 0 直接显示模式
                                    if (dr[2].ToString() == "")
                                    {
                                        label.Dispatcher.BeginInvoke(new Action(() => { label.Content = " " + dr[3].ToString() + " "; }));
                                        continue;
                                    }
                                    string station_name = dr[2].ToString();
                                    int address = int.Parse(dr[3].ToString());
                                    for (int i = 0; i < mydata.Station_Info_List.Count; i++)
                                    {
                                        Running_Data_Struct mystruct = (Running_Data_Struct)mydata.Station_Info_List[i];
                                        //string myname = mystruct.Get_Name();
                                        if (mystruct.Get_Name() == station_name)
                                        {
                                            // 当站的名与结构的站名相同
                                            if (value_type == "Int")
                                            {
                                                int[] num = mystruct.Get_IntData();
                                                label.Dispatcher.BeginInvoke(new Action(() => { label.Content = " " + num[address].ToString() + " "; }));
                                            }

                                            if (value_type == "Double")
                                            {

                                            }

                                            if (value_type == "Bool")
                                            {

                                            }
                                            break;
                                        }
                                    }
                                }
                                #endregion

                                // 1 模式 条件显示文字模式
                                #region
                                if (mode == "1")
                                {
                                    if (dr[2].ToString() == "" || dr[3].ToString() == "")
                                    {
                                        continue;  // 如果站名或者地址有一个为空，那么就不能用条件显示模式
                                    }
                                    string station_name = dr[2].ToString();
                                    int address = 0;
                                    try
                                    {
                                        address = int.Parse(dr[3].ToString());
                                    }
                                    catch { continue; }
                                    for (int i = 0; i < mydata.Station_Info_List.Count; i++)
                                    {
                                        Running_Data_Struct mystruct = (Running_Data_Struct)mydata.Station_Info_List[i];
                                        //string myname = mystruct.Get_Name();
                                        if (mystruct.Get_Name() == station_name)
                                        {
                                            // 当站的名与结构的站名相同
                                            if (value_type == "Int")
                                            {
                                                int[] num = mystruct.Get_IntData();
                                                int getvalue = num[address];
                                                string condition1 = dr[5].ToString();
                                                string condition2 = dr[8].ToString();
                                                string condition3 = dr[11].ToString();
                                                int value1 = -1;
                                                int value2 = -1;
                                                int value3 = -1;
                                                try
                                                {
                                                    value1 = int.Parse(dr[6].ToString());
                                                }
                                                catch { }
                                                try
                                                {
                                                    value2 = int.Parse(dr[9].ToString());
                                                }
                                                catch { }
                                                try
                                                {
                                                    value3 = int.Parse(dr[12].ToString());
                                                }
                                                catch { }
                                                string Return_Value1 = dr[7].ToString();
                                                string Return_Value2 = dr[10].ToString();
                                                string Return_Value3 = dr[13].ToString();
                                                string result1 = Condition_Int(getvalue, condition1, value1, Return_Value1);
                                                string result2 = Condition_Int(getvalue, condition2, value2, Return_Value2);
                                                string result3 = Condition_Int(getvalue, condition3, value3, Return_Value3);
                                                if (result1 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Content = " " + result1 + " "; })); continue; }
                                                if (result2 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Content = " " + result2 + " "; })); continue; }
                                                if (result3 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Content = " " + result3 + " "; })); continue; }
                                                label.Content = "标签设置有错误！";

                                            }

                                            if (value_type == "Double")
                                            {

                                            }

                                            if (value_type == "Bool")
                                            {

                                            }
                                            break;
                                        }
                                    }
                                }
                                #endregion

                                // 2 模式 直接显示标签颜色
                                #region
                                if (mode == "2")
                                {
                                    if (dr[2].ToString() == "" || dr[3].ToString() == "") continue;
                                    string station_name = dr[2].ToString();
                                    int address = 0;
                                    try
                                    {
                                        address = int.Parse(dr[3].ToString());
                                    }
                                    catch { continue; }
                                    for (int i = 0; i < mydata.Station_Info_List.Count; i++)
                                    {
                                        Running_Data_Struct mystruct = (Running_Data_Struct)mydata.Station_Info_List[i];
                                        if (mystruct.Get_Name() == station_name)
                                        {
                                            if (value_type == "Int")
                                            {

                                            }
                                            if (value_type == "Double")
                                            {

                                            }
                                            if (value_type == "Bool")
                                            {
                                                bool[] bool_num = mystruct.Get_SwitchData();
                                                bool getvalue = bool_num[address];
                                                string condition1 = dr[5].ToString();
                                                string condition2 = dr[8].ToString();
                                                string condition3 = dr[11].ToString();
                                                bool value1 = false;
                                                bool value2 = false;
                                                bool value3 = false;
                                                try
                                                {
                                                    value1 = bool.Parse(dr[6].ToString());
                                                }
                                                catch { }
                                                try
                                                {
                                                    value2 = bool.Parse(dr[9].ToString());
                                                }
                                                catch { }
                                                try
                                                {
                                                    value3 = bool.Parse(dr[12].ToString());
                                                }
                                                catch { }
                                                string Return_Value1 = dr[7].ToString();
                                                string Return_Value2 = dr[10].ToString();
                                                string Return_Value3 = dr[13].ToString();
                                                string color1 = Condition_Bool(getvalue, condition1, value1, Return_Value1);
                                                string color2 = Condition_Bool(getvalue, condition2, value2, Return_Value2);
                                                string color3 = Condition_Bool(getvalue, condition3, value3, Return_Value3);
                                                if (color1 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color1)); })); continue; }
                                                if (color2 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color2)); })); continue; }
                                                if (color3 != null) { label.Dispatcher.BeginInvoke(new Action(() => { label.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color3)); })); continue; }
                                            }
                                            break;
                                        }
                                    }

                                }
                                #endregion
                            }
                            catch { }
                        }
                        gengxin = false;
                    }
                    catch { gengxin = false; }
                }
            
        }
        
        public MyLabel(DataRow dr,SQL_Connect_Builder builder,Running_Data data)
        {
            InitializeComponent();

            mydata = data;
            mydata.value_Change_Event += new EventHandler(Gengxin_Tick);

            // mydata的变化与mylabel的变化进行对接

            sqlbuilder = builder;

            ValueTable = builder.Select_Table("Value_Table");                //  数据字典表
            ValueTable.Columns[0].ColumnName = "Value_Name";

            this.Name = dr[0].ToString();

            ParentWindow = dr[1].ToString();

            ParentGrid = dr[2].ToString();

            
            try
            {
                Width = double.Parse(dr[3].ToString());
            }
            catch
            {
                Width = double.NaN;
            }

            try
            {
                Height = double.Parse(dr[4].ToString());
            }
            catch
            {
                Height = double.NaN;
            }
            try
            {
                
                this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(dr[15].ToString()));
                
            }
            catch { }

            // 横对齐解析
            switch(dr[5].ToString())
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
            switch(dr[6].ToString())
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

            MarginLeft = double.Parse(dr[7].ToString());
            MarginRight = double.Parse(dr[8].ToString());
            MarginTop = double.Parse(dr[9].ToString());
            MarginBottom = double.Parse(dr[10].ToString());

            this.Margin = new Thickness(MarginLeft, MarginTop, MarginRight, MarginBottom);

            switch(dr[11].ToString())
            {
                case "Left":
                    Label.HorizontalContentAlignment = HorizontalAlignment.Left;
                    break;
                case "Right":
                    Label.HorizontalContentAlignment = HorizontalAlignment.Right;
                    break;
                case "Center":
                    Label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    break;
                case "Stretch":
                    Label.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    break;
                default:
                    Label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    break;
            }

            switch(dr[12].ToString())
            {
                case "Top":
                    Label.VerticalContentAlignment = VerticalAlignment.Top;
                    break;
                case "Bottom":
                    Label.VerticalContentAlignment = VerticalAlignment.Bottom;
                    break;
                case "Center":
                    Label.VerticalContentAlignment = VerticalAlignment.Center;
                    break;
                case "Stretch":
                    Label.VerticalContentAlignment = VerticalAlignment.Stretch;
                    break;
                default:
                    Label.VerticalContentAlignment = VerticalAlignment.Center;
                    break;
            }

            double myfontsize = double.Parse(dr[13].ToString());
           // Label.FontSize = myfontsize;
            this.FontSize = myfontsize;
            //label.FontSize = myfontsize;

            Value_Name = dr[14].ToString();
            ALLMyLabel_List.Add(this);
        }

        public string Get_Content()
        {
            return Label.Content.ToString();
        }

        public string Get_Value_Name()
        {
            return Value_Name;
        }

        ///应用功能 比较功能
        public static string Condition_Int(int scr_value ,string condition,int condition_value,string result_value)
        {
            if(condition=="等于")
            {
                if (scr_value == condition_value) return result_value;
                else return null;
            }
            else if(condition=="大于")
            {
                if (scr_value > condition_value) return result_value;
                else return null;
            }
            else if(condition=="小于")
            {
                if (scr_value < condition_value) return result_value;
                else return null;
            }
            else if(condition=="大于等于")
            {
                if (scr_value >= condition_value) return result_value;
                else return null;
            }
            else if(condition=="小于等于")
            {
                if (scr_value <= condition_value) return result_value;
                else return null;
            }
            else if(condition=="不等于")
            {
                if (scr_value != condition_value) return result_value;
                else return null;
            }
            else
            {
                return null;
            }
        }
        public static string Condition_Bool(bool scr_value,string condition,bool condition_value,string result_value)
        {
            if(condition=="等于")
            {
                if (scr_value == condition_value) return result_value;
                else return null;
            }
            else if(condition=="不等于")
            {
                if (scr_value != condition_value) return result_value;
                else return null;
            }
            else
            {
                return null;
            }
        }
    }
}
