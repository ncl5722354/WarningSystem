using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newwarningsystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label_error.Visible = false;
        }

        protected void Button_ok_Click(object sender, EventArgs e)
        {
            Label_error.Visible = false;
            if(TextBox_username.Text=="admin" && TextBox_password.Text=="admin")
            {
                // 登录成功
                // 切换界面
                //MainMap view = new MainMap();
                Response.Redirect("MainMap.aspx");
            }
            else
            {
                // 登录失败
                Label_error.Visible = true;
                
            }
        }
    }
}