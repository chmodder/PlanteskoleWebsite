using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductsInCart
/// </summary>
public class ProductsInCart
{
    #region FIELDS
    private int _id;
    private string _name;
    private float _price;
    private int _amount;
    #endregion

    #region PROPERTIES
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public float Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Amount
    {
        get { return _amount; }
        set { _amount = value; }
    }

    public float PriceTotal
    {
        get { return _amount * _price; }
    }


    #endregion

    #region CONSTRUCTORS
    public ProductsInCart()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ProductsInCart(int Id, string Name, float Price, int Amount)
    {
        this._id = Id;
        this._name = Name;
        this._price = Price;
        this._amount = Amount;
    }
    #endregion
}