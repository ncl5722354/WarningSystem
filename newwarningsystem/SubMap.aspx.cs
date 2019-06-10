using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;
using String_Caozuo;
using System.Collections;
using System.Text;
using System.IO;
using System.IO.Ports;


namespace newwarningsystem
{
    public partial class SubMap : System.Web.UI.Page
    {
        
        public static string map_name = "";
        public static string pic_uri = "";

        public static double click_value = 0;
        public static double max = 0;
        public static double min = 0;

        public static double start1 = 0;
        public static double end1 = 0;
        public static double start2 = 0;
        public static double end2 = 0;
        public static int selected1 = 0;
        public static int selected2 = 0;

        public static string chafen_title = "";

        double start_position = 160;
        double end_postion = 780;

        double value1 = 0;
        double value2 = 0;
        double value3 = 0;
        double value4 = 0;
        double value5 = 0;

        public static string listbox3_select = "";
        protected void Page_Load(object sender, EventArgs e)
        {

          //  Create_Map();
            ReFlush_List();
            Create_Map();
            Label_timer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            value1 = double.Parse(Set.set_yuzhi.IniReadValue("yuzhi", "1"));
            value2 = double.Parse(Set.set_yuzhi.IniReadValue("yuzhi", "2"));
            value3 = double.Parse(Set.set_yuzhi.IniReadValue("yuzhi", "3"));
            value4 = double.Parse(Set.set_yuzhi.IniReadValue("yuzhi", "4"));
            value5 = double.Parse(Set.set_yuzhi.IniReadValue("yuzhi", "5"));


            Chart_bingzhuangtu.Series[0].Points.Clear();
            Chart_bingzhuangtu.Series[0].Points.AddY(40);
            Chart_bingzhuangtu.Series[0].Points.AddY(35);
            Chart_bingzhuangtu.Series[0].Points.AddY(30);
            Chart_bingzhuangtu.Series[0].Points.AddY(20);
            Chart_bingzhuangtu.Series[0].Points.AddY(10);


            Chart_bingzhuangtu.Style["width"] = "200px";
            Chart_bingzhuangtu.Style["height"] = "200px";

            Chart_bingzhuangtu.Series[0].Points[0].Color = System.Drawing.Color.DarkBlue;
            Chart_bingzhuangtu.Series[0].Points[1].Color = System.Drawing.Color.Blue;
            Chart_bingzhuangtu.Series[0].Points[2].Color = System.Drawing.Color.LightGreen;
            Chart_bingzhuangtu.Series[0].Points[3].Color = System.Drawing.Color.Yellow;
            Chart_bingzhuangtu.Series[0].Points[4].Color = System.Drawing.Color.Red;

            Chart_bingzhuangtu.Series[0].Points[0].Label = "无预警";
            Chart_bingzhuangtu.Series[0].Points[1].Label = "蓝色预警";
            Chart_bingzhuangtu.Series[0].Points[2].Label = "绿色预警";
            Chart_bingzhuangtu.Series[0].Points[3].Label = "黄色预警";
            Chart_bingzhuangtu.Series[0].Points[4].Label = "红色预警";

            Chart_bingzhuangtu.Series[0].Points[0].LabelForeColor = System.Drawing.Color.White;
            Chart_bingzhuangtu.Series[0].Points[1].LabelForeColor = System.Drawing.Color.White;
            Chart_bingzhuangtu.Series[0].Points[2].LabelForeColor = System.Drawing.Color.Blue;
            Chart_bingzhuangtu.Series[0].Points[3].LabelForeColor = System.Drawing.Color.Red;
            Chart_bingzhuangtu.Series[0].Points[4].LabelForeColor = System.Drawing.Color.Blue;
            //for(int i=0;i<=4;i++)
            //{
            //    Chart_bingzhuangtu.Series[0].Points[i].LabelForeColor = System.Drawing.Color.White;
            //}

            biaozhi1_label.Text = "<" + value1.ToString() + " mm";
            biaozhi2_label.Text = "<" + value2.ToString() + " mm";
            biaozhi3_label.Text = "<" + value3.ToString() + " mm";
            biaozhi4_label.Text = "<" + value5.ToString() + " mm";
            biaozhi5_label.Text = ">=" + value5.ToString() + " mm";


        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Set_Start_End(start1, end1, start2, end2);

            //Chart1.Style["position"] = "absolute";
            //Chart1.Style["left"] = "700px";
            //Chart1.Style["top"] = "100px";
            //Chart1.Width = 500;
            //Chart1.Height = 300;
            //Chart1.Series[0].Points.AddXY(0, 0);
            //刷新列表

            Chart2.Style["position"] = "absolute";
            Chart2.Style["left"] = "0%";

            Chart2.Style["top"] = "75%";
            Chart2.Style["z-index"] = "5";
            Chart2.Width = 1200;
            Chart2.Height = 200;
            Image1.ImageUrl = pic_uri;
            Label_title.Text = chafen_title;
            ListBox4.Items.Clear();
            ListBox4.Items.Add("00:00-01:00");
            ListBox4.Items.Add("01:00-02:00");
            ListBox4.Items.Add("02:00-03:00");
            ListBox4.Items.Add("03:00-04:00");
            ListBox4.Items.Add("04:00-05:00");
            ListBox4.Items.Add("05:00-06:00");
            ListBox4.Items.Add("06:00-07:00");
            ListBox4.Items.Add("07:00-08:00");
            ListBox4.Items.Add("08:00-09:00");
            ListBox4.Items.Add("09:00-10:00");
            ListBox4.Items.Add("10:00-11:00");
            ListBox4.Items.Add("11:00-12:00");
            ListBox4.Items.Add("12:00-13:00");
            ListBox4.Items.Add("13:00-14:00");
            ListBox4.Items.Add("14:00-15:00");
            ListBox4.Items.Add("15:00-16:00");
            ListBox4.Items.Add("16:00-17:00");
            ListBox4.Items.Add("17:00-18:00");
            ListBox4.Items.Add("18:00-19:00");
            ListBox4.Items.Add("19:00-20:00");
            ListBox4.Items.Add("20:00-21:00");
            ListBox4.Items.Add("21:00-22:00");
            ListBox4.Items.Add("22:00-23:00");
            ListBox4.Items.Add("23:00-23:59");

           

        }

