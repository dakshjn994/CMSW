using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.WebControls;

public partial class Webpages_BillReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT     Bill_Id,Customer_Email,Product_Amount,No_Products,Delivery_Address,Bill_Date FROM         dbo.[Bill]";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        CrystalReportBill cr = new CrystalReportBill();
        cr.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = cr;
        CrystalReportViewer1.Zoom(75);
    }
}