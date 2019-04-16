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
    /// MyLabel.xaml 的交互逻辑
    /// </summary>
    public partial class MyLabel : UserControl
    {
        public string Value_Name = "";                      // 标签的值
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();                    // 更新的时钟
        public int mode = 0;                    // 模式=0：  显示内容
                                                // 模式=1：  显示数字
                                                // 模式=2：  显示数字/10
                                                // 模式=3：  显示对秒计时的时间
                                                // 模式=5:   显示数字+1
        public IniFile inifile = null;
        public MyLabel(IniFile ini)
        {
            InitializeComponent();

            // 设置时钟
            timer.Interval = 300;
            timer.Tick += new EventHandler(Tick);
            timer.Enabled = true;

            inifile = ini;               //配置文件

            ReSet();
        }

        public void Set_Text(string txt)
        {
            mylabel.Content = txt;
        }

        private void Tick(object sender,EventArgs e)
        {
            ReSet();
            // 更新消息
            if (mode == 0)
            {

            }
            if (mode == 1)
            {
                string type = inifile.IniReadValue(Value_Name, "type");
                string address = inifile.IniReadValue(Value_Name,"address");
                string machine_num=inifile.IniReadValue(Value_Name,"machine_num");
                try
                {
                    if(type=="DT")
                    {
                        Set_Text(RealTime_data.DT[int.Parse(machine_num), int.Parse(address)].ToString());
                        return;
                    }
                    Set_Text("??");

                }
                catch { Set_Text("??"); }
            }
             
        }

        public void ReSet()
        {
            mylabel.Margin = new Thickness(0, 0, 0, 0);
            mylabel.Width = this.Width;
            mylabel.Height = this.Height;
            rectangle.Margin = new Thickness(0, 0, 0, 0);
            rectangle.Width = this.Width;
            rectangle.Height = this.Height;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReSet();
        }
    }
}
