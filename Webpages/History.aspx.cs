using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Customer_Email,Login,Time From History where User_Type=@User Order By Login";
        cmd.Parameters.AddWithValue("@User","Customer");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        SqlCommand scmd = con.CreateCommand();
        scmd.CommandText = "Select Customer_Email,Login,Time From History where User_Type=@User Order By Login";
        scmd.Parameters.AddWithValue("@User", "Admin");
        SqlDataAdapter sda = new SqlDataAdapter(scmd);
        DataTable sdt = new DataTable();
        sda.Fill(sdt);
        GridView2.DataSource = sdt;
        GridView2.DataBind();
    }
}