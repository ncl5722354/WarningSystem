using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileOperation;

namespace Ranji2019
{
    /// <summary>
    /// ValueConfig_Item.xaml 的交互逻辑
    /// </summary>
    public partial class ValueConfig_Item : UserControl
    {
        IniFile inifile = null;                     // 数据设置配置文件
        string Value_Name = "";
        public ValueConfig_Item(IniFile ini,string value_name)
        {
            inifile = ini;
            Value_Name = value_name;                // 数据名称
            InitializeComponent();
            mylabel.Content = value_name;

            init_view();
            Read_Config(Value_Name);
        }

        // 画面的初始化
        public void init_view()
        {
            cob_type.Items.Clear();
            cob_type.Items.Add("DT");
            cob_type.Items.Add("R");
        }


        public void Read_Config(string value)
        {
            // 读取配置
            string type = inifile.IniReadValue(Value_Name, "type");

            cob_type.Text = type;

            string address = inifile.IniReadValue(Value_Name,"address");

            txt_address.Text = address;

            //string machine_num = inifile.IniReadValue(Value_Name, "machine_num");

            //txt_machine_num.Text = machine_num;

        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            //inifile.IniWriteValue(Value_Name, "type", cob_type.Text);
            //inifile.IniWriteValue(Value_Name,"address",txt_address.Text);
           

            //for (int i = 1; i <= 100; i++)
            //{
            //    inifile.IniWriteValue(Value_Name + i.ToString(), "type", cob_type.Text);
            //    inifile.IniWriteValue(Value_Name + i.ToString(), "address", txt_address.Text);
            //    inifile.IniWriteValue(Value_Name + i.ToString(), "machine_num", i.ToString());
            //}
        }

        private void btn_ok_Click_1(object sender, RoutedEventArgs e)
        {
            inifile.IniWriteValue(Value_Name, "type", cob_type.Text);
            inifile.IniWriteValue(Value_Name, "address", txt_address.Text);


            for (int i = 1; i <= 100; i++)
            {
                inifile.IniWriteValue(Value_Name + i.ToString(), "type", cob_type.Text);
                inifile.IniWriteValue(Value_Name + i.ToString(), "address", txt_address.Text);
                inifile.IniWriteValue(Value_Name + i.ToString(), "machine_num", i.ToString());
            }
        }
    }
}
