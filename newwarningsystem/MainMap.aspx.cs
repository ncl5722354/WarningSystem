using System;
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

        public static int update_panel2_count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


            DateTime mytime = DateTime.Now;
            Label_timer.Text = mytime.ToString("yyyy-MM-dd HH:mm:ss");
            Circle_Yanse();    // 界面变化颜色
            Update_Panel2();   // 更新panel2
            //Image_point1.Attributes.Add("onMouseOver", "VisiblePanel2();");
            
        }

        private void Circle_Yanse()
        {
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
                    }
                    catch { break; }


                }

                if (circle1_max <= 0.01)
                    Circle1.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle1_max <= 0.1)
                    Circle1.BackColor = System.Drawing.Color.Blue;
                else if (circle1_max <= 1.0)
                    Circle1.BackColor = System.Drawing.Color.LightGreen;
                else if (circle1_max < 2)
                    Circle1.BackColor = System.Drawing.Color.Yellow;
                else if (circle1_max >=2)
                    Circle1.BackColor = System.Drawing.Color.Red;

                if (circle2_max <= 0.01)
                    Circle2.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle2_max <= 0.1)
                    Circle2.BackColor = System.Drawing.Color.Blue;
                else if (circle2_max <= 1.0)
                    Circle2.BackColor = System.Drawing.Color.LightGreen;
                else if (circle2_max < 2)
                    Circle2.BackColor = System.Drawing.Color.Yellow;
                else if (circle2_max >= 2)
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

                if (circle5_max <= 0.01)
                    Circle5.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle5_max <= 0.1)
                    Circle5.BackColor = System.Drawing.Color.Blue;
                else if (circle5_max <= 1.0)
                    Circle5.BackColor = System.Drawing.Color.LightGreen;
                else if (circle5_max < 2)
                    Circle5.BackColor = System.Drawing.Color.Yellow;
                else if (circle5_max >= 2)
                    Circle5.BackColor = System.Drawing.Color.Red;

                if (circle6_max <= 0.01)
                    Circle6.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle6_max <= 0.1)
                    Circle6.BackColor = System.Drawing.Color.Blue;
                else if (circle6_max <= 1.0)
                    Circle6.BackColor = System.Drawing.Color.LightGreen;
                else if (circle6_max < 2)
                    Circle6.BackColor = System.Drawing.Color.Yellow;
                else if (circle6_max >= 2)
                    Circle6.BackColor = System.Drawing.Color.Red;

                if (circle7_max <= 0.01)
                    Circle7.BackColor = System.Drawing.Color.DarkBlue;
                else if (circle7_max <= 0.1)
                    Circle7.BackColor = System.Drawing.Color.Blue;
                else if (circle7_max <= 1.0)
                    Circle7.BackColor = System.Drawing.Color.LightGreen;
                else if (circle7_max < 2)
                    Circle7.BackColor = System.Drawing.Color.Yellow;
                else if (circle7_max >= 2)
                    Circle7.BackColor = System.Drawing.Color.Red;
            }
            catch { }

        }           // 更新圆圈的颜色

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


                        double value =Math.Round(Math.Abs(positon_value - positon_value1) * (1 - Math.Sqrt(3) / 2) / 0.0482,2);

                        
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
                                mylabel.Style["top"] = (count*5).ToString()+"%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString()+"mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
           
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
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
                                mylabel.Style["top"] = (count * 5).ToString() + "%";
                                mylabel.Style["left"] = "0%";
                                mylabel.Style["z-index"] = "5";
                                mylabel.Text = "报警信息 位置：" + position_string + "m " + "位移量：" + value.ToString() + "mm";
                                mylabel.ForeColor = System.Drawing.Color.Red;
                                mylabel.BackColor = System.Drawing.Color.DarkBlue;
                                panel3.Controls.Add(mylabel);
                                count++;
                            }
                        }

                    }
                    catch { break; }
                    
                       
                    

                }
                Label label = new Label();
                label.Style["position"] = "absolute";
                label.Font.Size = FontUnit.Medium;
                label.Style["top"] = (count * 5).ToString() + "%";
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
            //view.Set_Start_End(602, 675, 0, 0);
            //Response.Redirect(view.GetRouteUrl());
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