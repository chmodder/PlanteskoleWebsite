using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Opretter et nyt objekt af typen Cart
        Cart C2Cart = new Cart();

        //Henter Sessionen kurv til kurv
        C2Cart.TakeCart();

        //Viser kurven i Repeateren CartContentRpt
        C2Cart.ShowCart((Repeater)FindControl("CartContentRpt"));
        ShopInfo FooterInfo = new ShopInfo();
        FooterNameLbl.Text = FooterInfo.ShopName;
        FooterAddressLbl.Text = FooterInfo.Address;
        FooterZipCityLbl.Text = FooterInfo.ZipCity;
        FooterPhoneLbl.Text = Convert.ToString(FooterInfo.Phone);
        
    }
    protected void CartCheckoutBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx");
    }
}
