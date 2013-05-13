using System;
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
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemDB idb = new ItemDB();
        List<Item> items = new List<Item>();
        items = (List<Item>)idb.getItems();
        if (items[0] == null)
        {
            lblInfo.Text = "null";
        }
        else
        {
        lblInfo.Text = items[0].name;
        }
    }

    public void ItemsGridView_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItemIndex != -1)
        {
            int category;

            try
            {
                category = int.Parse("xxx");
            }
            catch (Exception err)
            {
                category = 0;
            }
            if (category == 1 || category == 0)
            {
                lblInfo.Text += "ESS";
            }

            Item it = (Item)e.Row.DataItem;
            lblInfo.Text += it.name + ":";
            lblInfo.Text += it.sizes.Count + " ";
            if (it.sizes.Count > 0)
            {
                foreach (string size in it.sizes)
                {
                    lblInfo.Text += "(" + size + ")";
                }
            }
            else
            {
                e.Row.Visible = false;
            }
            
            DropDownList sizesDropdown = new DropDownList();
            sizesDropdown.ID = "dropDownRow" + e.Row.DataItemIndex;
            foreach (string size in it.sizes)
            {
                ListItem sizeitem = new ListItem();
                sizeitem.Text = size;
                sizesDropdown.Items.Add(sizeitem);
            }
            TableCell dropDownCell = new TableCell();
            dropDownCell.Controls.Add(sizesDropdown);
            e.Row.Cells.Add(dropDownCell);
        }
    }

}
