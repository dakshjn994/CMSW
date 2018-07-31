using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Webpages_Admin_Products : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    string yes = "yes";
    string no = "no";
    string id;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        noproducts.Visible = false;
        GridView2.Visible = false;
        lblName.Visible = false;
        lblPrice.Visible = false;
        lblMoney.Visible = false;
        lblDesc.Visible = false;
        chng.Visible = false;
        imgProduct.Visible = false;
        lblStatus.Visible = false;
        fuImage.Visible = false;
        btnChange.Visible = false;
        txtPath.Visible = false;
        txtMoney.Visible = false;
        txtName.Visible = false;
        taDescription.Visible = false;
        btnUpload.Visible = false;
        btnShow.Visible = false;
        try
        {
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandText = "Select Id,Name,Image,Money from Image where Active=@Active";
            com.Parameters.AddWithValue("@Active", yes);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select Id,Name,Image,Money from Image where Active=@Active";
            cmd.Parameters.AddWithValue("@Active", no);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable sdt = new DataTable();
            sda.Fill(sdt);
            GridView2.DataSource = sdt;
            GridView2.DataBind();
            con.Close();
        }
        catch(SqlException exp)
        {
            Response.Write(exp.Message.ToString());
        }
    }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button b=sender as Button;
        string id, name;
        if(b!=null)
        {
            id = b.CommandArgument;
            name = b.Text;
            DeleteDetail(id,name);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        string id, name;
        if (b != null)
        {
            id = b.CommandArgument;
            name = b.Text;
            DeleteDetail(id, name);
        }
    }
    protected void DeleteDetail(string id,string name)
    {
        if (name == "Delete")
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update Image set Active=@Active1 where Active=@Active and Id=@Id";
            cmd.Parameters.AddWithValue("@Active1", no);
            cmd.Parameters.AddWithValue("@Active", yes);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Products.aspx", false);
        }
        else 
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update Image set Active=@Active1 where Active=@Active and Id=@Id";
            cmd.Parameters.AddWithValue("@Active1", yes);
            cmd.Parameters.AddWithValue("@Active", no);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Products.aspx", false);
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        lblName.Visible = true;
        lblPrice.Visible = true;
        lblMoney.Visible = true;
        lblDesc.Visible = true;
        chng.Visible = true;
        fuImage.Visible = true;
        btnChange.Visible = true;
        btnUpload.Visible = true;
        txtPath.Visible = true;
        txtMoney.Visible = true;
        txtName.Visible = true;
        taDescription.Visible = true;
        Button b = sender as Button;
        if(b!=null)
        {
            id = b.CommandArgument;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from Image where Id="+id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count==1)
            {
                txtName.Text=(string)dt.Rows[0]["Name"];
                txtMoney.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0]["Money"]));
                txtPath.Text = (string)dt.Rows[0]["Image"];
                imgProduct.ImageUrl = (string)dt.Rows[0]["Image"];
                imgProduct.Visible = true;
                lblStatus.Text = "Data Explored";
                lblStatus.Visible = true;
                taDescription.InnerText = (string)dt.Rows[0]["Description"];
            }
            ViewState["dt"] = dt;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        if (fuImage.HasFile)
        {
            string extension = (string)Path.GetExtension(fuImage.FileName);
            if (extension == ".jpg" || extension == ".png" ||extension==".jpeg"||extension==".gif"||extension==".bmp")
            {
                string s = ("~/Uploads/" + fuImage.FileName).ToString();
                fuImage.SaveAs(Server.MapPath(s));
                lblStatus.Visible = true;
                lblStatus.Text = "File Uploaded";
                imgProduct.Visible = true;
                txtPath.Text = s;
                imgProduct.ImageUrl = s;
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
    protected void btnChange_Click(object sender, EventArgs e)
    {
        con.Open();
        DataTable dta=(DataTable)ViewState["dt"];
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Update Image set Id=@i,Name=@Name,Image=@Image,Money=@Money,Active=@Active,Description=@Des where Id=@Id";
        cmd.Parameters.AddWithValue("@i",dta.Rows[0]["Id"]);
        cmd.Parameters.AddWithValue("@Active",dta.Rows[0]["Active"]);
        cmd.Parameters.AddWithValue("@Name",txtName.Text);
        cmd.Parameters.AddWithValue("@Image",txtPath.Text);
        cmd.Parameters.AddWithValue("@Money",txtMoney.Text);
        cmd.Parameters.AddWithValue("@Des",taDescription.InnerText);
        cmd.Parameters.AddWithValue("@Id", dta.Rows[0]["Id"]);
        cmd.ExecuteNonQuery();
        con.Close();
        lblName.Visible = false;
        lblPrice.Visible = false;
        lblMoney.Visible = false;
        lblDesc.Visible = false;
        chng.Visible = false;
        imgProduct.Visible = false;
        lblStatus.Visible = false;
        fuImage.Visible = false;
        btnChange.Visible = false;
        txtPath.Visible = false;
        txtMoney.Visible = false;
        txtName.Visible = false;
        taDescription.Visible = false;
        btnUpload.Visible = false;
        Response.Redirect("Products.aspx");
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        noproducts.Visible = true;
        GridView2.Visible = true;
        btnDel.Visible = false;
        btnShow.Visible = true;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        noproducts.Visible = false;
        GridView2.Visible = false;
        btnDel.Visible = true;
        btnShow.Visible = false;
    }
}