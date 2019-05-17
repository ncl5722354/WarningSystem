using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;


namespace Ranji3._0
{
    public partial class General : Form
    {
       
        public MainView mv;
        public int page = 1;
        public General(MainView mymv)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            mv = mymv;
            
            InitializeComponent();
            chart_init();
        }

        public void setpage(int mypage)
        {
            //翻页的函数
            if (mypage <= 0) mypage = 1;
            page = mypage;
        }

        private void chart_init()
        {
             // 对16个chart图表进行初始化 假如没有开始时间，当前时间即为开始时间
             // 道先对开始时间进行判断
            for (int i = 1; i <= 60; i++)
            {
                DataSet ds = mv.mysqlconnection.sql_search_database("select * from start_time where machine_num='"+i.ToString()+"'");
                int rowcount = ds.Tables[0].Rows.Count;
                if (rowcount == 0)
                {
                    //表中没有开始时间
                    mv.mysqlconnection.excute_sql("insert into start_time values ('"+i.ToString()+"','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')");
                }
            }
            //setchart(chart1, 1);
            //setchart(chart2, 2);
            //setchart(chart3, 3);
            //setchart(chart4, 4);
            //setchart(chart5, 5);
            //setchart(chart6, 6);
            //setchart(chart7, 7);
            //setchart(chart8, 8);
            //setchart(chart9, 9);
            //setchart(chart10, 10);
            //setchart(chart11, 11);
            //setchart(chart12, 12);
            //setchart(chart13, 13);
            //setchart(chart14, 14);
            //setchart(chart15, 15);
            //setchart(chart16, 16);
            draw_line();
            //根据开始时间，设定间隔，最大值与最小值
        }

        private void setchart(Chart mychart, int machine_num)
        {
            // 针对一个图表和对应的机号的处理
            try
            {
                if (mychart.InvokeRequired)
                {
                    ThreadWork tw = new ThreadWork(setchart);
                    this.Invoke(tw, new object[2] { mychart, machine_num });
                }
                else
                {
                    mychart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                    DataSet ds = mv.mysqlconnection.sql_search_database("select * from start_time where machine_num=" + machine_num.ToString());
                    DataRow dr = ds.Tables[0].Rows[0];
                    DateTime starttime = DateTime.Parse(dr[1].ToString());
                    mychart.ChartAreas[0].AxisX.Minimum = starttime.ToOADate();
                    mychart.ChartAreas[0].AxisX.Maximum = starttime.AddHours(5).ToOADate();
                    mychart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                    mychart.ChartAreas[0].AxisX.Interval = 2;
                }
                
            }
            catch
            {
            }
        }

        private delegate void ThreadWork(Chart mychart,int machine_num);

