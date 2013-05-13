using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    public List<CartItem> cartItems { get; set; }
    public decimal totalPrice { get; set; }

	public Cart()
	{
        this.cartItems = new List<CartItem>();
        this.totalPrice = 0.0m;
	}

    public void AddItem(CartItem newItem)
    {
        foreach (CartItem item in cartItems)
        {
            if (item.name == newItem.name && item.size == newItem.size)
            {
                item.quantity += 1;
                totalPrice += newItem.price;
                return;
            }
        }
        cartItems.Add(newItem);
        totalPrice += newItem.price;
    }

    public void ChangeQuantity(int index, int newQuantity)
    {
        totalPrice -= cartItems[index].price * cartItems[index].quantity;
        cartItems[index].quantity = newQuantity;
        totalPrice += cartItems[index].price * cartItems[index].quantity;
    }

    public void RemoveItem(int index)
    {
        totalPrice -= cartItems[index].price * cartItems[index].quantity;
        cartItems.RemoveAt(index);
    }


}
