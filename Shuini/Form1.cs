using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;
using System.Collections;
using Communication;
using System.Net;

namespace Shuini
{
    public partial class Form1 : Form
    {
        ArrayList allsubview = new ArrayList();
        public static ArrayList allclient = new ArrayList();                                     // 所有的客户端
        public static double[] wendu = new double[400];                            /// 保存400号温度
                                                                                   /// 
        public static double[] shengwenwendu = new double[400];                   // 400个升温温度
        public static int[] shengwenshijian = new int[400];                       // 400个升温时间
        public static int[] jiangwenshijian = new int[400];                       // 400个降温时间
        public static int[] daojishi = new int[400];
        public static int[] duanhao = new int[400];
        public static int[] zhuangtai = new int[400];
        public static bool[] start_is = new bool[400];                           // 开始记录
        public static bool[] stop_is = new bool[400];                            // 结束记录
        
        public static bool[] connect_is = new bool[400];                         // 是否能讯上
        public static int[] connect_time_out = new int[400];                     // 通讯超时

        public static bool[] chuanganqi_connect_is = new bool[400];              // 传感器是否连接上

                                                                                   
        public Form1()
        {
            InitializeComponent();
            ViewCaoZuo.Max_Form(this);
            ViewCaoZuo.Object_Position(0.94, 0.05, 0.05, 0.04, button_exit, this.Controls);
            ViewCaoZuo.Object_Position(0.94, 0.10, 0.05, 0.04, button1, this.Controls);
            ViewCaoZuo.Object_Position(0.94, 0.15, 0.05, 0.04, button2, this.Controls);
            ViewCaoZuo.Object_Position(0.94, 0.20, 0.05, 0.04, button3, this.Controls);
            ViewCaoZuo.Object_Position(0.94, 0.25, 0.05, 0.04, button4, this.Controls);



            // 换页

            allsubview.Clear();
            for (int i = 1; i <= 16; i++)
            {
                SubView subview = new SubView();
                subview.Set_Machine_Num(i);
                ViewCaoZuo.Object_Position(0.01 + (i - 1) % 4 * 0.2, 0.05 + (i - 1) / 4 * 0.2, 0.19, 0.19, subview, this.Controls);
                allsubview.Add(subview);
            }

           /// 建立数个ip客户端，用以连接
           /// 
            for (int i = 1; i < 100; i++)
            {
                try
                {
                    string address_string = SubView.inifile.IniReadValue("station_ip",i.ToString());
                    IPAddress ip = IPAddress.Parse(address_string);
                    TcpServerClient client = new TcpServerClient(address_string, 8880);
                    allclient.Add(client);
                    client.Data_Arrival_Event += new EventHandler(DataArrival);
                }
                catch { }
            }


        }

        private void DataArrival(object sender,EventArgs e)
        {
            TcpServerClient client = (TcpServerClient)sender;
            string data_string = "";
            for (int i = 0; i < client.receive_num; i++)
            {
                data_string = data_string + " " + client.receive_byte[i].ToString("X").PadLeft(2,'0');
            }

            /// 判断来的数据是哪里来的数据
            /// 

           // 温度数据
            for (int i = 1; i < 100; i++)
            {
                string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                if (address_string == client.ServerIp.ToString())
                {
                    connect_time_out[i] = 0;
                }
            }
            if (client.receive_num == 17)
            {
                if (client.receive_byte[0] == 0x02 && client.receive_byte[1] == 0x03 && client.receive_byte[2] == 0x00 && client.receive_byte[3] == 0x00 && client.receive_byte[4] == 0x00 && client.receive_byte[5] == 0x02 && client.receive_byte[6] == 0xc4 && client.receive_byte[7] == 0x38)
                {
                    
                    // B口来的数据
                    for (int i = 1; i < 100; i++)
                    {
                        string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "B")
                        {
                            chuanganqi_connect_is[i] = true;
                            float wendu_mul_10 = client.receive_byte[11] * 256 + client.receive_byte[12];
                            wendu[i] = wendu_mul_10 / 10;
                            connect_time_out[i] = 0;
                        }
                    }
                }
                if (client.receive_byte[0] == 0x01 && client.receive_byte[1] == 0x03 && client.receive_byte[2] == 0x00 && client.receive_byte[3] == 0x00 && client.receive_byte[4] == 0x00 && client.receive_byte[5] == 0x02 && client.receive_byte[6] == 0xc4 && client.receive_byte[7] == 0x0b)
                {
                    
                    // A口来的数据
                    for (int i = 1; i < 100; i++)
                    {
                        string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "A")
                        {
                            chuanganqi_connect_is[i] = true;
                            double wendu_mul_10 = client.receive_byte[11] * 256 + client.receive_byte[12];
                            wendu[i] = wendu_mul_10 / 10;
                            connect_time_out[i] = 0;
                        }
                    }
                }
            }

