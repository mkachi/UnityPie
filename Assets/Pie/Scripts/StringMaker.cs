using System.Text;

namespace Pie
{
    public class StringMaker
    {
        private StringBuilder _builder = null;
        
        public static StringMaker Small
        {
            get
            {
                return new StringMaker(64);
            }
        }
        public static StringMaker Medium
        {
            get
            {
                return new StringMaker(256);
            }
        }
        public static StringMaker Large
        {
            get
            {
                return new StringMaker(1024);
            }
        }

        private StringMaker(int capacity)
        {
            _builder = new StringBuilder(capacity);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
        public StringMaker Clear()
        {
            _builder.Remove(0, _builder.Length);
            return this;
        }

        public static implicit operator string(StringMaker maker)
        {
            return maker.ToString();
        }

        public static StringMaker operator +(StringMaker maker, bool value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, byte value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, char value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, decimal value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, double value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, float value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, int value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, long value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, sbyte value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, short value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, string value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, uint value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, ulong value)
        {
            maker._builder.Append(value);
            return maker;
        }
        public static StringMaker operator +(StringMaker maker, ushort value)
        {
            maker._builder.Append(value);
            return maker;
        }
    }
}