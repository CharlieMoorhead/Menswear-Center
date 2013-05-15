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
using System.Collections;

/// <summary>
/// Summary description for CustomerDB
/// </summary>
public class CustomerDB
{
    private string connectionString;

	public CustomerDB()
	{
        connectionString = WebConfigurationManager.AppSettings["MYSQL_CONNECTION_STRING"];
	}

    public CustomerDB(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public int RegisterCustomer(Customer cus)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("InsertCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50));
        cmd.Parameters["@FirstName"].Value = cus.firstName;
        cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50));
        cmd.Parameters["@LastName"].Value = cus.lastName;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
        cmd.Parameters["@email"].Value = cus.email;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
        cmd.Parameters["@password"].Value = cus.password;

        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int, 4));
        cmd.Parameters["@CustomerID"].Direction = ParameterDirection.Output;

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@CustomerID"].Value;
        }
        catch (Exception err)
        {
            err.ToString();
            return -1;
        }
        finally
        {
            con.Close();
        }
    }

    public bool CheckEmail(string email)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("CheckEmail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
        cmd.Parameters["@email"].Value = email;

        try
        {
            con.Open();
            int count = (int)cmd.ExecuteScalar();

            con.Close();

            if (count == 0)
                return false;
            else return true;
        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();
        }
    }

    public bool CheckCustomer(string email, string password)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("CheckCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
        cmd.Parameters["@email"].Value = email;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
        cmd.Parameters["@password"].Value = password;

        try
        {
            con.Open();
            int count = (int)cmd.ExecuteScalar();

            con.Close();

            if (count == 0)
                return false;
            else return true;
        }
        catch (Exception err)
        {
            err.ToString();
            return false;
        }
        finally
        {
            con.Close();
        }
    }

    public Customer getCustomerByEmail(string email)
    {
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("GetCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50));
        cmd.Parameters["@email"].Value = email;

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (!reader.HasRows) return null;

            reader.Read();
            Customer cus = new Customer(
                (int)reader["customer_id"],
                (string)reader["firstName"],
                (string)reader["lastName"],
                (string)reader["email"],
                (string)reader["password"]);
            reader.Close();
            return cus;
        }
        catch (Exception err)
        {
            err.ToString();
            return null;
        }
        finally
        {
            con.Close();
        }
    }

    public ArrayList getCart(int customerID)
    {
        ArrayList cart = new ArrayList();

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("GetCart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int, 4));
        cmd.Parameters["@CustomerID"].Value = customerID;

        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ArrayList row = new ArrayList();
                for (int field = 0; field < reader.FieldCount; field++)
                {
                    string oneValue = reader.GetValue(field).ToString();

                    row.Add(oneValue);
                }
                cart.Add(row);
            }
            reader.Close();
            con.Close();

            return cart;
        }
        catch (Exception err)
        {
            err.ToString();
            ArrayList r = new ArrayList();
            return r;
        }
        finally
        {
            con.Close();
        }
    }
}
