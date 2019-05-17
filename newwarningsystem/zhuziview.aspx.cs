using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;
using System.Collections;
using String_Caozuo;
using System.Text;
using System.IO;

namespace newwarningsystem
{
    public partial class zhuziview : System.Web.UI.Page
    {
        public static double start1 = 0;
        public static double end1 = 0;
        public static double start2 = 0;
        public static double end2 = 0;
        public static int selected1 = 0;
        public static int selected2 = 0;

        public static double click_value = 0;
        public static double max = 0;
        public static double min = 0;

        public static string chafen_title = "";

        double start_position = 160;
        double end_postion = 780;
       

        protected void Click(object sender, EventArgs e)
        {
                Chart2.Series[0].Points.Clear();
                Button button = (Button)sender;
                try
                {

                    double value = double.Parse(button.Text);

                    click_value = value;

                    double jizhun = 0;
                    ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                    // 读取第一个文件作为基准
                    string file_jizhun = (string)filelist[0];
                    string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                    int count = 0;
                    
                    // 寻找相应的索引
                    foreach (string line in jizhun_list)
                    {
                        string position_string = string_caozuo.Get_Table_String(line, 1);
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


                    
                    


                }
                catch { }
            
        }


        public void ReShow(double value,double max,double min)
        {
            Chart2.Series[0].Points.Clear();
                //LinkButton button = (LinkButton)sender;
            try
            {
                //double value = double.Parse(button.Text);
                click_value = value;
                double jizhun = 0;
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist[0];
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                int count = 0;

                // 寻找相应的索引
                foreach (string line in jizhun_list)
                {
                    string position_string = string_caozuo.Get_Table_String(line, 1);
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
                ArrayList file1list = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");
                foreach (string file in file1list)
                {
                    try
                    {
                        ArrayList allfiles = FileCaozuo.Read_All_Files("D:\\data\\" , "*.txt");

                        string myline = FileCaozuo.Get_Line("D:\\data\\"  + file, count - 1);
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
                        Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        DateTime time1 = DateTime.Parse(year + "-" + month + "-" + day + " " + "00" + ":" + "00" + ":" + "00");
                        DateTime time2 = DateTime.Parse(year + "-" + month + "-" + day + " " + "23" + ":" + "59" + ":" + "59");
                        Chart2.ChartAreas[0].AxisX.Minimum = time1.ToOADate();
                        Chart2.ChartAreas[0].AxisX.Maximum = time2.ToOADate();
                        max = Chart2.ChartAreas[0].AxisX.Maximum;
                        min = Chart2.ChartAreas[0].AxisX.Minimum;
                    }
                    catch { }
                }
                //ArrayList alldirs = FileCaozuo.Read_All_Files("D:\\data\\","*.txt");
                //foreach (DirectoryInfo dirinfo in alldirs)
                //{
                //    ArrayList allfiles = FileCaozuo.Read_All_Files(dirinfo.FullName, "*.txt");
                //    //string[] alllines = FileCaozuo.Read_All_Line("D:\\data\\"+alldirs[0].ToString());
                //    string myline = FileCaozuo.Get_Line("D:\\data\\" + allfiles[0].ToString(), count - 1);
                //    string myvalue_string = string_caozuo.Get_Table_String(myline, 2);
                //    double myvalue = double.Parse(myvalue_string);
                //    string time_string = string_caozuo.Get_Dian_String(allfiles[0].ToString(), 1);
                //    string day_string = string_caozuo.Get_HengGang_String(time_string, 1);
                //    string year = string_caozuo.Get_Xiahuaxian_String(day_string, 1);
                //    string month = string_caozuo.Get_Xiahuaxian_String(day_string, 2);
                //    string day = string_caozuo.Get_Xiahuaxian_String(day_string, 3);
                //    DateTime time = DateTime.Parse(year + "-" + month + "-" + day);
                //    Chart2.Series[0].Points.AddXY(time.ToOADate(), Math.Abs(jizhun - myvalue) * (1 - Math.Sqrt(3) / 2) / 0.0482);
                //}
                //Chart2.ChartAreas[0].AxisX.Maximum = max;
                //Chart2.ChartAreas[0].AxisX.Minimum = min;
                //Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
                //max = Chart2.ChartAreas[0].AxisX.Maximum;
                //min = Chart2.ChartAreas[0].AxisX.Minimum;
            }
            catch { }
        }

        public void Set_Start_End(double start1,double end1,double start2,double end2)
        {

            try
            {

                // 读取文件夹中的文件
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist[0];
                string file_now = (string)filelist[filelist.Count - 1];

                // 读取所有的行
                int count1 = 0;
                int count2 = 0;

                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

                for (int i = 0; i < jizhun_list.Length - 1; i++)
                {
                    try
                    {
                        string position_string = string_caozuo.Get_Table_String(jizhun_list[i], 1);
                        double position = double.Parse(position_string);
                        if (position >= start1 && position <= end1)
                        {
                            try
                            {
                                string value_jizhun_string = string_caozuo.Get_Table_String(jizhun_list[i], 2);
                                string value_now_string = string_caozuo.Get_Table_String(now_list[i], 2);
                                double jizhun = double.Parse(value_jizhun_string);
                                double now = double.Parse(value_now_string);
                                // (value-value*Math.Sqrt(3)/2)/0.0482;
                                double value = Math.Round(Math.Abs(now - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482, 3);
                                // 左侧
                                LinkButton label_position = new LinkButton();

                                //ImageButton label = new ImageButton();
                                label_position.Click += new EventHandler(Click);
                                // label_position.Attributes.Add("onclick", "Click()");

                                label_position.Text = position.ToString("#0.000");
                                label_position.BackColor = System.Drawing.Color.Blue;
                                label_position.ForeColor = System.Drawing.Color.White;

                                Button label_value = new Button();
                                label_value.Text = "1";
                                count1++;
                                //position: absolute
                                double danwei = (end_postion - start_position) / (end1 - start1);
                                    

                                //label_position.Style["position"] = "absolute";
                                //label_position.Style["top"] = (start_position + count1 * danwei).ToString() + "px";
                                //label_position.Style["left"] = "20px";
                                label_value.Style["position"] = "absolute";
                                label_value.Style["top"] = (start_position + count1 * danwei).ToString() + "px";
                                label_value.Style["left"] = "120px";
                                label_value.Text = position_string;

                                if (value < 0.01)
                                {
                                    label_value.BackColor = System.Drawing.Color.DarkBlue;
                                    label_value.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                else if (value >= 0.01 && value <= 0.5)
                                {
                                    label_value.BackColor = System.Drawing.Color.Blue;
                                    label_value.ForeColor = System.Drawing.Color.Blue;
                                }
                                else if (value >= 0.5 && value <= 1.0)
                                {
                                    label_value.BackColor = System.Drawing.Color.LightGreen;
                                    label_value.ForeColor = System.Drawing.Color.LightGreen;
                                }
                                else if (value > 1.0 && value < 2)
                                {
                                    label_value.BackColor = System.Drawing.Color.Yellow;
                                    label_value.ForeColor = System.Drawing.Color.Yellow;
                                }

                                else if (value >= 2)
                                {
                                    label_value.BackColor = System.Drawing.Color.Red;
                                    label_value.ForeColor = System.Drawing.Color.Red;
                                }
                                label_value.ToolTip = "位置:" + position_string + " 位移量:" + value.ToString();
                                label_value.Click += new EventHandler(Click);
                                //this.form1.Controls.Add(label_position);
                                this.form1.Controls.Add(label_value);
                            }
                            catch { }
                        }

                    }
                    catch { }

                }
            }
            catch { }
            try{
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

                // 读取第一个文件作为基准
                string file_jizhun = (string)filelist[0];
                string file_now = (string)filelist[filelist.Count - 1];

                // 读取所有的行
                int count1 = 0;
                int count2 = 0;

                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);
                for (int i = jizhun_list.Length - 2; i >= 0; i--)
                {
                    try
                    {
                        string position_string = string_caozuo.Get_Table_String(jizhun_list[i], 1);
                        double position = double.Parse(position_string);
                        if (position >= start2 && position <= end2)
                        {
                            try
                            {
                                string value_jizhun_string = string_caozuo.Get_Table_String(jizhun_list[i], 2);
                                string value_now_string = string_caozuo.Get_Table_String(now_list[i], 2);
                                double jizhun = double.Parse(value_jizhun_string);
                                double now = double.Parse(value_now_string);
                                // (value-value*Math.Sqrt(3)/2)/0.0482;
                                double value = Math.Round(Math.Abs(now - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482, 3);
                                // 左侧
                                LinkButton label_position = new LinkButton();
                                label_position.Click += new EventHandler(Click);
                                //label_position.Attributes.Add("onclick", "Click()");


                                label_position.Text = position.ToString("#0.000");
                                label_position.BackColor = System.Drawing.Color.Blue;
                                label_position.ForeColor = System.Drawing.Color.White;

                                Button label_value = new Button();
                                label_value.Text = "1";

                                if (value < 0.01)
                                {
                                    label_value.BackColor = System.Drawing.Color.DarkBlue;
                                    label_value.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                else if(value>=0.01 && value<= 0.5)
                                {
                                    label_value.BackColor = System.Drawing.Color.Blue;
                                    label_value.ForeColor = System.Drawing.Color.Blue;
                                }
                                else if (value >= 0.5 && value <= 1.0)
                                {
                                    label_value.BackColor = System.Drawing.Color.LightGreen;
                                    label_value.ForeColor = System.Drawing.Color.LightGreen;
                                }
                                else if (value > 1.0 && value < 2)
                                {
                                    label_value.BackColor = System.Drawing.Color.Yellow;
                                    label_value.ForeColor = System.Drawing.Color.Yellow;
                                }

                                else if(value>=2)
                                {
                                    label_value.BackColor = System.Drawing.Color.Red;
                                    label_value.ForeColor = System.Drawing.Color.Red;
                                }
                                double danwei = (end_postion - start_position) / (end1 - start1);
                                count2++;
                                //position: absolute
                                //label_position.Style["position"] = "absolute";
                                //label_position.Style["top"] = (180 + count2 * 17).ToString() + "px";
                                //label_position.Style["left"] = "440px";
                                label_value.Style["position"] = "absolute";
                                label_value.Style["top"] = (start_position + count2 * danwei).ToString() + "px";
                                label_value.Style["left"] = "370px";
                                label_value.Text = position_string;
                                label_value.Click += new EventHandler(Click);

                                label_value.ToolTip = "位置:" + position_string + " 位移量:" + value.ToString();

                                //this.form1.Controls.Add(label_position);
                                this.form1.Controls.Add(label_value);
                            }
                            catch { }
                        }

                    }
                    catch { }
                }

            }
            catch { }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Set_Start_End(start1, end1, start2, end2);
            Label_title.Text = chafen_title;
            //Chart1.Style["position"] = "absolute";
            //Chart1.Style["left"] = "700px";
            //Chart1.Style["top"] = "100px";
            //Chart1.Width = 500;
            //Chart1.Height = 300;
            ////Chart1.Series[0].Points.AddXY(0, 0);
            ////刷新列表

            //Chart2.Style["position"] = "absolute";
            //Chart2.Style["left"] = "700px";
            //Chart2.Style["top"] = "800px";
            //Chart2.Width = 500;
            //Chart2.Height = 300;

            //ReFlush_List();
            
            
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           // Set_Start_End(start1, end1, start2, end2);
            Chart1.Style["position"] = "absolute";
            Chart1.Style["left"] = "700px";
            Chart1.Style["top"] = "100px";
            Chart1.Width = 500;
            Chart1.Height = 300;
            //Chart1.Series[0].Points.AddXY(0, 0);
            //刷新列表

            Chart2.Style["position"] = "absolute";
            Chart2.Style["left"] = "700px";

            Chart2.Style["top"] = "200px";

            Chart2.Width = 500;
            Chart2.Height = 300;

            ReFlush_List();
            
        }

        private void ReFlush_List()
        {
            ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            foreach(string myline in filelist)
            {
                ListBox1.Items.Add(myline);
                ListBox2.Items.Add(myline);
            }

           ArrayList alldirs =  FileCaozuo.Read_All_Dir("D:\\data\\");
           ListBox3.Items.Clear();
            foreach(DirectoryInfo info in alldirs)
            {
                ListBox3.Items.Add(info.Name);
            }
        }

        private void ReFlush_Chart()
        {
            Chart1.Series[0].Points.Clear();
            Chart1.Series[1].Points.Clear();
            try
            {
                string jizhun_file = ListBox1.Items[0].Value.ToString();
                string filename = ListBox1.Items[ListBox1.SelectedIndex].Value.ToString();
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + jizhun_file);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + filename);

                for (int i = 0; i < jizhun_list.Length; i++)
                {
                    string position_string = string_caozuo.Get_Table_String(jizhun_list[i], 1);
                    double position = double.Parse(position_string);
                    string value_jizhun_string = string_caozuo.Get_Table_String(jizhun_list[i], 2);
                    string value_now_string = string_caozuo.Get_Table_String(now_list[i], 2);
                    double jizhun = double.Parse(value_jizhun_string);
                    double now = double.Parse(value_now_string);
                   
                    double value = Math.Round(Math.Abs(now - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482, 3);
                    if(position>=start1 && position<=end2)
                    {
                        Chart1.Series[0].Points.AddXY(position, value);
                    }
                }

            }
            catch { }
            try
            {
                string jizhun_file = ListBox2.Items[0].Value.ToString();
                string filename = ListBox2.Items[ListBox2.SelectedIndex].Value.ToString();
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + jizhun_file);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + filename);

                for (int i = 0; i < jizhun_list.Length; i++)
                {
                    string position_string = string_caozuo.Get_Table_String(jizhun_list[i], 1);
                    double position = double.Parse(position_string);
                    string value_jizhun_string = string_caozuo.Get_Table_String(jizhun_list[i], 2);
                    string value_now_string = string_caozuo.Get_Table_String(now_list[i], 2);
                    double jizhun = double.Parse(value_jizhun_string);
                    double now = double.Parse(value_now_string);

                    double value = Math.Round(Math.Abs(now - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482, 3);
                    if (position >= start1 && position <= end2)
                    {
                        Chart1.Series[1].Points.AddXY(position, value);
                    }
                }

            }
            catch { }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReFlush_Chart();
            
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReFlush_Chart();
        }

        protected void ListBox1_TextChanged(object sender, EventArgs e)
        {
            //ReFlush_Chart();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReFlush_Chart();
        }

        protected void link_Click(object sender, EventArgs e)
        {

            ChaFenSearch.start1 = start1;
            ChaFenSearch.start2 = start2;
            ChaFenSearch.end1 = end1;
            ChaFenSearch.end2 = end2;
            ChaFenSearch.title = chafen_title+"差分查询";
            Response.Redirect("ChaFenSearch.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (max - min >= 0.3)
            {
                Chart2.ChartAreas[0].AxisX.Maximum = max - 0.1;
                Chart2.ChartAreas[0].AxisX.Minimum = min + 0.1;
                max = Chart2.ChartAreas[0].AxisX.Maximum;
                min = Chart2.ChartAreas[0].AxisX.Minimum;
                ReShow(click_value, max, min);

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
                Chart2.ChartAreas[0].AxisX.Maximum = max + 0.1;
                Chart2.ChartAreas[0].AxisX.Minimum = min - 0.1;
                max = Chart2.ChartAreas[0].AxisX.Maximum;
                min = Chart2.ChartAreas[0].AxisX.Minimum;
                ReShow(click_value, max, min);
                
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Chart2.ChartAreas[0].AxisX.Maximum = max + 0.1;
            Chart2.ChartAreas[0].AxisX.Minimum = min + 0.1;
            max = Chart2.ChartAreas[0].AxisX.Maximum;
            min = Chart2.ChartAreas[0].AxisX.Minimum; 
            ReShow(click_value, max, min);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Chart2.ChartAreas[0].AxisX.Maximum = max - 0.1;
            Chart2.ChartAreas[0].AxisX.Minimum = min - 0.1;
            max = Chart2.ChartAreas[0].AxisX.Maximum;
            min = Chart2.ChartAreas[0].AxisX.Minimum;
            ReShow(click_value, max, min);
        }

        protected void link0_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMap.aspx");


        }

        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 寻找基准
            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
            int count = 0;
            double jizhun = 0;

            // 寻找相应的索引
            foreach (string line in jizhun_list)
            {
                string position_string = string_caozuo.Get_Table_String(line, 1);
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
                ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\" + ListBox3.Items[ListBox3.SelectedIndex].Value.ToString(), "*.txt");
                foreach (string file in filelist)
                {
                    try
                    {
                        ArrayList allfiles = FileCaozuo.Read_All_Files("D:\\data\\" + ListBox3.Items[ListBox3.SelectedIndex].Value.ToString(), "*.txt");

                        string myline = FileCaozuo.Get_Line("D:\\data\\" + ListBox3.Items[ListBox3.SelectedIndex].Value.ToString()+"\\"+file, count - 1);
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
                        Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                         DateTime time1= DateTime.Parse(year + "-" + month + "-" + day + " " + "00" + ":" + "00" + ":" + "00");
                        DateTime time2= DateTime.Parse(year + "-" + month + "-" + day + " " + "23" + ":" + "59" + ":" + "59");
                         Chart2.ChartAreas[0].AxisX.Minimum = time1.ToOADate();
                         Chart2.ChartAreas[0].AxisX.Maximum = time2.ToOADate();
                         max = Chart2.ChartAreas[0].AxisX.Maximum;
                         min = Chart2.ChartAreas[0].AxisX.Minimum;
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}