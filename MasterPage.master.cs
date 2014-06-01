using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCustomNameSpace;
using Access = MyCustomNameSpace.Access;

public partial class MasterPage : System.Web.UI.MasterPage
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
        //if (Session["UserRole"].ToString() == "admin")
        //{
        //    Response.Redirect("~/Admin/Default.aspx");
        //}
        #endregion

        ////Test stuff
        //Response.Write("MasterPage_Init");
        Response.Write(Session["RoleId"].ToString());

        //ACL
        LoginBox.Visible = Users.Allowed("LogIn");
        LogoutBox.Visible = Users.Allowed("LogOut");

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        #region RightSidebar
        //Opretter et nyt objekt af typen Cart
        Cart C2Cart = new Cart();
        //Henter Sessionen kurv til kurv
        C2Cart.TakeCart();
        //Viser kurven i Repeateren CartContentRpt
        C2Cart.ShowCart((Repeater)FindControl("CartContentRpt"));


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
    protected void CartCheckoutBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Checkout.aspx");
    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        string UserName = UserNameTbx.Text;
        string PassWord = PasswordTxb.Text;

        Access NewLogin = new Access();
        NewLogin.Login(UserName, PassWord);

        Response.Redirect(Request.RawUrl);
        //Return to last page or frontpage?___//



    }
    protected void LogOutBtn_Click(object sender, EventArgs e)
    {
        Access LogOut = new Access();
        LogOut.LogOut();
    }
}
