using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCustomNameSpace;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        string UserName = UserNameTbx.Text;
        string PassWord = PassWordTbx.Text;
        Access Login = new Access();
        Login.Login(UserName, PassWord);

        if (Session["LastWebform"] != null)
        {
            string LastPage = Session["LastWebform"].ToString();
            Session["LastWebform"] = null;
            Response.Redirect(LastPage);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}