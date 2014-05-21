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
    #region FIELDS

    private string _pageName;
    private List<PageContent> _currentPageContent;
    private string _codeName;
    private string _content;

    #endregion


    #region CONSTRUCTORS

    public CurrentPage()
    {

    }

    #endregion

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

    #region METHODS

    /// <summary>
    /// Henter alle felter med CodeName og Content i en liste der tilhører sidenavnet i input-parametret og tilføjer listen til _currentPageContent field.
    /// </summary>
    /// <param name="currentPageName"></param>
    public void GetCurrentPageContent(string currentPageName)
    {

        PageName = currentPageName;
        List<PageContent> DBCurrentPageContent = DataAccessLayer.GetPageContent(PageName);
        CurrentPageContent = DBCurrentPageContent;
    }

    //public string GetElementMediaContent(string codeName)
    //{
    //    CodeName = codeName;

    //    foreach (var item in CurrentPageMediaContent)
    //    {
    //        if (item.CodeName == CodeName)
    //        {
    //            Content = item.Content;
    //        }

    //    }
    //    return Content;
    //}

    /// <summary>
    /// Henter Listen fra _currentPageContent field og returner liste-items, hvor _codeName field matcher liste-items
    /// This Method still has a bug that returns wrong value, if an Elements codeName does not match the item.CodeName in CurrentPageContent list (from field _currentPageContent)
    /// </summary>
    /// <param name="codeName"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Finder sidenavnet på siden, metoden kaldes fra
    /// </summary>
    /// <returns></returns>
    public string GetCurrentPageName()
    {
        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string PageName = Info.Name;
        return PageName;
    }
    #endregion


    #region PROPERTIES
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
    #endregion


}