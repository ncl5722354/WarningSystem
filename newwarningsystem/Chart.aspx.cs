using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using FileOperation;
using String_Caozuo;

namespace newwarningsystem
{
    public partial class Chart : System.Web.UI.Page
    {
        static int line1 = 1;
        static DateTime datetime1 = DateTime.Parse("1900-01-01");
        static DateTime datetime2 = DateTime.Parse("1900-01-01");
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime mytime = DateTime.Now;
            Label_timer.Text = mytime.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                double screenwith = double.Parse(MainMap.x);
                double screenheight = double.Parse(MainMap.y);
                Chart1.Style["width"] = (screenwith *0.7).ToString() + "px";
                Chart2.Style["width"] = (screenwith *0.7).ToString() + "px";
            }
            catch { }
           //Update_Panel2();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Update_Panel2();
        }

        private void Update_Panel2()
        {
            double circle1_max = 0;
            double circle2_max = 0;
            double circle3_max = 0;
            double circle4_max = 0;
            double circle5_max = 0;
            double circle6_max = 0;
            double circle7_max = 0;
            double count = 0;
            string max_position = "";
            Chart1.Series.Clear();
            Chart2.Series.Clear();
            Chart1.Series.Add("坡道1");

            Chart1.Series.Add("坡道2");
            Chart1.Series.Add("坡道3");
            Chart1.Series.Add("管道1");
            Chart1.Series.Add("管道2");
            Chart1.Series.Add("管道3");
            Chart1.Series.Add("管道4");

            Chart1.Legends.Add("坡道1");
            Chart1.Legends.Add("坡道2");
            Chart1.Legends.Add("坡道3");
            Chart1.Legends.Add("管道1");
            Chart1.Legends.Add("管道2");
            Chart1.Legends.Add("管道3");
            Chart1.Legends.Add("管道4");

            Chart2.Legends.Add("");
            Chart2.Series.Add("");
            Chart2.Series.Add("");
            Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
            Chart2.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Spline;
            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);

            string file_now = (string)filelist_1[filelist_1.Count - 1];
            string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

            string file1;
            string file2;
            if (datetime1.Year != 1900)
            {
                string selectedate = "";
                for (int z = 0; z < filelist_1.Count; z++)
                {
                    try
                    {
                        file1 = (string)filelist_1[z];
                       
                        selectedate = string_caozuo.Get_HengGang_String(file1, 1);
                        if (selectedate != datetime1.ToString("yyyy_MM_dd")) continue;
                        string[] list = FileCaozuo.Read_All_Line("D:\\data\\" + file1);
                        try
                        {
                            for (int i = 0; i < jizhun_list.Length; i++)
                            {
                                try
                                {
                                    string line = list[i];
                                    string position_string = string_caozuo.Get_Table_String(line, 1);
                                    string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                                    double positon_value = double.Parse(postion_value_string);
                                    double position = double.Parse(position_string);

                                    string line_jizhun = jizhun_list[i];
                                    string position_string1 = string_caozuo.Get_Table_String(line_jizhun, 1);
                                    string postion_value_string1 = string_caozuo.Get_Table_String(line_jizhun, 2);
                                    double positon_value1 = double.Parse(postion_value_string1);
                                    double position1 = double.Parse(position_string1);


                                    double value = Math.Abs(positon_value - positon_value1) * (1 - Math.Sqrt(3) / 2) / 0.0482;
                                    value = Math.Round(value, 3);

                                    // 

                                   // Chart1.Series.Clear();
                                    if (position >= 2164 && position <= 2317)
                                    {
                                        //Chart1.Titles[0].Text = Image_point1.ToolTip;
                                         Chart1.Series[0].Points.AddXY(position, value);
                                        if (line1 == 1)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道1";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道1";
                                        }
                                    }
                                    if (position >= 2361 && position <= 2558)
                                    {

                                        //Chart1.Titles[0].Text = Image_point2.ToolTip;
                                        Chart1.Series[1].Points.AddXY(position, value);
                                        if (line1 == 2)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道2";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道2";
                                        }
                                    }
                                    if (position >= 2934 && position <= 3074)
                                    {

                                        //Chart1.Titles[0].Text = Image_point3.ToolTip;
                                         Chart1.Series[2].Points.AddXY(position, value);
                                        if (line1 == 3)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道3";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道3";
                                        }
                                    }
                                    if (position >= 602 && position <= 675)
                                    {

                                        // Chart1.Titles[0].Text = Image_point4.ToolTip;
                                        Chart1.Series[3].Points.AddXY(position, value);
                                        if (line1 == 4)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道1";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道1";
                                        }
                                    }
                                    if (position >= 742 && position <= 810)
                                    {

                                        //Chart1.Titles[0].Text = Image_point5.ToolTip;
                                        Chart1.Series[4].Points.AddXY(position, value);
                                        if (line1 == 5)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道2";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道2";
                                        }
                                    }
                                    if (position >= 875 && position <= 939)
                                    {

                                        //Chart1.Titles[0].Text = Image_point6.ToolTip;
                                        Chart1.Series[5].Points.AddXY(position, value);
                                        if (line1 == 6)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道3";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道3";
                                        }
                                    }
                                    if (position >= 994 && position <= 1069)
                                    {

                                        //Chart1.Titles[0].Text = Image_point7.ToolTip;
                                        Chart1.Series[6].Points.AddXY(position, value);
                                        if (line1 == 7)
                                        {
                                            Chart2.Series[0].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道4";
                                            Chart2.Series[0].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道4";
                                        }
                                    }

                                }
                                catch { break; }

                            }
                        }
                        catch { }
                    }
                    catch { }
                    if (selectedate == datetime1.ToString("yyyy_MM_dd")) break;
                }
            }
           
            if(datetime2.Year!=1900)
            {
                string selectedate = "";
                for (int z = 0; z < filelist_1.Count; z++)
                {
                    try
                    {
                        file2 = (string)filelist_1[z];
                       
                        selectedate = string_caozuo.Get_HengGang_String(file2, 1);
                        if (selectedate != datetime2.ToString("yyyy_MM_dd")) continue;
                        string[] list = FileCaozuo.Read_All_Line("D:\\data\\" + file2);
                        try
                        {
                            for (int i = 0; i < jizhun_list.Length; i++)
                            {
                                try
                                {
                                    string line = list[i];
                                    string position_string = string_caozuo.Get_Table_String(line, 1);
                                    string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                                    double positon_value = double.Parse(postion_value_string);
                                    double position = double.Parse(position_string);

                                    string line_jizhun = jizhun_list[i];
                                    string position_string1 = string_caozuo.Get_Table_String(line_jizhun, 1);
                                    string postion_value_string1 = string_caozuo.Get_Table_String(line_jizhun, 2);
                                    double positon_value1 = double.Parse(postion_value_string1);
                                    double position1 = double.Parse(position_string1);


                                    double value = Math.Abs(positon_value - positon_value1) * (1 - Math.Sqrt(3) / 2) / 0.0482;
                                    value = Math.Round(value, 3);

                                    // 

                                   
                                    if (position >= 2164 && position <= 2317)
                                    {
                                        //Chart1.Titles[0].Text = Image_point1.ToolTip;
                                         Chart1.Series[0].Points.AddXY(position, value);
                                        if (line1 == 1)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道1";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道1";
                                        }
                                    }
                                    if (position >= 2361 && position <= 2558)
                                    {

                                        //Chart1.Titles[0].Text = Image_point2.ToolTip;
                                        Chart1.Series[1].Points.AddXY(position, value);
                                        if (line1 == 2)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道2";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道2";
                                        }
                                    }
                                    if (position >= 2934 && position <= 3074)
                                    {

                                        //Chart1.Titles[0].Text = Image_point3.ToolTip;
                                         Chart1.Series[2].Points.AddXY(position, value);
                                        if (line1 == 3)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "坡道3";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "坡道3";
                                        }
                                    }
                                    if (position >= 602 && position <= 675)
                                    {

                                        // Chart1.Titles[0].Text = Image_point4.ToolTip;
                                        Chart1.Series[3].Points.AddXY(position, value);
                                        if (line1 == 4)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道1";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道1";
                                        }
                                    }
                                    if (position >= 742 && position <= 810)
                                    {

                                        //Chart1.Titles[0].Text = Image_point5.ToolTip;
                                        Chart1.Series[4].Points.AddXY(position, value);
                                        if (line1 == 5)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道2";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道2";
                                        }
                                    }
                                    if (position >= 875 && position <= 939)
                                    {

                                        //Chart1.Titles[0].Text = Image_point6.ToolTip;
                                        Chart1.Series[5].Points.AddXY(position, value);
                                        if (line1 == 6)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道3";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道3";
                                        }
                                    }
                                    if (position >= 994 && position <= 1069)
                                    {

                                        //Chart1.Titles[0].Text = Image_point7.ToolTip;
                                        Chart1.Series[6].Points.AddXY(position, value);
                                        if (line1 == 7)
                                        {
                                            Chart2.Series[1].Points.AddXY(position, value);
                                            Chart2.Legends[0].Title = "管道4";
                                            Chart2.Series[1].Name = selectedate;
                                            Chart2.Titles[0].Text = "管道4";
                                        }
                                    }

                                }
                                catch { break; }

                            }
                        }
                        catch { }
                    }
                    catch { }
                    if (selectedate == datetime2.ToString("yyyy_MM_dd")) break;
                }
            }


           

            for (int i = 0; i < 7;i++ )
            {
                
            }
            // panel3.Controls.Clear();
            if (datetime1.Year != 1900 || datetime1.Year!=1900)
            {
                return;
            }
            try
                {
                    for (int i = 0; i < jizhun_list.Length; i++)
                    {
                        try
                        {
                            string line = now_list[i];
                            string position_string = string_caozuo.Get_Table_String(line, 1);
                            string postion_value_string = string_caozuo.Get_Table_String(line, 2);
                            double positon_value = double.Parse(postion_value_string);
                            double position = double.Parse(position_string);

                            string line_jizhun = jizhun_list[i];
                            string position_string1 = string_caozuo.Get_Table_String(line_jizhun, 1);
                            string postion_value_string1 = string_caozuo.Get_Table_String(line_jizhun, 2);
                            double positon_value1 = double.Parse(postion_value_string1);
                            double position1 = double.Parse(position_string1);


                            double value = Math.Abs(positon_value - positon_value1) * (1 - Math.Sqrt(3) / 2) / 0.0482;
                            value = Math.Round(value, 3);

                            // 
                            
                            //Chart1.Series.Clear();
                            if (position >= 2164 && position <= 2317)
                            {
                                 //Chart1.Titles[0].Text = Image_point1.ToolTip;
                                Chart1.Series[0].Points.AddXY(position, value);
                                if(line1==1)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "坡道1";
                                    Chart2.Series[0].Name = "坡道1";
                                    Chart2.Titles[0].Text = "坡道1";
                                }
                            }
                            if (position >= 2361 && position <= 2558)
                            {

                                //Chart1.Titles[0].Text = Image_point2.ToolTip;
                                Chart1.Series[1].Points.AddXY(position, value);
                                if (line1 == 2)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "坡道2";
                                    Chart2.Series[0].Name = "坡道2";
                                    Chart2.Titles[0].Text = "坡道2";
                                }
                            }
                            if (position >= 2934 && position <= 3074)
                            {

                                //Chart1.Titles[0].Text = Image_point3.ToolTip;
                                Chart1.Series[2].Points.AddXY(position, value);
                                if (line1 == 3)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "坡道3";
                                    Chart2.Series[0].Name = "坡道3";
                                    Chart2.Titles[0].Text = "坡道3";
                                }
                            }
                            if (position >= 602 && position <= 675)
                            {

                                // Chart1.Titles[0].Text = Image_point4.ToolTip;
                                Chart1.Series[3].Points.AddXY(position, value);
                                if (line1 == 4)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "管道1";
                                    Chart2.Series[0].Name = "管道1";
                                    Chart2.Titles[0].Text = "管道1";
                                }
                            }
                            if (position >= 742 && position <= 810)
                            {

                                //Chart1.Titles[0].Text = Image_point5.ToolTip;
                                Chart1.Series[4].Points.AddXY(position, value);
                                if (line1 == 5)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "管道2";
                                    Chart2.Series[0].Name = "管道2";
                                    Chart2.Titles[0].Text = "管道2";
                                }
                            }
                            if (position >= 875 && position <= 939)
                            {

                                //Chart1.Titles[0].Text = Image_point6.ToolTip;
                                Chart1.Series[5].Points.AddXY(position, value);
                                if (line1 == 6)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "管道3";
                                    Chart2.Series[0].Name = "管道3";
                                    Chart2.Titles[0].Text = "管道3";
                                }
                            }
                            if (position >= 994 && position <= 1069)
                            {

                                //Chart1.Titles[0].Text = Image_point7.ToolTip;
                                Chart1.Series[6].Points.AddXY(position, value);
                                if (line1 == 7)
                                {
                                    Chart2.Series[0].Points.AddXY(position, value);
                                    Chart2.Legends[0].Title = "管道4";
                                    Chart2.Series[0].Name = "管道4";
                                    Chart2.Titles[0].Text = "管道4";
                                }
                            }

                        }
                        catch { break; }

                    }
                }
                catch { }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            line1 = 1;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            line1 = 2;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            line1 = 3;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            line1 = 4;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            line1 = 5;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            line1 = 6;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            line1= 7;
        }

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

        protected void calender1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                datetime1 = e.Day.Date;
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                datetime2 = e.Day.Date;
            }
        }
    }
}