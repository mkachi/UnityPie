using System;

namespace Pie.Security
{
    public class SecureString
    {
        private byte[] _value;

        public SecureString(string value)
        {
            _value = Convert.FromBase64String(value);
        }

        public static implicit operator SecureString(string value)
        {
            return new SecureString(value);
        }

        public static explicit operator string(SecureString value)
        {
            return value.Decrypt();
        }

        public string Decrypt()
        {
            return Convert.ToBase64String(_value);
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

        public static SecureString operator +(SecureString c1, SecureString c2)
        {
            return new SecureString(c1.Decrypt() + c2.Decrypt());
        }

        public static bool operator ==(SecureString x, SecureString y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureString x, SecureString y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
    }
}