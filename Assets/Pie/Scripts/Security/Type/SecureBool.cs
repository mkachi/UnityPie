using System;

namespace Pie.Security
{
    public class SecureBool
    {
        private byte[] _value;

        public SecureBool(bool value)
        {
            _value = Convert.FromBase64String(value.ToString());
        }

        public static implicit operator SecureBool(bool value)
        {
            return new SecureBool(value);
        }

        public static explicit operator bool(SecureBool value)
        {
            return value.Decrypt();
        }

        public bool Decrypt()
        {
            return bool.Parse(Convert.ToBase64String(_value));
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

        public static SecureBool operator &(SecureBool c1, SecureBool c2)
        {
            return new SecureBool(c1.Decrypt() & c2.Decrypt());
        }
        public static SecureBool operator |(SecureBool c1, SecureBool c2)
        {
            return new SecureBool(c1.Decrypt() | c2.Decrypt());
        }

        public static SecureBool operator ^(SecureBool c1, SecureBool c2)
        {
            return new SecureBool(c1.Decrypt() ^ c2.Decrypt());
        }
        public static bool operator ==(SecureBool x, SecureBool y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureBool x, SecureBool y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
    }
}