using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Webpages_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
        //    //ddlCountry.DataSource = GetData("spGetCountries",null);
        //    //ddlCountry.DataBind();
        //    //ListItem liCountry=new ListItem("Select Country","-1");
        //    //ddlCountry.Items.Insert(0,liCountry);
        ////    ListItem liState = new ListItem("Select State", "-1");
        ////    ddlState.Items.Insert(0, liState);
        ////    ListItem liCity = new ListItem("Select City", "-1");
        ////    ddlCity.Items.Insert(0, liCity);
        ////    ddlState.Enabled = false;
        ////    ddlCity.Enabled = false;
        ////    txtMNo.Text = null;
        ////    txtMNo.Enabled = false;
        //}
    }
    private DataSet GetData(string SPName,SqlParameter SPParameter)
    {
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Dropdown"].ConnectionString);
         SqlDataAdapter da = new SqlDataAdapter(SPName, con);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
        if(SPParameter!=null)
        {
            da.SelectCommand.Parameters.Add(SPParameter);
        }
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        SqlConnection conn=null;
        try
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConn"].ConnectionString);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = ("Insert into Customer(Customer_name,Customer_email_id,Customer_password,Mobile_No,Customer_address,Active) values(@Customer_name,@Customer_email_id,@Customer_password,@Mobile_No,@Customer_address,@Active)");
                cmd.Parameters.AddWithValue("@Customer_name",txtFName.Text + " " + txtMName.Text + " " + txtLName.Text);
                cmd.Parameters.AddWithValue("@Customer_email_id",txtEmail.Text);
                cmd.Parameters.AddWithValue("@Customer_password",txtPasswd.Text);
                cmd.Parameters.AddWithValue("@Mobile_No",txtMNo.Text);
                cmd.Parameters.AddWithValue("@Customer_address", txtAddress.Text + "," + txtStreet.Text + "," + txtTaluka.Text + "," + txtPIN.Text + "." );
                cmd.Parameters.AddWithValue("@Active","yes");
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 1)
                {
                    Session["Email1"] = txtEmail.Text;
                    Session["Name1"] = "Customer "+txtFName.Text +" "+ txtMName.Text +" "+ txtLName.Text;
                    string var = "Registration Successful " + txtFName.Text;
                    Response.Write("<script language=javascript>alert('" + var + "');</script>");
                    Response.Redirect("Recovery.aspx"); 
                    //string myScriptValue = "function callMe() {alert('Successfull Login!'); }";
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "myScriptName", myScriptValue, true);
                }
            }
        }
        catch (SqlException imei)
        {
        }
        finally
        {
            if(conn!=null)
            {
                conn.Close();
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    public void Clear()
    { 
        txtEmail.Text = "";
        txtFName.Text = "";
        txtMName.Text = "";
        txtLName.Text = "";
        txtMNo.Text = "";
        txtPasswd.Text = "";
        txtRPassword.Text = "";
        txtAddress.Text = "";
        txtPIN.Text = "";
        txtStreet.Text = "";
        txtTaluka.Text = "";
        //ddlCountry.ClearSelection();
        //ddlState.ClearSelection();
        //ddlCity.ClearSelection();
    }
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlState.SelectedIndex == 0)
    //    {
    //    }
    //    else
    //    {
    //        ddlCity.Enabled = true;
    //        SqlParameter para=new SqlParameter("@State_id",ddlState.SelectedValue);
    //        DataSet ds = GetData("spGetCitiesByStateId", para);
    //        ddlCity.DataSource = ds ;
    //        ddlCity.DataBind();
    //        ListItem liCity = new ListItem("Select City", "-1");
    //        ddlCity.Items.Insert(0, liCity);
    //    }
    //}
    //protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int[] code=new int[3];
    //    code[1] = 91;
    //    code[2] = 94;
    //    if (ddlCountry.SelectedIndex == 0)
    //    {
    //        ddlState.Enabled = false;
    //        ddlCity.Enabled = false;
    //        txtMNo.Text = null;
    //        txtMNo.Enabled = false;
    //    }
    //    else
    //    {
    //        int index = ddlCountry.SelectedIndex;
    //        txtMNo.Text = code[index].ToString();
    //        txtMNo.Enabled = true;
    //        ddlState.Enabled = true;
    //        SqlParameter para = new SqlParameter("@Country_id", ddlCountry.SelectedValue);
    //        DataSet ds = GetData("spGetStatesByCountryId",para);
    //        ddlState.DataSource = ds;
    //        ddlState.DataBind();
    //        ListItem liState = new ListItem("Select State", "-1");
    //        ddlState.Items.Insert(0, liState);
    //        ddlCity.SelectedIndex = 0;
    //        ddlCity.Enabled = false;
            
    //    }
    //}
}//string com="Insert into Customer(Customer_first_name,Customer_middle_name,Customer_last_name,Customer_email_id,Customer_password,Customer_address,Products_ordered,Mobile_No) values('" + txtFName.Text + "','" + txtMName.Text + "','" +txtLName.Text+ "','" +txtEmail.Text+ "','" +txtPasswd.Text+ "','" +taAdd.InnerText+ "','NULL','" +txtMNo.Text+ "')";