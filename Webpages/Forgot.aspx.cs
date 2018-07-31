using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Forgot : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {  
       txtForgot.Visible = false;
        txtQuestion.Visible = false;
        btnSubmit.Visible = false;
        btnclear.Visible = false;
        question.Visible = false;
        answer1.Visible = false;
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        txtForgot.Text = null;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != null)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Count(*) From Customer Where Customer_email_id=@email";
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            int no = Convert.ToInt32(cmd.ExecuteScalar());
            if (no != null)
            {
                SqlCommand com = con.CreateCommand();
                com.CommandText = "Select Recovery_Questions From Recovery Where Customer_email_id=@email";
                com.Parameters.AddWithValue("@email", txtEmail.Text);
                string a=(string)com.ExecuteScalar();
                txtQuestion.Text = a;
                    txtForgot.Visible = true;
                    txtQuestion.Visible = true;
                    txtEmail.Visible = true;
                    txtEmail.Enabled= false;
                    Button1.Visible = false;
                    //email.Visible = false;
                    question.Visible = true;
                    answer1.Visible = true;
                    btnSubmit.Visible = true;
                    btnclear.Visible = true;
            }
            else
            {
                lblError.Text = "Please Enter Correct Email";
            }
            con.Close();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Select Answer From Recovery Where Customer_email_id=@email";
        com.Parameters.AddWithValue("@email",txtEmail.Text);
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            Session["answer"] = (string)dr["Answer"];
        }
        con.Close();
        string answer=(string)Session["answer"];
        answer.Trim();
        if ((txtForgot.Text)!=(answer))
        {
            lblError.Text = "Wrong Answer"+answer+"hy";
        }
        else
        {
            Session["email"] = txtEmail.Text;
            Response.Redirect("Reset.aspx");
        }
    }
}