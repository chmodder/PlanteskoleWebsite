using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
	 #region FIEDLS
    private int _id;
    private int _costumerId;
    //private int _paymentId;
    //private int _shippingId;
    private int _orderState;
    private float _priceTotal;
    #endregion

    #region PROPERTIES
    public int Id
    {
        get { return this._id; }
    }

    public int CostumerId
    {
        get { return this._costumerId; }
        set { this._costumerId = value; }
    }

    public int OrderState
    {
        get { return _orderState; }
        set { _orderState = value; }
    }

    public float PriceTotal
    {
        get { return _priceTotal; }
        set { _priceTotal = value; }
    }

    //public int PaymentId
    //{
    //    get { return this._paymentId; }
    //    set { this._paymentId = value; }
    //}

    //public int ShippingId
    //{
    //    get { return this._shippingId; }
    //    set { this._shippingId = value; }
    //}
    #endregion

    #region CONSTRUCTORS
    public Order()
    {
    }


    public Order(int CostumerId, int OrderState, Cart cart)
    {
        PriceTotal = cart.PriceAllContent;

        //OPRET ORDRE I DB

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = @"INSERT INTO Orders ([FkUserId], [PriceTotal], [FkOrderStateId])
                                VALUES (@CostumerId, @PriceTotal, @OrderState); SELECT SCOPE_IDENTITY();";

        cmd.Parameters.Add("@CostumerId", SqlDbType.Int).Value = CostumerId;
        cmd.Parameters.Add("@PriceTotal", SqlDbType.Float).Value = PriceTotal;
        cmd.Parameters.Add("@OrderState", SqlDbType.Int).Value = OrderState;

        conn.Open();
        int id = Convert.ToInt32(cmd.ExecuteScalar());
        this._id = id;

        // OPRET ORDRELINJER I DB

        foreach (ProductsInCart product in cart.CartList)
        {
            SqlCommand cmdP = new SqlCommand();
            cmdP.Connection = conn;
            cmdP.CommandText =
                "INSERT INTO OrderDetails ([FKProductId], [Amount], [FkOrderId], [PriceEach], [PriceTotal]) " +
                "                   VALUES (@pid, @amount, @oid, @PriceEach, @priceTotal);";
            cmdP.Parameters.Add("@pid", SqlDbType.Int).Value = product.Id;
            cmdP.Parameters.Add("@amount", SqlDbType.Int).Value = product.Amount;
            cmdP.Parameters.Add("@oid", SqlDbType.Int).Value = this.Id;
            cmdP.Parameters.Add("@priceEach", SqlDbType.Decimal).Value = product.Price;  
            cmdP.Parameters.Add("@priceTotal", SqlDbType.Decimal).Value = product.PriceTotal;

            cmdP.ExecuteNonQuery();
            
        }

        conn.Close();
    }
    #endregion
}
