using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class ViewCart : System.Web.UI.Page
{
    CustomerDB db = new CustomerDB();
    Customer customer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            MembershipUser User = Membership.GetUser();
            WelcomeLabel.Text = User.UserName + "'s Cart";
        }
        else
        {
            WelcomeLabel.Text = "Your Cart";
        }
        Display_Cart();
    }

    protected void Display_Cart()
    {
        //double totalCost = 0;
        //double itemCost = 0;
        
        HtmlTable cartTable = new HtmlTable();
        cartTable.ID = "CartTable";
        cartTable.Border = 1;
        cartTable.CellPadding = 5;
        cartTable.CellSpacing = 0;
        cartTable.BorderColor = "Gray";

        HtmlTableRow row;
        HtmlTableCell cell;
       // int rowCount = 0;

        //create the header row and add to the table
        row = new HtmlTableRow();
        cell = new HtmlTableCell();
        cell.InnerHtml = "<b>Item</b>";
        cell.Height = "25px";
        cell.Width = "100px";
        row.Cells.Add(cell);
        cell = new HtmlTableCell();
        cell.InnerHtml = "<b>Price</b>";
        cell.Height = "20px";
        cell.Width = "100px";
        row.Cells.Add(cell);
        cell = new HtmlTableCell();
        cell.InnerHtml = "<b>Size</b>";
        cell.Height = "20px";
        cell.Width = "100px";
        row.Cells.Add(cell);
        cell = new HtmlTableCell();
        cell.InnerHtml = "<b>Quantity</b>";
        cell.Height = "20px";
        cell.Width = "80px";
        row.Cells.Add(cell);
        cartTable.Rows.Add(row);

        //ArrayList cart = db.getCart(cust.customerID);
        if (Session["Cart"] != null)//cart.Count != 0)
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart.cartItems.Count != 0)
            {
                for (int j = 0; j < cart.cartItems.Count; j++)
                {
                    row = new HtmlTableRow();
                    cell = new HtmlTableCell();
                    cell.InnerHtml = cart.cartItems[j].name;
                    cell.InnerHtml += " <input type=\"hidden\" name=\"item_name_" 
                            + (j+1) + "\" value=\"" + cart.cartItems[j].name + "\" />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = "$" + cart.cartItems[j].price.ToString();
                    cell.InnerHtml += " <input type=\"hidden\" name=\"amount_" + (j + 1)
                            + "\" value=\"" + cart.cartItems[j].price.ToString() + "\" />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    cell.InnerHtml = cart.cartItems[j].size;
                    cell.InnerHtml += " <input type=\"hidden\" name=\"on0_" + (j+1)
                            + "\" value=\"size\" />";
                    cell.InnerHtml += " <input type=\"hidden\" name=\"os0_" + (j+1)
                            + "\" value=\"" + cart.cartItems[j].size + "\" />";
                    row.Cells.Add(cell);

                    cell = new HtmlTableCell();
                    TextBox text = new TextBox();
                    text.Text = cart.cartItems[j].quantity.ToString();
                    cell.InnerHtml += " <input type=\"hidden\" name=\"quantity_" + (j + 1)
                            + "\" value=\"" + cart.cartItems[j].quantity.ToString() + "\" />";
                    cell.Controls.Add(text);
                    row.Cells.Add(cell);

                    cartTable.Rows.Add(row);

                    /* row = new HtmlTableRow();
                     ArrayList oneRow = (ArrayList)cart[j];
                     for (int field = 0; field < oneRow.Count; field++)
                     {
                         if (field == 1)
                         {
                             itemCost = double.Parse(oneRow[field].ToString());
                         }
                         else if (field == 3)
                         {
                             totalCost += (double.Parse(oneRow[field].ToString())) * itemCost;
                         }
                         cell = new HtmlTableCell();

                         cell.InnerHtml = oneRow[field].ToString();
                         row.Cells.Add(cell);
                     }
                     cartTable.Rows.Add(row);
                 */
                }

                row = new HtmlTableRow();
                cell = new HtmlTableCell();
                cell.InnerHtml = "<b>Total Price:</b>";
                row.Cells.Add(cell);
                cell = new HtmlTableCell();
                Label totalPricelbl = new Label();
                totalPricelbl.ID = "TotalPriceLbl";
                totalPricelbl.Text = "$" + cart.totalPrice.ToString();
                cell.Controls.Add(totalPricelbl);
                row.Cells.Add(cell);
                cell = new HtmlTableCell();
                Button checkoutButton = new Button();
                checkoutButton.Text = "Checkout";
                cell.Controls.Add(checkoutButton);
                if (!Context.User.Identity.IsAuthenticated)
                {
                    Session["LoginRedirect"] = "ViewCart.aspx";
                    checkoutButton.PostBackUrl = "Login.aspx";
                }

                row.Cells.Add(cell);
                cell = new HtmlTableCell();
                Button updateButton = new Button();
                updateButton.Click += Update_Click;
                updateButton.Text = "Update";
                updateButton.ID = "UpdateButton";
                updateButton.PostBackUrl = "ViewCart.aspx";
                cell.Controls.Add(updateButton);
                row.Cells.Add(cell);
                cartTable.Rows.Add(row);
            }
            else
            {
                row = new HtmlTableRow();
                cell = new HtmlTableCell();
                cell.Width = "140px";
                cell.InnerHtml = "<b>Your cart is empty.</b>";
                row.Cells.Add(cell);
                cartTable.Rows.Add(row);
            }
        }
        else //if cart.count == 0
        {
            row = new HtmlTableRow();
            cell = new HtmlTableCell();
            cell.Width = "140px";
            cell.InnerHtml = "<b>Your cart is empty.</b>";
            row.Cells.Add(cell);
            cartTable.Rows.Add(row);
        }

        MainPanel.Controls.Add(cartTable);
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        Cart cart = (Cart)Session["Cart"];
        HtmlTable cartTable = (HtmlTable)FindControl("CartTable");
        bool refresh = false;

        for (int i = 1; i < cartTable.Rows.Count - 1; i++)
        {
            TextBox box = (TextBox)cartTable.Rows[i].Cells[3].Controls[1];
            try
            {
                if (int.Parse(box.Text) <= 0)
                {
                    cartTable.Rows.RemoveAt(i);
                    cart.RemoveItem(i - 1);
                    refresh = true;
                    i -= 1;
                }
                else if (int.Parse(box.Text) != cart.cartItems[i-1].quantity)
                {
                    cart.ChangeQuantity(i - 1, int.Parse(box.Text));
                }
            }
            catch (FormatException err)
            {
                err.ToString();
                box.Text = cart.cartItems[i - 1].quantity.ToString();
            }
        }
        if (cartTable.Rows.Count == 2) //if there's no items in the cart
        {
            cartTable.Rows.RemoveAt(1);
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.Width = "140px";
            cell.InnerHtml = "<b>Your cart is empty.</b>";
            row.Cells.Add(cell);
            cartTable.Rows.Add(row);
        }
        else
        {
            Label priceLabel = (Label)FindControl("TotalPriceLbl");
            priceLabel.Text = "$" + cart.totalPrice.ToString();
        }
        Response.Redirect("ViewCart.aspx");
    }
}
