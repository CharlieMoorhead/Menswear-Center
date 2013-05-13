<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Home.aspx.cs" Inherits="_Default" %>
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
<form id="form1" name="form1" method="post" action="" runat="server">
<apress:HeaderUserControl ID="Header1" runat="server" />
<div id="body_area">
  <apress:LeftUserControl ID="Left1" runat="server" />
  <div class="midarea">
    <div class="head"><asp:Label runat="server" ID="WelcomeLabel" /></div>
    <div class="body_textarea">This is the Menswear Center</div>
    <div class="innerbanner"></div>
  </div>
</div>
<apress:FooterUserControl ID="Footer1" runat="server" />
</form>

</body>
</html>
