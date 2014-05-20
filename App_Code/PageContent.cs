using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageContent
/// </summary>
public class PageContent
{
    private string _codeName;
    private string _content;

	public PageContent()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string CodeName
    {
        get { return _codeName; }
        set { _codeName = value; }
    }

    public string Content
    {
        get { return _content; }
        set { _content = value; }
    }
}