        private void ReFlush_List()
        {
            ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");
            

            ArrayList alldirs = FileCaozuo.Read_All_Dir("D:\\data\\");
            ListBox3.Items.Clear();
            foreach (DirectoryInfo info in alldirs)
            {
                ListBox3.Items.Add(info.Name);
            }
        }


        protected void Click(object sender, EventArgs e)
        {
            Chart2.Series[0].Points.Clear();
            Calendar1.SelectedDate = DateTime.Parse("1900-01-01");
            ImageButton ib = (ImageButton)sender;
            string tooltip = ib.ToolTip;
            string position_string_wanzheng = string_caozuo.Get_KongGe_String(tooltip, 1);
            string position_string1 = string_caozuo.Get_Maohao_String(position_string_wanzheng, 2);
            
            try
            {
                double value = double.Parse(position_string1);

                click_value = value;

                double jizhun = 0;
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist[0];
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                int count = 0;
                string position_string = "";

                // 寻找相应的索引
                foreach (string line in jizhun_list)
                {
                    position_string = string_caozuo.Get_Table_String(line, 1);
                    string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                    double positon_value = double.Parse(postion_value_string);
                    double position = double.Parse(position_string);
                    count++;
                    if (position == value)
                    {
                        jizhun = positon_value;
                        break;
                    }
                }
                // count就是相应的索引数
                ArrayList alldirs = FileCaozuo.Read_All_Dir("D:\\data\\");
               Chart2.Titles[0].Text = "位置：" + position_string1 + "位置曲线";
                foreach (DirectoryInfo dirinfo in alldirs)
                {

                    try
                    {
                        ArrayList allfiles = FileCaozuo.Read_All_Files(dirinfo.FullName, "*.txt");
                        //string[] alllines = FileCaozuo.Read_All_Line("D:\\data\\"+alldirs[0].ToString());
                        string myline = FileCaozuo.Get_Line("D:\\data\\" + allfiles[0].ToString(), count - 1);
                        string myvalue_string = string_caozuo.Get_Table_String(myline, 2);
                        double myvalue = double.Parse(myvalue_string);
                        string time_string = string_caozuo.Get_Dian_String(allfiles[0].ToString(), 1);
                        string day_string = string_caozuo.Get_HengGang_String(time_string, 1);
                        string year = string_caozuo.Get_Xiahuaxian_String(day_string, 1);
                        string month = string_caozuo.Get_Xiahuaxian_String(day_string, 2);
                        string day = string_caozuo.Get_Xiahuaxian_String(day_string, 3);
                        DateTime time = DateTime.Parse(year + "-" + month + "-" + day);
                        Chart2.Series[0].Points.AddXY(time.ToOADate(), Math.Abs(jizhun - myvalue) * (1 - Math.Sqrt(3) / 2) / 0.0482);
                        Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
                    }
                    catch { }
                }


                max = Chart2.ChartAreas[0].AxisX.Maximum;
                min = Chart2.ChartAreas[0].AxisX.Minimum;

                //Chart2.Titles[0].Text = "2";




            }
            catch { }

        }


