using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

    #region GetPageContent(NoTryCatch)
    //    public static List<PageContent> GetPageContent(string pageName)
    //    {
    //        Cmd.CommandText = @"
    //            SELECT CodeName, Content FROM PageContent
    //            INNER JOIN Pages
    //                ON Pages.Id = PageContent.FkPageId
    //            WHERE Pages.PageName = @PageName";

    //        Cmd.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = pageName;

    //        Cmd.Connection = Conn;

    //        List<PageContent> PageContentList = new List<PageContent>();

    //        Conn.Open();
    //        SqlDataReader Reader = Cmd.ExecuteReader();

    //        if (Reader.Read())
    //        {
    //            while (Reader.Read())
    //            {
    //                PageContent TempContent = new PageContent();
    //                TempContent.Content = (string)Reader["Content"];
    //                TempContent.CodeName = (string)Reader["CodeName"];

    //                PageContentList.Add(TempContent);
    //            }
    //        }
    //        Conn.Close();

    //        return PageContentList;
    //    }
    #endregion

    //Returns all Table-rows WHERE Pagename match input parameter
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

    #endregion

}