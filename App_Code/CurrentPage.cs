using System;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageContent
/// </summary>
public class CurrentPage
{
    private string _pageName;
    private List<PageContent> _currentPageContent;
    private string _codeName;
    private string _content;


    public CurrentPage()
    {

    }

    #region HIDE
    //public string CurrentPageContent(string CurrentPageName string CodeName)
    //{
    //    PageName = CurrentPageName;
    //    ArrayList PageContent = DataAccessLayer.GetPageContent(PageName);

    //    if (PageContent.Contains(CodeName))
    //    {
    //        var IndexId = PageContent.IndexOf(CodeName);
    //        Content = PageContent. ;
    //return someshit;
    //    }

    //}
    #endregion

    public void GetCurrentPageContent(string currentPageName)
    {

        PageName = currentPageName;
        List<PageContent> DBCurrentPageContent = DataAccessLayer.GetPageContent(PageName);
        CurrentPageContent = DBCurrentPageContent;
    }

    public string GetElementContent(string codeName)
    {
        CodeName = codeName;

        foreach (var item in CurrentPageContent)
        {
            if (item.CodeName == CodeName)
            {
                Content = item.Content;

            }

        }
        return Content;
    }



    public string PageName
    {
        get { return _pageName; }
        set { _pageName = value; }
    }

    public List<PageContent> CurrentPageContent
    {
        get { return _currentPageContent; }
        set { _currentPageContent = value; }
    }

    public string CodeName
    {
        get { return _codeName; }
        set { _codeName = value; }
    }

    public string Content
    {
        get { return _content; }
        set { _content = value; }
    }


    //}
    //private string GetPageContent(string PageName)
    //{
    //    DataTable Dt = DataAccessLayer.GetPageContent(PageName);

    //    foreach (DataRow dr in Dt.Rows)
    //    {
    //        foreach (DataColumn column in Dt.Columns)
    //        {
    //            Content = dr["Content"].ToString();
    //        }
    //    }
    //}

    public string GetCurrentPageName()
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string PageName = Info.Name;
        return PageName;
    }
    //FUCK THIS SHIT!!!
}