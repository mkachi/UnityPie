using System;

namespace Pie.Security
{
    public class SecureDouble
    {
        private byte[] _value;

        public SecureDouble(double value)
        {
            _value = Convert.FromBase64String(value.ToString());
        }

        public static implicit operator SecureDouble(double value)
        {
            return new SecureDouble(value);
        }

        public static explicit operator double(SecureDouble value)
        {
            return value.Decrypt();
        }

        public double Decrypt()
        {
            return double.Parse(Convert.ToBase64String(_value));
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

        public static SecureDouble operator +(SecureDouble c1, SecureDouble c2)
        {
            return new SecureDouble((double)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureDouble operator -(SecureDouble c1, SecureDouble c2)
        {
            return new SecureDouble((double)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureDouble operator *(SecureDouble c1, SecureDouble c2)
        {
            return new SecureDouble((double)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureDouble operator /(SecureDouble c1, SecureDouble c2)
        {
            return new SecureDouble((double)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureDouble operator %(SecureDouble c1, SecureDouble c2)
        {
            return new SecureDouble((double)(c1.Decrypt() % c2.Decrypt()));
        }

        public static SecureDouble operator ++(SecureDouble c)
        {
            return new SecureDouble((double)(c.Decrypt() + 1));
        }
        public static SecureDouble operator --(SecureDouble c)
        {
            return new SecureDouble((double)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureDouble x, SecureDouble y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureDouble x, SecureDouble y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureDouble x, SecureDouble y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureDouble x, SecureDouble y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureDouble x, SecureDouble y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureDouble x, SecureDouble y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}