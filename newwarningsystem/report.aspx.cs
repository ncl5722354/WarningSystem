using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using FileOperation;
using System.Collections;
using String_Caozuo;

namespace newwarningsystem
{
    public partial class report : System.Web.UI.Page
    {
        //DataSet ds = new DataSet(); 

        public static DateTime selected_date = DateTime.Now;
        public static DateTime selected_old = DateTime.Parse("1900-01-01");

        DataTable dt = new DataTable();
        double circle1_max = 0; 
        double circle2_max = 0;
        double circle3_max = 0;
        double circle4_max = 0;
        double circle5_max = 0;
        double circle6_max = 0;
        double circle7_max = 0;

        string max_pos1 = "";
        string max_pos2 = "";
        string max_pos3 = "";
        string max_pos4 = "";
        string max_pos5 = "";
        string max_pos6 = "";
        string max_pos7 = "";
            
            double count = 0;
            string max_position="";
        protected void Page_Load(object sender, EventArgs e)
        {
            user_Chart();

        }

        public void user_Chart()
        {
            Panel_port.Controls.Clear();

            Label date_title = new Label();
            date_title.Text = selected_date.ToString("yyyy年MM月dd日")+"报表详情";
            date_title.Style["width"] = "100%";
            date_title.Style["height"] = "5%";
            date_title.Style["text-align"] = "center";
            date_title.Style["top"] = "0%";
            date_title.Style["left"] = "0%";
            date_title.Style["position"] = "absolute";
            date_title.BorderStyle = BorderStyle.Solid;
            date_title.BorderWidth = 2;
            date_title.BorderColor = System.Drawing.Color.Black;
            Panel_port.Controls.Add(date_title);

            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);

            string[] now_list = null;
            for (int z = 0; z < filelist_1.Count; z++)
            {
                string file_now = (string)filelist_1[filelist_1.Count - 1];
                now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);
                string thisdate = string_caozuo.Get_HengGang_String(file_now,1);
                if (thisdate == selected_date.ToString("yyyy_MM_dd"))
                {
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

                                    if (value >= circle1_max)
                                    {
                                        circle1_max = value;
                                        max_pos1 = position_string;
                                    }


                                }
                                if (position >= 2361 && position <= 2558)
                                {
                                    if (value >= circle2_max)
                                    {
                                        circle2_max = value;
                                        max_pos2 = position_string;
                                    }

                                }
                                if (position >= 2934 && position <= 3074)
                                {
                                    if (value >= circle3_max)
                                    {
                                        circle3_max = value;
                                        max_pos3 = position_string;
                                    }

                                }
                                if (position >= 602 && position <= 675)
                                {
                                    if (value >= circle4_max)
                                    {
                                        circle4_max = value;
                                        max_pos4 = position_string;
                                    }

                                }
                                if (position >= 742 && position <= 810)
                                {
                                    if (value >= circle5_max)
                                    {
                                        circle5_max = value;
                                        max_pos5 = position_string;
                                    }

                                }
                                if (position >= 875 && position <= 939)
                                {
                                    if (value >= circle6_max)
                                    {
                                        circle6_max = value;
                                        max_pos6 = position_string;
                                    }

                                }
                                if (position >= 994 && position <= 1069)
                                {
                                    if (value >= circle7_max)
                                    {
                                        circle7_max = value;
                                        max_pos7 = position_string;
                                    }

                                }

                            }
                            catch { break; }
                        }
                    }
                    catch { }
                }

                for(int i=0;i<=7;i++)
                {
                    Label left = new Label();
                    Label middle = new Label();
                    Label right = new Label();
                    if(i==0)
                    {
                        left.Text="区域";
                        middle.Text = "最大位移(mm)";
                        right.Text = "位置(m)";
                    }
                    if (i == 1)
                    {
                        left.Text = "坡道1";
                        middle.Text = Math.Round(circle1_max, 3).ToString();
                        right.Text = max_pos1;
                    }
                    if (i == 2)
                    {
                        left.Text = "坡道2";
                        middle.Text = Math.Round(circle2_max, 3).ToString();
                        right.Text = max_pos2;
                    }
                    if (i == 3)
                    {
                        left.Text = "坡道3";
                        middle.Text = Math.Round(circle3_max, 3).ToString();
                        right.Text = max_pos3;
                    }
                    if (i == 4)
                    {
                        left.Text = "管道1";
                        middle.Text = Math.Round(circle4_max, 3).ToString();
                        right.Text = max_pos4;
                    }
                    if (i == 5)
                    {
                        left.Text = "管道2";
                        middle.Text = Math.Round(circle5_max, 3).ToString();
                        right.Text = max_pos5;
                    }
                    if (i == 6)
                    {
                        left.Text = "管道3";
                        middle.Text = Math.Round(circle6_max, 3).ToString();
                        right.Text = max_pos6;
                    }
                    if (i == 7)
                    {
                        left.Text = "管道4";
                        middle.Text = Math.Round(circle7_max, 3).ToString();
                        right.Text = max_pos7;
                    }
                    left.Style["position"] = "absolute";
                    left.Style["left"] = "0%";
                    left.Style["top"] = (i * 7 + 6).ToString() + "%";
                    left.Style["width"] = "20%";
                    left.Style["hegit"] = "7%";
                    left.Style["text-align"] = "center";
                    left.BorderColor = System.Drawing.Color.Black;
                    left.BorderStyle = BorderStyle.Solid;
                    left.BorderWidth = 2;


                    middle.Style["position"] = "absolute";
                    middle.Style["left"] = "21%";
                    middle.Style["top"] = (i * 7 + 6).ToString() + "%";
                    middle.Style["width"] = "28%";
                    middle.Style["hegit"] = "7%";
                    middle.Style["text-align"] = "center";
                    middle.BorderColor = System.Drawing.Color.Black;
                    middle.BorderStyle = BorderStyle.Solid;
                    middle.BorderWidth = 2;

                    right.Style["position"] = "absolute";
                    right.Style["left"] = "50%";
                    right.Style["top"] = (i * 7 + 6).ToString() + "%";
                    right.Style["width"] = "39%";
                    right.Style["hegit"] = "7%";
                    right.Style["text-align"] = "center";
                    right.BorderColor = System.Drawing.Color.Black;
                    right.BorderStyle = BorderStyle.Solid;
                    right.BorderWidth = 2;

                    Panel_port.Controls.Add(left);
                    Panel_port.Controls.Add(middle);
                    Panel_port.Controls.Add(right);
                }
            }

           
        }
             

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                selected_date = e.Day.Date;
                if(selected_date!=selected_old)
                {
                    Response.AddHeader("Refresh", "0");
                }
                selected_old = selected_date;
            }
        }
    }
}