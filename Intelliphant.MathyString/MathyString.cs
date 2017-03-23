using System;
using System.Collections.Generic;
using System.Linq;

namespace Intelliphant.MathyString
{
    public class MathyString
    {
        private readonly string value;
        public MathyString(string value) => this.value = value;
        public override string ToString() => value;

        public static implicit operator string(MathyString s) => s.value;

        public static implicit operator MathyString(string s) => new MathyString(s);

        public static MathyString operator *(MathyString s, int multiplicand) => string.Concat(Enumerable.Repeat(s.value, multiplicand));

        public static MathyString[] operator /(MathyString s, int divisor)
        {
            var quotient = new List<MathyString>();
            for (int i = 0; i < s.value.Length; i += divisor)
            {
                quotient.Add(s.value.Substring(i, Math.Min(divisor, s.value.Length - i)));
            }
            return quotient.ToArray();
        }

        public static MathyString[] operator /(MathyString s, string divisor) => s.value.Split(new string[] { divisor }, StringSplitOptions.None).Select(str => new MathyString(str)).ToArray();

        public static MathyString operator %(MathyString s, int divisor) => s.value.Substring(s.value.Length - s.value.Length % divisor);

        public static MathyString[] operator %(MathyString s, string divisor)
        {
            int count = s.value.Split(new string[] { divisor }, StringSplitOptions.None).Length;
            return (count > 0) ? Enumerable.Repeat(divisor, count - 1).Select(str => new MathyString(str)).ToArray() : new MathyString[0];
        }

        public static MathyString operator -(MathyString s, string subtrahend) => new MathyString(s.value.Replace(subtrahend, ""));

        public static MathyString operator -(MathyString s, int subtrahend)
        {
            int l = s.value.Length - subtrahend;
            return (l >= 0) ? s.value.Substring(0, l) : new string('\b', Math.Abs(l));
        }

        public static MathyString operator +(MathyString s, string addend) => new MathyString(s.value + addend);

        public static MathyString operator --(MathyString s) => s - 1;

        public static MathyString operator ++(MathyString s) => new MathyString(s.value + 1);
    }
}
