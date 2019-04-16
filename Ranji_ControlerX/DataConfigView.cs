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
    public partial class DataConfigView : Form
    {
        public DataConfigView()
        {
            InitializeComponent();
            Read_Data_Info();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainSubView.DataAddView view = new MainSubView.DataAddView();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                // 确认加入数据
                Read_Data_Info();
            }
        }


        private void Read_Data_Info()
        {
            DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllData");
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.RowCount = 1;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1[j, 0].Value = "";
                    }
                }
                else
                {
                    dataGridView1.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                           // dataGridView1[j+1, i].Value = dt.Rows[i][j].ToString();
                        dataGridView1[0, i].Value = i + 1;
                        dataGridView1[1, i].Value = dt.Rows[i][0].ToString();
                        dataGridView1[2, i].Value = dt.Rows[i][1].ToString();
                        dataGridView1[3, i].Value = dt.Rows[i][2].ToString();
                        dataGridView1[4, i].Value = dt.Rows[i][4].ToString();
                        dataGridView1[5, i].Value = dt.Rows[i][5].ToString();
                        dataGridView1[6, i].Value = dt.Rows[i][6].ToString();
                        
                    }
                }
            }
            else
            {
                dataGridView1.RowCount = 1;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1[j, 0].Value = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells[0].RowIndex == -1) { MessageBox.Show("没有选择要删除的数据项！"); return; }
            string namekey = dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString();
            string where_cmd = "dataname='" + namekey + "'";
            MainView.Main_DataBase_Builder.Delete("AllData", where_cmd);
            Read_Data_Info();
        }
    }
}
