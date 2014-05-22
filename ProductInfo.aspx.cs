using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string LastPage = Session["LastPage"].ToString();
        string ThisPageFullUrl = Request.Url.AbsoluteUri;
        Session["LastPage"] = ThisPageFullUrl;
        Response.Redirect(LastPage);
    }
}