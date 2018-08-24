namespace Pie.Security
{
    public class SecureSByte
    {
        private sbyte _value;

        public SecureSByte(sbyte value)
        {
            _value = (sbyte)(_value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureSByte(sbyte value)
        {
            return new SecureSByte(value);
        }

        public static explicit operator sbyte(SecureSByte value)
        {
            return value.Decrypt();
        }

        public sbyte Decrypt()
        {
            return (sbyte)(_value ^ SecuritySystem.RandomHash);
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

        public static SecureSByte operator +(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureSByte operator -(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureSByte operator *(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureSByte operator /(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureSByte operator %(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() % c2.Decrypt()));
        }
        public static SecureSByte operator &(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() & c2.Decrypt()));
        }

        public static SecureSByte operator ^(SecureSByte c1, SecureSByte c2)
        {
            return new SecureSByte((sbyte)(c1.Decrypt() ^ c2.Decrypt()));
        }

        public static SecureSByte operator ~(SecureSByte c)
        {
            return new SecureSByte((sbyte)(~c.Decrypt()));
        }
        public static SecureSByte operator ++(SecureSByte c)
        {
            return new SecureSByte((sbyte)(c.Decrypt() + 1));
        }
        public static SecureSByte operator --(SecureSByte c)
        {
            return new SecureSByte((sbyte)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureSByte x, SecureSByte y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureSByte x, SecureSByte y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureSByte x, SecureSByte y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureSByte x, SecureSByte y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureSByte x, SecureSByte y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureSByte x, SecureSByte y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}