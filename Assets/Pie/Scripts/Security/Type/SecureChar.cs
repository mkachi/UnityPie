namespace Pie.Security
{
    public class SecureChar
    {
        private char _value;

        public SecureChar(char value)
        {
            _value = (char)(_value ^ SecuritySystem.RandomHash);
        }

        public static implicit operator SecureChar(char value)
        {
            return new SecureChar(value);
        }

        public static explicit operator char(SecureChar value)
        {
            return value.Decrypt();
        }

        public char Decrypt()
        {
            return (char)(_value ^ SecuritySystem.RandomHash);
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

        public static SecureChar operator +(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() + c2.Decrypt()));
        }
        public static SecureChar operator -(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() - c2.Decrypt()));
        }
        public static SecureChar operator *(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() * c2.Decrypt()));
        }
        public static SecureChar operator /(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() / c2.Decrypt()));
        }
        public static SecureChar operator %(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() % c2.Decrypt()));
        }
        public static SecureChar operator &(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() & c2.Decrypt()));
        }
        public static SecureChar operator |(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() | c2.Decrypt()));
        }

        public static SecureChar operator ^(SecureChar c1, SecureChar c2)
        {
            return new SecureChar((char)(c1.Decrypt() ^ c2.Decrypt()));
        }

        public static SecureChar operator ~(SecureChar c)
        {
            return new SecureChar((char)(~c.Decrypt()));
        }
        public static SecureChar operator ++(SecureChar c)
        {
            return new SecureChar((char)(c.Decrypt() + 1));
        }
        public static SecureChar operator --(SecureChar c)
        {
            return new SecureChar((char)(c.Decrypt() - 1));
        }

        public static bool operator ==(SecureChar x, SecureChar y)
        {
            return (x.Decrypt() == y.Decrypt());
        }
        public static bool operator !=(SecureChar x, SecureChar y)
        {
            return !(x.Decrypt() == y.Decrypt());
        }
        public static bool operator <(SecureChar x, SecureChar y)
        {
            return (x.Decrypt() < y.Decrypt());
        }
        public static bool operator >(SecureChar x, SecureChar y)
        {
            return (x.Decrypt() > y.Decrypt());
        }
        public static bool operator <=(SecureChar x, SecureChar y)
        {
            return (x.Decrypt() <= y.Decrypt());
        }
        public static bool operator >=(SecureChar x, SecureChar y)
        {
            return (x.Decrypt() >= y.Decrypt());
        }
    }
}