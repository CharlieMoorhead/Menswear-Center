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


public class CartItem
{
    public string name { get; set; }
    public decimal price { get; set; }
    public string size { get; set; }
    public int quantity { get; set; }   

	public CartItem(string name, decimal price,
                    string size, int quantity)
	{
        this.name = name;
        this.price = price;
        this.size = size;
        this.quantity = quantity;
	}
}
