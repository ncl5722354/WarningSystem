using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealPhotonics
{
    public partial class DataShow : Form
    {
        string show_cmd = "";
        bool show_data = false;

        public DataShow()
        {
            InitializeComponent();
            MainView.client.Data_Arrival_Event += new EventHandler(Data_Arrival_Show);
        }

        private void Data_Arrival_Show(object sender,EventArgs e)
        {
            byte[] receive_byte = MainView.client.receive_byte;
            int data_length=MainView.client.receive_num;
            int start_index = 0;
            int end_index = 0;
            string get_cmd = Encoding.Default.GetString(receive_byte);
            int show_num = 0;
            for (int i = 0; i < data_length;i++)
            {
                if(receive_byte[i]==0)
                {
                     // 用\0作分割
                    end_index = i;
                    string this_cmd = get_cmd.Substring(start_index, end_index - start_index);
                    show_cmd = show_cmd + this_cmd + "\n";
                    show_num++;
                    if (show_num >= 10)
                    {
                        show_num = 0;
                        show_cmd = "";          //最多显示十条，显示超过十条清屏
                    }
                    start_index = i + 1;
                    
                }
            }
            try
            {
                if (show_data == true)
                {
                    richTextBox1.Invoke(new EventHandler(delegate { richTextBox1.Text = show_cmd; }));
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            show_cmd = "";
            richTextBox1.Text = show_cmd;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                show_data = true;
            }
            else
            {
                show_data = false;
            }
        }

        private void DataShow_Load(object sender, EventArgs e)
        {
            
        }
    }
}
