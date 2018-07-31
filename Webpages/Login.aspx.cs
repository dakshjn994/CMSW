using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Login : System.Web.UI.Page
{
    string login;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string name = "Customer";
        UserLogin(name);
    }
    private char ValidationSummary()
    {
        throw new NotImplementedException();
    }
    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        string name = "Admin";
        UserLogin(name);
    }
    //public void MsgBox(String ex, Page pg, Object obj)
    //{
        //string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        //Type cstype = obj.GetType();
        //ClientScriptManager cs = pg.ClientScript;
      //  cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    //}
    protected void UserLogin(string tablename)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString))
        {
            try
            {
                string sas = "yes";
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Count(*) from " + tablename + " where " + tablename + "_email_id=@Email and " + tablename + "_password=@Password and Active=@Active", con);
                SqlCommand command = new SqlCommand("Select " + tablename + "_name from " + tablename + " where " + tablename + "_email_id=@Email and " + tablename + "_password=@Password and Active=@Active", con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Active", sas);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);
                command.Parameters.AddWithValue("@Active", sas);
                int noOfUser = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (noOfUser == 1)
                {
                    string name = command.ExecuteScalar().ToString();
                    Session["Email"] = txtEmail.Text;
                    Session["Name"] = tablename + " " + name;
                    login = "Successful";
                    History(login,tablename);
                    if (tablename.Equals("Customer"))
                    {
                        if (Session["Cart"] != null)
                        {
                            string var = "Login Successful " + tablename;
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                            Response.Redirect("Cart.aspx");
                        }
                        else
                        {
                            string var = "Login Successful " + tablename;
                            Response.Write("<script language=javascript>alert('" + var + "');</script>");
                            Response.Redirect("Main.aspx");
                        }

                    }
                    if (tablename.Equals("Admin"))
                    {
                        string var = "Login Successful " + tablename;
                        Response.Write("<script language=javascript>alert('" + var + "');</script>");
                        Response.Redirect("Products.aspx");
                    }
                }
                else
                {
                    string var = "Wrong Username/Password " + tablename;
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    login = "Failed";
                    History(login,tablename);
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                con.Close();
                Response.Redirect("ErrorPa.aspx?iD=" + ex.Message);
            }
        }
    }
        protected void History(string login,string tablename)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
            con.Open();
            SqlCommand com = con.CreateCommand();
                com.CommandText = "Insert into History values(@Email,@Login,@Type,@Time)";
                com.Parameters.AddWithValue("@Email",txtEmail.Text);
                com.Parameters.AddWithValue("@Login",login);
                com.Parameters.AddWithValue("@Type", tablename);
            DateTime date=DateTime.Now;
            com.Parameters.AddWithValue("@Time",date);
                com.ExecuteNonQuery();
                con.Close();
        }
    }