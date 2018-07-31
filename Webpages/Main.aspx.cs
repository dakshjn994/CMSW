using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Webpages_Main : System.Web.UI.Page
{
    string id;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Id,Name,Image,Money from Image where Active='yes'";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        ItemList.DataSource = dt;
        ItemList.DataBind();
        con.Close();
    }
    protected void btnCart_Click(object sender, EventArgs e)
    {  
        Button b = sender as Button;
        if(b!=null)
        {
            id = b.CommandArgument;
            int ab = Convert.ToInt32(id);
            DataTable dta = Session["Cart"] as DataTable;
            if(dta!=null)
            {
                foreach(DataRow dr in dta.Rows)
                {
                    int i=(int)dr["Id"];
                    if (ab.Equals(i))
                    {
                        Session["bool"] = "true";
                        break;
                    }
                    Session["bool"] = "false";
                }
                
            }
            else
            {
                Session["bool"] = "false";
            }
            if (Convert.ToString(Session["bool"]).Equals("false"))
            {
                con.Open();
                
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Select Id,Name,Image,Money,Description from Image where Id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session["bool"]=null;
                Session["dtSelectedProduct"] = dt;
                con.Close();
            }
            else
            {
                Session["bool"]=null;
                Session["dtSelectedProduct"] = null;
            }
            Response.Redirect("Cart.aspx");
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if (b != null)
        {
            id = b.CommandArgument;
            Response.Redirect("Details.aspx?Id=" + id);
        }
    }
}