using System.Text;

namespace Pie
{
    public class StringUtils
    {
        private StringBuilder _builder = null;

        public static StringUtils Small
        {
            get
            {
                return new StringUtils(64);
            }
        }
        public static StringUtils Medium
        {
            get
            {
                return new StringUtils(256);
            }
        }
        public static StringUtils Large
        {
            get
            {
                return new StringUtils(1024);
            }
        }

        private StringUtils(int capacity)
        {
            _builder = new StringBuilder(capacity);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
        public StringUtils Clear()
        {
            _builder.Remove(0, _builder.Length);
            return this;
        }

        public static implicit operator string(StringUtils utile)
        {
            return utile.ToString();
        }

        public static StringUtils operator +(StringUtils utile, bool value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, byte value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, char value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, decimal value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, double value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, float value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, int value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, long value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, sbyte value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, short value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, string value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, uint value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, ulong value)
        {
            utile._builder.Append(value);
            return utile;
        }
        public static StringUtils operator +(StringUtils utile, ushort value)
        {
            utile._builder.Append(value);
            return utile;
        }

        public static string[] Split(string str, params string[] separator, System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries)
        {
            return str.Split(separator, option);
        }
        public static char[] Split(string str, params char[] separator, System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries)
        {
            return str.Split(separator, option);
        }
    }
}