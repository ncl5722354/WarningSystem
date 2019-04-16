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
    public partial class SetMachine_num : Form
    {
        public int machine_num = 0;
        public SetMachine_num(int num)
        {
            InitializeComponent();
            machine_num = num;
            string machine_name = SubView.inifile.IniReadValue("station",num.ToString());
            textBox1.Text = machine_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubView.inifile.IniWriteValue("station",machine_num.ToString(),textBox1.Text);
            this.Dispose();
        }
    }
}
