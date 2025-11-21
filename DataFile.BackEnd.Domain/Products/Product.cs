using DataFile.BackEnd.Domain.Products.ValueObjects;
using ErrorOr;

namespace DataFile.BackEnd.Domain.Products
{
    public class Product
    {
        public ProductId Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        private Product() { }
        private Product(ProductId id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public static Product Create(string id, string name, decimal price, int stock)
        {
            var _id = ProductId.Create(id);
            return new Product(_id, name, price, stock);
        }

        public ErrorOr<Product> DecreaseStock(int quantity)
        {
            if (Stock < quantity) { return Error.Validation(description: $"No hay stock disponible"); }
            Stock -= quantity;
            return this;
        }
    }
}