        private void draw_chart(Chart mychart,int machine_num)
        {
            //将对应的开始时间读出来
            if (true)
            {
                if (mychart.InvokeRequired)
                {
                    ThreadWork tw = new ThreadWork(draw_chart);
                    try
                    {
                        this.Invoke(tw, new object[2] { mychart, machine_num });
                    }
                    catch { }
                }
                else
                {
                    try
                    {

                        DataSet ds = mv.mysqlconnection.sql_search_database("Select * from start_time where machine_num=" + machine_num.ToString());
                        DataRow dr = ds.Tables[0].Rows[0];
                        DateTime starttime = DateTime.Parse(dr[1].ToString());
                        // 将历史记录中相相应的都读出来
                        ds = mv.mysqlconnection.sql_search_database("Select machine_num,value,save_time from history where machine_num=" + machine_num.ToString() + " and  save_time>" + "'" + starttime.ToString() + "' and save_time<'" + starttime.AddHours(5).ToString() + "' order by save_time");
                        int count = ds.Tables[0].Rows.Count;
                        mychart.Series[0].Points.Clear();
                        for (int i = 0; i < count; i++)
                        {
                            DataRow mydr = ds.Tables[0].Rows[i];
                            int myvalue = int.Parse(mydr[1].ToString());
                            DateTime mytime = DateTime.Parse(mydr[2].ToString());
                            mychart.Series[0].Points.AddXY(mytime, myvalue);
                        }
                    }
                    catch
                    {
                        mychart.Series[0].Points.Clear();
                    }
                    // 画设定曲线
                    try
                    {
                        // int datagridview_row_count = dataGridView1.Rows.Count;
                        DataSet ds = mv.mysqlconnection.sql_search_database("Select * from start_time where machine_num=" + machine_num.ToString());
                        DataRow dr = ds.Tables[0].Rows[0];
                        DateTime starttime = DateTime.Parse(dr[1].ToString()); //开始时间
                        DataSet gongyi_ds = mv.mysqlconnection.sql_search_database("Select * from craft_machine" + machine_num.ToString());
                        int datagridview_row_count = gongyi_ds.Tables[0].Rows.Count;
                        mychart.Series[1].Points.Clear();
                        for (int i = 0; i < datagridview_row_count; i++)
                        {
                            if (gongyi_ds.Tables[0].Rows[i][4].ToString() == "温控")
                            {
                                int wendu = int.Parse(gongyi_ds.Tables[0].Rows[i][1].ToString());
                                mychart.Series[1].Points.AddXY(starttime, wendu);
                                int timespan = int.Parse(gongyi_ds.Tables[0].Rows[i][3].ToString());
                                starttime = starttime.AddMinutes(timespan);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
                
            }

        }

        private void General_Load(object sender, EventArgs e)
        {
            // 标签值要加进来
            myLabel_duanhao1.mv = this.mv;
            myLabel_duanhao2.mv = this.mv;
            myLabel_duanhao3.mv = this.mv;
            myLabel_duanhao4.mv = this.mv;
            myLabel_duanhao5.mv = this.mv;
            myLabel_duanhao6.mv = this.mv;
            myLabel_duanhao7.mv = this.mv;
            myLabel_duanhao8.mv = this.mv;
            myLabel_duanhao9.mv = this.mv;
            myLabel_duanhao10.mv = this.mv;
            myLabel_duanhao11.mv = this.mv;
            myLabel_duanhao12.mv = this.mv;
            myLabel_duanhao13.mv = this.mv;
            myLabel_duanhao14.mv = this.mv;
            myLabel_duanhao15.mv = this.mv;
            myLabel_duanhao16.mv = this.mv;

            myLabel_runtime1.mv = this.mv;
            myLabel_runtime2.mv = this.mv;
            myLabel_runtime3.mv = this.mv;
            myLabel_runtime4.mv = this.mv;
            myLabel_runtime5.mv = this.mv;
            myLabel_runtime6.mv = this.mv;
            myLabel_runtime7.mv = this.mv;
            myLabel_runtime8.mv = this.mv;
            myLabel_runtime9.mv = this.mv;
            myLabel_runtime10.mv = this.mv;
            myLabel_runtime11.mv = this.mv;
            myLabel_runtime12.mv = this.mv;
            myLabel_runtime13.mv = this.mv;
            myLabel_runtime14.mv = this.mv;
            myLabel_runtime15.mv = this.mv;
            myLabel_runtime16.mv = this.mv;

            myLabel_jiare1.mv = this.mv;
            myLabel_jiare2.mv = this.mv;
            myLabel_jiare3.mv = this.mv;
            myLabel_jiare4.mv = this.mv;
            myLabel_jiare5.mv = this.mv;
            myLabel_jiare6.mv = this.mv;
            myLabel_jiare7.mv = this.mv;
            myLabel_jiare8.mv = this.mv;
            myLabel_jiare9.mv = this.mv;
            myLabel_jiare10.mv = this.mv;
            myLabel_jiare11.mv = this.mv;
            myLabel_jiare12.mv = this.mv;
            myLabel_jiare13.mv = this.mv;
            myLabel_jiare14.mv = this.mv;
            myLabel_jiare15.mv = this.mv;
            myLabel_jiare16.mv = this.mv;

            myLabel_lengque1.mv = this.mv;
            myLabel_lengque2.mv = this.mv;
            myLabel_lengque3.mv = this.mv;
            myLabel_lengque4.mv = this.mv;
            myLabel_lengque5.mv = this.mv;
            myLabel_lengque6.mv = this.mv;
            myLabel_lengque7.mv = this.mv;
            myLabel_lengque8.mv = this.mv;
            myLabel_lengque9.mv = this.mv;
            myLabel_lengque10.mv = this.mv;
            myLabel_lengque11.mv = this.mv;
            myLabel_lengque12.mv = this.mv;
            myLabel_lengque13.mv = this.mv;
            myLabel_lengque14.mv = this.mv;
            myLabel_lengque15.mv = this.mv;
            myLabel_lengque16.mv = this.mv;

            myLabel_zongruntime1.mv = this.mv;
            myLabel_zongruntime2.mv = this.mv;
            myLabel_zongruntime3.mv = this.mv;
            myLabel_zongruntime4.mv = this.mv;
            myLabel_zongruntime5.mv = this.mv;
            myLabel_zongruntime6.mv = this.mv;
            myLabel_zongruntime7.mv = this.mv;
            myLabel_zongruntime8.mv = this.mv;
            myLabel_zongruntime9.mv = this.mv;
            myLabel_zongruntime10.mv = this.mv;
            myLabel_zongruntime11.mv = this.mv;
            myLabel_zongruntime12.mv = this.mv;
            myLabel_zongruntime13.mv = this.mv;
            myLabel_zongruntime14.mv = this.mv;
            myLabel_zongruntime15.mv = this.mv;
            myLabel_zongruntime16.mv = this.mv;

           
            myLabel_wendu1.mv = this.mv;
            myLabel_wendu2.mv = this.mv;
            myLabel_wendu3.mv = this.mv;
            myLabel_wendu4.mv = this.mv;
            myLabel_wendu5.mv = this.mv;
            myLabel_wendu6.mv = this.mv;
            myLabel_wendu7.mv = this.mv;
            myLabel_wendu8.mv = this.mv;
            myLabel_wendu9.mv = this.mv;
            myLabel_wendu10.mv = this.mv;
            myLabel_wendu11.mv = this.mv;
            myLabel_wendu12.mv = this.mv;
            myLabel_wendu13.mv = this.mv;
            myLabel_wendu14.mv = this.mv;
            myLabel_wendu15.mv = this.mv;
            myLabel_wendu16.mv = this.mv;

            myLabel_yewei1.mv = this.mv;
            myLabel_yewei2.mv = this.mv;
            myLabel_yewei3.mv = this.mv;
            myLabel_yewei4.mv = this.mv;
            myLabel_yewei5.mv = this.mv;
            myLabel_yewei6.mv = this.mv;
            myLabel_yewei7.mv = this.mv;
            myLabel_yewei8.mv = this.mv;
            myLabel_yewei9.mv = this.mv;
            myLabel_yewei10.mv = this.mv;
            myLabel_yewei11.mv = this.mv;
            myLabel_yewei12.mv = this.mv;
            myLabel_yewei13.mv = this.mv;
            myLabel_yewei14.mv = this.mv;
            myLabel_yewei15.mv = this.mv;
            myLabel_yewei16.mv = this.mv;

            Label_Qidong1.mv = this.mv;
            Label_Qidong2.mv = this.mv;
            Label_Qidong3.mv = this.mv;
            Label_Qidong4.mv = this.mv;
            Label_Qidong5.mv = this.mv;
            Label_Qidong6.mv = this.mv;
            Label_Qidong7.mv = this.mv;
            Label_Qidong8.mv = this.mv;
            Label_Qidong9.mv = this.mv;
            Label_Qidong10.mv = this.mv;
            Label_Qidong11.mv = this.mv;
            Label_Qidong12.mv = this.mv;
            Label_Qidong13.mv = this.mv;
            Label_Qidong14.mv = this.mv;
            Label_Qidong15.mv = this.mv;
            Label_Qidong16.mv = this.mv;

            myLabel_shouzidong1.mv = this.mv;
            myLabel_shouzidong2.mv = this.mv;
            myLabel_shouzidong3.mv = this.mv;
            myLabel_shouzidong4.mv = this.mv;
            myLabel_shouzidong5.mv = this.mv;
            myLabel_shouzidong6.mv = this.mv;
            myLabel_shouzidong7.mv = this.mv;
            myLabel_shouzidong8.mv = this.mv;
            myLabel_shouzidong9.mv = this.mv;
            myLabel_shouzidong10.mv = this.mv;
            myLabel_shouzidong11.mv = this.mv;
            myLabel_shouzidong12.mv = this.mv;
            myLabel_shouzidong13.mv = this.mv;
            myLabel_shouzidong14.mv = this.mv;
            myLabel_shouzidong15.mv = this.mv;
            myLabel_shouzidong16.mv = this.mv;

            myLabel_zhubeng1.mv = this.mv;
            myLabel_zhubeng2.mv = this.mv;
            myLabel_zhubeng3.mv = this.mv;
            myLabel_zhubeng4.mv = this.mv;
            myLabel_zhubeng5.mv = this.mv;
            myLabel_zhubeng6.mv = this.mv;
            myLabel_zhubeng7.mv = this.mv;
            myLabel_zhubeng8.mv = this.mv;
            myLabel_zhubeng9.mv = this.mv;
            myLabel_zhubeng10.mv = this.mv;
            myLabel_zhubeng11.mv = this.mv;
            myLabel_zhubeng12.mv = this.mv;
            myLabel_zhubeng13.mv = this.mv;
            myLabel_zhubeng14.mv = this.mv;
            myLabel_zhubeng15.mv = this.mv;
            myLabel_zhubeng16.mv = this.mv;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            mv.detail.Set_machine_num(1 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
           // mv.detail.ReFlash_Craft_Chart();
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(2 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
           // mv.detail.ReFlash_Craft_Chart();
        }

        private void chart5_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(5 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(3 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart6_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(6 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart7_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(7 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart8_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(8 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart4_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(4 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart16_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(16 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart15_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(15 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart10_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(10 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart9_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(9 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart13_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(13 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        private void chart14_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num(14 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
            mv.detail.Reset_Craft_ComboBox();
            //mv.detail.ReFlash_Craft_Chart();
        }

        public void draw_line()
        {
            //一次画线的过程
            Console.WriteLine("drawline starttime is "+DateTime.Now.ToString());
            //setchart(chart1, 1 + (page - 1) * 16);
            //setchart(chart2, 2 + (page - 1) * 16);
            //setchart(chart3, 3 + (page - 1) * 16);
            //setchart(chart4, 4 + (page - 1) * 16);
            //setchart(chart5, 5 + (page - 1) * 16);
            //setchart(chart6, 6 + (page - 1) * 16);
            //setchart(chart7, 7 + (page - 1) * 16);
            //setchart(chart8, 8 + (page - 1) * 16);
            //setchart(chart9, 9 + (page - 1) * 16);
            //setchart(chart10, 10 + (page - 1) * 16);
            //setchart(chart11, 11 + (page - 1) * 16);
            //setchart(chart12, 12 + (page - 1) * 16);
            //setchart(chart13, 13 + (page - 1) * 16);
            //setchart(chart14, 14 + (page - 1) * 16);
            //setchart(chart15, 15 + (page - 1) * 16);
            //setchart(chart16, 16 + (page - 1) * 16);

            //draw_chart(chart1, 1+(page-1)*16);
            //draw_chart(chart2, 2+(page-1)*16);
            //draw_chart(chart3, 3+(page-1)*16);
            //draw_chart(chart4, 4 + (page - 1) * 16);
            //draw_chart(chart5, 5 + (page - 1) * 16);
            //draw_chart(chart6, 6 + (page - 1) * 16);
            //draw_chart(chart7, 7 + (page - 1) * 16);
            //draw_chart(chart8, 8 + (page - 1) * 16);
            //draw_chart(chart9, 9 + (page - 1) * 16);
            //draw_chart(chart10, 10 + (page - 1) * 16);
            //draw_chart(chart11, 11 + (page - 1) * 16);
            //draw_chart(chart12, 12 + (page - 1) * 16);
            //draw_chart(chart13, 13 + (page - 1) * 16);
            //draw_chart(chart14, 14 + (page - 1) * 16);
            //draw_chart(chart15, 15 + (page - 1) * 16);
            //draw_chart(chart16, 16 + (page - 1) * 16);
            // 标签
            myLabel_duanhao1.Machine_num = 1 + (page - 1) * 16;
            myLabel_duanhao2.Machine_num = 2 + (page - 1) * 16;
            myLabel_duanhao3.Machine_num = 3 + (page - 1) * 16;
            myLabel_duanhao4.Machine_num = 4 + (page - 1) * 16;
            myLabel_duanhao5.Machine_num = 5 + (page - 1) * 16;
            myLabel_duanhao6.Machine_num = 6 + (page - 1) * 16;
            myLabel_duanhao7.Machine_num = 7 + (page - 1) * 16;
            myLabel_duanhao8.Machine_num = 8 + (page - 1) * 16;
            myLabel_duanhao9.Machine_num = 9 + (page - 1) * 16;
            myLabel_duanhao10.Machine_num = 10 + (page - 1) * 16;
            myLabel_duanhao11.Machine_num = 11 + (page - 1) * 16;
            myLabel_duanhao12.Machine_num = 12 + (page - 1) * 16;
            myLabel_duanhao13.Machine_num = 13 + (page - 1) * 16;
            myLabel_duanhao14.Machine_num = 14 + (page - 1) * 16;
            myLabel_duanhao15.Machine_num = 15 + (page - 1) * 16;
            myLabel_duanhao16.Machine_num = 16 + (page - 1) * 16;

            myLabel_jiare1.Machine_num = 1 + (page - 1) * 16;
            myLabel_jiare2.Machine_num = 2 + (page - 1) * 16;
            myLabel_jiare3.Machine_num = 3 + (page - 1) * 16;
            myLabel_jiare4.Machine_num = 4 + (page - 1) * 16;
            myLabel_jiare5.Machine_num = 5 + (page - 1) * 16;
            myLabel_jiare6.Machine_num = 6 + (page - 1) * 16;
            myLabel_jiare7.Machine_num = 7 + (page - 1) * 16;
            myLabel_jiare8.Machine_num = 8 + (page - 1) * 16;
            myLabel_jiare9.Machine_num = 9 + (page - 1) * 16;
            myLabel_jiare10.Machine_num = 10 + (page - 1) * 16;
            myLabel_jiare11.Machine_num = 11 + (page - 1) * 16;
            myLabel_jiare12.Machine_num = 12 + (page - 1) * 16;
            myLabel_jiare13.Machine_num = 13 + (page - 1) * 16;
            myLabel_jiare14.Machine_num = 14 + (page - 1) * 16;
            myLabel_jiare15.Machine_num = 15 + (page - 1) * 16;
            myLabel_jiare16.Machine_num = 16 + (page - 1) * 16;

            myLabel_lengque1.Machine_num = 1 + (page - 1) * 16;
            myLabel_lengque2.Machine_num = 2 + (page - 1) * 16;
            myLabel_lengque3.Machine_num = 3 + (page - 1) * 16;
            myLabel_lengque4.Machine_num = 4 + (page - 1) * 16;
            myLabel_lengque5.Machine_num = 5 + (page - 1) * 16;
            myLabel_lengque6.Machine_num = 6 + (page - 1) * 16;
            myLabel_lengque7.Machine_num = 7 + (page - 1) * 16;
            myLabel_lengque8.Machine_num = 8 + (page - 1) * 16;
            myLabel_lengque9.Machine_num = 9 + (page - 1) * 16;
            myLabel_lengque10.Machine_num = 10 + (page - 1) * 16;
            myLabel_lengque11.Machine_num = 11 + (page - 1) * 16;
            myLabel_lengque12.Machine_num = 12 + (page - 1) * 16;
            myLabel_lengque13.Machine_num = 13 + (page - 1) * 16;
            myLabel_lengque14.Machine_num = 14 + (page - 1) * 16;
            myLabel_lengque15.Machine_num = 15 + (page - 1) * 16;
            myLabel_lengque16.Machine_num = 16 + (page - 1) * 16;

            myLabel_runtime1.Machine_num = 1 + (page - 1) * 16;
            myLabel_runtime2.Machine_num = 2 + (page - 1) * 16;
            myLabel_runtime3.Machine_num = 3 + (page - 1) * 16;
            myLabel_runtime4.Machine_num = 4 + (page - 1) * 16;
            myLabel_runtime5.Machine_num = 5 + (page - 1) * 16;
            myLabel_runtime6.Machine_num = 6 + (page - 1) * 16;
            myLabel_runtime7.Machine_num = 7 + (page - 1) * 16;
            myLabel_runtime8.Machine_num = 8 + (page - 1) * 16;
            myLabel_runtime9.Machine_num = 9 + (page - 1) * 16;
            myLabel_runtime10.Machine_num = 10 + (page - 1) * 16;
            myLabel_runtime11.Machine_num = 11 + (page - 1) * 16;
            myLabel_runtime12.Machine_num = 12 + (page - 1) * 16;
            myLabel_runtime13.Machine_num = 13 + (page - 1) * 16;
            myLabel_runtime14.Machine_num = 14 + (page - 1) * 16;
            myLabel_runtime15.Machine_num = 15 + (page - 1) * 16;
            myLabel_runtime16.Machine_num = 16 + (page - 1) * 16;


            myLabel_zongruntime1.Machine_num = 1 + (page - 1) * 16;
            myLabel_zongruntime2.Machine_num = 2 + (page - 1) * 16;
            myLabel_zongruntime3.Machine_num = 3 + (page - 1) * 16;
            myLabel_zongruntime4.Machine_num = 4 + (page - 1) * 16;
            myLabel_zongruntime5.Machine_num = 5 + (page - 1) * 16;
            myLabel_zongruntime6.Machine_num = 6 + (page - 1) * 16;
            myLabel_zongruntime7.Machine_num = 7 + (page - 1) * 16;
            myLabel_zongruntime8.Machine_num = 8 + (page - 1) * 16;
            myLabel_zongruntime9.Machine_num = 9 + (page - 1) * 16;
            myLabel_zongruntime10.Machine_num = 10 + (page - 1) * 16;
            myLabel_zongruntime11.Machine_num = 11 + (page - 1) * 16;
            myLabel_zongruntime12.Machine_num = 12 + (page - 1) * 16;
            myLabel_zongruntime13.Machine_num = 13 + (page - 1) * 16;
            myLabel_zongruntime14.Machine_num = 14 + (page - 1) * 16;
            myLabel_zongruntime15.Machine_num = 15 + (page - 1) * 16;
            myLabel_zongruntime16.Machine_num = 16 + (page - 1) * 16;

            Label_Qidong1.Machine_num = 1 + (page - 1) * 16;
            Label_Qidong2.Machine_num = 2 + (page - 1) * 16;
            Label_Qidong3.Machine_num = 3 + (page - 1) * 16;
            Label_Qidong4.Machine_num = 4 + (page - 1) * 16;
            Label_Qidong5.Machine_num = 5 + (page - 1) * 16;
            Label_Qidong6.Machine_num = 6 + (page - 1) * 16;
            Label_Qidong7.Machine_num = 7 + (page - 1) * 16;
            Label_Qidong8.Machine_num = 8 + (page - 1) * 16;
            Label_Qidong9.Machine_num = 9 + (page - 1) * 16;
            Label_Qidong10.Machine_num = 10 + (page - 1) * 16;
            Label_Qidong11.Machine_num = 11 + (page - 1) * 16;
            Label_Qidong12.Machine_num = 12 + (page - 1) * 16;
            Label_Qidong13.Machine_num = 13 + (page - 1) * 16;
            Label_Qidong14.Machine_num = 14 + (page - 1) * 16;
            Label_Qidong15.Machine_num = 15 + (page - 1) * 16;
            Label_Qidong16.Machine_num = 16 + (page - 1) * 16;

            myLabel_shouzidong1.Machine_num = 1 + (page - 1) * 16;
            myLabel_shouzidong2.Machine_num = 2 + (page - 1) * 16;
            myLabel_shouzidong3.Machine_num = 3 + (page - 1) * 16;
            myLabel_shouzidong4.Machine_num = 4 + (page - 1) * 16;
            myLabel_shouzidong5.Machine_num = 5 + (page - 1) * 16;
            myLabel_shouzidong6.Machine_num = 6 + (page - 1) * 16;
            myLabel_shouzidong7.Machine_num = 7 + (page - 1) * 16;
            myLabel_shouzidong8.Machine_num = 8 + (page - 1) * 16;
            myLabel_shouzidong9.Machine_num = 9 + (page - 1) * 16;
            myLabel_shouzidong10.Machine_num = 10 + (page - 1) * 16;
            myLabel_shouzidong11.Machine_num = 11 + (page - 1) * 16;
            myLabel_shouzidong12.Machine_num = 12 + (page - 1) * 16;
            myLabel_shouzidong13.Machine_num = 13 + (page - 1) * 16;
            myLabel_shouzidong14.Machine_num = 14 + (page - 1) * 16;
            myLabel_shouzidong15.Machine_num = 15 + (page - 1) * 16;
            myLabel_shouzidong16.Machine_num = 16 + (page - 1) * 16;

            myLabel_zhubeng1.Machine_num = 1 + (page - 1) * 16;
            myLabel_zhubeng2.Machine_num = 2 + (page - 1) * 16;
            myLabel_zhubeng3.Machine_num = 3 + (page - 1) * 16;
            myLabel_zhubeng4.Machine_num = 4 + (page - 1) * 16;
            myLabel_zhubeng5.Machine_num = 5 + (page - 1) * 16;
            myLabel_zhubeng6.Machine_num = 6 + (page - 1) * 16;
            myLabel_zhubeng7.Machine_num = 7 + (page - 1) * 16;
            myLabel_zhubeng8.Machine_num = 8 + (page - 1) * 16;
            myLabel_zhubeng9.Machine_num = 9 + (page - 1) * 16;
            myLabel_zhubeng10.Machine_num = 10 + (page - 1) * 16;
            myLabel_zhubeng11.Machine_num = 11 + (page - 1) * 16;
            myLabel_zhubeng12.Machine_num = 12 + (page - 1) * 16;
            myLabel_zhubeng13.Machine_num = 13 + (page - 1) * 16;
            myLabel_zhubeng14.Machine_num = 14 + (page - 1) * 16;
            myLabel_zhubeng15.Machine_num = 15 + (page - 1) * 16;
            myLabel_zhubeng16.Machine_num = 16 + (page - 1) * 16;

            myLabel_wendu1.Machine_num = 1 + (page - 1) * 16;
            myLabel_wendu2.Machine_num = 2 + (page - 1) * 16;
            myLabel_wendu3.Machine_num = 3 + (page - 1) * 16;
            myLabel_wendu4.Machine_num = 4 + (page - 1) * 16;
            myLabel_wendu5.Machine_num = 5 + (page - 1) * 16;
            myLabel_wendu6.Machine_num = 6 + (page - 1) * 16;
            myLabel_wendu7.Machine_num = 7 + (page - 1) * 16;
            myLabel_wendu8.Machine_num = 8 + (page - 1) * 16;
            myLabel_wendu9.Machine_num = 9 + (page - 1) * 16;
            myLabel_wendu10.Machine_num = 10 + (page - 1) * 16;
            myLabel_wendu11.Machine_num = 11 + (page - 1) * 16;
            myLabel_wendu12.Machine_num = 12 + (page - 1) * 16;
            myLabel_wendu13.Machine_num = 13 + (page - 1) * 16;
            myLabel_wendu14.Machine_num = 14 + (page - 1) * 16;
            myLabel_wendu15.Machine_num = 15 + (page - 1) * 16;
            myLabel_wendu16.Machine_num = 16 + (page - 1) * 16;

            myLabel_yewei1.Machine_num = 1 + (page - 1) * 16;
            myLabel_yewei2.Machine_num = 2 + (page - 1) * 16;
            myLabel_yewei3.Machine_num = 3 + (page - 1) * 16;
            myLabel_yewei4.Machine_num = 4 + (page - 1) * 16;
            myLabel_yewei5.Machine_num = 5 + (page - 1) * 16;
            myLabel_yewei6.Machine_num = 6 + (page - 1) * 16;
            myLabel_yewei7.Machine_num = 7 + (page - 1) * 16;
            myLabel_yewei8.Machine_num = 8 + (page - 1) * 16;
            myLabel_yewei9.Machine_num = 9 + (page - 1) * 16;
            myLabel_yewei10.Machine_num = 10 + (page - 1) * 16;
            myLabel_yewei11.Machine_num = 11 + (page - 1) * 16;
            myLabel_yewei12.Machine_num = 12 + (page - 1) * 16;
            myLabel_yewei13.Machine_num = 13 + (page - 1) * 16;
            myLabel_yewei14.Machine_num = 14 + (page - 1) * 16;
            myLabel_yewei15.Machine_num = 15 + (page - 1) * 16;
            myLabel_yewei16.Machine_num = 16 + (page - 1) * 16; 

            //
            label_page.Text = page.ToString();
            if (page <= 1) { button1.Enabled = false; } else { button1.Enabled = true; }
            if (page >= 4) { button2.Enabled = false; } else { button2.Enabled = true; }
            Label_jihao1.Text = (1 + (page - 1) * 16).ToString() + "号机";
            Label_jihao2.Text = (2 + (page - 1) * 16).ToString() + "号机";
            Label_jihao3.Text = (3 + (page - 1) * 16).ToString() + "号机";
            Label_jihao4.Text = (4 + (page - 1) * 16).ToString() + "号机";
            Label_jihao5.Text = (5 + (page - 1) * 16).ToString() + "号机";
            Label_jihao6.Text = (6 + (page - 1) * 16).ToString() + "号机";
            Label_jihao7.Text = (7 + (page - 1) * 16).ToString() + "号机";
            Label_jihao8.Text = (8 + (page - 1) * 16).ToString() + "号机";
            Label_jihao9.Text = (9 + (page - 1) * 16).ToString() + "号机";
            Label_jihao10.Text = (10 + (page - 1) * 16).ToString() + "号机";
            Label_jihao11.Text = (11 + (page - 1) * 16).ToString() + "号机";
            Label_jihao12.Text = (12 + (page - 1) * 16).ToString() + "号机";
            Label_jihao13.Text = (13 + (page - 1) * 16).ToString() + "号机";
            Label_jihao14.Text = (14 + (page - 1) * 16).ToString() + "号机";
            Label_jihao15.Text = (15 + (page - 1) * 16).ToString() + "号机";
            Label_jihao16.Text = (16 + (page - 1) * 16).ToString() + "号机";
            Console.WriteLine("drawline endtime is " + DateTime.Now.ToString());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                Thread newthread = new Thread(draw_line);
                newthread.Start();
            }

            // 删除两天以上的数据
            mv.mysqlconnection.excute_sql("delete from history where datediff(day,'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"',save_time)>'3'");
            mv.mysqlconnection.excute_sql("delete from history where datediff(day,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',save_time)<'-3'");
            //mv.mysqlconnection.excute_sql("delete from history where datediff(day,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',save_time)<'-3'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (page > 1) page = page - 1;
            if (page <= 1) button1.Enabled = false;
            draw_line();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (page < 4) page = page + 1;
            if (page >= 4) button2.Enabled = false;
            draw_line();
        }

        private void chart11_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num( 11 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
        }

        private void chart12_Click(object sender, EventArgs e)
        {
            mv.detail.Set_machine_num( 12 + (page - 1) * 16);
            mv.Show_Form(mv.detail);
            mv.detail.draw_line();
        }

        private void myLabel1_Click(object sender, EventArgs e)
        {

        }

        private void myLabel_jiare_Click(object sender, EventArgs e)
        {

        }
    }
}
