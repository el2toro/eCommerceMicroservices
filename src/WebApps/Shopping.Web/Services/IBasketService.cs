using System.Net;

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


    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        //Get basket if bot exist, create new basket with defalt logged in user name: swn
        var userName = "swn";
        ShoppingCartModel basket;

        try
        {
            var getBasketResponse = await GetBasket(userName);
            basket = getBasketResponse.Cart;
        }
        catch (ApiException apiException) when (apiException.StatusCode == HttpStatusCode.NotFound)
        {
            basket = new ShoppingCartModel
            {
                UserName = userName,
                Items = []
            };
        }

        return basket;
    }
}
