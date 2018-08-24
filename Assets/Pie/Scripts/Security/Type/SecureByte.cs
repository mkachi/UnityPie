namespace Pie.Security
{
    public class SecureByte
    {
        private byte _value;

        public SecureByte(byte value)
        {
            _value = (byte)(_value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureByte(byte value)
        {
            return new SecureByte(value);
        }

        public static explicit operator byte(SecureByte value)
        {
            return value.Decrypt();
        }

        public byte Decrypt()
        {
            return (byte)(_value ^ SecuritySystem.RandomHash);
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

        public static SecureByte operator +(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureByte operator -(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureByte operator *(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureByte operator /(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureByte operator %(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() % c2.Decrypt()));
        }
        public static SecureByte operator &(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() & c2.Decrypt()));
        }
        public static SecureByte operator |(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() | c2.Decrypt()));
        }

        public static SecureByte operator ^(SecureByte c1, SecureByte c2)
        {
            return new SecureByte((byte)(c1.Decrypt() ^ c2.Decrypt()));
        }

        public static SecureByte operator ~(SecureByte c)
        {
            return new SecureByte((byte)(~c.Decrypt()));
        }
        public static SecureByte operator ++(SecureByte c)
        {
            return new SecureByte((byte)(c.Decrypt() + 1));
        }
        public static SecureByte operator --(SecureByte c)
        {
            return new SecureByte((byte)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureByte x, SecureByte y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureByte x, SecureByte y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureByte x, SecureByte y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureByte x, SecureByte y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureByte x, SecureByte y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureByte x, SecureByte y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}