using Ordering.Domain.Models;
using Ordering.Domain.ValueObjets;

namespace Ordering.Infrastructure.Data.Extentions;

public static class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("14616b12-d950-4ad4-93d1-2b8536144f20")), "Anthony", "anthony.meki@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("d0d4fe78-ae7a-43b1-b36f-9c730c6e17ba")), "Dely", "dely.mely@gmail.com")
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("0e9b4f9b-7311-4d6d-8601-7d1e63164096")), "Iphone 13", 900),
            Product.Create(ProductId.Of(new Guid("197e4644-7f13-4a74-ab3e-ed7c61832f60")), "Iphone 14", 1000),
            Product.Create(ProductId.Of(new Guid("4370b6d9-1a43-4a4f-80e6-617e21bebb0e")), "Iphone 15", 1300),
            Product.Create(ProductId.Of(new Guid("9a71c5c5-74f0-4ee8-b20e-d2308b0abf1f")), "Iphone 16", 1500)
        };

    public static IEnumerable<Order> OrderWithItems
    {
        get
        {
            var address1 = Address.Of("johny", "ricci", "johny@gmai.com", "Wall Street 1", "USA", "New York", "23659");
            var address2 = Address.Of("mark", "beddo", "mark@gmai.com", "Wall Street 2", "USA", "New York", "23456");

            var payment1 = Payment.Of("johny", "555555555444444333336669", "03/29", "663", 1);
            var payment2 = Payment.Of("mark", "555522255444114333338888", "05/28", "532", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("14616b12-d950-4ad4-93d1-2b8536144f20")),
                OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment: payment1);

            order1.Add(ProductId.Of(new Guid("0e9b4f9b-7311-4d6d-8601-7d1e63164096")), 1, 900);
            order1.Add(ProductId.Of(new Guid("197e4644-7f13-4a74-ab3e-ed7c61832f60")), 2, 1000);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("d0d4fe78-ae7a-43b1-b36f-9c730c6e17ba")),
                OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment: payment2);

            order1.Add(ProductId.Of(new Guid("4370b6d9-1a43-4a4f-80e6-617e21bebb0e")), 2, 1300);
            order1.Add(ProductId.Of(new Guid("9a71c5c5-74f0-4ee8-b20e-d2308b0abf1f")), 1, 1500);

            return new List<Order> { order1, order2 };
        }
    }

}
