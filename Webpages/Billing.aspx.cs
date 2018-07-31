using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webpages_Billing : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Bill_Id"]!=null)
        {
        int i=(int)Session["Bill_Id"];
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT        dbo.[Order].Order_Id, dbo.[Order].Bill_Id, dbo.[Order].Customer_Email, dbo.[Order].Product_Id, dbo.[Order].Product_Name, dbo.[Order].Product_Quantity, dbo.[Order].Order_Amount, dbo.[Order].Date, dbo.Bill.Delivery_Address FROM            dbo.Bill INNER JOIN dbo.[Order] ON dbo.Bill.Bill_Id = dbo.[Order].Bill_Id WHERE dbo.[Order].Bill_Id=@w AND dbo.[Bill].Bill_Id=@w";
        cmd.Parameters.AddWithValue("@w",i);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        CrystalReportImpBilling cr = new CrystalReportImpBilling();
        cr.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = cr;
        CrystalReportViewer1.Zoom(75);
        }
        else
        {
            Response.Redirect("Main.aspx");
        }
    }
}