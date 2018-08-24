namespace Pie.Security
{
    public class SecureFloat
    {
        private byte[] _value;

        public SecureFloat(float value)
        {
            _value = System.Convert.FromBase64String(value.ToString());
        }

        public static implicit operator SecureFloat(float value)
        {
            return new SecureFloat(value);
        }

        public static explicit operator float(SecureFloat value)
        {
            return value.Decrypt();
        }

        public float Decrypt()
        {
            return float.Parse(System.Convert.ToBase64String(_value));
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

        public static SecureFloat operator +(SecureFloat c1, SecureFloat c2)
        {
            return new SecureFloat((float)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureFloat operator -(SecureFloat c1, SecureFloat c2)
        {
            return new SecureFloat((float)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureFloat operator *(SecureFloat c1, SecureFloat c2)
        {
            return new SecureFloat((float)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureFloat operator /(SecureFloat c1, SecureFloat c2)
        {
            return new SecureFloat((float)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureFloat operator %(SecureFloat c1, SecureFloat c2)
        {
            return new SecureFloat((float)(c1.Decrypt() % c2.Decrypt()));
        }

        public static SecureFloat operator ++(SecureFloat c)
        {
            return new SecureFloat((float)(c.Decrypt() + 1));
        }
        public static SecureFloat operator --(SecureFloat c)
        {
            return new SecureFloat((float)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureFloat x, SecureFloat y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureFloat x, SecureFloat y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureFloat x, SecureFloat y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureFloat x, SecureFloat y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureFloat x, SecureFloat y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureFloat x, SecureFloat y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}