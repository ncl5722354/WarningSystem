using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;

namespace jisuanqi
{
    public partial class Form1 : Form
    {
        private Button button_num1 = new Button();    // 新建按钮1
        private Button button_num2 = new Button();    // 新建按钮2
        private Button button_num3 = new Button();    // 新建按钮3

        private Label show_label = new Label();

        private string show_string = "";
        public Form1()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            //this.BackColor = System.Drawing.Color.FromName("Blue");

            ViewCaoZuo.Object_Position(0.05, 0.01, 0.8, 0.1, show_label, this.Controls);

            button_num1.Text = "1";
            ViewCaoZuo.Object_Position(0.01, 0.2, 0.2, 0.15, button_num1, this.Controls);
            button_num1.Click += new EventHandler(Button1_Click);

            button_num2.Text = "2";
            ViewCaoZuo.Object_Position(0.01+0.3, 0.2, 0.2, 0.15, button_num2, this.Controls);
            button_num2.Click += new EventHandler(Button1_Click);

            button_num3.Text = "3";
            ViewCaoZuo.Object_Position(0.01+0.3*2, 0.2, 0.2, 0.15, button_num3, this.Controls);
            button_num3.Click += new EventHandler(Button1_Click);


        }

        private void Button1_Click(object sender,EventArgs  e)
        {
            Button mylabel = (Button)sender;
            show_string = show_string + mylabel.Text;
            show_label.Text = show_string;
        }

       
    }
}
