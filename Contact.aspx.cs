using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentPage ContactPage = new CurrentPage();
        string ContactPageName = ContactPage.GetCurrentPageName();
        ContactPage.GetCurrentPageContent(ContactPageName);

        AddressH2Lbl.Text = ContactPage.GetElementContent("AddressH2Lbl");

        ShopInfo Address = new ShopInfo();

        //Create and populate RptAddressSource List with Address fields
        List<ShopInfo> RptAddressSource = new List<ShopInfo>();
        RptAddressSource.AddRange(new[] { Address });

        //Bind RptDatasource, which is the list above to AddressRepeater
        AddressRpt.DataSource = RptAddressSource;
        AddressRpt.DataBind();

        BusinessHoursH2.Text = ContactPage.GetElementContent("BusinessHoursH2");

        BusinessHoursRpt.DataSource = DataAccessLayer.GetBusinessHours();
        BusinessHoursRpt.DataBind();

        ContactFormH2.Text = ContactPage.GetElementContent("ContactFormH2");



    }
}