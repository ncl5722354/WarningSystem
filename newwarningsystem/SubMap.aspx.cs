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

namespace newwarningsystem
{
    public partial class SubMap : System.Web.UI.Page
    {
        public static string map_name = "";
        public static string pic_uri = "";

        public static double click_value = 0;
        public static double max = 0;
        public static double min = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            Create_Map();
        }


        protected void Click(object sender, EventArgs e)
        {
            Chart2.Series[0].Points.Clear();
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
                        double position = double.Parse(string_caozuo.Get_Table_String(jizhun_list[j], 1));
                        double jizhun = double.Parse(string_caozuo.Get_Table_String(jizhun_list[j], 2));
                        double value = (double.Parse(string_caozuo.Get_Table_String(now_list[j], 2)) - jizhun) * (1 - Math.Sqrt(3) / 2) / 0.0482;
                        
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
                                imagebutton.Style["top"] = (y * 3-430 ).ToString() + "px";
                                imagebutton.Style["left"] = (x * 3 - 700).ToString() + "px";
                                imagebutton.Style["width"] = "5px";
                                imagebutton.Style["height"] = "5px";
                                imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                imagebutton.Click += new ImageClickEventHandler(Click);
                            }
                            if (map_name == "二号坡上")
                            {
                                imagebutton.Style["top"] = (y * 6 - 400).ToString() + "px";
                                imagebutton.Style["left"] = (x * 6 - 2300).ToString() + "px";
                                imagebutton.Style["width"] = "5px";
                                imagebutton.Style["height"] = "5px";
                                imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                imagebutton.Click += new ImageClickEventHandler(Click);
                            }
                            if (map_name == "二号坡下")
                            {
                                imagebutton.Style["top"] = (y * 6 - 900).ToString() + "px";
                                imagebutton.Style["left"] = (x * 6 - 2300).ToString() + "px";
                                imagebutton.Style["width"] = "5px";
                                imagebutton.Style["height"] = "5px";
                                imagebutton.ToolTip = "位置:" + position.ToString("#0.000") + " 位移量:" + value.ToString("#0.000");
                                imagebutton.Click += new ImageClickEventHandler(Click);
                            }


                            form1.Controls.Add(imagebutton);

                        }
                    }
                }
            }
            catch{}
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Image1.ImageUrl = pic_uri;
           
        }

        protected void link0_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }

    }
}