using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Admin_AdminMaster : System.Web.UI.MasterPage
{
    string[] fname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] != null)
        {
            string name = (string)(Session["Name"]);
            fname = name.Split(' ');
            NAME.Visible = true;
            NAME.InnerText = "Welcome Mr." + fname[1];
            Logout.Visible = true;
        }
        else
        {
            Logout.Visible = false;
            NAME.Visible = false;
            Response.Redirect("Main.aspx");
        }
        if(fname[0]!="Admin")
        {
            Response.Redirect("Main.aspx");
        }
    }
    protected void NAME_ServerClick(object sender, EventArgs e)
    {
        Session["Name"] = null;
        Session["Email"] = null;
        Response.Redirect("Main.aspx");
    }
}