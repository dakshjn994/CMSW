using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Profile : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Email"]!=null && Session["Name"]!=null)
        {
            string email1 = (string)Session["Email"];
            email.InnerText = email1;
            string name1 = (string)Session["Name"];
            name.InnerText = name1;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Mobile_No,Customer_address From Customer Where Customer_email_id=@Customer";
            cmd.Parameters.AddWithValue("@Customer",email1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                number.InnerText=Convert.ToString(dr["Mobile_No"]);
                address.InnerText = (string)dr["Customer_address"];
            }
            con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandText = "Select Time From History Where Customer_Email=@Customer";
            cmd1.Parameters.AddWithValue("@Customer", email1);
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            con.Close();
            DataList1.DataSource = dt1;
            DataList1.DataBind();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}