        private void Create_Map()
        { 
            try{
                int count = int.Parse(MainMap.ini.IniReadValue(map_name, "count"));
                for (int i = 1; i <= count; i++)
                {
                    string linename = MainMap.ini.IniReadValue(map_name, "line" + i.ToString());
                    double rukou = double.Parse(MainMap.ini.IniReadValue(linename , "rukou"));
                    double chukou = double.Parse(MainMap.ini.IniReadValue(linename , "chukou"));
                    ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                    // 读取第一个文件作为基准
                    string file_jizhun = (string)filelist[0];
                    string file_now = (string)filelist[filelist.Count - 1];

                    //// 读取所有的行
                    //int count1 = 0;
                    //int count2 = 0;

                    string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                    string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

                    int mycount = 0;
                    for (int j = 0; j < jizhun_list.Length - 1; j++)
                    {
                        try
                        {

                            double position = double.Parse(string_caozuo.Get_Table_String(jizhun_list[j], 1));
                            if (position >= rukou && position <= chukou)
                            {
                                mycount++;
                                // 加入一个点
                                

                            }
                        }
                        catch { }
                    }
                    int thiscount = 0;
                    for (int j = 0; j < jizhun_list.Length - 1; j++)
                    {
                        try
                        {
                            double position = Math.Abs(double.Parse(string_caozuo.Get_Table_String(jizhun_list[j], 1)));
                            double jizhun = Math.Abs(double.Parse(string_caozuo.Get_Table_String(jizhun_list[j], 2)));
                            double value = Math.Abs(double.Parse(string_caozuo.Get_Table_String(now_list[j], 2)) - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482;

                            if (position >= rukou && position <= chukou)
                            {
                                thiscount++;
                                // 加入一个点
                                double x1 = double.Parse(MainMap.ini.IniReadValue(linename, "X1"));
                                double x2 = double.Parse(MainMap.ini.IniReadValue(linename, "X2"));
                                double y1 = double.Parse(MainMap.ini.IniReadValue(linename, "Y1"));
                                double y2 = double.Parse(MainMap.ini.IniReadValue(linename, "Y2"));

                                // 点的坐标
                                double x = (x2 - x1) / mycount * thiscount + x1;
                                double y = (y2 - y1) / mycount * thiscount + y1;
                                ImageButton imagebutton = new ImageButton();
                                imagebutton.ImageUrl = "~/Resource/bluedot.ico";
                                imagebutton.Style["position"] = "absolute";
                                if (map_name == "一号坡")
                                {
                                    imagebutton.Style["top"] = (y / 2.5 - 17).ToString() + "%";
                                    imagebutton.Style["left"] = (x / 3.7 - 32).ToString() + "%";
                                    imagebutton.Style["width"] = "5px";
                                    imagebutton.Style["height"] = "5px";
                                    imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                    imagebutton.Click += new ImageClickEventHandler(Click);
                                }
                                if (map_name == "二号坡上")
                                {
                                    imagebutton.Style["top"] = (y / 1.2 - 63).ToString() + "%";
                                    imagebutton.Style["left"] = (x / 3.4 - 100).ToString() + "%";
                                    imagebutton.Style["width"] = "5px";
                                    imagebutton.Style["height"] = "5px";
                                    imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                    imagebutton.Click += new ImageClickEventHandler(Click);
                                }
                                if (map_name == "二号坡下")
                                {
                                    imagebutton.Style["top"] = (y / 1.5 - 92).ToString() + "%";
                                    imagebutton.Style["left"] = (x / 3 - 115).ToString() + "%";
                                    imagebutton.Style["width"] = "5px";
                                    imagebutton.Style["height"] = "5px";
                                    imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                    imagebutton.Click += new ImageClickEventHandler(Click);
                                }


                                form1.Controls.Add(imagebutton);

                            }
                        }
                        catch { }
                    }
                }
            }
            catch{}
        }
        

        protected void link0_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 寻找基准
            
        }

        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
            int count = 0;
            double jizhun = 0;
            string position_string = "";
            // 寻找相应的索引
            foreach (string line in jizhun_list)
            {
                position_string = string_caozuo.Get_Table_String(line, 1);
                string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                double positon_value = double.Parse(postion_value_string);
                double position = double.Parse(position_string);
                count++;
                if (position == click_value)
                {
                    jizhun = positon_value;
                    break;
                }
            }


