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

public partial class Webpages_Test : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText="SELECT     Order_Id,Bill_Id,Customer_Email,Product_Id,Product_Name,Product_Quantity,Order_Amount,Date FROM         dbo.[Order]";
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        CrystalReportOrder cr = new CrystalReportOrder();
        cr.SetDataSource(dt);
        CrystalReportViewer1.ReportSource = cr;
        CrystalReportViewer1.Zoom(75);
    }
}