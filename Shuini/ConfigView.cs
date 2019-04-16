using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Shuini
{
    public partial class ConfigView : Form
    {
        private int mymachine_num = 0;
        public ConfigView(int num)
        {
            InitializeComponent();
            mymachine_num = num;
            label_machine_num.Text = mymachine_num + "号机";
            // 设定机台号
            comboBox_station_num.Items.Clear();
            for (int i = 1; i <= 400; i++)
            {
                comboBox_station_num.Items.Add(i.ToString());
            }

            comboBox_chuanganqi.Items.Add("A");
            comboBox_chuanganqi.Items.Add("B");

            comboBox_station_num.Text = SubView.inifile.IniReadValue("station_num_config",mymachine_num.ToString());
            comboBox_chuanganqi.Text = SubView.inifile.IniReadValue("station_chuanganqi", mymachine_num.ToString());

            textBox_ip.Text = SubView.inifile.IniReadValue("station_ip",mymachine_num.ToString());
            textBox_jiangwentime.Text = "0";
            textBox_shengwentime.Text = "0";
            textBox_shengwenwendu.Text = "0";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubView.inifile.IniWriteValue("station_num_config",mymachine_num.ToString(),comboBox_station_num.Text);
            SubView.inifile.IniWriteValue("station_chuanganqi", mymachine_num.ToString(), comboBox_chuanganqi.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SubView.inifile.IniWriteValue("station_ip",mymachine_num.ToString(),textBox_ip.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_shengwenwendu.Text = Form1.shengwenwendu[mymachine_num].ToString();
            textBox_shengwentime.Text = Form1.shengwenshijian[mymachine_num].ToString();
            textBox_jiangwentime.Text = Form1.jiangwenshijian[mymachine_num].ToString();
        }
    }
}
