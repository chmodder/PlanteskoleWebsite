using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Privileges
/// </summary>
public class Privileges
{
    private int _id;
    private string _name;
    private string _codeName;
    private string _description;

    public Privileges()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string CodeName
    {
        get { return _codeName; }
        set { _codeName = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    #region Methods

    #endregion

}