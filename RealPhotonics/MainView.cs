using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ViewConfig;
using Communication;
using MyShape;
using SqlConnect;
using ViewConfig;
using voice;

namespace RealPhotonics
{
    public partial class MainView : Form
    {

        // 连接服务端的客户端
        public static TcpServerClient client = new TcpServerClient("192.168.1.8", 50023);
        public static voiceControls player = new voiceControls("6175.wav");

        public MainView()
        {
            InitializeComponent();
            //usermangement.TopLevel = false;
            //datashow.TopLevel = false;
            //mapconfig.TopLevel = false;
        }

        public void kehu_Show()
        {
            panel1.Top =(int)(this.Height*0.1);
            panel1.Left = 0;
            panel1.Width = this.Width;
            panel1.Height = this.Height;
            ViewCaoZuo.Show_Form_In_Panel(showview, panel1);
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private UserMangement usermangement = new UserMangement();
        private DataShow datashow = new DataShow();
        private MapConfig mapconfig = new MapConfig();
        private ShowView showview = new ShowView();
        private CamConfig camconfig = new CamConfig();

        private void MainView_Load(object sender, EventArgs e)
        {
            ViewCaoZuo.Max_Form(this);
            ViewCaoZuo.Object_Position(0.1, 0.1, 0.8,0.85, panel1, this.Controls);
            label_username.Text = Login.username;
            label_passion.Text = Login.passion;
            
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            //usermangement.Show_View();
            //panel1.Controls.Add(usermangement);
            //ViewCaoZuo.Max_Form(usermangement);
            ViewCaoZuo.Show_Form_In_Panel(usermangement, panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            //datashow.Show();
            //panel1.Controls.Add(datashow);
            //ViewCaoZuo.Max_Form(datashow);
            ViewCaoZuo.Show_Form_In_Panel(datashow, panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            //mapconfig.Show();
            //panel1.Controls.Add(mapconfig);
            //ViewCaoZuo.Max_Form(mapconfig);
            ViewCaoZuo.Show_Form_In_Panel(mapconfig, panel1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewCaoZuo.Show_Form_In_Panel(showview, panel1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateSqlValueType[] create_warningtable = new CreateSqlValueType[3];
            string table_name = "warning"+DateTime.Now.ToString("yyyyMMdd");
            create_warningtable[0] = new CreateSqlValueType("datetime", "createtime", true);
            create_warningtable[1] = new CreateSqlValueType("nvarchar(50)","type");
            create_warningtable[2] = new CreateSqlValueType("nvarchar(50)","location");
            Login.builder.Create_Table(table_name,create_warningtable);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewCaoZuo.Show_Form_In_Panel(camconfig,panel1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            player.voiceplay_loop();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            player.play_stop();
        }

        
    }
}
