using System;
using System.Data;
using System.Configuration;
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
using System.Collections.Generic;

/// <summary>
/// Summary description for ItemDB
/// </summary>
public class ItemDB
{
    private string connectionString;

    public ItemDB()
    {
        connectionString = WebConfigurationManager.ConnectionStrings["default"].ConnectionString;
    }

    public ItemDB(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<Item> getItems()
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand getItemsCmd = new SqlCommand("GetItems", con);
        getItemsCmd.CommandType = CommandType.StoredProcedure;
        SqlCommand getSizesCmd = new SqlCommand("GetSizesForItem", con);
        getSizesCmd.CommandType = CommandType.StoredProcedure;
        getSizesCmd.Parameters.Add(new SqlParameter("@ItemID", SqlDbType.Int, 4));
        
        try
        {
            con.Open();
            SqlDataReader itemReader = getItemsCmd.ExecuteReader();
            if (!itemReader.HasRows) return null;

            List<Item> items = new List<Item>();
            while(itemReader.Read())
            {
                List<string> sizes = new List<string>();
                items.Add(new Item(
                            (int)itemReader["item_id"],
                            (string)itemReader["name"],
                            (decimal)itemReader["price"],
                            (string)itemReader["picture_url"],
                            (int)itemReader["category_id"],
                            sizes));
            }
            itemReader.Close();


            foreach (Item item in items)
            {
                List<string> sizes = new List<string>();
                getSizesCmd.Parameters["@ItemID"].Value = (int)item.itemID;
                SqlDataReader sizeReader = getSizesCmd.ExecuteReader();

                if (sizeReader.HasRows)
                {
                    while (sizeReader.Read())
                        sizes.Add((string)sizeReader["size"]);
                }
                sizeReader.Close();
                item.sizes = sizes;
            }

            con.Close();
            return items;
        }
        catch (Exception err)
        {
            throw err;
            err.ToString();
            return null;
        }
        finally
        {
            con.Close();
        }
    }
}