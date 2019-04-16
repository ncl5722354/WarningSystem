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
    public partial class DataAddView : Form
    {
        public DataAddView()
        {
            InitializeComponent();
            comboBox_type.Items.Clear();
            comboBox_type.Items.Add("整型");
            comboBox_type.Items.Add("浮点型");
            comboBox_type.Items.Add("时间型");
            comboBox_type.Items.Add("字符串型");


            // 作用域   作用域分为全局和各个页面
            comboBox_scope.Items.Clear();
            comboBox_scope.Items.Add("全局");

            // 数据源   数据源分为内部数据和外部数据
            comboBox_datasource.Items.Clear();
            comboBox_datasource.Items.Add("内部数据");
            comboBox_datasource.Items.Add("外部数据");



            DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllView");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_scope.Items.Add(dr[0].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "") { MessageBox.Show("数据名称不能为空！"); return; }
            if (comboBox_type.Text.Trim() == "") { MessageBox.Show("数据格式不能为空！"); return; }
            if (comboBox_scope.Text.Trim() == "") { MessageBox.Show("数据作用域不能为空！"); return; }
            if (comboBox_datasource.Text.Trim() == "") { MessageBox.Show("数据源不能为空！"); return; }
            if (textBox_machine_num.Text.Trim() == "") { MessageBox.Show("机号不能为空！"); return; }
            if (textBox_address.Text.Trim() == "") { MessageBox.Show("地址不能为空！"); return; }

            string[] insert_cmd = new string[7];
            insert_cmd[0] = textBox1.Text.Trim();
            insert_cmd[1] = comboBox_type.Text.Trim();
            insert_cmd[2] = comboBox_scope.Text.Trim();
            insert_cmd[3] = "";               // 根据实际情况进行变化
            insert_cmd[4] = comboBox_datasource.Text.Trim();
            insert_cmd[5] = textBox_machine_num.Text.Trim();
            insert_cmd[6] = textBox_address.Text.Trim();

            bool success = MainView.Main_DataBase_Builder.Insert("AllData",insert_cmd);
            if (success == false) { MessageBox.Show("创建数据失败！"); return; }

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DataAddView_Load(object sender, EventArgs e)
        {

        }
    }
}
