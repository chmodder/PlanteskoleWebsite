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


    private static SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    private static SqlCommand Cmd = new SqlCommand();

    public DataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region READ
    public static DataTable GetShopInfo()
    {
        Cmd.CommandText = @"
            SELECT * FROM ShopInfo";

        Cmd.Connection = Conn;
        SqlDataAdapter da = new SqlDataAdapter(Cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    //    public static ArrayList GetPageContent(string pageName)
    //    {
    //        Cmd.CommandText = @"
    //            SELECT Content FROM PageContent
    //            INNER JOIN Pages
    //                ON Pages.Id = PageContent.FkPageId
    //            WHERE Pages.PageName = @PageName";

    //        Cmd.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = pageName;

    //        Cmd.Connection = Conn;

    //        ArrayList PageContentList = new ArrayList();
    //        SqlDataReader Reader = Cmd.ExecuteReader();

    //        if (Reader.Read())
    //        {
    //            while (Reader.Read())
    //            {
    //                PageContentList.Add("CodeName").ToString();
    //                PageContentList.Add("Content").ToString();
    //            }
    //        }

    //        return PageContentList;
    //    }

    public static List<PageContent> GetPageContent(string pageName)
    {
        Cmd.CommandText = @"
            SELECT Content FROM PageContent
            INNER JOIN Pages
                ON Pages.Id = PageContent.FkPageId
            WHERE Pages.PageName = @PageName";

        Cmd.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = pageName;

        Cmd.Connection = Conn;


        List<PageContent> PageContentList = new List<PageContent>();
        SqlDataReader Reader = Cmd.ExecuteReader();

        if (Reader.Read())
        {
            while (Reader.Read())
            {
                PageContent TempContent = new PageContent();
                TempContent.Content = (string)Reader["Content"];
                TempContent.CodeName = (string)Reader["CodeName"];

                PageContentList.Add(TempContent);
            }
        }

        return PageContentList;
    }
    #endregion


    //    //FUCK THIS SHIT!!!
    //    internal static string GetPageContent(string PageName, string Codename)
    //    {
    //        Cmd.CommandText = @"
    //            SELECT * FROM ShopInfo";

    //        Cmd.Connection = Conn;
    //        Cmd.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = PageName;
    //        Cmd.Parameters.Add("@PageName", SqlDbType.NVarChar).Value = Codename;

    //        List<CurrentPage>

    //        SqlDataReader Reader = new SqlDataReader;
    //        Cmd.ExecuteReader();
    //        Conn.Open();
    //        return ;
    //    }
}