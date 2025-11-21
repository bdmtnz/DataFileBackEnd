using DataFile.BackEnd.Domain.Common.Entities;

namespace DataFile.BackEnd.Domain.Users.ValueObjects
{
    public class UserId : ValueObject
    {
        public Ulid Value { get; }

        public UserId(Ulid value)
        {
            Value = value;
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Ulid.NewUlid());
        }

        public static UserId Create(Ulid value)
        {
            return new UserId(value);
        }

        public static UserId Create(string value)
        {
            return new UserId(Ulid.Parse(value));
        }
    }
}
