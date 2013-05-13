<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftUserControl.ascx.cs" Inherits="LeftUserControl" %>

<div class="left">
    <div class="left_menutop"></div>
    <div class="left_menu_area">
      <div align="right">
        <a href="Home.aspx" class="left_menu">Home</a><br />
        <a href="Browse.aspx?cat=1" class="left_menu">Accessories</a><br />
        <a href="#" class="left_menu">Dress Shirts</a><br />
        <a href="#" class="left_menu">Graphic Tees</a><br />
        <a href="#" class="left_menu">Jeans</a><br />
        <a href="#" class="left_menu">Pajamas</a><br />
        <a href="#" class="left_menu">Pants</a><br />
        <a href="Browse.aspx?cat=7" class="left_menu">Shirts</a><br />
        <a href="#" class="left_menu">Shorts</a><br />
        <a href="#" class="left_menu">Contact us</a>
       </div>
<asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="Advertisements.xml" Target="_blank" />
    </div>
</div>