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

public partial class Webpages_Admin : System.Web.UI.Page
{
    bool abc;
    protected void Page_Load(object sender, EventArgs e)
    {
        imgProduct.Visible = false;
        lblStatus.Visible = false;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (FileImage.HasFile)
        {
            string extension = (string)Path.GetExtension(FileImage.FileName);
            if (extension == ".jpg" || extension == ".png" ||extension==".jpeg"||extension==".gif"||extension==".bmp")
            {
                string s = ("~/Uploads/" + FileImage.FileName).ToString();
                FileImage.SaveAs(Server.MapPath(s));
                lblStatus.Visible = true;
                lblStatus.Text = "File Uploaded";
                imgProduct.Visible = true;
                if (CheckBox1.Checked == true)
                {
                    abc = true;
                }
                else
                {
                    abc = false;
                }
                imgProduct.ImageUrl = "~/Uploads/" + FileImage.FileName;
                InsertDetail(s, abc);
                Response.Redirect("Products.aspx");
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
    protected void InsertDetail(string a,bool ab)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString))
        {
            con.Open();
            string c;
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Select Count(*) from Image";
            int i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            if (ab != null)
            {
                if (ab)
                {
                    c = "yes";
                }
                else
                {
                    c = "no";
                }
            }
            else
            {
                c = "no";
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert into Image(Id,Name,Image,Money,Active,Description) values(@Id,@Name,@Image,@Money,@Active,@Description)";
            cmd.Parameters.Add("@Id",i);
            cmd.Parameters.Add("@Name",txtName.Text);
            cmd.Parameters.Add("@Image",a);
            cmd.Parameters.Add("@Money",txtPrice.Text);
            cmd.Parameters.Add("@Active",c);
            cmd.Parameters.Add("@Description",txtareaDES.InnerText);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}