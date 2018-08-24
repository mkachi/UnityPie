namespace Pie.Security
{
    public class SecureShort
    {
        private short _value;

        public SecureShort(short value)
        {
            _value = (short)(_value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureShort(short value)
        {
            return new SecureShort(value);
        }

        public static explicit operator short(SecureShort value)
        {
            return value.Decrypt();
        }

        public short Decrypt()
        {
            return (short)(_value ^ SecuritySystem.RandomHash);
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

        public static SecureShort operator +(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureShort operator -(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureShort operator *(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureShort operator /(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureShort operator %(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() % c2.Decrypt()));
        }
        public static SecureShort operator &(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() & c2.Decrypt()));
        }
        public static SecureShort operator |(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() | c2.Decrypt()));
        }

        public static SecureShort operator ^(SecureShort c1, SecureShort c2)
        {
            return new SecureShort((short)(c1.Decrypt() ^ c2.Decrypt()));
        }

        public static SecureShort operator ~(SecureShort c)
        {
            return new SecureShort((short)(~c.Decrypt()));
        }
        public static SecureShort operator ++(SecureShort c)
        {
            return new SecureShort((short)(c.Decrypt() + 1));
        }
        public static SecureShort operator --(SecureShort c)
        {
            return new SecureShort((short)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureShort x, SecureShort y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureShort x, SecureShort y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureShort x, SecureShort y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureShort x, SecureShort y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureShort x, SecureShort y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureShort x, SecureShort y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}