using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Approval : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] != null)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Bill_Id,Product_Name,Product_Quantity,Order_Amount from [Order] where Customer_Email=@Customer_Email and Approval=@Approval Order By Bill_Id";
            cmd.Parameters.AddWithValue("@Approval", "yes");
            cmd.Parameters.AddWithValue("@Customer_Email", (string)Session["Email"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SqlCommand scmd = con.CreateCommand();
            scmd.CommandText = "Select Bill_Id,Product_Name,Product_Quantity,Order_Amount from [Order] where Customer_Email=@Customer_Email and Approval=@Approval Order By Bill_Id";
            scmd.Parameters.AddWithValue("@Approval", "no");
            scmd.Parameters.AddWithValue("@Customer_Email", (string)Session["Email"]);
            SqlDataAdapter sda = new SqlDataAdapter(scmd);
            DataTable sdt = new DataTable();
            sda.Fill(sdt);
            GridView2.DataSource = sdt;
            GridView2.DataBind();
            con.Close();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}