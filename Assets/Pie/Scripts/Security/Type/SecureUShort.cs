namespace Pie.Security
{
    public class SecureUShort
    {
        private ushort _value;

        public SecureUShort(ushort value)
        {
            _value = (ushort)(value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureUShort(ushort value)
        {
            return new SecureUShort(value);
        }

        public static explicit operator ushort(SecureUShort value)
        {
            return value.Decrypt();
        }

        public ushort Decrypt()
        {
            return (ushort)(_value ^ SecuritySystem.RandomHash);
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

        public static bool operator ==(SecureUShort x, SecureUShort y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureUShort x, SecureUShort y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureUShort x, SecureUShort y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureUShort x, SecureUShort y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureUShort x, SecureUShort y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureUShort x, SecureUShort y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}