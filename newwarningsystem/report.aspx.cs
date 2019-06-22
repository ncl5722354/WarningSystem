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

        DataTable dt = new DataTable();
        double circle1_max = 0; 
            double circle2_max = 0;
            double circle3_max = 0;
            double circle4_max = 0;
            double circle5_max = 0;
            double circle6_max = 0;
            double circle7_max = 0;
            double count = 0;
            string max_position="";
        protected void Page_Load(object sender, EventArgs e)
        {
            user_Chart();

        }

        public void user_Chart()
        {
            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);

            string file_now = (string)filelist_1[filelist_1.Count - 1];
            string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

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
                                max_position = position_string;
                            }

                            //if(value>=value5)
                            //{
                            //    Label mylabel = new Label();
                            //    mylabel.Style["position"] = "absolute";
                            //    mylabel.Font.Size = FontUnit.Medium;
                            //    mylabel.Style["top"] = (count*7).ToString()+"%";
                            //    mylabel.Style["left"] = "0%";
                            //    mylabel.Style["z-index"] = "5";
                            //    mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString()+"mm";
                            //    mylabel.ForeColor = System.Drawing.Color.Red;
                            //    mylabel.BackColor = System.Drawing.Color.DarkBlue;
                            //    panel3.Controls.Add(mylabel);

                            //    count++;
                            //}
                            //Chart1.Titles[0].Text = Image_point1.ToolTip;
                            // Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 2361 && position <= 2558)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }
                        if (position >= 2934 && position <= 3074)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }
                        if (position >= 602 && position <= 675)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }
                        if (position >= 742 && position <= 810)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }
                        if (position >= 875 && position <= 939)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }
                        if (position >= 994 && position <= 1069)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                        }

                    }
                    catch { break; }
                }
            }
            catch { }
        }
             

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }
    }
}