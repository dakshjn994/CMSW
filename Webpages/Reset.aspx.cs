using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Reset : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["email"]==null)
        {
            Response.Redirect("Forgot.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update [Customer] SET Customer_password=@pass WHERE Customer_email_id=@email";
            cmd.Parameters.AddWithValue("@pass",TextBox1.Text);
            cmd.Parameters.AddWithValue("@email",(string)Session["email"]);
            cmd.ExecuteNonQuery();
            Session.Clear();
            string var = "Password Change Successful ";
            Response.Write("<script language=javascript>alert('" + var + "');</script>");
            Response.Redirect("Login.aspx");
    }
}