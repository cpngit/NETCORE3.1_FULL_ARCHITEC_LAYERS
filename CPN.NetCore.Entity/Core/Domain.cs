using System;
using CPN.NetCore.Entity.Core.Contract;

namespace CPN.NetCore.Entity.Core
{
    public abstract class Domain<TId> : IDomain<TId>
    {
       
        public TId Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Domain<TId>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 67) + Id.GetHashCode();
        }

        public static bool operator ==(Domain<TId> a, Domain<TId> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Domain<TId> a, Domain<TId> b)
        {
            return !(a == b);
        }

    }
   
}