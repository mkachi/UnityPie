namespace Pie.Security
{
    public class SecureInt
    {
        private int _value;

        public SecureInt(int value)
        {
            _value = value ^ SecuritySystem.RandomHash;
        }

        public static implicit operator SecureInt(int value)
        {
            return new SecureInt(value);
        }

        public static explicit operator int(SecureInt value)
        {
            return value.Decrypt();
        }

        public int Decrypt()
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

        public static SecureInt operator +(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() + c2.Decrypt());
        }
        public static SecureInt operator -(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() - c2.Decrypt());
        }
        public static SecureInt operator *(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() * c2.Decrypt());
        }
        public static SecureInt operator /(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() / c2.Decrypt());
        }
        public static SecureInt operator %(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() % c2.Decrypt());
        }
        public static SecureInt operator &(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() & c2.Decrypt());
        }
        public static SecureInt operator |(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() | c2.Decrypt());
        }

        public static SecureInt operator ^(SecureInt c1, SecureInt c2)
        {
            return new SecureInt(c1.Decrypt() ^ c2.Decrypt());
        }

        public static SecureInt operator ~(SecureInt c)
        {
            return new SecureInt(~c.Decrypt());
        }
        public static SecureInt operator ++(SecureInt c)
        {
            return new SecureInt(c.Decrypt() + 1);
        }
        public static SecureInt operator --(SecureInt c)
        {
            return new SecureInt(c.Decrypt() - 1);
        }

        public static bool operator ==(SecureInt x, SecureInt y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureInt x, SecureInt y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureInt x, SecureInt y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureInt x, SecureInt y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureInt x, SecureInt y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureInt x, SecureInt y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}