<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>
<%@ Register TagPrefix="apress" TagName="HeaderUserControl" Src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="FooterUserControl" Src="FooterUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="LeftUserControl" Src="LeftUserControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menswear Center</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" >
        <input type="hidden" name="cmd" value="_cart" />
        <input type="hidden" name="upload" value="1" />
        <input type="hidden" name="business" value="charli_1303579791_biz@gmail.com" />
        
        <apress:HeaderUserControl ID="Header1" runat="server" />
        <div id="body_area">
            <apress:LeftUserControl ID="Left1" runat="server" />
            <div class="midarea">
                <div class="head"><asp:Label runat="server" ID="WelcomeLabel" /></div>
                <div class="body_textarea">
                
                <asp:Panel runat="server" ID="MainPanel" />
                
                </div>
            </div>
        </div>
        <apress:FooterUserControl ID="Footer1" runat="server" />
    </form>
</body>
</html>
