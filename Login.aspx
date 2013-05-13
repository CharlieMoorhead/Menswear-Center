<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="apress" TagName="HeaderUserControl" Src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="FooterUserControl" Src="FooterUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="LeftUserControl" Src="LeftUserControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Menswear Center</title>
<link href="style.css" rel="stylesheet" type="text/css" />
</head>

<body>
<form id="form1" runat="server">
<apress:HeaderUserControl ID="Header1" runat="server" />
<div id="body_area">
  <apress:LeftUserControl ID="Left1" runat="server" />
  <div class="midarea">
    <div class="head">Login
    </div>
    <div class="body_textarea">
        <div align="left">
        
        <asp:Login ID="LoginCtrl" runat="server">
            <LayoutTemplate>
        <asp:TextBox runat="server" ID="UserName" Width="400px" Font-Size="14px" /> User Name
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="UserName" Display="Dynamic"><br />*required field</asp:RequiredFieldValidator><br /><br />
            
        <asp:TextBox runat="server" ID="Password" Width="400px" Font-Size="14px" TextMode="Password" /> Password
        <asp:RequiredFieldValidator runat="server"
            ControlToValidate="Password" Display="Dynamic"><br />*required field</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
            ControlToValidate="Password" Display="Dynamic" ValidationExpression="^.*(?=.{6,}).*$">
            <br />*not a valid password</asp:RegularExpressionValidator><br /><br />
        <asp:CheckBox ID="RememberMe" runat="server" Text=" Remember Me" /><br />
        <asp:Label ID="FailureText" runat="server" ForeColor="Red" /><br />
        
        <asp:Button runat="server" ID="Login" Text="Login" Font-Size="16px" 
                CommandName="Login" />
            </LayoutTemplate>
        </asp:Login>
        </div>
    </div>
  </div>
</div>
<apress:FooterUserControl ID="Footer1" runat="server" />
    </form>

</body>
</html>
