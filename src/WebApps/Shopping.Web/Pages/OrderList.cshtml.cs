namespace Shopping.Web.Pages;

public class OrderListModel
    (IOrderingService orderingService, ILogger<OrderListModel> logger)
    : PageModel
{
    public IEnumerable<OrderModel> Orders { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync()
    {
        //Assuming customerId is passed from UI authenticated user swn
        var customerId = new Guid("14616b12-d950-4ad4-93d1-2b8536144f20");

        var response = await orderingService.GetOrdersByCystomer(customerId);
        Orders = response.Orders;

        return Page();
    }
}
