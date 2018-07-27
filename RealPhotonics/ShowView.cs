using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealPhotonics
{
    public partial class ShowView : Form
    {
        public static string mapname = "装配体";                                // 更改地图名称
        Image myimage = Image.FromFile(System.Environment.CurrentDirectory + "\\mappic\\" + mapname + ".bmp");
        DataTable dt = null;
        manwalking walkingtubiao = new manwalking();
        manwalkpanpa walkingpanpa = new manwalkpanpa();
        int shandong_count = 0;
        int panpa_count = 0;

        private int warning_count = -1;

        private int warning_location=-1;
        private string warning_time;
        private string  warning_type="";
        private int cam_channel=0;
        private int cam_id = -1;
        private int warning_timer = 3;           //记录报警信息时间间隔
        bool cansave = false;
        public static string  warning_voice = "";

        public ShowView()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(walkingtubiao);
            pictureBox1.Controls.Add(walkingpanpa);
            //walkingtubiao.Left =0; //-walkingtubiao.Width;
            //walkingtubiao.Top = 0; //-walkingtubiao.Height;
            //walkingtubiao.BackColor = System.Drawing.Color.Transparent;
            try
            {
                dt = Login.builder.Select_Table(mapname);
            }
            catch { }
            MainView.client.Data_Arrival_Event += new EventHandler(Show_Man_Walking);

        }

        private void ShowView_Load(object sender, EventArgs e)
        {
            Show_Map_View();
            if (myimage != null)
            {
            }
            List_Reflush();
           // camView1.Login_in("192.168.1.4", 8000, "admin", "12345678abc");
            camView1.ReSet_Size();
        }

        private void Show_Map_View()
        {
            // 将对应的地图显示出来
            
            panel2.BackgroundImage = myimage;
            pictureBox1.Width = myimage.Width;
            pictureBox1.Height = myimage.Height;
            panel2.Width = myimage.Width;
            panel2.Height = myimage.Height;
            pictureBox1.Image = myimage;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //if (myimage != null)
            //{
            //    Graphics g = pictureBox1.CreateGraphics();
            //    g.Clear(Color.White);
            //    g.DrawImage(myimage, 0, 0, myimage.Width, myimage.Height);
            //    //g.Clear(Color.White);
            //    //pictureBox1.Parent = panel2;
            //    //pictureBox1.BackColor = Color.Transparent;
            //    //g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(1000, 1000 + count));

            //    //ount++;
            //    //if (count >= 1000)
            //    //{
            //    //  count = 1000;
            //    //}

            //    //DataTable dt = Login.builder.Select_Table(mapname);
            //    //foreach (DataRow dr in dt.Rows)
            //    //{
            //    //    int start_x = int.Parse(dr[1].ToString());
            //    //    int start_y = int.Parse(dr[2].ToString());
            //    //    int end_x = int.Parse(dr[3].ToString());
            //    //    int end_y = int.Parse(dr[4].ToString());
            //    //    g.DrawLine(new Pen(Color.Green, 5), new Point(start_x, start_y), new Point(end_x, end_y));
            //    //}
            //    //g.Dispose();
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Show_Man_Walking(object sender,EventArgs e)
        {
            byte[] receive_byte = MainView.client.receive_byte;
            int data_length = MainView.client.receive_num;
            int start_index = 0;
            int end_index = 0;
            string get_cmd = Encoding.Default.GetString(receive_byte);
            int show_num = 0;
            //warning_count = 3;                   // 开始3秒钟的一个警报

            for (int i = 0; i < data_length; i++)
            {
                if (receive_byte[i] == 0)
                {
                    // 用\0作分割
                    end_index = i;
                    string this_cmd = get_cmd.Substring(start_index, end_index - start_index);
                    //show_cmd = show_cmd + this_cmd + "\n";
                    //show_num++;
                    //if (show_num >= 10)
                    //{
                    //    show_num = 0;
                    //    show_cmd = "";          //最多显示十条，显示超过十条清屏
                    //}
                    //start_index = i + 1;
                    // 对命令进行解析
                    string year = this_cmd.Substring(2, 4);
                    string month = this_cmd.Substring(6, 2);
                    string day = this_cmd.Substring(8, 2);
                    string hour = this_cmd.Substring(10, 2);
                    string min = this_cmd.Substring(12, 2);
                    string second = this_cmd.Substring(14, 2);
                    string position = this_cmd.Substring(16, 5);
                    string time = year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + second;
                    string type = this_cmd.Substring(1, 1);

                    warning_location = int.Parse(position);
                    warning_time = time;
                    //warning_type = int.Parse(type);
                    cam_channel = 0;

                    try
                    {
                        DateTime create_time = DateTime.Parse(time);
                        int mytype = int.Parse(type);
                        int myposition = int.Parse(position);
                        string[] insert_cmd=new string[3];

                        // 显示图标位置

                        if(dt!=null)
                        {
                            foreach(DataRow dr in dt.Rows)
                            {
                                int start_value = int.Parse(dr[5].ToString());
                                int end_value = int.Parse(dr[6].ToString());
                                int start_x = int.Parse(dr[1].ToString());
                                int end_x = int.Parse(dr[3].ToString());
                                int start_y = int.Parse(dr[2].ToString());
                                int end_y = int.Parse(dr[4].ToString());
                                string kind=dr[7].ToString();
                                warning_voice = dr[8].ToString();
                                warning_count = 2;
                                if(myposition>=start_value && myposition<=end_value && kind=="行人")
                                {
                                    warning_type = "行人";
                                    float bili = ((float)(myposition - start_value) / ((float)(end_value - start_value)));
                                    float x = (end_x - start_x) * bili+start_x;
                                    float y = (end_y - start_y) * bili+start_y;
                                    shandong_count = 5;
                                    // 位置就是x 与 y
                                    //richTextBox1.Invoke(new EventHandler(delegate { richTextBox1.Text = show_cmd; }));
                                    walkingtubiao.Invoke(new EventHandler(delegate
                                    {
                                        walkingtubiao.Left = ((int)x) - walkingtubiao.Width / 2;
                                        walkingtubiao.Top = ((int)y) - walkingtubiao.Height / 2;
                                    }));
                                    
                                    break;
                                }
                                if (myposition >= start_value && myposition <= end_value && kind == "攀爬")
                                {
                                    warning_type = "攀爬";
                                    float bili = ((float)(myposition-start_value) / ((float)(end_value - start_value)));
                                    float x = (end_x - start_x) * bili+start_x;
                                    float y = (end_y - start_y) * bili+start_y;
                                    shandong_count = 5;
                                    // 位置就是x 与 y
                                    //richTextBox1.Invoke(new EventHandler(delegate { richTextBox1.Text = show_cmd; }));
                                    walkingpanpa.Invoke(new EventHandler(delegate
                                    {
                                        walkingpanpa.Left = ((int)x) - walkingpanpa.Width / 2;
                                        walkingpanpa.Top = ((int)y) - walkingpanpa.Height / 2;
                                    }));

                                    break;
                                }
                            }
                        }
                        string table_name="warning"+DateTime.Now.ToString("yyyyMMdd");
                        insert_cmd[0]=time;
                        insert_cmd[1]=warning_type;
                        insert_cmd[2]=position;
                        // 记录下一个报警信息
                        try
                        {
                            if (cansave == true)
                            {
                                cansave = false;
                                warning_timer = 3;
                                Login.builder.Insert(table_name, insert_cmd);
                                // 第一次加入时候，刷新列表
                                listView1.Invoke(new EventHandler(delegate { List_Reflush(); }));
                                
                            }

                        }
                        catch { }
                    }
                    catch { }
                }
            }
            try
            {
                
            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_warnlocation.Text = warning_location.ToString();
            label_warningtime.Text = warning_time;
            label_camchannel.Text = "0";

            DataTable dt = Login.builder.Select_Table("camconfig");
            foreach(DataRow dr in dt.Rows)
            {
                int minvalue = int.Parse(dr[5].ToString());
                int maxvalue = int.Parse(dr[6].ToString());
                if(warning_location>=minvalue && warning_location<=maxvalue)
                {
                    int id = int.Parse(dr[0].ToString());
                    if(id!=cam_id)
                    {
                        string ip = dr[1].ToString();
                        short port = short.Parse(dr[2].ToString());
                        string username = dr[3].ToString();
                        string password = dr[4].ToString();
                        camView1.Login_in(ip,port,username,password);

                    }
                }
            }

            
            label_ruqintype.Text = warning_type;
            if(shandong_count>=0)
            {
                shandong_count--;
                if(shandong_count<=0)
                {
                    walkingtubiao.Top = -walkingtubiao.Height;
                    walkingtubiao.Left = -walkingtubiao.Width;
                   // pictureBox1.Refresh();
                    if (myimage != null)
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        g.Clear(Color.White);
                        g.DrawImage(myimage, 0, 0, myimage.Width, myimage.Height);
                        
                    }
                }
            }
            if (panpa_count >= 0)
            {
                panpa_count--;
                if (panpa_count <= 0)
                {
                    
                    walkingpanpa.Top = -walkingpanpa.Height;
                    walkingpanpa.Left = -walkingpanpa.Width;
                    // pictureBox1.Refresh();
                    if (myimage != null)
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        g.Clear(Color.White);
                        g.DrawImage(myimage, 0, 0, myimage.Width, myimage.Height);

                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(warning_timer>=0)
            {
                cansave = false;
                warning_timer--;
            }
            else
            {
                cansave = true;
            }
            if(warning_count>=0)
            {
                if(warning_voice!=MainView.player.myfilename)
                {
                    MainView.player = null;
                    MainView.player = new voice.voiceControls(warning_voice);
                }
                try
                {
                    MainView.player.voiceplay_loop();
                }
                catch { }
                warning_count--;
            }
            else
            {
                try
                {
                    MainView.player.play_stop();
                }
                catch { }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            List_Reflush();
            //DateTime selected_datetime = dateTimePicker1.Value;
            //string table_name="warning"+selected_datetime.ToString("yyyyMMdd");
            //string where_cmd="createtime >'"+selected_datetime.ToString("yyyy-MM-dd 00:00:00")+"' and createtime<'"+selected_datetime.ToString("yyyy-MM-dd 23:59:59")+"'";
            //DataTable dt = null;
            //try
            //{
            //    dt = Login.builder.Select_Table(table_name);
            //}
            //catch {
            //   //MessageBox.Show("表格不存在");
              
            //}
            //try
            //{
            //    int count = dt.Rows.Count;
            //    //MessageBox.Show("一共有"+count.ToString()+"行");
            //}
            //catch { }
            //listView1.Items.Clear();
            //if (dt != null)
            //{
                
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        ListViewItem item = new ListViewItem();
            //        item.Text = dt.Rows[i][0].ToString();
            //        //item.SubItems.Add(dt.Rows[i][1].ToString());
            //        item.SubItems.Add(dt.Rows[i][1].ToString());
            //        item.SubItems.Add(dt.Rows[i][2].ToString());
            //        listView1.Items.Add(item);
            //    }
            //}
        }

        private void List_Reflush()
        {
            DateTime selected_datetime = dateTimePicker1.Value;
            string table_name = "warning" + selected_datetime.ToString("yyyyMMdd");
            string where_cmd = "createtime >'" + selected_datetime.ToString("yyyy-MM-dd 00:00:00") + "' and createtime<'" + selected_datetime.ToString("yyyy-MM-dd 23:59:59") + "'";
            DataTable dt = null;
            try
            {
                dt = Login.builder.Select_Table(table_name);
            }
            catch
            {
                //MessageBox.Show("表格不存在");

            }
            try
            {
                int count = dt.Rows.Count;
                //MessageBox.Show("一共有"+count.ToString()+"行");
            }
            catch { }
            listView1.Items.Clear();
            if (dt != null)
            {

                for (int i = dt.Rows.Count-1; i >=0; i--)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dt.Rows[i][0].ToString();
                    //item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices[0] >= 0)
                {
                    
                        // 用来与之前的东西进行对比
                        int index = listView1.SelectedIndices[0];
                        //string a = listView1.Items[index].SubItems[2].Text.ToString();
                        int loaction = int.Parse(listView1.Items[index].SubItems[2].Text);
                        DateTime thistime = DateTime.Parse(listView1.Items[index].Text);
                        DataTable dt = Login.builder.Select_Table("camconfig");
                        if (dt == null)
                        {
                            return;
                        }
                        if (dt.Rows.Count == 0)
                        {
                            return;
                        }
                        foreach (DataRow dr in dt.Rows)
                        {
                            int min = int.Parse(dr[5].ToString());
                            int max = int.Parse(dr[6].ToString());

                            if (loaction >= min && loaction <= max)
                            {
                                // 就是这个被选择的摄像头
                                string ip = dr[1].ToString();
                                int port = int.Parse(dr[2].ToString());
                                string username = dr[3].ToString();
                                string password = dr[4].ToString();
                                int channel = 0;
                                switch (ip)
                                {
                                    case "192.168.1.2":
                                        channel = 1;
                                        break;
                                    case "192.168.1.4":
                                        channel = 2;
                                        break;
                                    default:
                                        channel = 0;
                                        break;
                                }

                                camView2.ReView("192.168.1.40", 8000, "admin", "12345678abc", thistime, channel);
                                // MessageBox.Show("ip is " + ip);
                            }
                        }
                    
                }
            }
            catch { }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
