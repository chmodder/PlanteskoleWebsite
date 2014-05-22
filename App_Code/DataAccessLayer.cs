using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public class DataAccessLayer
{

    public DataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region READ
    public static DataTable GetShopInfo()
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandText = @"
            SELECT * FROM ShopInfo";

        Cmd.Connection = Conn;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //    public static List<BusinessHours> GetBusinessHours()
    //    {
    //        List<BusinessHours> BusinessHoursList = new List<BusinessHours>();

    //        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //        SqlCommand Cmd = new SqlCommand();
    //        Cmd.CommandText = @"
    //            SELECT * FROM BusinessHours";

    //        Cmd.Connection = Conn;
    //        SqlDataAdapter da = new SqlDataAdapter(Cmd);
    //        DataTable Dt = new DataTable();
    //        da.Fill(Dt);

    //        foreach (DataRow Dr in Dt.Rows)
    //        {
    //            foreach (DataColumn column in Dt.Columns)
    //            {
    //                BusinessHours TempList = new BusinessHours();
    //                TempList.Day = Dr["Day"].ToString();
    //                TempList.Time = Dr["Time"].ToString();
    //            }
    //        }
    //        return BusinessHoursList;
    //    }

    public static List<BusinessHours> GetBusinessHours()
    {
        List<BusinessHours> BusinessHoursList = new List<BusinessHours>();

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandText = @"
            SELECT * FROM BusinessHours";

        Cmd.Connection = Conn;
        Conn.Open();
        SqlDataReader Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            BusinessHours TempList = new BusinessHours();

            TempList.Day = Reader["Day"].ToString();
            TempList.Time = Reader["Time"].ToString();

            BusinessHoursList.Add(TempList);
        }
        Conn.Close();

        return BusinessHoursList;
    }



    /// <summary>
    /// Returns all Table-rows WHERE Pagename match input parameter
    /// </summary>
    /// <param name="pageName"></param>
    /// <returns></returns>
    public static List<PageContent> GetPageContent(string pageName)
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandText = @"
            SELECT CodeName, Content FROM PageContent
            INNER JOIN Pages
                ON Pages.Id = PageContent.FkPageId
            WHERE Pages.PageName = @PageNameInput";

        Cmd.Parameters.Add("@PageNameInput", SqlDbType.NVarChar).Value = pageName;

        Cmd.Connection = Conn;

        List<PageContent> PageContentList = new List<PageContent>();
        try
        {
            Conn.Open();
            SqlDataReader Reader = Cmd.ExecuteReader();


            while (Reader.Read())
            {
                PageContent TempContent = new PageContent();

                TempContent.Content = (string)Reader["Content"];
                TempContent.CodeName = (string)Reader["CodeName"];

                PageContentList.Add(TempContent);
            }

        }

        catch (Exception)
        {
            //Handle exception, perhaps log it and do the needful
        }
        finally
        {
            //Connection should always be closed here so that it will close always
            Conn.Close();
        }


        return PageContentList;
    }

    #region TESTING
    //    public static List<Product> GetAllProducts()
    //    {
    //        List<Product> ListProducts = new List<Product>();

    //        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    //        SqlCommand Cmd = new SqlCommand();


    //        Cmd.CommandText = @"Select * From Products
    //                          INNER JOIN Categories
    //                            ON Categories.Id = Products.FkCategoryId";

    //        Cmd.Connection = Conn;

    //        Conn.Open();

    //        SqlDataReader Reader = Cmd.ExecuteReader();

    //        while (Reader.Read())
    //        {
    //            Product TempProduct = new Product();

    //            TempProduct.Id = Convert.ToInt32(Reader["Id"]);
    //            TempProduct.Name = Reader["Name"].ToString();
    //            TempProduct.Description = Reader["Description"].ToString();
    //            TempProduct.Img = Reader["Img"].ToString();
    //            TempProduct.Price = Convert.ToSingle(Reader["Price"]);
    //            //TempProduct.Price = (float)float.Parse(Reader["Price"]);
    //            TempProduct.Stock = Convert.ToInt32(Reader["Stock"]);

    //            ListProducts.Add(TempProduct);
    //        }

    //        Conn.Close();

    //        return ListProducts;
    //    }

    #endregion

    #endregion

}