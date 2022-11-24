using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reporting_System
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Pre_Render(object sender,EventArgs e)
        {
            //if(Session["RoleId"].ToString() !=null && Session["RoleId"].ToString()!="" )
            //{
            //    String Path = "../Controls/"+ Session["RoleId"].ToString();
            //    Control navigation = (Control)Page.LoadControl(Path + ".ascx");
               
            //    pnlNavigation.Controls.Add(navigation);

            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["RoleId"] != null && Session["RoleId"].ToString() != "")
            //{
            //    String Path = "../Controls/" + Session["RoleId"].ToString();
            //    Control navigation = (Control)Page.LoadControl(Path + ".ascx");

            //    pnlNavigation.Controls.Add(navigation);

            //}
            //else {
            //   // Response.Redirect("~/Login.aspx");
            //}

        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}