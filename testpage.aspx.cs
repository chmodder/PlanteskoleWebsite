using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void repAddress_OnItemCommand(object source, RepeaterCommandEventArgs e)
    {
        var lblFloat = (Label)e.Item.FindControl("lblFloat");
        Response.Write(Single.Parse(lblFloat.Text));
    }
}