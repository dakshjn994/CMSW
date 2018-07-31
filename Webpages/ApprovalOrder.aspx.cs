using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_ApprovalOrder : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    string no = "no";
    string yes = "yes";
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select * from [Order] Where Approval=@Approval";
        cmd.Parameters.AddWithValue("@Approval",no);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        string id;
        if(b!=null)
        {
            id = (string)b.CommandArgument;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update [Order] Set Approval=@Approval Where Order_Id=@Id";
            cmd.Parameters.AddWithValue("@Approval",yes);
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("ApprovalOrder.aspx");
        }
    }
}