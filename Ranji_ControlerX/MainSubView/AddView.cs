using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX.MainSubView
{
    public partial class AddView : Form
    {
        public static string View_Name = "";    //新加入的界面的名字
        public AddView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string view_name = textBox_Name.Text;
            if (view_name.Trim() == "") { MessageBox.Show("画面名不能为空！"); return; }
            else
            {
                View_Name = view_name;
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AddView_Load(object sender, EventArgs e)
        {

        }
    }
}
