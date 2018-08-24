namespace Pie.Security
{
    public class SecureLong
    {
        private long _value;

        public SecureLong(long value)
        {
            _value = value ^ SecuritySystem.RandomHash;
        }

        public static implicit operator SecureLong(long value)
        {
            return new SecureLong(value);
        }

        public static explicit operator long(SecureLong value)
        {
            return value.Decrypt();
        }

        public long Decrypt()
        {
            return _value ^ SecuritySystem.RandomHash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static SecureLong operator +(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() + c2.Decrypt());
        }
        public static SecureLong operator -(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() - c2.Decrypt());
        }
        public static SecureLong operator *(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() * c2.Decrypt());
        }
        public static SecureLong operator /(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() / c2.Decrypt());
        }
        public static SecureLong operator %(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() % c2.Decrypt());
        }
        public static SecureLong operator &(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() & c2.Decrypt());
        }
        public static SecureLong operator |(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() | c2.Decrypt());
        }

        public static SecureLong operator ^(SecureLong c1, SecureLong c2)
        {
            return new SecureLong(c1.Decrypt() ^ c2.Decrypt());
        }

        public static SecureLong operator ~(SecureLong c)
        {
            return new SecureLong(~c.Decrypt());
        }
        public static SecureLong operator ++(SecureLong c)
        {
            return new SecureLong(c.Decrypt() + 1);
        }
        public static SecureLong operator --(SecureLong c)
        {
            return new SecureLong(c.Decrypt() - 1);
        }

        public static bool operator ==(SecureLong x, SecureLong y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureLong x, SecureLong y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureLong x, SecureLong y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureLong x, SecureLong y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureLong x, SecureLong y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureLong x, SecureLong y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}