using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class HeaderUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LogoLabel.Text = ConfigurationManager.AppSettings["websiteName"];

        if (Context.User.Identity.IsAuthenticated)
        {
            MembershipUser User = Membership.GetUser();
            HeaderLbl1.Text = "Hi " + User.UserName + " | ";
            HeaderLbl2.Text = "<a href=\"Logout.aspx\">Logout</a>";
        }
        else
        {
            HeaderLbl1.Text = "<a href=\"Register.aspx\">Register</a> | ";
            HeaderLbl2.Text = "<a href=\"Login.aspx\">Login</a>";
        }
    }
}
