using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Shop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void UpdateCartBtn_Click(object sender, EventArgs e)
    {

    }

    protected void ProductsGv_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Hent Produkt-Id'et fra rækken. Det skal bruges som QueryString parameter på den "Se mere" produktside, der skal navigeres hen til
        int Id = Convert.ToInt32(ProductsGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"].ToString());

        //Henter Url med Querystring ind i en string variabel
        string ThisPageFullUrl = Request.Url.AbsoluteUri;
        Session["LastPage"] = ThisPageFullUrl;

        Response.Redirect("ProductInfo.aspx?ItemId=" + Id);

        #region TESTING
        ////Dataen, der gemmes i varablen er nummeret i arrayet, som starter på 0, og er IKKE Id'et som tilhører rækken
        //int RowIndex = Convert.ToInt32(e.CommandArgument);
        //TestLbl.Text = "RowIndex: " + RowIndex + "<br />" + "Id: " + Id + "<br />Url from object: " + ThisPageRawUrl;
        #endregion
    }
}