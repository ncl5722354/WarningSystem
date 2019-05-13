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
    public partial class zhuziview : System.Web.UI.Page
    {
        public static double start1 = 0;
        public static double end1 = 0;
        public static double start2 = 0;
        public static double end2 = 0;
        public static int selected1 = 0;
        public static int selected2 = 0;
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

                string[] jizhun_list= FileCaozuo.Read_All_Line("D:\\data\\" + file_jizhun);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + file_now);

                for (int i = 0; i < jizhun_list.Length-1; i++) 
                {
                    try
                    {
                        string position_string = string_caozuo.Get_Table_String(jizhun_list[i], 1);
                        double position = double.Parse(position_string);
                        if(position>=start1 && position<=end1)
                        {
                            try
                            {
                                string value_jizhun_string = string_caozuo.Get_Table_String(jizhun_list[i], 2);
                                string value_now_string = string_caozuo.Get_Table_String(now_list[i], 2);
                                double jizhun = double.Parse(value_jizhun_string);
                                double now = double.Parse(value_now_string);
                                // (value-value*Math.Sqrt(3)/2)/0.0482;
                                double value = Math.Round(Math.Abs(now - jizhun) * (1 - Math.Sqrt(3) / 2)/0.0482,3);
                                // 左侧
                                Label label_position = new Label();
                                label_position.Text = position.ToString();
                                Label label_value = new Label();
                                label_value.Text = value.ToString();
                                count1++;
                                 //position: absolute
                                label_position.Style["position"] = "absolute";
                                label_position.Style["top"] = (180 + count1 * 17).ToString()+"px";
                                label_position.Style["left"] = "20px";
                                label_value.Style["position"] = "absolute";
                                label_value.Style["top"] = (180 + count1 * 17).ToString() + "px";
                                label_value.Style["left"] = "100px";


                                this.form1.Controls.Add(label_position);
                                this.form1.Controls.Add(label_value);
                            }
                            catch { }
                        }

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
                                Label label_position = new Label();
                                label_position.Text = position.ToString();
                                Label label_value = new Label();
                                label_value.Text = value.ToString();
                                count2++;
                                //position: absolute
                                label_position.Style["position"] = "absolute";
                                label_position.Style["top"] = (180 + count2 * 17).ToString() + "px";
                                label_position.Style["left"] = "430px";
                                label_value.Style["position"] = "absolute";
                                label_value.Style["top"] = (180 + count2 * 17).ToString() + "px";
                                label_value.Style["left"] = "350px";


                                this.form1.Controls.Add(label_position);
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
           
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Set_Start_End(start1, end1, start2, end2);
            Chart1.Style["position"] = "absolute";
            Chart1.Style["left"] = "500px";
            Chart1.Style["top"] = "100px";
            Chart1.Width = 500;
            Chart1.Height = 300;
            //Chart1.Series[0].Points.AddXY(0, 0);
            //刷新列表
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
    }
}