using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileOperation;
using String_Caozuo;
using System.Collections;
using System.IO;
using System.Text;
using SqlConnect;
using System.Threading;

namespace update
{
    public partial class Form1 : Form
    {
        bool isupdate = false;
        SQL_Connect_Builder builder = new SQL_Connect_Builder(".", "saigedata", 1, 1000);

        int wenjian = 0;
        int wenjianzong = 0;
        int shuju = 0;
        int shujuzong = 0;
        public Form1()
        {
            InitializeComponent();
            CreateSqlValueType[] create_cmd = new CreateSqlValueType[2];
            create_cmd[0] = new CreateSqlValueType("nvarchar(50)", "mykey", true);
            create_cmd[1] = new CreateSqlValueType("nvarchar(50)","num");
            builder.Create_Table("tiaonum", create_cmd);


            string[] inser_cmd = new string[2];
            inser_cmd[0] = "mynum";
            inser_cmd[1] = "0";
            builder.Insert("tiaonum", inser_cmd);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread mythread = new Thread(thread);
            mythread.Start();
        }

        private void thread()
        {
            if (isupdate == false)
                isupdate = true;
            else
                return;
            ArrayList list = FileCaozuo.Read_All_Files("D://data//", "*.txt");


            int count = 0;
            try
            {
                string where_cmd = "mykey='mynum'";
                DataTable dt= builder.Select_Table("tiaonum", where_cmd);
                count = int.Parse(dt.Rows[0][1].ToString());
            }
            catch { }

            for (int i = count; i < list.Count; i++)
            {
                CreateSqlValueType[] create_cmd = new CreateSqlValueType[2];
                create_cmd[0] = new CreateSqlValueType("float","pos",true);
                create_cmd[1] = new CreateSqlValueType("float", "value");

                string name = (string)list[i];
                string filename = string_caozuo.Get_Dian_String(name, 1);
                builder.Create_Table("data" + string_caozuo.Get_HengGang_String(filename, 1) + string_caozuo.Get_HengGang_String(filename, 2), create_cmd);

                wenjian = i;
                wenjianzong = list.Count;


                string mywhere_cmd = "mykey='mynum'";
                string[] update_cmd = new string[1];
                update_cmd[0] = "num='" + i.ToString() + "'";

                builder.Updata("tiaonum", mywhere_cmd, update_cmd);

                // 读取全部数据
                string[] jizhun_list = FileCaozuo.Read_All_Line("D:\\data\\" + name);
                for(int j=0;j<jizhun_list.Length;j++)
                {
                    try
                    {
                        shuju = j;
                        shujuzong = jizhun_list.Length;
                        string pos = string_caozuo.Get_Table_String(jizhun_list[j], 1);
                        string value = string_caozuo.Get_Table_String(jizhun_list[j], 2);

                       


                        string[] insert_cmd = new string[2];
                        insert_cmd[0] = pos;
                        insert_cmd[1] = value;
                        bool result=  builder.Insert("data"+string_caozuo.Get_HengGang_String(filename,1)+string_caozuo.Get_HengGang_String(filename,2),insert_cmd);
                    }
                    catch { }
                }

            }
            isupdate = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = wenjian.ToString() + "/" + wenjianzong.ToString();
            label4.Text = shuju.ToString() + "/" + shujuzong.ToString();
        }
    }
}
