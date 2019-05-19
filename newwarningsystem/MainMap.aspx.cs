using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileOperation;

namespace newwarningsystem
{
    public partial class MainMap : System.Web.UI.Page
    {
        public static IniFile ini = new IniFile("D:\\config\\Map.ini"); 

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
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
            
            
        }

        protected void Image_point5_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 742;
            zhuziview.end1 = 776;
            zhuziview.start2 = 776;
            zhuziview.end2 = 810;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point6_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 875;
            zhuziview.end1 = 907;
            zhuziview.start2 = 907;
            zhuziview.end2 = 939;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void Image_point7_Click(object sender, ImageClickEventArgs e)
        {
            zhuziview.start1 = 994;
            zhuziview.end1 = 1032;
            zhuziview.start2 = 1032;
            zhuziview.end2 = 1069;
            ImageButton mybutton = (ImageButton)sender;
            zhuziview.chafen_title = mybutton.ToolTip;
            Response.Redirect("zhuziview.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Image_point1_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/1.png";
            SubMap.map_name = "一号坡";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2164;
            SubMap.end2 = 2317;
            Response.Redirect("SubMap.aspx");
        }

        protected void Image_point2_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/2.png";
            SubMap.map_name = "二号坡上";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2361;
            SubMap.end2 = 2558;
            Response.Redirect("SubMap.aspx");
        }

        protected void Image_point3_Click(object sender, ImageClickEventArgs e)
        {
            SubMap.pic_uri = "~/Resource/3.png";
            SubMap.map_name = "二号坡下";
            ImageButton mybutton = (ImageButton)sender;
            SubMap.chafen_title = mybutton.ToolTip;
            
            SubMap.start1 = 2934;
            SubMap.end2 = 3074;
            Response.Redirect("SubMap.aspx");
        }
    }
}