<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderUserControl.ascx.cs" Inherits="HeaderUserControl" %>

 <div id="topheader">
   <div class="logo"><asp:Label runat="server" ID="LogoLabel" /></div>
   <div class="menu_area">
    <a href="Home.aspx" class="menu_link">Home</a>
    <a href="Browse.aspx" class="menu_link">Shop</a>
    <a href="#" class="menu_link">About</a>
   </div>
 </div>
 <div id="search_strip">
  <div class="userlinks">
    <asp:Label ID="HeaderLbl1" runat="server" />
    <asp:Label ID="HeaderLbl2" runat="server" />
    | <a href="ViewCart.aspx">View cart</a>
   </div>
  <div class="search_area">
    <div class="search_box">
      <label>
      <input name="textfield" type="text" class="searchtextbox" />
      </label>
    </div>
    <div class="search_go">
      <div align="center"><a href="#" class="go">GO</a></div>
    </div>
    <div class="search_box">&raquo; <a href="#" class="advancesearch">Advanced Search</a></div>
  </div>
 </div>