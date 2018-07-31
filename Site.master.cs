using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Site : System.Web.UI.MasterPage
{
    int n;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cart"]!=null)
        { 
        DataTable dt=Session["Cart"] as DataTable;
        n=dt.Rows.Count;
        lblCartValue.Text = "(" + n + ")";
        }
        NAME.Visible = true;
        Administrator.Visible = false;
        if (Page.Title == "Recovery" || Page.Title=="Order")
        {
            header.Visible = false;
        }
        if(Page.Title=="Bill")
        {
            Session["Cart"] = null;
            
        }
        /*if(Page.Title=="Register"||Page.Title=="Login"||Page.Title=="Cart"||Page.Title=="Forgot Password"||Page.Title=="Recovery")
        {
            Image1.Visible = false;
        }*/
        if(Session["Name"]!=null)
        {
            Approval.Visible = true;
            error.Visible = true;
            string name=(string)(Session["Name"]);
            string[] fname=name.Split(' ');
            Logout.Visible = true;
            NAME.Visible = true;
            NAME.InnerText ="Welcome "+fname[1].ToString()+" "+fname[3].ToString();
            if(fname[0]=="Admin")
            {
                Administrator.Visible = true;
                Main.Visible = false;
                Cart.Visible = false;
                Approval.Visible = false;
                NAME.HRef = "/Webpages/Products.aspx";
            }
            Login.Visible = false;
            Register.Visible = false;
        }
        else
        {
            error.Visible = false;
            Approval.Visible = false;
            Logout.Visible = false;
            NAME.Visible = false;
            NAME.InnerText = null;
            Login.Visible = true;
            Register.Visible = true;
        }
    }
    protected void NAME_ServerClick(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("/Webpages/Login.aspx"); 
    }
}