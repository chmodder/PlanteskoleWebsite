using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BusinessHours
/// </summary>
public class BusinessHours
{
    private string _day;
    private string _time;

	public BusinessHours()
	{
        
	}

    public string Day
    {
        get { return _day; }
        set { _day = value; }
    }

    public string Time
    {
        get { return _time; }
        set { _time = value; }
    }
}