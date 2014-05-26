using System;
using System.Collections.Generic;
using System.Data;
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


        foreach (GridViewRow Row in ProductsGv.Rows)
        {
            if (Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox IdChb = (Row.Cells[0].FindControl("IdChb") as CheckBox);
                if (IdChb.Checked)
                {
                    #region GetItemParameters
                    //Get Item Parameters (4 parameters)
                    //1) Get ProductId
                    HiddenField HiddenFieldId = Row.Cells[0].FindControl("HiddenFieldId") as HiddenField;
                    int Id = Convert.ToInt32(HiddenFieldId.Value);
                    //TestLbl.Text = Id.ToString();

                    //2) Get Amount
                    TextBox AmountTbx = Row.Cells[0].FindControl("AmountTbx") as TextBox;
                    int Amount = Convert.ToInt32(AmountTbx.Text);
                    //TestLbl.Text = Amount.ToString();

                    //3) Get ProductName
                    //Opfølging på <Row.Cells[3].Text;> Hvad betyder 3-tallet i firkant-parantesen?
                    //Er det rækkefølgen på cellerne i rækken - Dvs. nummer 3 celle i rækken?
                    //Er der ikke en mere præcis måde, man kan udvælge cellen på - fx. med værdien/data'en i cellen?
                    //string ProductName = ProductsGv.DataKeys[Row.RowIndex]["Name"].ToString();
                    string ProductName = Row.Cells[3].Text;
                    //TestLbl.Text = ProductName.ToString();

                    ////4) Get Price
                    float Price = (float)Convert.ToSingle(Row.Cells[4].Text);
                    //float Price = (float)ProductsGv.DataKeys[Row.RowIndex]["Price"];
                    //TestLbl.Text = Price.ToString();
                    #endregion

                    //liste kaldet "Cart" med plads til produkter
                    Cart C1Cart = new Cart();

                    ////Henter Sessionen kurv til kurv
                    C1Cart.TakeCart();

                    // AddToCart
                    C1Cart.AddToCart(Id, Amount, ProductName, Price);

                    //Viser kurven
                    C1Cart.ShowCart((Repeater)Master.FindControl("CartContentRpt"));

                    //Fjerner fluebenene efter varene er lagt i kurven
                    IdChb.Checked = false;
                }
            }
        }
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