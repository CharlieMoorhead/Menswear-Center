<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>
<%@ Register TagPrefix="apress" TagName="HeaderUserControl" Src="HeaderUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="FooterUserControl" Src="FooterUserControl.ascx" %>
<%@ Register TagPrefix="apress" TagName="LeftUserControl" Src="LeftUserControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menswear Center</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <apress:HeaderUserControl ID="Header1" runat="server" />
        <div id="body_area">
            <apress:LeftUserControl ID="Left1" runat="server" />
            <div class="midarea">
                <div class="head">
                
                <asp:Label runat="server" ID="WelcomeLabel"  />
                
                </div>
            
                <div class="body_textarea">
                <asp:Label runat="server" ID="messageLabel" />
                <asp:ObjectDataSource ID="sourceItems" runat="server" TypeName="ItemDB" 
            SelectMethod="getItems" />                
                <%-- <asp:SqlDataSource ID="sourceItems" runat="server"
                    ProviderName="System.Data.SqlClient"
                    ConnectionString="<%$ ConnectionStrings:default %>"
                    SelectCommand="GetItemsInCategory" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="CategoryID" QueryStringField="cat" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
                
                <asp:GridView ID="ItemGrid" runat="server" DataSourceID="sourceItems" 
                        OnRowCreated="ItemGrid_RowCreated" ShowHeader="false"
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                        GridLines="None" OnSelectedIndexChanged="ItemGrid_SelectedIndexChanged" EnableViewState="false" >
                    <RowStyle BackColor="#E3EAEB" />
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="Item Name" 
                            ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" >
                        </asp:BoundField>
                        <asp:BoundField DataField="price" HeaderText="Price" 
                            DataFormatString="{0:C}" ItemStyle-Width="60px"
                            ItemStyle-HorizontalAlign="Center" >
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="pictureURL" HeaderText="" 
                            ControlStyle-Width="150px"  />
                        <asp:HyperLinkField DataNavigateUrlFields="pictureURL" Text="View Larger" 
                            ControlStyle-Font-Size="Smaller" />
                        <asp:TemplateField >
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" Text="Add to Cart" CommandName="Select" />
                        
                    </Columns>
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                
                </div>
            </div>
        </div>
        <apress:FooterUserControl ID="Footer1" runat="server" />
    </form>
</body>
</html>
