using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Webpages_Details : System.Web.UI.Page
{
    string name;
    string image;
    string money;
    string des;
    string id;
    string yes = "yes";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["Id"]!=null)
        {
            id=Request.QueryString["Id"];
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Name,Image,Money,Description from Image where Id=@Id and Active=@Active";
            cmd.Parameters.AddWithValue("@Id",id);
            cmd.Parameters.AddWithValue("@Active",yes);
            dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dt);
             foreach (DataRow row in dt.Rows)
             {
                 name = row["Name"].ToString();
                 image = row["Image"].ToString();
                 money = row["Money"].ToString();
                 des = row["Description"].ToString();
             }
             if (name == null || des == null || money == null || image == null || id==null)
             {
                 id = null;
                 Response.Redirect("Main.aspx");
             }
             else
             {
                 Image1.ImageUrl = image;
                 p1.InnerText = des;
                 p2.InnerText = "Rs. " + money + " /per Metre";
                 h1.InnerText = name;
                 a1.HRef = image;
             }
        }
        else
        {
            Response.Redirect("Main.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            int ab = Convert.ToInt32(id);
            DataTable dta = Session["Cart"] as DataTable;
            if (dta != null)
            {
                foreach (DataRow dr in dta.Rows)
                {
                    int i = (int)dr["Id"];
                    if (ab.Equals(i))
                    {
                        Session["bool"] = "true";
                        break;
                    }
                    Session["bool"] = "false";
                }

            }
            else
            {
                Session["bool"] = "false";
            }
            if (Convert.ToString(Session["bool"]).Equals("false"))
            {
                con.Open();

                SqlCommand com = con.CreateCommand();
                com.CommandText = "Select Id,Name,Image,Money,Description from Image where Id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Session["bool"] = null;
                Session["dtSelectedProduct"] = dt;
                con.Close();
            }
            else
            {
                Session["bool"] = null;
                Session["dtSelectedProduct"] = null;
            }
            Response.Redirect("Cart.aspx");
        }
    }