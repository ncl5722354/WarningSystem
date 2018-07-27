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
using SqlConnect;

namespace RealPhotonics
{
    public partial class Login : Form
    {

        public static string passion = "";
        public static string username = "";
        public static SQL_Connect_Builder builder = new SQL_Connect_Builder(".", "realphotonics", 0, 100);               // 数据库的连接
        public Login()
        {
            InitializeComponent();
            // 建立用户表
            CreateSqlValueType[] create_usertable_value=new CreateSqlValueType[3];
            create_usertable_value[0]=new CreateSqlValueType("nvarchar(50)","userID",true);
            create_usertable_value[1]=new CreateSqlValueType("nvarchar(50)","password");
            create_usertable_value[2]=new CreateSqlValueType("nvarchar(50)","passion");
            builder.Create_Table("usertable",create_usertable_value);

            // 建立报警表
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ViewCaoZuo.Object_Position_Screen(0.5, 0.4, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            // admin进入
            if(textBox_username.Text=="admin" && textBox_password.Text=="admin")
            {
                username = textBox_username.Text;
                passion = "管理员";
                this.Hide();
                MainView mv = new MainView();
                mv.Show();
            }
            else
            {
                string myusername = textBox_username.Text.Trim();
                string password = textBox_password.Text.Trim();
                string where_cmd = "userID='" + myusername + "'";
                DataTable dt = builder.Select_Table("usertable", where_cmd);
                if(dt!=null)
                {
                    if(dt.Rows.Count==0)
                    {
                        MessageBox.Show("用户名或密码错误！");
                    }
                    if (dt.Rows.Count > 0)
                    {
                        username = dt.Rows[0][0].ToString();
                        passion = dt.Rows[0][2].ToString();
                        this.Hide();
                        MainView mv = new MainView();
                        mv.Show();
                        if (passion == "用户")
                        {
                            mv.kehu_Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }
            }
        }
    }
}
