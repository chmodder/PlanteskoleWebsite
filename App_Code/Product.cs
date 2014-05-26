using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    private int _productId;
    private string _name;
    private int _soilTypeId;
    private string _soilType;
    private int _cultivationTimeId;
    private string _cultivationTime;
    private int _productNumber;
    private string _description;
    private int _stockMax;
    private int _stockMin;
    private int _categoryId;
    private string _categoryName;
    //private ArrayList _images;
    private float _price;

	public Product()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int SoilTypeId
    {
        get { return _soilTypeId; }
        set { _soilTypeId = value; }
    }

    public string SoilType
    {
        get { return _soilType; }
        set { _soilType = value; }
    }

    public int CultivationTimeId
    {
        get { return _cultivationTimeId; }
        set { _cultivationTimeId = value; }
    }

    public string CultivationTime
    {
        get { return _cultivationTime; }
        set { _cultivationTime = value; }
    }

    public int ProductNumber
    {
        get { return _productNumber; }
        set { _productNumber = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int StockMax
    {
        get { return _stockMax; }
        set { _stockMax = value; }
    }

    public int StockMin
    {
        get { return _stockMin; }
        set { _stockMin = value; }
    }

    public int CategoryId
    {
        get { return _categoryId; }
        set { _categoryId = value; }
    }

    public string CategoryName
    {
        get { return _categoryName; }
        set { _categoryName = value; }
    }

    public float Price
    {
        get { return _price; }
        set { _price = value; }
    }
}