using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace newwarningsystem
{
    public partial class MainMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Imagemap_DataBinding(object sender, EventArgs e)
        {

        }

        protected void Image_point4_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 602;
            zhuziview.end1 = 638;
            zhuziview.start2 = 638;
            zhuziview.end2 = 674;
            //view.Set_Start_End(602, 675, 0, 0);
            //Response.Redirect(view.GetRouteUrl());
            Response.Redirect("zhuziview.aspx");
            
        }

        protected void Image_point5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point7_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("zhuziview.aspx");
        }
    }
}