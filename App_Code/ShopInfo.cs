using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls.Expressions;

public class ShopInfo
{
    #region FIELDS

    private int _id;
    private string _shopName;
    private string _address;
    private int _zip;
    private string _city;
    private int _phone;
    private string _email;

    #endregion

    #region CONSTRUCTORS

    public ShopInfo()
    {
        DataTable Dt = DataAccessLayer.GetShopInfo();
        foreach (DataRow Dr in Dt.Rows)
        {
            foreach (DataColumn column in Dt.Columns)
            {
                Id = Convert.ToInt32(Dr["Id"]);
                ShopName = Dr["ShopName"].ToString();
                Address = Dr["Address"].ToString();
                Zip = Convert.ToInt32(Dr["Zip"]);
                City = Dr["City"].ToString();
                Phone = Convert.ToInt32(Dr["Phone"]);
                Email = Dr["Email"].ToString();
            }
        }

        #region Testkode
        //_shopName = Convert.ToString(Dt.Row["ShopName"]);

        //    _zip = Dt.Select(Item[DataColumn("Zip")]);

        //    _address.Add(Dr["Id"]);

        //    foreach (var Item in Dt)
        //    {
        //        _zip = Dt.Select(Item[DataColumn("Zip")]);
        //        _address = Convert.ToString(Dt.Rows[Convert.ToInt32("Address")]);
        //    
        //    }


        //    _shopName = ;
        //    _address =...;
        //
        #endregion
    }


    #endregion

    #region PROPERTIES

    //public DataTable ListOfAll
    //{

    //    get
    //    {
    //        List<this> AllShopInfoList = new List<this>();
    //        AllShopInfoList.;
    //    }
    //}

    public string ZipCity
    {
        get { return Convert.ToString(Zip) + " " + City; }
    }

    public string ShopName
    {
        get { return _shopName; }
        set { _shopName = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public int Zip
    {
        get { return _zip; }
        set { _zip = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public int Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    #endregion
}
