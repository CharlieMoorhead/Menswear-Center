using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class Item
{
    public int itemID { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public string pictureURL { get; set; }
    public int categoryID { get; set; }
    public List<string> sizes { get; set; } 
   

	public Item(int itemID, string name, decimal price,
                    string pictureURL, int cat, List<string> sizes)
	{
        this.itemID = itemID;
        this.name = name;
        this.price = price;
        this.pictureURL = pictureURL;
        this.categoryID = cat;
        this.sizes = sizes;
	}
}
