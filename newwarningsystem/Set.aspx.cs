using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;

namespace newwarningsystem
{
    public partial class Set : System.Web.UI.Page
    {
        public static IniFile set_yuzhi = new IniFile("D:\\config\\yuzhi.ini");
        static string value1;
        static string value2;
        static string value3;
        static string value4;
        static string value5;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true)
            {
                set_yuzhi.IniWriteValue("yuzhi", "1", TextBox1.Text);
                set_yuzhi.IniWriteValue("yuzhi", "2", TextBox2.Text);
                set_yuzhi.IniWriteValue("yuzhi", "3", TextBox3.Text);
                set_yuzhi.IniWriteValue("yuzhi", "4", TextBox4.Text);
                set_yuzhi.IniWriteValue("yuzhi", "5", TextBox5.Text);
                Response.Redirect("MainMap.aspx");
            }


            TextBox1.Text = set_yuzhi.IniReadValue("yuzhi", "1");
            TextBox2.Text = set_yuzhi.IniReadValue("yuzhi", "2");
            TextBox3.Text = set_yuzhi.IniReadValue("yuzhi", "3");
            TextBox4.Text = set_yuzhi.IniReadValue("yuzhi", "4");
            TextBox5.Text = set_yuzhi.IniReadValue("yuzhi", "5");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            value1 = TextBox1.Text;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            value2 = TextBox2.Text;
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            value3 = TextBox3.Text;
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            value4 = TextBox4.Text;
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            value5 = TextBox5.Text;
        }
    }
}