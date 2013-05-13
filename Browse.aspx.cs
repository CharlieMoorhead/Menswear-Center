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

public partial class Browse : System.Web.UI.Page
{
    ItemDB idb = new ItemDB();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ItemGrid_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem == null)
        {
            //do nothing
        }
        else if (e.Row.DataItemIndex != -1)
        {
            Item it = (Item)e.Row.DataItem;
            int category;

            try
            {
                category = int.Parse(Request.QueryString["cat"]);
            }
            catch (Exception err)
            {
                err.ToString();
                category = 0;
            }

            if (it.categoryID != category && category != 0)
            {
                e.Row.Visible = false;
            }
            else
            {
                DropDownList dropdown = (DropDownList)e.Row.Cells[4].Controls[1];
                foreach (string size in it.sizes)
                {
                    ListItem sizeitem = new ListItem();
                    sizeitem.Text = size;
                    dropdown.Items.Add(sizeitem);
                }
            }
        }
    }

    protected void ItemGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = ItemGrid.Rows[ItemGrid.SelectedIndex].Cells[0].Text;
        decimal price = decimal.Parse(ItemGrid.Rows[ItemGrid.SelectedIndex].Cells[1].Text.Remove(0,1));
        DropDownList list = (DropDownList)ItemGrid.Rows[ItemGrid.SelectedIndex].Cells[4].Controls[1];
        string size = list.SelectedItem.Text;
        int quantity = 1;

        CartItem newCartItem = new CartItem(name, price, size, quantity);

        if (Session["Cart"] == null)
        {
            Cart cart = new Cart();
            cart.AddItem(newCartItem);
            Session["Cart"] = cart;
        }
        else
        {
            Cart cart = (Cart)Session["Cart"];
            cart.AddItem(newCartItem);
        }
        messageLabel.Text = newCartItem.size + "-sized " + newCartItem.name + " added to your cart.<br /><br />";
    }
}
