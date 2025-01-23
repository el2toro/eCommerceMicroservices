namespace Basket.API.Models;

public class SoppingCart
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

    public SoppingCart(string username)
    {
        UserName = username;
    }

    public SoppingCart()
    {
    }
}
