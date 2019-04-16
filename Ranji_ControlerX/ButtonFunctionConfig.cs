using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX
{
    public partial class ButtonFunctionConfig : Form
    {
        public string mybuttonname = "";
        public ButtonFunctionConfig(string buttonname)
        {
            InitializeComponent();
            mybuttonname = buttonname;
            comboBox_function.Items.Clear();
            comboBox_function.Items.Add("数据设定");
            comboBox_function.Items.Add("页面切换");
            comboBox_function.Items.Add("刷新本页面");
            comboBox_function.Items.Add("刷新控件");
            Reflush_function_table();

            All_Hide();
        }

        private void All_Hide()
        {
            label_value1.Visible = false;
            label_value2.Visible = false;
            label_value3.Visible = false;
            label_value4.Visible = false;
            label_value5.Visible = false;
            label_value6.Visible = false;
            label_value7.Visible = false;
            label_value8.Visible = false;
            label_value9.Visible = false;
            label_value10.Visible = false;

            comboBox_value1.Visible = false;
            comboBox_value1.Text = "";

            comboBox_value2.Visible = false;
            comboBox_value2.Text = "";

            comboBox_value3.Visible = false;
            comboBox_value3.Text = "";

            comboBox_value4.Visible = false;
            comboBox_value4.Text = "";

            comboBox_value5.Visible = false;
            comboBox_value5.Text = "";

            comboBox_value6.Visible = false;
            comboBox_value6.Text = "";

            comboBox_value7.Visible = false;
            comboBox_value7.Text = "";

            comboBox_value8.Visible = false;
            comboBox_value8.Text = "";

            comboBox_value9.Visible = false;
            comboBox_value9.Text = "";

            comboBox_value10.Visible = false;
            comboBox_value10.Text = "";
        }

        private void Show_All()
        {
            label_value1.Visible = true;
            label_value2.Visible = true;
            label_value3.Visible = true;
            label_value4.Visible = true;
            label_value5.Visible = true;
            label_value6.Visible = true;
            label_value7.Visible = true;
            label_value8.Visible = true;
            label_value9.Visible = true;
            label_value10.Visible = true;

            comboBox_value1.Visible = true;
            comboBox_value2.Visible = true;
            comboBox_value3.Visible = true;
            comboBox_value4.Visible = true;
            comboBox_value5.Visible = false;
            comboBox_value6.Visible = false;
            comboBox_value7.Visible = false;
            comboBox_value8.Visible = false;
            comboBox_value9.Visible = false;
            comboBox_value10.Visible = false;
        }

        private void comboBox_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            All_Hide();
            if(comboBox_function.Text=="数据设定")
            {
                comboBox_value1.Visible = true;
                comboBox_value2.Visible = true;

                label_value1.Visible = true;
                label_value2.Visible = true;

                label_value1.Text = "数据名称";
                label_value2.Text = "给定值";


                // 给数据名称加值
                comboBox_value1.Items.Clear();

                DataTable data_dt = MainView.Main_DataBase_Builder.Select_Table("AllData");
                foreach (DataRow dr in data_dt.Rows)
                {
                    comboBox_value1.Items.Add(dr[0].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 新增一条
            if (comboBox_function.Text == "") { MessageBox.Show("此项不能为空！"); return; }
            string[] insert_cmd = new string[12];
            insert_cmd[0] = "f"+DateTime.Now.ToString("yyyyMMddHHmmss");
            insert_cmd[1] = comboBox_function.Text;
            insert_cmd[2] = comboBox_value1.Text;
            insert_cmd[3] = comboBox_value2.Text;
            insert_cmd[4] = comboBox_value3.Text;
            insert_cmd[5] = comboBox_value4.Text;
            insert_cmd[6] = comboBox_value5.Text;
            insert_cmd[7] = comboBox_value6.Text;
            insert_cmd[8] = comboBox_value7.Text;
            insert_cmd[9] = comboBox_value8.Text;
            insert_cmd[10] = comboBox_value9.Text;
            insert_cmd[11] = comboBox_value10.Text;
            MainView.Main_DataBase_Builder.Insert(mybuttonname,insert_cmd);
            Reflush_function_table();
        }

        private void Reflush_function_table()
        {
            DataTable function_table = MainView.Main_DataBase_Builder.Select_Table(mybuttonname);
            if (function_table == null)
            {
                dataGridView1.RowCount = 1;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1[i, 0].Value = "";
                }
                return;
            }
            if (function_table.Rows.Count==0)
            {
                dataGridView1.RowCount = 1;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1[i, 0].Value = "";
                }
                return;
            }

            dataGridView1.RowCount = function_table.Rows.Count;
            for (int i = 0; i < function_table.Rows.Count; i++)
            {
                for (int j = 0; j < function_table.Columns.Count; j++)
                {
                    dataGridView1[j, i].Value = function_table.Rows[i][j].ToString();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int selecte_index = dataGridView1.SelectedCells[0].RowIndex;
            if(selecte_index>=0)
            {
                comboBox_function.Text = dataGridView1[1, selecte_index].Value.ToString();
                comboBox_value1.Text = dataGridView1[2, selecte_index].Value.ToString();
                comboBox_value2.Text = dataGridView1[3, selecte_index].Value.ToString();
                comboBox_value3.Text = dataGridView1[4, selecte_index].Value.ToString();
                comboBox_value4.Text = dataGridView1[5, selecte_index].Value.ToString();
                comboBox_value5.Text = dataGridView1[6, selecte_index].Value.ToString();
                comboBox_value6.Text = dataGridView1[7, selecte_index].Value.ToString();
                comboBox_value7.Text = dataGridView1[8, selecte_index].Value.ToString();
                comboBox_value8.Text = dataGridView1[9, selecte_index].Value.ToString();
                comboBox_value9.Text = dataGridView1[10, selecte_index].Value.ToString();
                comboBox_value10.Text = dataGridView1[11, selecte_index].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selecte_index = dataGridView1.SelectedCells[0].RowIndex;
            if (selecte_index >= 0)
            {
                string key = dataGridView1[0, selecte_index].Value.ToString();
                string[] update_cmd = new string[11];
                string where_cmd = "functionkey='" + dataGridView1[0,selecte_index].Value.ToString() + "'";
                update_cmd[0] = "myfunction='" + comboBox_function.Text + "'";
                update_cmd[1] = "Value1='" + comboBox_value1.Text + "'";
                update_cmd[2] = "Value2='" + comboBox_value2.Text + "'";
                update_cmd[3] = "Value3='" + comboBox_value3.Text + "'";
                update_cmd[4] = "Value4='" + comboBox_value4.Text + "'";
                update_cmd[5] = "Value5='" + comboBox_value5.Text + "'";
                update_cmd[6] = "Value6='" + comboBox_value6.Text + "'";
                update_cmd[7] = "Value7='" + comboBox_value7.Text + "'";
                update_cmd[8] = "Value8='" + comboBox_value8.Text + "'";
                update_cmd[9] = "Value9='" + comboBox_value9.Text + "'";
                update_cmd[10] = "Value10='" + comboBox_value10.Text + "'";
                MainView.Main_DataBase_Builder.Updata(mybuttonname, where_cmd, update_cmd);

            }
            Reflush_function_table();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             int selecte_index = dataGridView1.SelectedCells[0].RowIndex;
             if (selecte_index >= 0)
             {
                
                 string key = dataGridView1[0, selecte_index].Value.ToString();
                 string where_cmd = "functionkey='" + key + "'";
                 MainView.Main_DataBase_Builder.Delete(mybuttonname, where_cmd);
             }
             Reflush_function_table();
        }
    }
}
