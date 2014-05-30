using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class Users
{
    private int _userId;
    private string _userName;
    private string _email;
    private string _passWord;
    private string _firstName;
    private string _lastName;
    private string _address;
    private int _zip;
    private string _city;
    private int _roleId;

    public Users()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Gets user form DB that matches the input from database and sets field values
    /// </summary>
    /// <param name="id"></param>
    public Users(int id)
    {
        DataTable ThisUserDt = DataAccessLayer.GetUserData(id);

        foreach (DataRow Dr in ThisUserDt.Rows)
        {
            foreach (DataColumn Column in ThisUserDt.Columns)
            {
                _userId = Convert.ToInt32(Dr["Id"]);
                UserName = Dr["UserName"].ToString();
                PassWord = Dr["PassWord"].ToString();
                FirstName = Dr["Email"].ToString();
                FirstName = Dr["FirstName"].ToString();
                LastName = Dr["LastName"].ToString();
                Address = Dr["Address"].ToString();
                Zip = Convert.ToInt32(Dr["ZipCode"]);
                City = Dr["City"].ToString();
                RoleId = Convert.ToInt32(Dr["FkRoleId"]);
            }
        }

    }

    /// <summary>
    /// Checks if user is in DB. If user is not found, then a new user/customer is created in DB using input parameters
    /// </summary>
    public Users(string userName, string email, string passWord, string firstName, string lastName, string address, int zip, string city)
    {
        //Check if user is in db
        //Remember to implement check before creating user to avoid duplicates in Users Table
        //

        //RoleId 2 is customer
        RoleId = 2;

        //sets property/field values
        UserName = userName;
        Email = email;
        PassWord = passWord;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Zip = zip;
        City = city;

        //Creates User in DB and Sets this _userId field value
        _userId = DataAccessLayer.CreateNewUser(RoleId, UserName, Email, PassWord, firstName, lastName, Address, Zip, City);

        //Creates/Updates Session "privileges" with privileges set to new user
        SetUserPrivilegeSession();
    }

    #region METHODS

    /// <summary>
    /// Checks if UserName is in DB
    /// </summary>
    /// <param name="userName"></param>
    /// <returns>bool</returns>
    public static bool UserNameIsInDB(string userName)
    {
        bool UserIsInDB = false;
        DataTable UserFoundDt = DataAccessLayer.GetUserData(userName);

        if (UserFoundDt.Columns.Contains(userName))
        {
            UserIsInDB = true;
        }

        return UserIsInDB;
    }

    public static bool Allowed(string codeName)
    {
        bool tempbool = false;

        List<Privileges> PermisionsList = new List<Privileges>();
        PermisionsList = (List<Privileges>)HttpContext.Current.Session["Privileges"];
        foreach (Privileges item in PermisionsList)
        {
            if (item.CodeName == codeName)
                tempbool = true;
            else
                tempbool = false;
        }

        return tempbool;
    }

    public static void SetUserPrivilegeSession()
    {
        //Gets RoleId from seeion
        object RoleId = HttpContext.Current.Session["RoleId"];

        //Check user privileges Privileges (Arraylist)
        HttpContext.Current.Session["Privileges"] = DataAccessLayer.GetUserPermissions(RoleId);
    }



    #endregion

    #region PROPERTIES
    public int UserId
    {
        get { return _userId; }
    }

    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string PassWord
    {
        get { return _passWord; }
        set { _passWord = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }

    public int Zip
    {
        get { return _zip; }
        set { _zip = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public int RoleId
    {
        get { return _roleId; }
        set { _roleId = value; }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    #endregion
}