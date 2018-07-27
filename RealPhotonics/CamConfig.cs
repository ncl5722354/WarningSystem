using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlConnect;

namespace RealPhotonics
{
    public partial class CamConfig : Form
    {
        public CamConfig()
        {
            InitializeComponent();
            // 建立摄像头设定列表
            CreateSqlValueType[] cam_config_table = new CreateSqlValueType[7];
            cam_config_table[0] = new CreateSqlValueType("nvarchar(50)", "camID", true);
            cam_config_table[1] = new CreateSqlValueType("nvarchar(50)","camIP");
            cam_config_table[2] = new CreateSqlValueType("nvarchar(50)","camPort");
            cam_config_table[3] = new CreateSqlValueType("nvarchar(50)","username");
            cam_config_table[4] = new CreateSqlValueType("nvarchar(50)","password");
            cam_config_table[5] = new CreateSqlValueType("nvarchar(50)","minvalue");
            cam_config_table[6] = new CreateSqlValueType("nvarchar(50)","maxvalue");
            Login.builder.Create_Table("camconfig",cam_config_table);
            Read_Cam_Info();
        }

        public void Read_Cam_Info()
        {
            listView1.Items.Clear();
            DataTable dt = Login.builder.Select_Table("camconfig");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dt.Rows[i][0].ToString();
                //item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add(dt.Rows[i][2].ToString());
                item.SubItems.Add(dt.Rows[i][3].ToString());
                item.SubItems.Add(dt.Rows[i][4].ToString());
                item.SubItems.Add(dt.Rows[i][5].ToString());
                item.SubItems.Add(dt.Rows[i][6].ToString());
                listView1.Items.Add(item);
            }

        }    

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_camid.Text=="")
            {
                MessageBox.Show("摄像头ID不能为空！");
                return;
            }
            if(textBox_camip.Text=="")
            {
                MessageBox.Show("摄像头IP不能为空！");
                return;
            }
            if(textBox_camport.Text=="")
            {
                MessageBox.Show("摄像头端口不能为空！");
                return;
            }
            if(textBox_user.Text=="")
            {
                MessageBox.Show("摄像头用户名不能为空！");
                return;
            }
            if(textBox_password.Text=="")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if(textBox_minvalue.Text=="")
            {
                MessageBox.Show("最小值不能为空！");
                return;
            }
            if(textBox_maxvalue.Text=="")
            {
                MessageBox.Show("最大值不能为空！");
                return;
            }
            string[] insert_cmd=new string[7];
            insert_cmd[0]=textBox_camid.Text;
            insert_cmd[1]=textBox_camip.Text;
            insert_cmd[2]=textBox_camport.Text;
            insert_cmd[3]=textBox_user.Text;
            insert_cmd[4]=textBox_password.Text;
            insert_cmd[5]=textBox_minvalue.Text;
            insert_cmd[6]=textBox_maxvalue.Text;
            Login.builder.Insert("camconfig", insert_cmd);
            Read_Cam_Info();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string selected_id = listView1.SelectedItems[0].Text;
                string wherer_cmd = "camID='" + selected_id + "'";
                Login.builder.Delete("camconfig", wherer_cmd);
                Read_Cam_Info();
            }
            catch
            {

            }
        }
    }
}
