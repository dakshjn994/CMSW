using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Webpages_Recovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAnswer.Enabled = false;
        if(Session["Email1"]==null)
        {
            Response.Redirect("Main.aspx");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Index = ddlRQuestion.SelectedIndex;
        if (Index != 0)
        {
            txtAnswer.Enabled = true;
        }
        else
        {
            txtAnswer.Enabled = false;
        }
    }
    protected void btnrClear_Click(object sender, EventArgs e)
    {
        ddlRQuestion.ClearSelection();
        txtAnswer.Text = "";
        txtAnswer.Enabled = false;
    }
    protected void btnRecovery_Click(object sender, EventArgs e)
    {
        SqlConnection conn;
        using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString))
        {
            try
            {
                if (Session["Email1"] != null && Session["Name1"] != null)
                {
                    string email = (Convert.ToString(Session["Email1"]));
                    string name = (Convert.ToString(Session["Name1"]));
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.CommandText = ("Insert into Recovery(Customer_email_id,Recovery_Questions,Answer) values(@Customer_email_id,@Recovery_Questions,@Answer)");
                    cmd.Parameters.AddWithValue("@Customer_email_id", email);
                    cmd.Parameters.AddWithValue("@Recovery_Questions", ddlRQuestion.SelectedItem.Text.ToString());
                    string ans = txtAnswer.Text;
                    ans.Trim();
                    cmd.Parameters.AddWithValue("@Answer", ans);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        conn.Close();
                        Session.Clear();
                        Session["Email"] = email;
                        Session["Name"] = name;
                        Response.Redirect("Main.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Main.aspx",false);
                }
            }
            catch (Exception i)
            {
                Response.Redirect("Main.aspx?Id=" + i.Message.ToString(), false);
            }
        }
    }
}