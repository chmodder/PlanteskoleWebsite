using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testpage2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    DataAccessLayer.GetProductList();

        //    Product ItemProduct = new Product();
        //    List<Product> ItemRptSrc = new List<Product>();

        //    foreach (Product ProductItem in DataAccessLayer.GetProductList())
        //    {
        //        if (ProductItem.ProductId == 1)
        //        {
        //            ItemRptSrc.AddRange(new[] {ProductItem});
        //            break;
        //        }
        //    }

        //    ItemInfoRpt.DataSource = ItemRptSrc;
        //    ItemInfoRpt.DataBind();
        //}
    }

    protected void ItemInfoRpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //virker IKKE (textbox text Eval fra DB)
        var PriceLbl = (Label)e.Item.FindControl("PriceLbl");
        Response.Write(Single.Parse(PriceLbl.Text));

        //virker (hardcoded i textbox text)
        var PriceLbl2 = (Label)e.Item.FindControl("PriceLbl2");
        Response.Write(Single.Parse(PriceLbl2.Text)); 
    }

}