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

public partial class Webpages_CustomerReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT     Customer_name, Customer_email_id, Mobile_No, Customer_address FROM         dbo.Customer WHERE Active=@a";
        cmd.Parameters.AddWithValue("@a","yes");
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        CrystalReportCustomer cr = new CrystalReportCustomer();
        cr.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = cr;
        CrystalReportViewer1.Zoom(75);
    }
}