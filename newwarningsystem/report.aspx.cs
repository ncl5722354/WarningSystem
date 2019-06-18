using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
namespace newwarningsystem
{
    public partial class report : System.Web.UI.Page
    {
        //DataSet ds = new DataSet(); 

        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            user_Chart();
        }

        public void user_Chart()
        {

            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("1", dt));
        }

        protected void ImageButton_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MainMap.aspx");
        }
    }
}