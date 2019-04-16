using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranji_ControlerX.NormalControls
{
    public partial class NormalLabelConfig : Form
    {
        public static string Label_Name;
        public static string Label_Txt;
        public static int Label_Left;
        public static int Label_Top;
        public static int Label_Width;
        public static int Label_Height;
        public static string BackColor;
        public static string MyFont;
        public static int MyFontSize;
        public static string FontColor;
        public static string LabelType;                                        // 标签的种类

        public static string DataType;
        public static string Machine_num;
        public static string offsite;
        public static string ValueAddress;
        
        public NormalLabelConfig(string labeltype)
        {
            InitializeComponent();


            ///实始化 字体大小的下拉菜单
            ///
            for (int i = 3; i <= 45;i++)
            {
                comboBox_FontSize.Items.Add(i.ToString());
            }

            LabelType = labeltype;       
            
            textBox_Name.Text = Label_Name;
            textBox_txt.Text = Label_Txt;
            textBox_left.Text = Label_Left.ToString();
            textBox_top.Text = Label_Top.ToString();
            textBox_width.Text = Label_Width.ToString();
            textBox_height.Text = Label_Height.ToString();
            label_BackColor.BackColor = System.Drawing.Color.FromName(BackColor);

            if (labeltype == "ValueLabel")
            {
                comboBox_datatype.Items.Add("整型");
                comboBox_datatype.Items.Add("浮点型");
                comboBox_datatype.Items.Add("字符串");
            }

            comboBox_FontSize.Text = MyFontSize.ToString();
            label_FontColor.BackColor = System.Drawing.Color.FromName(FontColor);

            try
            {
                if(labeltype=="ValueLabel")
                {
                    string where_cmd = "labelname='" + Label_Name + "'";
                    DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllValuelabel",where_cmd);
                    DataRow dr=dt.Rows[0];
                    comboBox_datatype.Text = dr[10].ToString();
                    textBox_machinenum.Text = dr[11].ToString();
                    comboBox_offsite.Text = dr[12].ToString();
                    textBox_value_address.Text = dr[13].ToString();
                }
            }
            catch { }

        }

        public void Set_Normal()
        {
            tabControl1.TabPages.RemoveAt(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///不能有空的
            ///
            try
            {
                if (textBox_Name.Text.Trim() == "") { MessageBox.Show("标签名为空！"); return; }
                if (comboBox_FontSize.Text.Trim() == "") { MessageBox.Show("标签名为空！"); return; }

                Label_Name = textBox_Name.Text.Trim();
                Label_Txt = textBox_txt.Text.Trim();
                Label_Left = int.Parse(textBox_left.Text);
                Label_Top = int.Parse(textBox_top.Text);
                Label_Width = int.Parse(textBox_width.Text);
                Label_Height = int.Parse(textBox_height.Text);
                BackColor = label_BackColor.BackColor.Name;
                MyFontSize = int.Parse(comboBox_FontSize.Text);
                FontColor = label_FontColor.BackColor.Name;
                DataType = comboBox_datatype.Text;
                Machine_num = textBox_machinenum.Text;
                offsite = comboBox_offsite.Text;
                ValueAddress = textBox_value_address.Text;

            }
            catch { MessageBox.Show("数据出错！"); return; }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label_BackColor_Click(object sender, EventArgs e)
        {
            tools.ColorConfig view = new tools.ColorConfig();
            DialogResult result = view.ShowDialog();
            if(result==DialogResult.OK)
            {
                label_BackColor.BackColor = System.Drawing.Color.FromName(tools.ColorConfig.Selected_Color);
            }
        }

        private void label_FontColor_Click(object sender, EventArgs e)
        {
            tools.ColorConfig view = new tools.ColorConfig();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                label_FontColor.BackColor = System.Drawing.Color.FromName(tools.ColorConfig.Selected_Color);
            }

        }

        private void NormalLabelConfig_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_datatype_SelectedValueChanged(object sender, EventArgs e)
        {
            string namekey = comboBox_datatype.Items[comboBox_datatype.SelectedIndex].ToString();
            string where = "datatype='" + namekey + "'";
            DataTable dt = MainView.Main_DataBase_Builder.Select_Table("AllData", where);
            comboBox_offsite.Items.Clear();
            comboBox_offsite.Text = "";
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        comboBox_offsite.Items.Add(dr[0].ToString());
                    }
                }
            }
        }
    }
}
