using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFile.BackEnd.Domain.Common.Entities
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object?> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return object.Equals(left, right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !object.Equals(left, right);
        }

        public override int GetHashCode()
        {
            return (from x in GetEqualityComponents()
                    select x?.GetHashCode() ?? 0).Aggregate((int x, int y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}