            if(client.receive_num==8)
            {
                if (client.receive_byte[0] != 0xff)
                {
                    for (int i = 1; i < 100; i++)
                    {
                        string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "A" && client.receive_byte[0] == 01)
                        {
                            chuanganqi_connect_is[i] = false;
                            connect_time_out[i] = 0;
                        }
                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "B" && client.receive_byte[0] == 02)
                        {
                            chuanganqi_connect_is[i] = false;
                            connect_time_out[i] = 0;
                        }
                    }
                }
            }

            // 其他数据
            if (client.receive_num == 17)
            {
                if (client.receive_byte[0] == 0xff)
                {
                    for (int i = 1; i < 100; i++)
                    {
                        string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "A")
                        {
                            // 发送开始与停止信息
                            
                            if(start_is[i]==true)
                            {
                                string ip = SubView.inifile.IniReadValue("station_ip", i.ToString());
                                foreach (TcpServerClient myclient in Form1.allclient)
                                {
                                    if (client.ServerIp.ToString() == ip)
                                    {
                                        //byte[] send_byte = new byte[3];
                                        //send_byte[0] = 0xFF;
                                        //send_byte[1] = 0xff;
                                        //send_byte[2] = 0xff;
                                        //myclient.Send_Data(send_byte);
                                        connect_time_out[i] = 0;
                                        if(zhuangtai[i]==1)
                                        {
                                            start_is[i] = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (stop_is[i] == true)
                            {
                                string ip = SubView.inifile.IniReadValue("station_ip", i.ToString());
                                foreach (TcpServerClient myclient in Form1.allclient)
                                {
                                    if (client.ServerIp.ToString() == ip)
                                    {
                                        //byte[] send_byte = new byte[3];
                                        //send_byte[0] = 0xF0;
                                        //send_byte[1] = 0xf0;
                                        //send_byte[2] = 0xf0;
                                        //myclient.Send_Data(send_byte);
                                        connect_time_out[i] = 0;
                                        if (zhuangtai[i] == 0)
                                        {
                                            stop_is[i] = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            float wendu = client.receive_byte[1];
                            shengwenwendu[i] = wendu / 10;
                            shengwenshijian[i] = client.receive_byte[2];
                            jiangwenshijian[i] = client.receive_byte[3];
                            daojishi[i] = client.receive_byte[4]*3600+client.receive_byte[5]*60+client.receive_byte[6];
                            if (daojishi[i] != 0) Console.WriteLine(daojishi[i].ToString());
                            duanhao[i] = client.receive_byte[7];
                            zhuangtai[i] = client.receive_byte[8];

                        }
                        if (address_string == client.ServerIp.ToString() && SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "B")
                        {
                            //chuanganqi_connect_is[i] = true;
                            if (start_is[i] == true)
                            {
                                string ip = SubView.inifile.IniReadValue("station_ip", i.ToString());
                                foreach (TcpServerClient myclient in Form1.allclient)
                                {
                                    if (client.ServerIp.ToString() == ip)
                                    {
                                        //byte[] send_byte = new byte[3];
                                        //send_byte[0] = 0xEF;
                                        //send_byte[1] = 0xEf;
                                        //send_byte[2] = 0xEf;
                                        //myclient.Send_Data(send_byte);
                                        //start_is[i] = false;
                                        connect_time_out[i] = 0;
                                        if (zhuangtai[i] == 1)
                                        {
                                            start_is[i] = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (stop_is[i] == true)
                            {
                                string ip = SubView.inifile.IniReadValue("station_ip", i.ToString());
                                foreach (TcpServerClient myclient in Form1.allclient)
                                {
                                    if (client.ServerIp.ToString() == ip)
                                    {
                                        //byte[] send_byte = new byte[3];
                                        //send_byte[0] = 0xE0;
                                        //send_byte[1] = 0xE0;
                                        //send_byte[2] = 0xE0;
                                        //myclient.Send_Data(send_byte);
                                        //stop_is[i] = false;
                                        connect_time_out[i] = 0;
                                        if (zhuangtai[i] == 0)
                                        {
                                            stop_is[i] = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            float wendu = client.receive_byte[9];
                            shengwenwendu[i] = wendu / 10;
                            shengwenshijian[i] = client.receive_byte[10];
                            jiangwenshijian[i] = client.receive_byte[11];
                            daojishi[i] = client.receive_byte[12] * 3600 + client.receive_byte[13] * 60 + client.receive_byte[14];
                            if (daojishi[i] != 0) Console.WriteLine(daojishi[i].ToString());
                            duanhao[i] = client.receive_byte[15];
                            zhuangtai[i] = client.receive_byte[16];

                        }
                    }
                }
            }
            Console.WriteLine(data_string);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set_Page(1);
        }

        private void Set_Page(int page)
        {
            for (int i = 0; i < allsubview.Count; i++)
            {
                SubView subview = (SubView)allsubview[i];
                subview.Set_Machine_Num((page - 1) * 16 + i + 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Set_Page(2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                 string address_string = SubView.inifile.IniReadValue("station_ip", i.ToString());

                 if (SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "A")
                 {
                     if (start_is[i] == true)
                     {
                         foreach (TcpServerClient myclient in Form1.allclient)
                         {
                             if (myclient.ServerIp.ToString() == address_string)
                             {
                                 byte[] send_byte = new byte[3];
                                 send_byte[0] = 0xFF;
                                 send_byte[1] = 0xff;
                                 send_byte[2] = 0xff;
                                 myclient.Send_Data(send_byte);
                                 Console.WriteLine(myclient.ServerIp+"发送开始！");
                                 break;
                             }
                         }
                     }
                     if (stop_is[i] == true)
                     {
                         foreach (TcpServerClient myclient in Form1.allclient)
                         {
                             if (myclient.ServerIp.ToString() == address_string)
                             {
                                 byte[] send_byte = new byte[3];
                                 send_byte[0] = 0xF0;
                                 send_byte[1] = 0xf0;
                                 send_byte[2] = 0xf0;
                                 myclient.Send_Data(send_byte);
                                 Console.WriteLine(myclient.ServerIp + "发送结束！");
                                 break;
                             }
                         }
                     }

                 }
                 if (SubView.inifile.IniReadValue("station_chuanganqi", i.ToString()) == "B")
                 {
                     if (start_is[i] == true)
                     {
                         foreach (TcpServerClient myclient in Form1.allclient)
                         {
                             if (myclient.ServerIp.ToString() == address_string)
                             {
                                 byte[] send_byte = new byte[3];
                                 send_byte[0] = 0xEF;
                                 send_byte[1] = 0xef;
                                 send_byte[2] = 0xef;
                                 myclient.Send_Data(send_byte);
                                 Console.WriteLine(myclient.ServerIp + "发送开始！");
                                 break;
                             }
                         }
                     }
                     if (stop_is[i] == true)
                     {
                         foreach (TcpServerClient myclient in Form1.allclient)
                         {
                             if (myclient.ServerIp.ToString() == address_string)
                             {
                                 byte[] send_byte = new byte[3];
                                 send_byte[0] = 0xE0;
                                 send_byte[1] = 0xE0;
                                 send_byte[2] = 0xe0;
                                 myclient.Send_Data(send_byte);
                                 Console.WriteLine(myclient.ServerIp + "发送结束！");
                                 break;
                             }
                         }
                     }
                 }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < 400; i++)
            {
                if(connect_time_out[i]<=10)
                    connect_time_out[i]++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Set_Page(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Set_Page(4);
        }
    }
}
