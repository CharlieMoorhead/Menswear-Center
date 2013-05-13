using System;
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


public class Customer
{
    public int customerID{ get; set; }
    public string firstName{ get; set; }
    public string lastName{ get; set; }
    public string email{ get; set; }
    public string password{ get; set; }

	public Customer(int customerID, string firstName, string lastName,
        string email, string password)
	{
        this.customerID = customerID;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
	}
}
