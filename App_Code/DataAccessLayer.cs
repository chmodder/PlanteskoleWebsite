﻿using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
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

    public static List<Product> GetProductList()
    {
        List<Product> ProductList = new List<Product>();

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandText = @"
                SELECT 
	                Products.Id AS ProductId, Products.Name AS ProductName,  Products.Description AS ProductDesc, Products.Price, Products.ProductNumber, Products.StockMin, Products.StockMax,
	                CultivationTime.Id AS CultivationTimeId, CultivationTime.Name AS CultivationTimeName ,
	                SoilType.Id AS SoilTypeId, SoilType.Name AS SoilTypeName,
	                Categories.Id AS CategoryId, Categories.Name AS CategoryName
                FROM Products
                INNER JOIN CultivationTime
                ON CultivationTime.Id = Products.FkCultivationTimeId
                INNER JOIN Categories
                ON Categories.Id = Products.FkCategoryId
                INNER JOIN SoilType
                ON SoilType.Id = Products.FkSoilTypeId";

        Cmd.Connection = Conn;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable Dt = new DataTable();
        da.Fill(Dt);

        foreach (DataRow Dr in Dt.Rows)
        {
            foreach (DataColumn column in Dt.Columns)
            {
                Product TempList = new Product();

                TempList.ProductId = (int)Dr["ProductId"];
                TempList.Name = Dr["ProductName"].ToString();
                TempList.Description = Dr["ProductDesc"].ToString();
                TempList.CategoryId = (int)Dr["CategoryId"];
                TempList.CategoryName = Dr["CategoryName"].ToString();
                TempList.ProductNumber = (int)Dr["ProductNumber"];
                TempList.SoilTypeId = (int)Dr["SoilTypeId"];
                TempList.SoilType = Dr["SoilTypeName"].ToString();
                TempList.StockMin = (int)Dr["StockMin"];
                TempList.StockMax = (int)Dr["StockMax"];
                TempList.CultivationTimeId = (int)Dr["CultivationTimeId"];
                TempList.CultivationTime = Dr["CultivationTimeName"].ToString();
                TempList.Price = Convert.ToSingle(Dr["Price"]);
                //TempList.SoilType = Dr["SoilTypeName"].ToString();

                ProductList.Add(TempList);
            }
        }
        return ProductList;
    }

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

    public static List<ProductImages> GetProductImages(int productId)
    {
        List<ProductImages> ProductImagesList = new List<ProductImages>();

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();
        Cmd.CommandText = @"
            SELECT * FROM Images
            INNER JOIN ProductImages
                ON ProductImages.FkImageId = Images.Id
            WHERE ProductImages.FkProductId = @ProductId";

        Cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;

        Cmd.Connection = Conn;
        Conn.Open();
        SqlDataReader Reader = Cmd.ExecuteReader();

        while (Reader.Read())
        {
            ProductImages TempList = new ProductImages();

            TempList.ImageId = (int)Reader["Id"];
            TempList.FileName = Reader["Name"].ToString();
            TempList.ProductId = (int)Reader["FkProductId"];

            ProductImagesList.Add(TempList);
        }
        Conn.Close();

        return ProductImagesList;
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

    /// <summary>
    /// Returns permissionslist for RoleId
    /// </summary>
    /// <param name="RoleId"></param>
    /// <returns></returns>
    internal static List<Privileges> GetUserPermissions(object RoleId)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();

        cmd.CommandText = @"SELECT P.Id, P.Name, P.CodeName, P.Description
                            FROM RolePrivileges RP
                            INNER JOIN Privileges P
                                ON P.Id = RP.FkPrivilegeId
                            WHERE RP.FkRoleId = @RoleId";

        cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = Convert.ToInt32(RoleId);

        cmd.Connection = conn;

        conn.Open();

        List<Privileges> PermissionsList = new List<Privileges>();

        SqlDataReader reader = cmd.ExecuteReader();

        foreach (var item in reader)
        {
            Privileges TempPrivilege = new Privileges();

            TempPrivilege.Id = (int)reader["Id"];
            TempPrivilege.CodeName = (string)reader["CodeName"];
            TempPrivilege.Name = (string)reader["Name"];
            TempPrivilege.Description = (string)reader["Description"];

            PermissionsList.Add(TempPrivilege);

        }

        conn.Close();
        return PermissionsList;
    }

    //Returns UserData in DataTable format by either userid or username
    //Uses optional parameters
    public static DataTable GetUserData(int id)
    {

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();

        DataTable dt = new DataTable();

        Cmd.CommandText = @"
            SELECT * FROM Users
            INNER JOIN Roles
                ON Users.FkRoleId = Roles.Id
            WHERE Users.Id = @id";

        Cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        Cmd.Connection = Conn;

        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(dt);

        return dt;
    }

    public static DataTable GetUserData(string userName)
    {

        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand Cmd = new SqlCommand();

        DataTable dt = new DataTable();

        Cmd.CommandText = @"
            SELECT * FROM Users
            INNER JOIN Roles
                ON Users.FkRoleId = Roles.Id
            WHERE Users.UserName = @userName";

        Cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
        Cmd.Connection = Conn;

        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        da.Fill(dt);

        return dt;
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

    #region WRITE

    /// <summary>
    /// Creates new user in table Users. Returns UserId
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="userName"></param>
    /// <param name="email"></param>
    /// <param name="passWord"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="address"></param>
    /// <param name="zip"></param>
    /// <param name="city"></param>
    /// <returns>UserId</returns>
    public static int CreateNewUser(int roleId, string userName, string email, string passWord, string firstName, string lastName, string address, int zip, string city)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(@"
                                        INSERT INTO Users (UserName, PassWord, Email, FirstName, LastName, Address, ZipCode, City, FkRoleId)
                                                    VALUES (@UserName, @PassWord, @Email, @FirstName, @LastName, @Address, @ZipCode, @City, @FkRoleId);
                                        SELECT SCOPE IDENTITY() AS 'UserId'");

        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
        cmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = passWord;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
        cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
        cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = address;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
        cmd.Parameters.Add("@ZipCode", SqlDbType.Int).Value = zip;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
        cmd.Parameters.Add("@FkRoleId", SqlDbType.Int).Value = roleId;

        cmd.Connection = conn;

        conn.Open();
        int ThisNewUserId = (int)cmd.ExecuteScalar();
        conn.Close();

        return ThisNewUserId;

    }

    #endregion

}