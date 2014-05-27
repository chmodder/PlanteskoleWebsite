using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Opretter et nyt objekt af typen Cart
        Cart C2Cart = new Cart();

        //Henter Sessionen kurv til kurv
        C2Cart.TakeCart();

        //Viser Kurven i "CheckoutGv"
        CheckoutGv.DataSource = C2Cart.CartList;
        CheckoutGv.DataBind();


        PriceAllContentLbl.Text = C2Cart.PriceAllContent.ToString(CultureInfo.InvariantCulture) + " Kr.";
    }

    //private float priceforall()
    //{
    //    Cart TempCart = new Cart();
    //    float TempPrice = 0;

    //    foreach (var item in TempCart.CartList)
    //    {

    //        TempPrice =+ item.Price;
    //    }

    //    return TempPrice;
    //}


    protected void CheckoutGv_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        ////Get productId
        //int Id = (int)e.Values["Id"];
        int Id = Convert.ToInt32(CheckoutGv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"].ToString());

        //Delete from DB using Cart class

        //Take Cart
        Cart C3Cart = new Cart();

        //Henter Sessionen kurv til kurv
        C3Cart.TakeCart();

        C3Cart.RemoveAll(Id);

        //Viser Kurven i "CheckoutGv"
        CheckoutGv.DataSource = C3Cart.CartList;
        CheckoutGv.DataBind();

    }

    protected void OrderBtn_Click(object sender, EventArgs e)
    {
        //Until ACL is created UserId will be Hardcoded/constant, if userId is needed
    }
}