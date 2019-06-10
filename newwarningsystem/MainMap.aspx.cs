﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;
using System.Collections;
using String_Caozuo;

namespace newwarningsystem
{
    public partial class MainMap : System.Web.UI.Page
    {
        public static IniFile ini = new IniFile("D:\\config\\Map.ini");

        public static int update_panel2_count = 1;

        static double value1 = 0;
        static double value2 = 0;
        static double value3 = 0;
        static double value4 = 0;
        static double value5 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            DateTime mytime = DateTime.Now;
            Label_timer.Text = mytime.ToString("yyyy-MM-dd HH:mm:ss");
            Circle_Yanse();    // 界面变化颜色
            Update_Panel2();   // 更新panel2
            


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

            Label_label1.Text = "小于" + value1.ToString() + "mm";
            Label_label2.Text = "大于" + value1.ToString() + "mm 小于" + value2.ToString() + "mm";
            Label_label3.Text = "大于" + value2.ToString() + "mm 小于" + value5.ToString() + "mm";
            Label_label4.Text = "大于" + value5.ToString()+"mm";

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

            

            // 设备状态饼状图
            Chart_shebeizhuangtai.Style["width"] = "200px";
            Chart_shebeizhuangtai.Style["height"] = "200px";
            Chart_shebeizhuangtai.Series[0].Points.Clear();
            Chart_shebeizhuangtai.Series[0].Points.AddY(100);
            Chart_shebeizhuangtai.Series[0].Points[0].Color = System.Drawing.Color.Blue;
            Chart_shebeizhuangtai.Series[0].Points[0].Label = "设备正常";
            Chart_shebeizhuangtai.Series[0].Points[0].LabelForeColor = System.Drawing.Color.White;

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            
            HttpBrowserCapabilities bc = Request.Browser;
            int a = bc.ScreenPixelsWidth;
        }

        private void Circle_Yanse()
        {
            // 计算比例
            float allcount = 0;
            float count1 = 0;
            float count2 = 0;
            float count3 = 0;
            float count4 = 0;


            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);

