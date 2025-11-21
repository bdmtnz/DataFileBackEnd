using DataFile.BackEnd.Domain.Common.Entities;

namespace DataFile.BackEnd.Domain.Orders.ValueObjects
{
    public class OrderId : ValueObject
    {
        public Ulid Value { get; }

        public OrderId(Ulid value)
        {
            Value = value;
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public static OrderId CreateUnique()
        {
            return new OrderId(Ulid.NewUlid());
        }

        public static OrderId Create(Ulid value)
        {
            return new OrderId(value);
        }

        public static OrderId Create(string value)
        {
            return new OrderId(Ulid.Parse(value));
        }
    }
}
