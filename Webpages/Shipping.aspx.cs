using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Webpages_Shipping : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Email"]!=null)
        {

        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = true;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButton2.Checked)
        {
            if (TextBox1.Text == null)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Please Enter Address";
            }
            else
            {
                Session["Add"]=TextBox1.Text;
                Response.Redirect("Order.aspx");
            }
        }
        if(RadioButton1.Checked)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Customer_address from Customer where Customer_email_id=@Customer_email_id";
            cmd.Parameters.AddWithValue("@Customer_email_id", (string)Session["Email"]);
            Session["Add"] = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            Response.Redirect("Order.aspx");
        }
        if(!RadioButton2.Checked && !RadioButton1.Checked)
        {
            Label1.Text = "Please Select an Option";
        }
    }
}