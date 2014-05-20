using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentPage DefaultPage = new CurrentPage();
        string ThisPageName = DefaultPage.GetCurrentPageName();
        DefaultPage.GetCurrentPageContent(ThisPageName);



        TopH1Lbl.Text = DefaultPage.GetElementContent("TopH1Lbl");

        #region Udkommenteret

        //CurrentPage DefaultPage = new CurrentPage();
        //DefaultPage.PageName = DefaultPage.GetCurrentPageName();

        //Lav liste over DB-elementer der hører til siden

        //DefaultPage.Codename = "TopH1Lbl";
        //TopH1Lbl.Text = DefaultPage.Content;

        ////Implement Img content

        //DefaultPage.Codename = "AboutUsH2Lbl";
        //AboutUsH2Lbl.Text = DefaultPage.Content;

        //DefaultPage.Codename = "AboutUsPLbl";
        //AboutUsPLbl.Text = DefaultPage.Content;

        //List<CurrentPage> ContentList = new List<CurrentPage>();

        //FUCK THIS SHIT!!
        #endregion

        ShopInfo Address = new ShopInfo();

        //Create and populate RptAddressSource List with Address fields
        List<ShopInfo> RptAddressSource = new List<ShopInfo>();
        RptAddressSource.AddRange(new[] {Address});

        //Bind RptDatasource, which is the list above to AddressRepeater
        AddressRpt.DataSource = RptAddressSource;
        AddressRpt.DataBind();
    }
}