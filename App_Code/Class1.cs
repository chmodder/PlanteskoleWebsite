using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProductImages
{
    private int _imageId;
    private string _fileName;
    private int _productId;

    public ProductImages()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ImageId
    {
        get { return _imageId; }
        set { _imageId = value; }
    }

    public string FileName
    {
        get { return _fileName; }
        set { _fileName = value; }
    }

    public int ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }
}