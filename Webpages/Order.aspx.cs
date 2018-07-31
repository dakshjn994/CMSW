using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

public partial class Webpages_Order : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
    int i = 0;
    int k = 0;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] != null && Session["Cart"]!=null && Session["Add"]!=null)
        {
            dt = Session["Cart"] as DataTable;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            foreach (DataRow dr in dt.Rows)
            {
                i += (int)dr["total"];
            }
            Label1.Text = "Rs. "+Convert.ToString(i);
            foreach (DataRow dr in dt.Rows)
            {
                k += (int)dr["Quantity"];
            }
            Label2.Text = Convert.ToString(k);
            lblName.Text = (string)Session["Name"];
            lblEmail.Text = (string)Session["Email"];
            lblAddress.Text = (string)Session["Add"];
        }
        else
        {
            Response.Redirect("Main.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dtcart=new DataTable();
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) From dbo.[Bill]";
        int billno = (int)cmd.ExecuteScalar();
        billno = billno + 1001;
        SqlCommand com = con.CreateCommand();
        com.CommandText = "Select Count(*) From dbo.[Order]";
        int orderno = (int)com.ExecuteScalar();
        orderno = orderno + 10001;
        SqlCommand command = con.CreateCommand();
        command.CommandText = "Insert into dbo.[Bill] values(@Bill_Id,@Customer_Email,@Product_Amount,@No_Products,@Delivery_Address,@Bill_Date)";
        command.Parameters.AddWithValue("@Bill_Id",billno);
        command.Parameters.AddWithValue("@Customer_Email", lblEmail.Text);
        command.Parameters.AddWithValue("@Product_Amount",i);
        command.Parameters.AddWithValue("@No_Products",k);
        command.Parameters.AddWithValue("@Delivery_Address",lblAddress.Text);
        DateTime Date=(DateTime.Now);
        command.Parameters.AddWithValue("@Bill_Date",Date);
        command.ExecuteNonQuery();
        con.Close();
        foreach(DataRow dr in dt.Rows)
        {
            int id = (int)dr["Id"];
            string name = (string)dr["Name"];
            int quantity = (int)dr["Quantity"];
            int total = (int)dr["total"];
            OrderInsert(orderno,billno,id,name,quantity,total);
            orderno++;
        }
        dtcart = data(billno);
        ExportToPdf(dtcart,billno);
        SendEmail se = new SendEmail();
        string msg = "Hello "+Convert.ToString(Session["Name"])+" this is the order you have placed";
        se.sendEMail((string)Session["Email"],msg,"E:\\Project\\CMSW\\PDF's\\"+billno+".pdf");
        Session["Bill_Id"] = billno;
        Response.Redirect("Billing.aspx");
    }
    private void OrderInsert(int orderno, int billno,int p2,string name,int p3,int p4)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Insert into dbo.[Order] values(@Order_Id,@Bill_Id,@Customer_email,@Product_Id,@Product_Name,@Product_Quantity,@Order_Amount,@Date,@Approval)";
        cmd.Parameters.AddWithValue("@Order_Id",orderno);
        cmd.Parameters.AddWithValue("@Bill_Id", billno);
        cmd.Parameters.AddWithValue("@Customer_email",lblEmail.Text);
        cmd.Parameters.AddWithValue("@Product_Id",p2);
        cmd.Parameters.AddWithValue("@Product_Name", name);
        cmd.Parameters.AddWithValue("@Product_Quantity", p3);
        cmd.Parameters.AddWithValue("@Order_Amount", p4);
        DateTime date = DateTime.Now;
        cmd.Parameters.AddWithValue("@Date", date);
        cmd.Parameters.AddWithValue("@Approval","no");
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public void ExportToPdf(DataTable dt,int billno)
    {
        Document document = new Document();
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("E:\\Project\\CMSW\\PDF's\\"+billno+".pdf", FileMode.Create));
        document.Open();
        iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
        font5.Color = new BaseColor(System.Drawing.Color.DarkGray);

        PdfPTable table = new PdfPTable(dt.Columns.Count);
        PdfPRow row = null;
        float[] widths = new float[] {100f, 100f, 100f, 100f };

        table.SetWidths(widths);

        table.WidthPercentage = 50;
        int iCol = 0;
        string colname = "";
        PdfPCell cell = new PdfPCell(new Phrase("Products"));
        cell.Colspan = dt.Columns.Count;

        foreach (DataColumn c in dt.Columns)
        {
            table.AddCell(new Phrase(c.ColumnName, font5));
        }

        foreach (DataRow r in dt.Rows)
        {
            if (dt.Rows.Count > 0)
            {
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase(r[3].ToString(), font5));
            }
        }
        string name = "cool";
        string order = "Bill no." + billno;
        document.Add(table);
        document.Close();
    }
    protected DataTable data(int billno)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "Select Order_Id,Product_Name,Product_Quantity,Order_Amount from [Order] where Bill_Id=@Id";
        cmd.Parameters.AddWithValue("@Id", billno);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }
}