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
    public partial class ButtonConfig : Form
    {
        // 按钮传送进来的属性
        public static string ButtonName;
        public static string ButtontTxt;
        public static string ButtonLeft;
        public static string ButtonTop;
        public static string ButtonWidth;
        public static string ButtonHeight;
        public static string BackColor;
        public static string Font;
        public static string FontSize;
        public static string FontColor;

        public ButtonConfig()
        {
            InitializeComponent();

            comboBox_fontsize.Items.Clear();
            for (int i = 1; i <= 50;i++)
            {
                comboBox_fontsize.Items.Add(i.ToString());
            }
            textBox_name.Text = ButtonName;
            textBox_txt.Text = ButtontTxt;
            textBox_left.Text = ButtonLeft;
            textBox_top.Text = ButtonTop;
            textBox_width.Text = ButtonWidth;
            textBox_height.Text = ButtonHeight;
            label_background.BackColor = Color.FromName(BackColor);
            comboBox_font.Text = Font;
            comboBox_fontsize.Text = FontSize;
            label_fontcolor.BackColor = Color.FromName(FontColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text.Trim() == "") { MessageBox.Show("按钮名称不能为空！"); return; }
            if (textBox_left.Text.Trim() == "") { MessageBox.Show("按钮左侧属性不能为空！"); return; }
            if (textBox_top.Text.Trim() == "") { MessageBox.Show("按钮上侧属性不能为空！"); return; }
            if (textBox_width.Text.Trim() == "") { MessageBox.Show("按钮宽度属性不能为空！"); return; }
            if (textBox_height.Text.Trim() == "") { MessageBox.Show("按钮高度属性不能为空！"); return; }
            if (comboBox_fontsize.Text.Trim() == "") { MessageBox.Show("字符大小不能为空！"); return; }

            ButtonName = textBox_name.Text;
            ButtontTxt = textBox_txt.Text;
            ButtonLeft = textBox_left.Text;
            ButtonTop = textBox_top.Text;
            ButtonWidth = textBox_width.Text;
            ButtonHeight = textBox_height.Text;
            BackColor = label_background.BackColor.Name;
            FontSize = comboBox_fontsize.Text;
            FontColor = label_fontcolor.BackColor.Name;

            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label_background_Click(object sender, EventArgs e)
        {
            tools.ColorConfig view = new tools.ColorConfig();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                label_background.BackColor = System.Drawing.Color.FromName(tools.ColorConfig.Selected_Color);
            }
        }

        private void label_fontcolor_Click(object sender, EventArgs e)
        {
            tools.ColorConfig view = new tools.ColorConfig();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                label_fontcolor.BackColor = System.Drawing.Color.FromName(tools.ColorConfig.Selected_Color);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打开功能设定
            ButtonFunctionConfig view = new ButtonFunctionConfig(ButtonName);
            view.ShowDialog();
        }
    }
}
