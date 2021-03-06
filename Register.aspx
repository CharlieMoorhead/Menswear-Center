<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Register.aspx.cs" Inherits="_Default" %>
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
    <div class="head"> Register
    </div>
    <div class="body_textarea">
        <div align="left">
        <asp:CreateUserWizard ID="RegisterUser" runat="server" 
                ContinueDestinationPageUrl="Home.aspx" 
                InvalidPasswordErrorMessage="Your password must contain at least 6 characters." EmailRegularExpression="[\w]{2,}@[\w]{2,}\.[\w]{2,}">
            <TextBoxStyle Width="300px" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" Title="" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
        </div>
    </div>
  </div>
</div>
<apress:FooterUserControl ID="Footer1" runat="server" />
    </form>

</body>
</html>