            string file_now = (string)filelist_1[filelist_1.Count - 1];
            string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);
            Chart1.Series[0].Points.Clear();
            double circle1_max = 0; 
            double circle2_max = 0;
            double circle3_max = 0;
            double circle4_max = 0;
            double circle5_max = 0;
            double circle6_max = 0;
            double circle7_max = 0;
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
                        if (position >= 2164 && position <= 2317)
                        {
                            if (value >= circle1_max)
                                circle1_max = value;
                        }
                        if (position >= 2361 && position <= 2558)
                        {
                            if (value >= circle2_max)
                                circle2_max = value;
                        }
                        if (position >= 2934 && position <= 3074)
                        {
                            if (value >= circle3_max)
                                circle3_max = value;
                        }
                        if (position >= 602 && position <= 675)
                        {
                            if (value >= circle4_max)
                                circle4_max = value;
                        }
                        if (position >= 742 && position <= 810)
                        {
                            if (value >= circle5_max)
                                circle5_max = value;
                        }
                        if (position >= 875 && position <= 939)
                        {
                            if (value >= circle6_max)
                                circle6_max = value;
                        }
                        if (position >= 994 && position <= 1069)
                        {
                            if (value >= circle7_max)
                                circle7_max = value;
                        }

                        if((position >= 2164 && position <= 2317)||(position >= 2361 && position <= 2558)||(position >= 2934 && position <= 3074)||(position >= 602 && position <= 675)||(position >= 742 && position <= 810)||(position >= 875 && position <= 939)||(position >= 994 && position <= 1069))
                        {
                            allcount++;
                            if (value < value1)
                                count1++;
                            else if (value < value2)
                                count2++;
                            else if (value < value5)
                                count3++;
                            else if (value >= value5)
                                count4++;
                           
                        }
                    }
                    catch { break; }


                }
                

                if (circle1_max <= value1)
                    Circle1.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle1_max <= value2)
                    Circle1.BackColor = System.Drawing.Color.Blue;
                else if (circle1_max <= value3)
                    Circle1.BackColor = System.Drawing.Color.LightGreen;
                else if (circle1_max < value5)
                    Circle1.BackColor = System.Drawing.Color.Yellow;
                else if (circle1_max >=value5)
                    Circle1.BackColor = System.Drawing.Color.Red;

                if (circle2_max <= value1)
                    Circle2.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle2_max <= value2)
                    Circle2.BackColor = System.Drawing.Color.Blue;
                else if (circle2_max <= value3)
                    Circle2.BackColor = System.Drawing.Color.LightGreen;
                else if (circle2_max < value5)
                    Circle2.BackColor = System.Drawing.Color.Yellow;
                else if (circle2_max >= value5)
                    Circle2.BackColor = System.Drawing.Color.Red;

                if (circle3_max <= 0.01)
                    Circle3.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle3_max <= 0.1)
                    Circle3.BackColor = System.Drawing.Color.Blue;
                else if (circle3_max <= 1.0)
                    Circle3.BackColor = System.Drawing.Color.LightGreen;
                else if (circle3_max < 2)
                    Circle3.BackColor = System.Drawing.Color.Yellow;
                else if (circle3_max >= 2)
                    Circle3.BackColor = System.Drawing.Color.Red;

                if (circle4_max <= 0.01)
                    Circle4.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle4_max <= 0.1)
                    Circle4.BackColor = System.Drawing.Color.Blue;
                else if (circle4_max <= 1.0)
                    Circle4.BackColor = System.Drawing.Color.LightGreen;
                else if (circle4_max < 2)
                    Circle4.BackColor = System.Drawing.Color.Yellow;
                else if (circle4_max >= 2)
                    Circle4.BackColor = System.Drawing.Color.Red;

                if (circle5_max <= value1)
                    Circle5.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle5_max <= value2)
                    Circle5.BackColor = System.Drawing.Color.Blue;
                else if (circle5_max <= value3)
                    Circle5.BackColor = System.Drawing.Color.LightGreen;
                else if (circle5_max < value5)
                    Circle5.BackColor = System.Drawing.Color.Yellow;
                else if (circle5_max >= value5)
                    Circle5.BackColor = System.Drawing.Color.Red;

                if (circle6_max <= value1)
                    Circle6.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle6_max <= value2)
                    Circle6.BackColor = System.Drawing.Color.Blue;
                else if (circle6_max <= value3)
                    Circle6.BackColor = System.Drawing.Color.LightGreen;
                else if (circle6_max < value5)
                    Circle6.BackColor = System.Drawing.Color.Yellow;
                else if (circle6_max >= value5)
                    Circle6.BackColor = System.Drawing.Color.Red;

                if (circle7_max <= value1)
                    Circle7.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle7_max <= value2)
                    Circle7.BackColor = System.Drawing.Color.Blue;
                else if (circle7_max <= value3)
                    Circle7.BackColor = System.Drawing.Color.LightGreen;
                else if (circle7_max < value5)
                    Circle7.BackColor = System.Drawing.Color.Yellow;
                else if (circle7_max >= value5)
                    Circle7.BackColor = System.Drawing.Color.Red;
                if (allcount != 0)
                {
                    Label_baifenbi1.Text = (Math.Round(count1 / allcount * 100, 2)).ToString() + "%";
                    Label_baifenbi2.Text = (Math.Round(count2 / allcount * 100, 2)).ToString() + "%";
                    Label_baifenbi3.Text = (Math.Round(count3 / allcount * 100, 2)).ToString() + "%";
                    Label_baifenbi4.Text = (Math.Round(count4 / allcount * 100, 2)).ToString() + "%";

                    Panel_value1.Style["width"] = (70 * (count1 / allcount)).ToString() + "%";
                    Panel_value2.Style["width"] = (70 * (count2 / allcount)).ToString() + "%";
                    Panel_value3.Style["width"] = (70 * (count3 / allcount)).ToString() + "%";
                    Panel_value4.Style["width"] = (70 * (count4 / allcount)).ToString() + "%";
                }
            }
            catch { }

        }           

        private void Update_Panel2()
        {
           
            if(IsPostBack==false)
            {
                int a = 0;
            }
            Panel2.Controls.Clear();

            // 加入一个panel3
            Panel panel3 = new Panel();
            panel3.Style["position"] = "absolute";
            panel3.Style["top"] = "10%";
            panel3.Style["left"] = "0%";
            panel3.Style["width"] = "99%";
            panel3.Style["height"] = "85%";
            panel3.BackColor = System.Drawing.Color.DarkBlue;
            panel3.BorderColor = System.Drawing.Color.Black;
            panel3.BorderStyle = BorderStyle.Solid;
            panel3.BorderWidth = 3;
            Panel2.Controls.Add(panel3);
            if(update_panel2_count==1)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size= FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point1.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 2)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point2.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 3)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point3.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 4)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point4.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 5)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point5.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 6)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point6.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }
            if (update_panel2_count == 7)
            {
                Label mylabel = new Label();
                mylabel.Style["position"] = "absolute";
                mylabel.Font.Size = FontUnit.Medium;
                mylabel.Style["top"] = "1%";
                mylabel.Style["left"] = "25%";
                mylabel.Style["z-index"] = "5";
                mylabel.Text = Image_point7.ToolTip;
                mylabel.ForeColor = System.Drawing.Color.White;
                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                Panel2.Controls.Add(mylabel);
            }

            ArrayList filelist_1 = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");

            // 读取第一个文件作为基准
            string file_jizhun = (string)filelist_1[0];
            string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);

            string file_now = (string)filelist_1[filelist_1.Count - 1];
            string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

            double circle1_max = 0; 
            double circle2_max = 0;
            double circle3_max = 0;
            double circle4_max = 0;
            double circle5_max = 0;
            double circle6_max = 0;
            double circle7_max = 0;
            double count = 0;
            string max_position="";
            panel3.Controls.Clear();
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


                        double value =Math.Abs(positon_value - positon_value1) * (1 - Math.Sqrt(3) / 2) / 0.0482;
                        value = Math.Round(value, 3);
                        
                        // 
                        if (position >= 2164 && position <= 2317 && update_panel2_count == 1)
                        {

                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }

                            if(value>=2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count*7).ToString()+"%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString()+"mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
           
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point1.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 2361 && position <= 2558 && update_panel2_count == 2)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point2.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 2934 && position <= 3074 && update_panel2_count == 3)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point3.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 602 && position <= 675 && update_panel2_count == 4)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point4.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 742 && position <= 810 && update_panel2_count == 5)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point5.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 875 && position <= 939 && update_panel2_count == 6)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point6.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }
                        if (position >= 994 && position <= 1069 && update_panel2_count == 7)
                        {
                            if (value >= circle1_max)
                            {
                                circle1_max = value;
                                max_position = position_string;
                            }
                            if (value >= 2)
                            {
                                Label mylabel = new Label();
                                mylabel.Style["position"] = "absolute";
                                mylabel.Font.Size = FontUnit.Medium;
                                mylabel.Style["top"] = (count * 7).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                            Chart1.Titles[0].Text = Image_point7.ToolTip;
                            Chart1.Series[0].Points.AddXY(position, value);
                        }

                    }
                    catch { break; }
                    
                       
                    

                }
                Label label = new Label();
                label.Style["position"] = "absolute";
                label.Font.Size = FontUnit.Medium;
                label.Style["top"] = (count * 7).ToString() + "%";
                label.Style["left"] = "0%";
                label.Style["z-index"] = "5";
                label.Text = "位移最大值 位置：" + max_position + "m " + "位移量：" + circle1_max.ToString() + "mm";
                label.ForeColor = System.Drawing.Color.White;
                label.BackColor = System.Drawing.Color.DarkBlue;
                panel3.Controls.Add(label);
                count++;
            }
            catch { }
            
        }



        protected void Imagemap_DataBinding(object sender, EventArgs e)
        {

        }

        public string Point1_visibile()
        {
            Panel2.Visible = false;
            return "0";
        }
       

        protected void Image_point4_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 602;
            zhuziview.end1 = 638;
            zhuziview.start2 = 638;
            zhuziview.end2 = 674;
           
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
            
            
        }

        protected void Image_point5_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 742;
            zhuziview.end1 = 776;
            zhuziview.start2 = 776;
            zhuziview.end2 = 810;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point6_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 875;
            zhuziview.end1 = 907;
            zhuziview.start2 = 907;
            zhuziview.end2 = 939;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point7_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 994;
            zhuziview.end1 = 1031.5;
            zhuziview.start2 = 1031.5;
            zhuziview.end2 = 1069;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Image_point1_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/1.png";
            SubMap.map_name = "一号坡";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2164;
            SubMap.end2 = 2317;
            Response.Redirect("SubMap.aspx");
        }

        protected void Image_point2_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/2.png";
            SubMap.map_name = "二号坡上";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2361;
            SubMap.end2 = 2558;
            Response.Redirect("SubMap.aspx");
        }

        protected void Image_point3_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/3.png";
            SubMap.map_name = "二号坡下";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2934;
            SubMap.end2 = 3074;
            Response.Redirect("SubMap.aspx");
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("report.aspx");
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Image_point1.Visible = false;
        }

        protected void timer2_Tick1(object sender, EventArgs e)
        {
           
        }

        protected void UpdatePanel4_DataBinding(object sender, EventArgs e)
        {

        }

        protected void timer3_Tick(object sender, EventArgs e)
        {
            if (update_panel2_count >= 7) update_panel2_count = 1;
            update_panel2_count++;
            
        }
    }
}