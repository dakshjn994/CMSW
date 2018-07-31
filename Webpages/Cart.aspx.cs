﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Cart : System.Web.UI.Page
{
     DataTable dtCart = new DataTable();
    String cs = ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString;
     bool n;
     protected void Page_Load(object sender, EventArgs e)
     {
         Checkout.Enabled = false;
         if (!IsPostBack)
         {
                 if (Session["Cart"] != null)
                 {
                     FillCart();
                 }
                 else
                 {
                     CreateCart();
                     FillCart();
                 }
             }
         }

    private void CreateCart()
    {
        dtCart = new DataTable();
        dtCart.Columns.Add("SrNo", typeof(int));
        dtCart.Columns.Add("Id", typeof(int));
        dtCart.Columns.Add("Name", typeof(string));
        dtCart.Columns.Add("Image", typeof(string));
        dtCart.Columns.Add("Description", typeof(string));
        dtCart.Columns.Add("Money", typeof(int));
        dtCart.Columns.Add("quantity", typeof(int));
        dtCart.Columns.Add("total", typeof(int));
    }
    private void FillCart()
    {
        try
        {
            if (Session["Cart"] != null)
            {
                dtCart = (DataTable)Session["Cart"];
            }
            DataTable dtSelProduct = (DataTable)Session["dtSelectedProduct"];
            //DataTable dtSelMaterial = (DataTable)Session["dtSelectedMaterial"];
            if (Session["dtSelectedProduct"] != null)
                {
                foreach (DataRow dr in dtSelProduct.Rows)
                {
                    dtCart.Rows.Add(Convert.ToInt32(dtCart.Rows.Count + 1), Convert.ToInt32(dr["Id"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["Money"]), 1, Convert.ToInt32(dr["Money"]));
                }
                Session["dtSelectedProduct"] = null;
                }
            //if (Session["dtSelectedMaterial"] != null)
            //{
            //    foreach (DataRow dr in dtSelMaterial.Rows)
            //    {
            //        dtCart.Rows.Add((dtCart.Rows.Count + 1), Convert.ToInt32(dr["Id"]), Convert.ToString(dr["Name"]), Convert.ToString(dr["Image"]), Convert.ToString(dr["Description"]), Convert.ToInt32(dr["Money"]), 1, Convert.ToInt32(dr["Money"]));
            //    }
            //    Session["dtSelectedMaterial"] = null;

            //}
            if (dtCart.Rows.Count != 0)
            {
                Checkout.Enabled = true;
            }
            Session["Cart"] = dtCart;
            gvCart.DataSource = dtCart;
            gvCart.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message+"Whatup";
        }
    }
    protected void imgDeleteProduct_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dtCart = (DataTable)Session["Cart"];
            int SrNo = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            dtCart.Rows.RemoveAt((SrNo - 1));
            dtCart = RegenerateDataTable(dtCart);
            gvCart.DataSource = dtCart;
            gvCart.DataBind();
            Session["Cart"] = dtCart;
            if (dtCart.Rows.Count == 0)
            {
                Checkout.Enabled = false;
            }
            Response.Redirect("Cart.aspx");
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
    }
    private DataTable RegenerateDataTable(DataTable dt)
    {
        int srno = 0;
        DataTable dtDup = dt.Clone();
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                DataRow drNew = dtDup.NewRow();
                srno += 1;
                drNew[0] = srno;
                drNew[1] = row[1];
                drNew[2] = row[2];
                drNew[3] = row[3];
                drNew[4] = row[4];
                drNew[5] = row[5];
                drNew[6] = row[6];
                drNew[7] = row[7];
                dtDup.Rows.Add(drNew);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString()+"Hello";
        }
        return dtDup;
    }

    protected void ddlQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dtCart = (DataTable)Session["Cart"];
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            if (row != null)
            {
                int quantity = Convert.ToInt32(((DropDownList)(row.FindControl("ddlQuantity"))).SelectedValue);
                int index = Convert.ToInt32(((DropDownList)(row.FindControl("ddlQuantity"))).SelectedIndex);
                int price = Convert.ToInt32(dtCart.Rows[row.RowIndex]["Money"]);
                dtCart.Rows[row.RowIndex].SetField("quantity", (quantity));
                dtCart.Rows[row.RowIndex].SetField("total", (quantity * price));
                gvCart.DataSource = dtCart;
                gvCart.DataBind();
                Session["Cart"] = dtCart;
                if (dtCart.Rows.Count != 0)
                {
                    Checkout.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
        }
    }
    public class SendEmail1
    {
        MailMessage mail;
        NetworkCredential mailAuthentication;
        static string FromID = "dakshjn994@gmail.com";                // ENTER FROM EMAIL ID
        static string pwd = "IAM4111198";                             // PASSWORD

        public void sendEMail(string ToEmail, string msg)
        {
            mail = new MailMessage(FromID, ToEmail, "Your Shopping", msg);
            mailAuthentication = new NetworkCredential(FromID, pwd);
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
            mailClient.EnableSsl = true;
            mailClient.Credentials = mailAuthentication;
            mail.IsBodyHtml = true;
            mailClient.Send(mail);
        }
    }
    protected void Email(string txtTo,string Data)
    {
        SendEmail1 s = new SendEmail1();
        s.sendEMail(txtTo.Trim(),Data.Trim());
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Mail has been sent successfully. .');", true);
    }

    protected void Checkout_Click(object sender, EventArgs e)
    {
        if (Session["Name"] == null || Session["Email"]==null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if(Session["Email"]!=null)
            {
                //string str=Convert.ToString(Session["Email"]);
                Response.Redirect("Shipping.aspx");
                //string data = "Hello Sir" ;
                //Email(str,data);
            }
        }
    }
    protected void Main_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
}