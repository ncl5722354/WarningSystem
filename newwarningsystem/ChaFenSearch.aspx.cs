using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;
using String_Caozuo;
using System.Collections;
using System.IO;
using System.Text;

namespace newwarningsystem
{
       
    public partial class ChaFenSearch : System.Web.UI.Page
    {
        public static double start1 = 0;
        public static double end1 = 0;
        public static double start2 = 0;
        public static double end2 = 0;
        public static string title = "";

        //public static Timer timer1 = new Timer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label_timer.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void ReFlush_List()
        {
            ArrayList filelist = FileCaozuo.Read_All_Files("D:\\data\\", "*.txt");
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            foreach (string myline in filelist)
            {
                ListBox1.Items.Add(myline);
                ListBox2.Items.Add(myline);
            }


           
        }

        private void Tick(object sender,EventArgs e)
        {

        }

        
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ReFlush_Chart();
        }

        protected void ListBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ReFlush_Chart();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReFlush_Chart();
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Set_Start_End(start1, end1, start2, end2);
            Chart1.Style["position"] = "absolute";
            Chart1.Style["left"] = "100px";
            Chart1.Style["top"] = "100px";
            Chart1.Width = 1000;
            Chart1.Height = 300;

            Label5.Text = title;

            //timer1.Tick += new EventHandler(Tick);
            //Chart1.Series[0].Points.AddXY(0, 0);
            //刷新列表

            //Chart2.Style["position"] = "absolute";
            //Chart2.Style["left"] = "700px";
            //Chart2.Style["top"] = "200px";
            //Chart2.Width = 500;
            //Chart2.Height = 300;

            ReFlush_List();

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
                Label_select1.Text = "第一曲线(红色)选择文件为:" + filename;

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
                        Chart1.Series[0].Points.AddXY(position, value);
                    
                }

            }
            catch { }
            try
            {
                string jizhun_file = ListBox2.Items[0].Value.ToString();
                string filename = ListBox2.Items[ListBox2.SelectedIndex].Value.ToString();
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + jizhun_file);
                string[] now_list = FileCaozuo.Read_All_Line("D:\\data\\" + filename);
                Label_select2.Text = "第二曲线(蓝色)选择文件为:" + filename;
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

                        Chart1.Series[1].Points.AddXY(position, value);
                    
                }

            }
            catch { }
        }

        protected void link_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }
    }
}