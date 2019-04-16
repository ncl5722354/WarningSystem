using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileOperation;
using Communication;


namespace Shuini
{
    public partial class SubView : UserControl
    {
        private int machine_num = 0;
        public static FileOperation.IniFile inifile = new IniFile("D:\\config\\config.ini");

        public SubView()
        {
            InitializeComponent();
        }

        public void Set_Machine_Num(int num)
        {
            machine_num = num;
            // 界面值也得有所变化
            label_machine_name.Text = inifile.IniReadValue("station", machine_num.ToString());

        }
        
        private void label7_DoubleClick(object sender, EventArgs e)
        {
            SetMachine_num view = new SetMachine_num(machine_num);
            view.ShowDialog();
            Set_Machine_Num(machine_num);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigView view = new ConfigView(machine_num);
            view.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Math.Round(Form1.wendu[machine_num], 2).ToString();// String.Format("{0:N2}", Form1.wendu[machine_num].ToString());

            if (Form1.connect_time_out[machine_num] >= 5)
            {
                label_communicate.Text = "通讯断开";
                label_chuanganqi.Text = "传感器状态：未连接";
                Form1.chuanganqi_connect_is[machine_num] = false;
                label_communicate.BackColor = System.Drawing.Color.FromName("Red");
                label_chuanganqi.BackColor = System.Drawing.Color.FromName("Red");
            }
            else
            {
                label_communicate.Text = "通讯正常";
                label_communicate.BackColor = System.Drawing.Color.FromName("Yellow");
            }

            if(Form1.chuanganqi_connect_is[machine_num]==true)
            {
                label_chuanganqi.Text = "传感器状态：连接上";
                label_chuanganqi.BackColor = System.Drawing.Color.FromName("Yellow");
            }
            else
            {
                label_chuanganqi.Text = "传感器状态：未连接";
                label_chuanganqi.BackColor = System.Drawing.Color.FromName("Red");
            }

            if (Form1.duanhao[machine_num] == 0) label4.Text = "未使用";
            if (Form1.duanhao[machine_num] == 1) label4.Text = "升温中";
            if (Form1.duanhao[machine_num] == 2) label4.Text = "降温中";
            if (Form1.duanhao[machine_num] == 3) label4.Text = "已结束";

            DateTime daojishi = DateTime.Parse("00:00:00");
            daojishi = daojishi.AddSeconds(Form1.daojishi[machine_num]);
            //if (Form1.daojishi[machine_num] != 0) Console.WriteLine(Form1.daojishi[machine_num].ToString());
            label6.Text = daojishi.ToString("HH:mm:ss");

            if(Form1.zhuangtai[machine_num]==0)
            {
                button1.Text = "开始";
                button1.BackColor = System.Drawing.Color.FromName("Yellow");
            }
            if (Form1.zhuangtai[machine_num] == 1)
            {
                button1.Text = "停止";
                button1.BackColor = System.Drawing.Color.FromName("Red");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.zhuangtai[machine_num] == 0)
            {
               //开始
                Form1.start_is[machine_num] = true;
                //string ip = SubView.inifile.IniReadValue("station_ip",machine_num.ToString());
                //foreach(TcpServerClient client in Form1.allclient)
                //{
                //    if(client.ServerIp.ToString()==ip)
                //    {
                //        byte[] send_byte = new byte[3];
                //        send_byte[0] = 0xFF;
                //        send_byte[1] = 0xff;
                //        send_byte[2] = 0xff;
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        break;
                //    }
                //}
            }
            if (Form1.zhuangtai[machine_num] == 1)
            {
                //开始
                string ip = SubView.inifile.IniReadValue("station_ip", machine_num.ToString());
                Form1.stop_is[machine_num] = true;
                //foreach (TcpServerClient client in Form1.allclient)
                //{
                //    if (client.ServerIp.ToString() == ip)
                //    {
                //        byte[] send_byte = new byte[3];
                //        send_byte[0] = 0xF0;
                //        send_byte[1] = 0xf0;
                //        send_byte[2] = 0xf0;
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        client.Send_Data(send_byte);
                //        System.Threading.Thread.Sleep(800);
                //        break;
                //    }
                //}
            }
        }
    }
}
