using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Webpages_Admin_Customers : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.Visible = false;
        btnHide.Visible = false;
            string s="yes";
            con.Open();
            SqlCommand com = con.CreateCommand();
            SqlCommand cmd = con.CreateCommand();
            com.CommandText = "Select Customer_name,Customer_email_id,Mobile_No,Customer_address from Customer where Active=@Active";
            cmd.CommandText = "Select Customer_name,Customer_email_id,Mobile_No,Customer_address from Customer where Active=@Active";
            com.Parameters.AddWithValue("@Active",s);
            s = "no";
            cmd.Parameters.AddWithValue("@Active",s);
            DataTable dt = new DataTable();
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(data);
            GridView2.DataSource = data;
            GridView2.DataBind();
            con.Close();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button b=sender as Button;
        string email,name;
        if(b!=null)
        {
            email=b.CommandArgument;
            name=b.Text;
            ChangeDetail(name,email);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        string email,name;
        if (b != null)
        {
            email = b.CommandArgument;
            name = b.Text;
            ChangeDetail(name,email);
        }
    }
    protected void ChangeDetail(string name,string email)
    {
        string yes="yes";
        string no="no";
        if(name=="Add")
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update Customer set Active=@Active1 where Active=@Active and Customer_email_id=@Customer_email_id";
            cmd.Parameters.AddWithValue("@Active1",yes);
            cmd.Parameters.AddWithValue("@Active", no);
            cmd.Parameters.AddWithValue("@Customer_email_id",email);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Customers.aspx",false);
        }
        if(name=="Delete")
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update Customer set Active=@Active1 where Active=@Active and Customer_email_id=@Customer_email_id";
            cmd.Parameters.AddWithValue("@Active1", no);
            cmd.Parameters.AddWithValue("@Active", yes);
            cmd.Parameters.AddWithValue("@Customer_email_id",email);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Customers.aspx",false);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        btnHide.Visible = true;
        btnShow.Visible = false;
    }
    protected void btnHide_Click(object sender, EventArgs e)
    {

        GridView2.Visible = false;
        btnHide.Visible = false;
        btnShow.Visible = true;
    }
}