using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCustomNameSpace;

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    public static string LastPage;
    protected void Page_Init(object sender, EventArgs e)
    {

        #region SetPrivileges
        //Checks if user is logged in
        //If no user is found in session, Role is set to guest
        //Privileges is set according to users role

        //sets Role to Guest, and sets userprivileges accordingly, if no user is found in session
        if (Session["UserId"] == null)
        {
            if (Session["RoleId"] == null)
            {
                //RoleId 3 is guest-role
                Session["RoleId"] = 3;
            }

        }
        Users.SetUserPrivilegeSession();
        if ((int)Session["RoleId"] != 1)
        {
            Response.Redirect("../Default.aspx");
        }
         
        
        #endregion

        ////Test stuff
        //Response.Write("MasterPage_Init");
        Response.Write(Session["RoleId"].ToString());

        //ACL
        //LogoutBox.Visible = Users.Allowed("LogOut");

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        #region RightSidebar
        
        //Shows notification messages from session
        if (Session["NotificationMsg"] != null)
        {
            MessageLbl.Text = Session["NotificationMsg"].ToString();
        }
        //clears messages after being showed in MessageLbl
        Session["NotificationMsg"] = "";

        if (Session["LastPage"] != null)
        {
            LastPage = Session["LastPage"].ToString();
            Session["LastPage"] = "";
        }

        #endregion

        #region Footerstuff
        //Footer stuff
        ShopInfo FooterInfo = new ShopInfo();
        FooterNameLbl.Text = FooterInfo.ShopName;
        FooterAddressLbl.Text = FooterInfo.Address;
        FooterZipCityLbl.Text = FooterInfo.ZipCity;
        FooterPhoneLbl.Text = Convert.ToString(FooterInfo.Phone);
        #endregion

        //Response.Write("MasterPage_Load");
    }
    

    protected void LogOutBtn_Click(object sender, EventArgs e)
    {
        Access LogOut = new Access();
        LogOut.LogOut();
    }
}
