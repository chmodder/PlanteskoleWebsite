using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    #region FIELDS

    private List<ProductsInCart> _cartList;

    #endregion

    #region PROPERTIES

    public List<ProductsInCart> CartList
    {
        get { return _cartList; }
        set { _cartList = value; }
    }

    #endregion

    #region CONSTRUCTORS

    /// <summary>
    /// Creates new list of type ProductsInCart (which is a class type).
    /// </summary>
    public Cart()
    {
        //liste kaldet "Cart" med plads til produkter
        CartList = new List<ProductsInCart>();
    }

    #endregion

    #region METHODS

    /// <summary>
    /// 1) If Session "Cart" does not exist, then a new session is created.
    /// 2) Cart is then updated with values from Session "Cart".
    /// </summary>
    /// <param name="CartList"></param>
    public void TakeCart()
    {
        //Hvis ikke vi har en session kaldet Cart
        if (HttpContext.Current.Session["Cart"] == null)
        {
            //Så oprettes en Session Cart med værdien List Cart
            HttpContext.Current.Session.Add("Cart", CartList);
        }

        //Sæt "List Cart" lig med "Session Cart"
        CartList = (List<ProductsInCart>)HttpContext.Current.Session["Cart"];

    }

    //unsure about syntax for now, or if it is possible to add default parameters this way
    //    public void AddToCart() : this(0,"",0,0);
    //{

    //}

    /// <summary>
    /// Adds item to Cart
    /// </summary>
    public void AddToCart(int ProductId, int ProductAmount, string ProductName, float ProductPrice)
    {
        bool NewProduct = true;

        //undersøg om produktet er i kurven
        foreach (ProductsInCart Product in CartList)
        {
            //Hvis produktet er fundet
            if (Product.Id == Convert.ToInt32(ProductId))
            {
                //Så opdater antal og samlet pris
                Product.Amount += Convert.ToInt32(ProductAmount);
                Product.Price += ProductPrice;

                //Nu er det konstateret, at det ikke er noget nyt produkt længere
                NewProduct = false;
            }

        }

        //Er det et nyt produkt?
        if (NewProduct)
        {
            //Hvis ja, så tilføj et produkt til listen
            this.CartList.Add(new ProductsInCart(
                ProductId,
                ProductName,
                ProductPrice,
                ProductAmount));
        }
    }

    /// <summary>
    /// Shows cart in Gridview
    /// Takes 1 parameter of type GridView and databinds it to the CartList
    /// </summary>
    /// <param name="View"></param>
    public void ShowCart(Repeater Rpt)
    {
        Rpt.DataSource = this.CartList;
        Rpt.DataBind();
    }

    ///// <summary>
    ///// Adds 1 item to Cart. Takes 1 Argument of type DataKey
    ///// </summary>
    ///// <param name="dataKey"></param>
    //public void AddOne(DataKey dataKey)
    //{
    //    foreach (ProductsInCart Product in CartList)
    //    {
    //        //Hvis produktet er fundet
    //        if (dataKey != null && Product.Id == (int)dataKey.Value)
    //        {
    //            //Så opdater antal og samlet pris
    //            Product.Amount += 1;
    //        }
    //    }
    //}

    ///// <summary>
    ///// Removes 1 item from Cart. Takes 1 Argument of type DataKey
    ///// </summary>
    ///// <param name="dataKey"></param>
    //public void RemoveOne(DataKey dataKey)
    //{
    //    foreach (ProductsInCart Product in CartList)
    //    {
    //        //Hvis produktet er fundet
    //        if (dataKey != null && Product.Id == (int)dataKey.Value)
    //        {
    //            if (Product.Amount == 1)
    //            {
    //                //Hvis Product.Amount er 1, så fortsættes til case "RemoveAll"
    //                //goto case "RemoveAll";
    //                this.RemoveAll(dataKey);
    //                break;
    //            }
    //            else
    //            {
    //                //Så opdater antal og samlet pris
    //                Product.Amount -= 1;
    //            }

    //        }
    //    }
    //}

    ///// <summary>
    ///// Removes all items from Cart of type indicated by Datakey. Takes 1 Argument of type DataKey
    ///// </summary>
    ///// <param name="dataKey"></param>
    //public void RemoveAll(DataKey dataKey)
    //{
    //    foreach (ProductsInCart Product in CartList)
    //    {
    //        //Hvis produktet er fundet
    //        if (dataKey != null && Product.Id == (int)dataKey.Value)
    //        {
    //            //Så fjernes alle variabler der hører til Cart list af typen ProductsInCart, hvor Id'et matcher e.CommandAgument
    //            CartList.Remove(Product);
    //            break;
    //        }
    //    }
    //}

    ///// <summary>
    ///// Removes all items from Cart.
    ///// </summary>
    //public void ClearCart()
    //{
    //    if (CartList != null)
    //    {
    //        CartList.Clear();
    //    }

    //}

    #endregion
}