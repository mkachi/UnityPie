namespace Pie.Security
{
    public class SecureULong
    {
        private ulong _value;

        public SecureULong(ulong value)
        {
            _value = (ulong)(value ^ (ulong)SecuritySystem.RandomHash);
        }

        public static implicit operator SecureULong(ulong value)
        {
            return new SecureULong(value);
        }

        public static explicit operator ulong(SecureULong value)
        {
            return value.Decrypt();
        }

        public ulong Decrypt()
        {
            return (ulong)(_value ^ (ulong)SecuritySystem.RandomHash);
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

        public static SecureULong operator +(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() + c2.Decrypt());
        }
        public static SecureULong operator -(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() - c2.Decrypt());
        }
        public static SecureULong operator *(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() * c2.Decrypt());
        }
        public static SecureULong operator /(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() / c2.Decrypt());
        }
        public static SecureULong operator %(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() % c2.Decrypt());
        }
        public static SecureULong operator &(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() & c2.Decrypt());
        }
        public static SecureULong operator |(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() | c2.Decrypt());
        }

        public static SecureULong operator ^(SecureULong c1, SecureULong c2)
        {
            return new SecureULong(c1.Decrypt() ^ c2.Decrypt());
        }

        public static SecureULong operator ~(SecureULong c)
        {
            return new SecureULong(~c.Decrypt());
        }
        public static SecureULong operator ++(SecureULong c)
        {
            return new SecureULong(c.Decrypt() + 1);
        }
        public static SecureULong operator --(SecureULong c)
        {
            return new SecureULong(c.Decrypt() - 1);
        }

        public static bool operator ==(SecureULong x, SecureULong y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureULong x, SecureULong y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureULong x, SecureULong y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureULong x, SecureULong y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureULong x, SecureULong y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureULong x, SecureULong y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}