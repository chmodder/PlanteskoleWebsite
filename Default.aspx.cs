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
        AboutUsH2Lbl.Text = DefaultPage.GetElementContent("AboutUsH2Lbl");
        AboutUsPLbl.Text = DefaultPage.GetElementContent("AboutUsPLbl");

        #region Udkommenteret

        ////Implement Img content

        #endregion

        AddressH2Lbl.Text = DefaultPage.GetElementContent("AddressH2Lbl");

        ShopInfo Address = new ShopInfo();

        //Create and populate RptAddressSource List with Address fields
        List<ShopInfo> RptAddressSource = new List<ShopInfo>();
        RptAddressSource.AddRange(new[] {Address});

        //Bind RptDatasource, which is the list above to AddressRepeater
        AddressRpt.DataSource = RptAddressSource;
        AddressRpt.DataBind();
    }
}