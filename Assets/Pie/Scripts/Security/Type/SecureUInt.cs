namespace Pie.Security
{
    public class SecureUInt
    {
        private uint _value;

        public SecureUInt(uint value)
        {
            _value = (uint)(value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureUInt(uint value)
        {
            return new SecureUInt(value);
        }

        public static explicit operator uint(SecureUInt value)
        {
            return value.Decrypt();
        }

        public uint Decrypt()
        {
            return (uint)(_value ^ SecuritySystem.RandomHash);
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

        public static SecureUInt operator +(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() + c2.Decrypt());
        }
        public static SecureUInt operator -(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() - c2.Decrypt());
        }
        public static SecureUInt operator *(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() * c2.Decrypt());
        }
        public static SecureUInt operator /(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() / c2.Decrypt());
        }
        public static SecureUInt operator %(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() % c2.Decrypt());
        }
        public static SecureUInt operator &(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() & c2.Decrypt());
        }
        public static SecureUInt operator |(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() | c2.Decrypt());
        }

        public static SecureUInt operator ^(SecureUInt c1, SecureUInt c2)
        {
            return new SecureUInt(c1.Decrypt() ^ c2.Decrypt());
        }

        public static SecureUInt operator ~(SecureUInt c)
        {
            return new SecureUInt(~c.Decrypt());
        }
        public static SecureUInt operator ++(SecureUInt c)
        {
            return new SecureUInt(c.Decrypt() + 1);
        }
        public static SecureUInt operator --(SecureUInt c)
        {
            return new SecureUInt(c.Decrypt() - 1);
        }

        public static bool operator ==(SecureUInt x, SecureUInt y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureUInt x, SecureUInt y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureUInt x, SecureUInt y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureUInt x, SecureUInt y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureUInt x, SecureUInt y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureUInt x, SecureUInt y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}