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

namespace RealPhotonics
{
    public partial class ADDLine : Form
    {
        public static string ID = "";
        public static int start_x = 0;
        public static int start_y = 0;
        public static int end_x = 0;
        public static int end_y = 0;
        public static int start_value = 0;
        public static int end_value = 0;
        public static string kind = "";
        public static string voice = "";
        public ADDLine()
        {
            InitializeComponent();
            Show_Voice();
            label_ID.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            comboBox_warning_type.Items.Add("行人");
            comboBox_warning_type.Items.Add("攀爬");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = label_ID.Text;
            try
            {
                start_x = int.Parse(textBox_startX.Text);
                start_y = int.Parse(textBox_startY.Text);
                end_x = int.Parse(textBox_endX.Text);
                end_y = int.Parse(textBox_endY.Text);
                start_value = int.Parse(textBox_startvalue.Text);
                end_value = int.Parse(textBox_endvalue.Text);
                kind = comboBox_warning_type.Text;
                voice = comboBox_voice.Text;
            }
            catch
            {
                MessageBox.Show("输入有误！");
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void ADDLine_Load(object sender, EventArgs e)
        {

        }

        private void Show_Voice()
        {
            string path = System.Environment.CurrentDirectory + "\\voice";
            FileCaozuo.Read_All_Files_Show_ComboBox(path, "*.wav", comboBox_voice);
        }
    }
}