            // 查询一天的
            Chart2.Series[0].Points.Clear();
            try
            {
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");
                foreach (string file in filelist)
                {
                    try
                    {
                        ArrayList allfiles = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");

                        string myline = FileCaozuo.Get_Line("D:\\data\\" + listbox3_select + "\\" + file, count - 1);
                        string myvalue_string = string_caozuo.Get_Table_String(myline, 2);
                        double myvalue = double.Parse(myvalue_string);
                        string time_string = string_caozuo.Get_Dian_String(file, 1);
                        string day_string = string_caozuo.Get_HengGang_String(time_string, 1);
                        string sub_time_string = string_caozuo.Get_HengGang_String(time_string, 2);
                        string year = string_caozuo.Get_Xiahuaxian_String(day_string, 1);
                        string month = string_caozuo.Get_Xiahuaxian_String(day_string, 2);
                        string day = string_caozuo.Get_Xiahuaxian_String(day_string, 3);
                        string hour = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 1);
                        string min1 = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 2);
                        string sec = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 3);
                        DateTime time = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min1 + ":" + sec);

                        string select_time = ListBox4.Items[ListBox4.SelectedIndex].Value.ToString();
                        string start_time = string_caozuo.Get_HengGang_String(select_time, 1);
                        string end_time = string_caozuo.Get_HengGang_String(select_time, 2);
                        string start_hour = string_caozuo.Get_Maohao_String(start_time, 1);
                        string start_min = string_caozuo.Get_Maohao_String(start_time, 2);
                        string end_hour = string_caozuo.Get_Maohao_String(end_time, 1);
                        string end_min = string_caozuo.Get_Maohao_String(end_time, 2);

