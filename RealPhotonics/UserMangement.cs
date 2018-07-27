using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataGridViewCaoZuo;


namespace RealPhotonics
{
    public partial class UserMangement : Form
    {
        public UserMangement()
        {
            InitializeComponent();

            // 初始化
            comboBox_add_passion.Items.Add("用户");
            comboBox_add_passion.Items.Add("管理员");

            comboBox_passion_shangai.Items.Add("用户");
            comboBox_passion_shangai.Items.Add("管理员");
            //Show_View();
        }

        private void UserMangement_Load(object sender, EventArgs e)
        {

        }



        public void Show_View()
        {
            this.Show();
            DataTable dt= Login.builder.Select_Table("usertable");
            DataGridView_CaoZuo.Fill_DataGridView_With_DataTable(dataGridView1, dt);
        }

        public void Reflush()
        {
            DataTable dt = Login.builder.Select_Table("usertable");
            DataGridView_CaoZuo.Fill_DataGridView_With_DataTable(dataGridView1, dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_add_user.Text.Trim() == "") { MessageBox.Show("添加用户名不能为空！"); return; }
            if (textBox_add_password.Text.Trim() == "") { MessageBox.Show("添加密码不能为空！"); return; }
            if (comboBox_add_passion.Text.Trim() == "") { MessageBox.Show("添加权限不能为空！"); return; }

            // 往表中添加用户
            string[] insert_cmd=new string[3];
            insert_cmd[0]=textBox_add_user.Text.Trim();
            insert_cmd[1]=textBox_add_password.Text.Trim();
            insert_cmd[2]=comboBox_add_passion.Text.Trim();
            Login.builder.Insert("usertable", insert_cmd);
            Reflush();
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int selected_index = dataGridView1.SelectedCells[0].RowIndex;
                textBox_user_shangai.Text = dataGridView1[0, selected_index].Value.ToString();
                textBox_password_shangai.Text = dataGridView1[1, selected_index].Value.ToString();
                comboBox_passion_shangai.Text = dataGridView1[2, selected_index].Value.ToString();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string key = textBox_user_shangai.Text.Trim();
                string where_cmd = "userID='" + key + "'";
                Login.builder.Delete("usertable", where_cmd);
                Reflush();
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string key = textBox_user_shangai.Text.Trim();
            //string username = textBox_user_shangai.Text.Trim();
            string password = textBox_password_shangai.Text.Trim();
            string passion=comboBox_passion_shangai.Text.Trim();
            string where_cmd="userID='" + key + "'";
            string[] updata_cmd=new string[2];
            updata_cmd[0]="password='"+password+"'";
            updata_cmd[1]="passion='"+passion+"'";
            Login.builder.Updata("usertable", where_cmd, updata_cmd);
            Reflush();
        }
    }
}
