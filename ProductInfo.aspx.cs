using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class ProductInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["LastPage"] == null!)
        //{
        //    Session["LastPage"] = 
        //}

        if (!IsPostBack)
        {
            int ItemId = Convert.ToInt32(Request.QueryString["ItemId"]);

            DataAccessLayer.GetProductList();

            Product ItemProduct = new Product();
            List<Product> ItemRptSrc = new List<Product>();

            foreach (Product ProductItem in DataAccessLayer.GetProductList())
            {
                if (ProductItem.ProductId == ItemId)
                {
                    ItemRptSrc.AddRange(new[] { ProductItem });
                    break;
                }
            }


            //foreach (RepeaterItem Item in ItemInfoRpt.Items)
            //{
            //    TextBox AmountTbx = (TextBox)Item.FindControl("AmountTbx");
            //    int ItemAmount = Convert.ToInt32(AmountTbx.Text);

            //}

            ItemInfoRpt.DataSource = ItemRptSrc;
            ItemInfoRpt.DataBind();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        string LastPage = Session["LastPage"].ToString();
        string ThisPageFullUrl = Request.Url.AbsoluteUri;
        Session["LastPage"] = ThisPageFullUrl;
        Response.Redirect(LastPage);
    }

    protected void ItemInfoRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //liste kaldet "Cart" med plads til produkter
        Cart C1Cart = new Cart();

        ////Henter Sessionen kurv til kurv
        C1Cart.TakeCart();

        foreach (RepeaterItem Item in ItemInfoRpt.Items)
        {
            //Sætter ProduktId'et fra Repeater-rækken værdien i en variabel
            HiddenField hfId = Item.FindControl("hfId") as HiddenField;
            int ProductId = int.Parse(hfId.Value);

            //Gets Textbox value from AmountTbx
            TextBox AmountTbx = (TextBox)Item.FindControl("AmountTbx");
            int ItemAmount = Convert.ToInt32(AmountTbx.Text);

            //Gets Label value from NameLbl
            Label NameLbl = (Label)Item.FindControl("NameLbl");
            string ProductName = NameLbl.Text.ToString();

            //Unable to convert to float. using hardcoded value for now
            #region PriceBugNeedsFixing
            //Gets Label value from PriceLbl
            float Price = 24;
            //Label PriceLbl = (Label)Item.FindControl("PriceLbl");
            //string PriceString = PriceLbl.Text;
            //float Price = (float)Convert.ToSingle(PriceString);

            //float Price = float.Parse(PriceString);

            //bool valid = float.TryParse(PriceLbl.Text.ToString(), out Price);
            ////float Price = float.Parse(PriceLbl.Text, CultureInfo.InvariantCulture.NumberFormat);
            #endregion

            C1Cart.AddToCart(ProductId, ItemAmount, ProductName, Price);

            TestLbl.Text = ItemAmount.ToString();
        }
        
        C1Cart.ShowCart((Repeater)Master.FindControl("CartContentRpt"));
    }
}