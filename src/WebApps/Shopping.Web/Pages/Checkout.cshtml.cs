namespace Shopping.Web.Pages;

public class CheckoutModel
    (IBasketService basketService, ILogger<CheckoutModel> logger)
    : PageModel
{
    public BasketCheckoutModel Order { get; set; } = default!;
    public ShoppingCartModel Cart { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();
        return Page();
    }

    public async Task<IActionResult> OnPostCheckoutAsync()
    {
        logger.LogInformation("Checkout button clicked");
        Cart = await basketService.LoadUserBasket();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Order.CustometId = new Guid("17bc6e02-1ba6-4cf3-aeb6-b504d6cc8b67");
        Order.UserName = Cart.UserName;
        Order.TotalPrice = Cart.TotalPrice;

        await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));

        return RedirectToPage("Confirmation", "OrderSubmitted");
    }
}
