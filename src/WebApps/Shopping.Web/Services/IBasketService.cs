namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Get("/basket-service/basket/{userName}")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Get("/basket-service/basket/{userName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Get("/basket-service/basket/checkout")]
    Task<CheckoutBasketRequest> CheckoutBasket(CheckoutBasketRequest request);
}
