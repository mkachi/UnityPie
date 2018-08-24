using System;

namespace Pie.Security
{
    public class SecureDecimal
    {
        private byte[] _value;

        public SecureDecimal(decimal value)
        {
            _value = Convert.FromBase64String(value.ToString());
        }

        public static implicit operator SecureDecimal(decimal value)
        {
            return new SecureDecimal(value);
        }

        public static explicit operator decimal(SecureDecimal value)
        {
            return value.Decrypt();
        }

        public decimal Decrypt()
        {
            return decimal.Parse(Convert.ToBase64String(_value));
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

        public static SecureDecimal operator +(SecureDecimal c1, SecureDecimal c2)
        {
            return new SecureDecimal((decimal)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureDecimal operator -(SecureDecimal c1, SecureDecimal c2)
        {
            return new SecureDecimal((decimal)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureDecimal operator *(SecureDecimal c1, SecureDecimal c2)
        {
            return new SecureDecimal((decimal)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureDecimal operator /(SecureDecimal c1, SecureDecimal c2)
        {
            return new SecureDecimal((decimal)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureDecimal operator %(SecureDecimal c1, SecureDecimal c2)
        {
            return new SecureDecimal((decimal)(c1.Decrypt() % c2.Decrypt()));
        }

        public static SecureDecimal operator ++(SecureDecimal c)
        {
            return new SecureDecimal((decimal)(c.Decrypt() + 1));
        }
        public static SecureDecimal operator --(SecureDecimal c)
        {
            return new SecureDecimal((decimal)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureDecimal x, SecureDecimal y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureDecimal x, SecureDecimal y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureDecimal x, SecureDecimal y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureDecimal x, SecureDecimal y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureDecimal x, SecureDecimal y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureDecimal x, SecureDecimal y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}