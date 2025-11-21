using DataFile.BackEnd.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFile.BackEnd.Domain.Products.ValueObjects
{
    public class ProductId : ValueObject
    {
        public Ulid Value { get; }

        public ProductId(Ulid value)
        {
            Value = value;
        }

        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public static ProductId CreateUnique()
        {
            return new ProductId(Ulid.NewUlid());
        }

        public static ProductId Create(Ulid value)
        {
            return new ProductId(value);
        }

        public static ProductId Create(string value)
        {
            return new ProductId(Ulid.Parse(value));
        }
    }
}
