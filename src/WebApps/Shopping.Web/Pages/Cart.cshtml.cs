namespace Shopping.Web.Pages;

public class CartModel
    (IBasketService basketService, ILogger<CartModel> logger)
    : PageModel
{
    public ShoppingCartModel Cart { get; set; } = new ShoppingCartModel();
    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteToCartAsync(Guid productId)
    {
        logger.LogInformation("Remove to cart clicked");

        Cart = await basketService.LoadUserBasket();
        Cart.Items.RemoveAll(i => i.ProductId == productId);
        await basketService.StoreBasket(new StoreBasketRequest(Cart));

        return RedirectToPage();
    }
}