                        Chart2.Series[0].Points.AddXY(time.ToOADate(), Math.Abs(jizhun - myvalue) * (1 - Math.Sqrt(3) / 2) / 0.0482);
                        Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                        DateTime time1 = DateTime.Parse(year + "-" + month + "-" + day + " " + start_hour + ":" + start_min + ":" + "00");
                        DateTime time2 = DateTime.Parse(year + "-" + month + "-" + day + " " + end_hour + ":" + end_min + ":" + "59");
                        Chart2.ChartAreas[0].AxisX.Minimum = time1.ToOADate();
                        Chart2.ChartAreas[0].AxisX.Maximum = time2.ToOADate();
                        Chart2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Minutes;
                        Chart2.ChartAreas[0].AxisX.Interval = 5;
                        max = Chart2.ChartAreas[0].AxisX.Maximum;
                        min = Chart2.ChartAreas[0].AxisX.Minimum;
                        Label11.Text = year + "年" + month + "月" + day + "日" + start_hour + "时-" + end_hour + "时" + "  位置:" + position_string + " 的趋势区线";
                    }
                    catch { }


                }


            }
            catch { }
        }

        protected void link_Click(object sender, EventArgs e)
        {
            ChaFenSearch.start1 = start1;
            ChaFenSearch.start2 = start2;
            ChaFenSearch.end1 = end1;
            ChaFenSearch.end2 = end2;
            ChaFenSearch.title = chafen_title + "差分查询";
            Response.Redirect("ChaFenSearch.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            Chart2.Titles[0].Text = " 的趋势区线";
            for (int i = 0; i < ListBox3.Items.Count; i++)
            {
                string date = ListBox3.Items[i].Value.ToString();
                string hour = string_caozuo.Get_Xiahuaxian_String(date, 1);
                string min = string_caozuo.Get_Xiahuaxian_String(date, 2);
                string sec = string_caozuo.Get_Xiahuaxian_String(date, 3);
                //e.Day.IsSelectable = e.Day.Date == DateTime.Parse(hour + "-" + min + "-" + sec);
                if (e.Day.Date != DateTime.Parse(hour + "-" + min + "-" + sec))
                {
                    e.Cell.ForeColor = System.Drawing.Color.LightGray;
                }

            }
            if (Calendar1.SelectedDate == DateTime.Parse("1900-01-01")) return;
            if (e.Day.IsSelected == true)
            {

                // 选择了某日
                #region
                DateTime select_datetime = Calendar1.SelectedDate;
                string date_string = select_datetime.Year.ToString().PadLeft(4, '0') + "_" + select_datetime.Month.ToString().PadLeft(2, '0') + "_" + select_datetime.Day.ToString().PadLeft(2, '0');

                ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist_1[0];
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                int count = 0;
                double jizhun = 0;
                string position_string = "";
                // 寻找相应的索引
                foreach (string line in jizhun_list)
                {
                    position_string = string_caozuo.Get_Table_String(line, 1);
                    string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                    double positon_value = double.Parse(postion_value_string);
                    double position = double.Parse(position_string);
                    count++;
                    if (position == click_value)
                    {
                        jizhun = positon_value;
                        break;
                    }
                }

                listbox3_select = date_string;
                // 查询一天的
                Chart2.Series[0].Points.Clear();
                try
                {
                    ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");
                    foreach (string file in filelist)
                    {
                        try
                        {
                            ArrayList allfiles = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");

                            string myline = FileCaozuo.Get_Line("D:\\data\\" + listbox3_select + "\\" + file, count - 1);
                            string myvalue_string = string_caozuo.Get_Table_String(myline, 2);
                            double myvalue = double.Parse(myvalue_string);
                            string time_string = string_caozuo.Get_Dian_String(file, 1);
                            string day_string = string_caozuo.Get_HengGang_String(time_string, 1);
                            string sub_time_string = string_caozuo.Get_HengGang_String(time_string, 2);
                            string year = string_caozuo.Get_Xiahuaxian_String(day_string, 1);
                            string month = string_caozuo.Get_Xiahuaxian_String(day_string, 2);
                            string day = string_caozuo.Get_Xiahuaxian_String(day_string, 3);
                            string hour = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 1);
                            string min1 = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 2);
                            string sec = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 3);
                            DateTime time = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min1 + ":" + sec);

                            Chart2.Series[0].Points.AddXY(time.ToOADate(), Math.Abs(jizhun - myvalue) * (1 - Math.Sqrt(3) / 2) / 0.0482);
                            Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                            DateTime time1 = DateTime.Parse(year + "-" + month + "-" + day + " " + "00" + ":" + "00" + ":" + "00");
                            DateTime time2 = DateTime.Parse(year + "-" + month + "-" + day + " " + "23" + ":" + "59" + ":" + "59");
                            Chart2.ChartAreas[0].AxisX.Minimum = time1.ToOADate();
                            Chart2.ChartAreas[0].AxisX.Maximum = time2.ToOADate();
                            Chart2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                            Chart2.ChartAreas[0].AxisX.Interval = 1;
                            max = Chart2.ChartAreas[0].AxisX.Maximum;
                            min = Chart2.ChartAreas[0].AxisX.Minimum;
                            Chart2.Titles[0].Text = year + "年" + month + "月" + day + "日  位置:" + position_string + " 的趋势区线";
                        }
                        catch { }
                    }
                    return;
                }
                catch { }
                #endregion
            }
        }

        protected void Calendar1_DayRender1(object sender, DayRenderEventArgs e)
        {
            //Chart2.Titles[0].Text = " 的趋势区线";
            for (int i = 0; i < ListBox3.Items.Count; i++)
            {
                string date = ListBox3.Items[i].Value.ToString();
                string hour = string_caozuo.Get_Xiahuaxian_String(date, 1);
                string min = string_caozuo.Get_Xiahuaxian_String(date, 2);
                string sec = string_caozuo.Get_Xiahuaxian_String(date, 3);
                //e.Day.IsSelectable = e.Day.Date == DateTime.Parse(hour + "-" + min + "-" + sec);
                //if (e.Day.Date != DateTime.Parse(hour + "-" + min + "-" + sec))
                //{
                //    e.Cell.ForeColor = System.Drawing.Color.LightGray;
                //}

            }
            if (Calendar1.SelectedDate == DateTime.Parse("1900-01-01")) return;
            if (e.Day.IsSelected == true)
            {

                // 选择了某日
                #region
                DateTime select_datetime = Calendar1.SelectedDate;
                string date_string = select_datetime.Year.ToString().PadLeft(4, '0') + "_" + select_datetime.Month.ToString().PadLeft(2, '0') + "_" + select_datetime.Day.ToString().PadLeft(2, '0');

                ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist_1[0];
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                int count = 0;
                double jizhun = 0;
                string position_string = "";
                // 寻找相应的索引
                foreach (string line in jizhun_list)
                {
                    position_string = string_caozuo.Get_Table_String(line, 1);
                    string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                    double positon_value = double.Parse(postion_value_string);
                    double position = double.Parse(position_string);
                    count++;
                    if (position == click_value)
                    {
                        jizhun = positon_value;
                        break;
                    }
                }

                listbox3_select = date_string;
                // 查询一天的
                Chart2.Series[0].Points.Clear();
                try
                {
                    ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");
                    foreach (string file in filelist)
                    {
                        try
                        {
                            ArrayList allfiles = FileCaozuo.Read_All_Files("D:\\data\\" + listbox3_select, "*.txt");

                            string myline = FileCaozuo.Get_Line("D:\\data\\" + listbox3_select + "\\" + file, count - 1);
                            string myvalue_string = string_caozuo.Get_Table_String(myline, 2);
                            double myvalue = double.Parse(myvalue_string);
                            string time_string = string_caozuo.Get_Dian_String(file, 1);
                            string day_string = string_caozuo.Get_HengGang_String(time_string, 1);
                            string sub_time_string = string_caozuo.Get_HengGang_String(time_string, 2);
                            string year = string_caozuo.Get_Xiahuaxian_String(day_string, 1);
                            string month = string_caozuo.Get_Xiahuaxian_String(day_string, 2);
                            string day = string_caozuo.Get_Xiahuaxian_String(day_string, 3);
                            string hour = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 1);
                            string min1 = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 2);
                            string sec = string_caozuo.Get_Xiahuaxian_String(sub_time_string, 3);
                            DateTime time = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + min1 + ":" + sec);

                            Chart2.Series[0].Points.AddXY(time.ToOADate(), Math.Abs(jizhun - myvalue) * (1 - Math.Sqrt(3) / 2) / 0.0482);
                            Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                            DateTime time1 = DateTime.Parse(year + "-" + month + "-" + day + " " + "00" + ":" + "00" + ":" + "00");
                            DateTime time2 = DateTime.Parse(year + "-" + month + "-" + day + " " + "23" + ":" + "59" + ":" + "59");
                            Chart2.ChartAreas[0].AxisX.Minimum = time1.ToOADate();
                            Chart2.ChartAreas[0].AxisX.Maximum = time2.ToOADate();
                            Chart2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                            Chart2.ChartAreas[0].AxisX.Interval = 1;
                            max = Chart2.ChartAreas[0].AxisX.Maximum;
                            min = Chart2.ChartAreas[0].AxisX.Minimum;
                            Chart2.Titles[0].Text = year + "年" + month + "月" + day + "日  位置:" + position_string + " 的趋势区线";
                            //Label11.Text = "执行了";
                        }
                        catch { }
                    }
                    return;
                }
                catch { }
                #endregion
            }
        }

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

        protected void ImageButton_chafen_Click(object sender, ImageClickEventArgs e)
        {
            ChaFenSearch.start1 = start1;
            ChaFenSearch.start2 = start2;
            ChaFenSearch.end1 = end1;
            ChaFenSearch.end2 = end2;
            ChaFenSearch.title = chafen_title + "差分查询";
            Response.Redirect("ChaFenSearch.aspx");
        }

        protected void ImageButton_set_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Set.aspx");
        }

    }
}