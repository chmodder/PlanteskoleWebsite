using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        string UserName = CreateUserNameTbx.Text;
        string PassWord = CreateUserPassWordTbx.Text;
        string Email = CreateUserEmailTbx.Text;
        string EmailConfirm = ConfirmUserEmailTbx.Text;
        string FirstName = CreateUserNameTbx.Text;
        string LastName = CreateUserPassWordTbx.Text;
        string Address = CreateUserNameTbx.Text;
        int Zip = Convert.ToInt32(CreateUserPassWordTbx.Text);
        string City = CreateUserPassWordTbx.Text;

        if (InputValidate(UserName, Email, EmailConfirm, PassWord, FirstName, LastName, Address, Zip, City))
        {
            Users NewUser = new Users(UserName, Email, PassWord, FirstName, LastName, Address, Zip, City);
            Users.SetUserPrivilegeSession();
        }

        
       
    }

    //Not all fields is validated. NEEDS more WORK
    private bool InputValidate(string userName, string email, string emailConfirm, string passWord, string firstName, string lastName, string address, int zip, string city)
    {
        //Only creates user in DB if userName is not yet in DB
        if (Users.UserNameIsInDb(userName))
        {
            ErrorLbl.Text = "Brugernavnet er taget";
            return false;
        }
        
        const string emailRegEx = @"^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,5}$";

        if (!Regex.IsMatch(emailConfirm, emailRegEx))
        {
            ErrorLbl.Text = "Forkert email format i Email-feltet";
            return false;
        }
        if (emailConfirm.Trim() != email.Trim())
        {
            ErrorLbl.Text = "Email felternes tekst er ikke ens";
            return false;
        }
        else
        {
            return true;
        }
    }

}