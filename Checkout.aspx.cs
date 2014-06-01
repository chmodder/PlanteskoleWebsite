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
        //Opretter et nyt objekt af typen Cart
        Cart C4Cart = new Cart();

        //Henter Sessionen kurv til kurv
        C4Cart.TakeCart();

        //Check userid if userid exists in session (if user is logged in). Else redirect to login and save page in session
        if (Session["UserId"] != null)
        {
            int CustomerId = (int)Session["UserId"];
            //Orderstate 1 = Order created
            Order CreateNewOrder = new Order(CustomerId, 1, C4Cart);
            Response.Redirect("OrderConfirmation.aspx");
        }
        else
        {
            Session["LastWebform"] = Request.RawUrl;
            Response.Redirect("LoginPage.aspx");
        }

    }
}