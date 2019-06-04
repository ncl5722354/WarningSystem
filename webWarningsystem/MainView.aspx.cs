using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webWarningsystem
{
    public partial class MainView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            mainpage view = new mainpage();
            string name = "mainpage.ascx";
            Show_View(view,name);
        }

        private void Show_View(UserControl mypage,string myname)
        {
            UserControl c1 = (UserControl)base.LoadControl(myname);
            
            c1.ID = "User1";
           // c1.Rufresh();
            this.Panel1.Controls.Clear();
            this.Panel1.Controls.Add(c1);
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ChaFenChaxun view = new ChaFenChaxun();
            string name = "ChaFenChaxun.ascx";
            Show_View(view, name);
        }
    }
}