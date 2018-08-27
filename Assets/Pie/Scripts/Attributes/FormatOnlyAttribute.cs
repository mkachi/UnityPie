namespace Pie.Attributes
{
    using UnityEngine;

    public sealed class FormatOnlyAttribute
        : PropertyAttribute
    {
        public string Format { get; private set; }

        public FormatOnlyAttribute(string format)
        {
            Format = format;
        }
    }
}