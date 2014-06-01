using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.ServiceModel.Security;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;


namespace MyCustomNameSpace
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Access
    {
        //private string _userName;
        //private string _passWord;
        //private object _action;

        public Access()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public object Action
        //{
        //    get { return _action; }
        //    set { _action = value; }
        //}

        #region METHODS

 
        public void Login(string userName, string passWord)
        {
            //_userName = userName;
            //_passWord = passWord;


            Users TempUser = new Users();

            DataTable UserDataDt = DataAccessLayer.GetUserData(userName);

            foreach (DataRow Dr in UserDataDt.Rows)
            {
                foreach (DataColumn column in UserDataDt.Columns)
                {

                    TempUser.UserId = (int)Dr["Id"];
                    TempUser.UserName = Dr["UserName"].ToString();
                    TempUser.PassWord = Dr["PassWord"].ToString();
                    TempUser.Email = Dr["Email"].ToString();
                    TempUser.FirstName = Dr["FirstName"].ToString();
                    TempUser.LastName = Dr["LastName"].ToString();
                    TempUser.Address = Dr["Address"].ToString();
                    TempUser.Zip = (int)Dr["ZipCode"];
                    TempUser.City = Dr["City"].ToString();
                    TempUser.RoleId = (int)Dr["FkRoleId"];
                    TempUser.RoleName = Dr["RoleName"].ToString();
                }
            }

            //if user is OK
            if (TempUser.PassWord == passWord && TempUser.UserName == userName)
            {
                HttpContext.Current.Session["UserId"] = TempUser.UserId;
                HttpContext.Current.Session["UserRole"] = TempUser.RoleName;
                HttpContext.Current.Session["RoleId"] = TempUser.RoleId;

                //Redundant??
                //Check user privileges Privileges (Arraylist)
                Users.SetUserPrivilegeSession();
            }
            else
            {
                TempUser.RoleName = "guest";
            }
                


            switch (TempUser.RoleName)
            {
                case "customer": HttpContext.Current.Session["NotificationMsg"] = "Velkommen " + userName;
                    break;
                case "admin": HttpContext.Current.Response.Redirect("~/Admin/Default.aspx");
                    break;
                case "guest": HttpContext.Current.Session["NotificationMsg"] = "Login mislykkedes";
                    break;
            }

            #region TESTING
            //HttpContext.Current.Session["NotificationMsg"] = "Velkommen " + userName;
            //string NotificationMsgInSession = (string)HttpContext.Current.Session["NotificationMsg"];

            //var Action = "";
            //switch (TempUser.RoleName)
            //{
            //    case "costumer": Action = "Welcome " + userName;
            //        break;
            //    case "admin": HttpContext.Current.Response.Redirect("Admin/Default.aspx");
            //        break;
            //    case "guest": Action = "Login mislykkedes";
            //        break;
            //}
            //return Action;

            #endregion
        }

        #region TESTING 2
        //private void RoleSpecificAction(string roleName, string userName)
        //{
        //    var Action;
        //    switch (roleName)
        //    {
        //        case "costumer": //Action = "Welcome " + userName;
        //            break;
        //        case "admin"://Go to admin;
        //            break;
        //        case "guest"://something;
        //            break;
        //    }
        //}
        #endregion

        public void LogOut()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }

        #endregion

        //public string UserName
        //{
        //    get { return _userName; }
        //    set { _userName = value; }
        //}

        //public string PassWord
        //{
        //    get { return _passWord; }
        //    set { _passWord = value; }
        //}
    }
}