namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>
            {
                Customer.Create(CustomerId.Of(new Guid("3f5fa27b-4169-4e83-9334-83e9c25dbb94")), "Yato", "yato@email.com"),
                Customer.Create(CustomerId.Of(new Guid("f5454289-bc9b-4acd-920e-4c57596b2d02")), "Ebisu", "ebisu@email.com"),
            };

        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(ProductId.Of(new Guid("03192019-f201-437b-934e-f517cb20e54c")), "Product 01", 100),
                Product.Create(ProductId.Of(new Guid("e1f653b8-279d-428d-a095-28e059b7a6cd")), "Product 02", 200),
                Product.Create(ProductId.Of(new Guid("7d6212e4-2449-42d0-a139-42a1e2c1974c")), "Product 03", 300),
                Product.Create(ProductId.Of(new Guid("cee8b43c-f109-437d-809a-7a7dcf8fda73")), "Product 04", 400),
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

                var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

                var order1 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("3f5fa27b-4169-4e83-9334-83e9c25dbb94")),
                                OrderName.Of("ORD_1"),
                                shippingAddress: address1,
                                billingAddress: address1,
                                payment1);
                order1.Add(ProductId.Of(new Guid("03192019-f201-437b-934e-f517cb20e54c")), 2, 500);
                order1.Add(ProductId.Of(new Guid("e1f653b8-279d-428d-a095-28e059b7a6cd")), 1, 400);

                var order2 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("f5454289-bc9b-4acd-920e-4c57596b2d02")),
                                OrderName.Of("ORD_2"),
                                shippingAddress: address2,
                                billingAddress: address2,
                                payment2);
                order2.Add(ProductId.Of(new Guid("7d6212e4-2449-42d0-a139-42a1e2c1974c")), 1, 650);
                order2.Add(ProductId.Of(new Guid("cee8b43c-f109-437d-809a-7a7dcf8fda73")), 2, 450);

                return new List<Order> { order1, order2 };
            }
        }

    }
}






