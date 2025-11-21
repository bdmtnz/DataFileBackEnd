using DataFile.BackEnd.Domain.Orders.ValueObjects;
using DataFile.BackEnd.Domain.Products;
using DataFile.BackEnd.Domain.Products.ValueObjects;
using DataFile.BackEnd.Domain.Users.ValueObjects;
using ErrorOr;

namespace DataFile.BackEnd.Domain.Orders
{
    public partial class Order
    {
        public OrderId Id { get; set; }
        public UserId UserId { get; private set; }
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }

        private Order() { }
        private Order(OrderId id, UserId userId, ProductId productId, int quantity)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }

        public static ErrorOr<Order> Create(UserId userId, Product product, int quantity)
        {
            var decreaseReuslt = product.DecreaseStock(quantity);
            if (decreaseReuslt.IsError) return decreaseReuslt.Errors;
            var _id = OrderId.CreateUnique();
            return new Order(_id, userId, product.Id, quantity);
        }
    }
}
