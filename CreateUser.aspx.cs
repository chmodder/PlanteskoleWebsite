using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserBtn_Click(object sender, EventArgs e)
    {
        
        ////Only creates user in DB if userName is not yet in DB
        //if (Users.UserNameIsInDB("userName"))
        //{
        //    Users NewUser = new Users(userName, passWord, firstName, lastName, address, zip, city);
        //    Users.SetUserPrivilegeSession();
        //}
    }
}