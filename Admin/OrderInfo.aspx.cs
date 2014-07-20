using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderInfo : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {

        //OrderStateDdl.SelectedValue = GetCurrentOrderStatus().ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OrderStateDdl.SelectedValue = GetCurrentOrderStatus().ToString();
        }
        //Label1.Text = OrderStateDdl.SelectedItem.Value;
        //OrderStateDdl.SelectedValue = GetCurrentOrderStatus().ToString();
        
    }

    private int GetCurrentOrderStatus()
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand("SELECT FkOrderStateId FROM Orders WHERE Orders.Id = @OrderId");

        Cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = Request.QueryString["OrderId"];

        Cmd.Connection = Conn;

        Conn.Open();
        int SelectedDdlValue = (int)Cmd.ExecuteScalar();
        Conn.Close();

        return SelectedDdlValue;
    }

    protected void LastPageBtn_Click(object sender, EventArgs e)
    {
        //Not able to find gridview pagesource yet
        Response.Redirect("Orders.aspx");
    }

    protected void UpdateOrderState()
    {
        Label1.Text = "OrderId: " + Request.QueryString["OrderId"];
        Label2.Text = "OrderStateId: " + GetCurrentOrderStatus().ToString(); 
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand("UPDATE Orders SET FkOrderStateId=@OrderStateId WHERE Id = @OrderId");

        Cmd.Parameters.Add("@OrderStateId", SqlDbType.Int).Value = OrderStateDdl.SelectedItem.Value;
        Cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["OrderId"]);

        Cmd.Connection = Conn;

        Conn.Open();
        Cmd.ExecuteNonQuery();
        Conn.Close();

        Response.Redirect(Request.RawUrl);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UpdateOrderState();
    }
}