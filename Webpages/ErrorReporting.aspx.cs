using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_ErrorReporting : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Email"]==null)
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileImage.HasFile)
        {
            string extension = (string)Path.GetExtension(FileImage.FileName);
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
            {
                string s = ("~/Error Screenshot/" + FileImage.FileName).ToString();
                FileImage.SaveAs(Server.MapPath(s));
                lblStatus.Visible = true;
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                lblStatus.Text = "Email Sent";
                imgProduct.Visible = true;
                imgProduct.ImageUrl = "~/Error Screenshot/" + FileImage.FileName;
                SendEmail se = new SendEmail();
                string msg="This is a new Error that the user is facing reported by "+(string)Session["Email"]+"   Description Of the Error: "+TextBox1.Text;
                SqlCommand cmd=con.CreateCommand();
                cmd.CommandText="Select Admin_email_id from Admin";
                DataTable dt=new DataTable();
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    string email=(string)dr["Admin_email_id"];
                    se.sendEMail(email, msg, "E:\\Project\\CMSW\\Error Screenshot\\"+FileImage.FileName);
                }
                SendEmail1 sq = new SendEmail1();
                string mess="We have Acknowledged Your Request Thank You For Reporting We will Get Back To You as Soon as possible "+(string)Session["Name"];
                sq.sendEMail((string)Session["Email"], mess);
            }
            else
            {
                imgProduct.Visible = false;
                lblStatus.Visible = true;
                lblStatus.Text = "Please Upload Correct Format File";
            }
        }
        else
        {
            imgProduct.Visible = false;
            lblStatus.Visible = true;
            lblStatus.Text = "Please Upload Image File";
        }
    }
}