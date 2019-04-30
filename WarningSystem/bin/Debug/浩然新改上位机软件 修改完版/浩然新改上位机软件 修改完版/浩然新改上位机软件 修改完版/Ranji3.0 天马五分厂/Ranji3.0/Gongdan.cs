using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ranji3._0
{
    public partial class Gongdan : Form
    {
        public static string gongdanhao = "";
        public Gongdan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gongdanhao = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
