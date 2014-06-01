using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void AllOrdersGv_OnRowCommand(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "More")
        {
            //Hent Produkt-Id'et fra rækken. Det skal bruges som QueryString parameter på den "Se mere" produktside, der skal navigeres hen til
            int Id = Convert.ToInt32(AllOrdersGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OrderId"].ToString());

            ////Henter Url med Querystring ind i en string variabel
            //string ThisPageFullUrl = Request.Url.AbsoluteUri;
            //Session["LastPage"] = ThisPageFullUrl;
            //Session["LastPage"] = Request.RawUrl;

            Response.Redirect("OrderInfo.aspx?OrderId=" + Id);
        }
    }

}