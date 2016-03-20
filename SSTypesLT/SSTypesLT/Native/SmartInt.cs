/**********************************************************************************

Simple Smart Types Lite
------------------

The MIT License (MIT)

Copyright (c) 2016 Dmitriy Gakh ( dmgakh@gmail.com ).

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

**********************************************************************************/

namespace SSTypes
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Used for quick and save operations with int type.
    /// Compatible with int and can be used whenever int uses.
    /// </summary>
    [Serializable, System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct SmartInt : IComparable, IComparable<SmartInt>, IEquatable<SmartInt>
    {
        private Int32 m_v;

        /// <summary>
        /// Bad value represented absent data, wrong data, e.t.c.
        /// </summary>
        public static readonly SmartInt BadValue = Int32.MinValue;

        /// <summary>
        /// Maximal valid value (2147483647)
        /// </summary>
        public static readonly SmartInt MaxValue = Int32.MaxValue;

        /// <summary>
        /// Minimal valid value (-2147483647)
        /// </summary>
        public static readonly SmartInt MinValue = Int32.MinValue + 1;

        // Private constants
        // Used internally to control possible overloading.
        private static readonly Int32 max_predparse_value = ((Int32.MaxValue - 1) / 10);

        /// <summary>
        /// Construct SmartInt from int.
        /// </summary>
        public SmartInt(Int32 value)
        {
            m_v = value;
        }

        /// <summary>
        /// Returns true if value is bad.
        /// </summary>
        public bool isBad()
        {
            return m_v == BadValue.m_v;
        }

        /// <summary>
        /// Returns true if value is bad or less than zero. Is useful for check IDs
        /// </summary>
        public bool isBadOrNegative()
        {
            return m_v < 0;
        }

        /// <summary>
        /// Converts the value of int to SmartInt.
        /// </summary>
        public static implicit operator SmartInt(Int32 value)
        {
            return new SmartInt(value);
        }

        /// <summary>
        /// Converts the value of SmartInt to int.
        /// </summary>
        public static implicit operator Int32(SmartInt value)
        {
            return value.m_v;
        }

        /*
        - Is not useful because compiler can assign SmartInt to Int64
        - Prevents using SmartInt in swith statement
                /// <summary>
                /// Converts the value of SmartInt to System.Int64.
                /// </summary>
                public static implicit operator Int64(SmartInt value)
                {
                    return value.m_v;
                }
        */

        /// <summary>
        /// Converts the value of System.Int64 to SmartInt explicitly.
        /// </summary>
        public static explicit operator SmartInt(Int64 value)
        {
            return SmartInt.Parse(value);
        }

        /*
        - Is not useful because compiler can assign SmartInt to Double

                /// <summary>
                /// Converts the value of SmartInt to System.Double.
                /// </summary>
                public static explicit operator Double(SmartInt value)
                {
                    return value.m_v;
                }
        */

        /// <summary>
        /// Converts the value of System.Double to SmartInt.
        /// </summary>
        public static explicit operator SmartInt(Double value)
        {
            return SmartInt.Parse(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to SmartInt.
        /// </summary>
        public static explicit operator SmartInt(SmartDouble value)
        {
            return SmartInt.Parse(value);
        }

/*
        - Is not useful because compiler can assign SmartInt to Decimal

        /// <summary>
        /// Converts the value of SmartInt to System.Decimal.
        /// </summary>
        public static implicit operator Decimal(SmartInt value)
        {
            return value.m_v;
        }
*/

        /// <summary>
        /// Converts the value of System.Decimal to SmartInt.
        /// </summary>
        public static explicit operator SmartInt(Decimal value)
        {
            if (value < SmartInt.MinValue)
                return SmartInt.BadValue;

            if (SmartInt.MaxValue < value)
                return SmartInt.BadValue;

            return new SmartInt((Int32)value);
        }

        /// <summary>
        /// Was not tested well !!!
        /// Parses to SmartInt binary values represented as string containing 0s and 1s.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, empty, cannot parse or contained a too long number.
        /// </summary>
        public static SmartInt ParseBinary(string b)
        {
            if (b == null)
                return SmartInt.BadValue;

            Int32 l = b.Length;

            Int32 number = 0;
            Int32 mr = 1;

            int i = l;

            while (i > 0)
            {
                i--;
                char c = b[i];

                if (c == '0') { mr <<= 1; continue; };
                if (c == '1') { number |= mr; mr <<= 1; continue; };
                if (c == ' ') { continue; };

                return SmartInt.BadValue;
            }

            if (i != 0)
                return SmartInt.BadValue;

            return number;
        }

        /// <summary>
        /// Parses string and returns SmartInt.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// </summary>
        public static SmartInt Parse(string s)
        {
            if (s != null)
                return SmartInt.Parse(s, 0, s.Length - 1);
            else
                return SmartInt.BadValue;
        }

        /// <summary>
        /// Parses string from inclusive start position to inclusive end position and returns SmartInt.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// </summary>
        public static SmartInt Parse(string s, int start, int end)
        {
            if (s == null)
                return SmartInt.BadValue;

            int end2 = end + 1;

            if (end2 > s.Length)
                return SmartInt.BadValue;

            Int32 number = 0;

            bool is_negative = false;
            bool is_positive = false;
            bool is_empty = true;

            int pos = start;

            while (pos < end2)
            {
                char c = s[pos];

                if (('0' <= c) && (c <= '9'))
                {
                    if (number > max_predparse_value)
                        return SmartInt.BadValue;

                    // number *= 10;
                    number = (number << 3) + number + number;
                    number += (Int32)(c - '0');

                    is_empty = false;

                    pos++;
                    continue;
                }

                if (c == ' ')
                {
                    if (pos == start)
                    {
                        while ((pos < end2) && (s[pos] == ' '))
                            pos++;

                        if (pos == end2)
                            return SmartInt.BadValue;
                    }
                    else
                    {
                        while ((pos < end2) && (s[pos] == ' '))
                            pos++;

                        if (pos != end2)
                            return SmartInt.BadValue;
                    }

                    continue;
                }

                if (c == '-')
                {
                    if ((is_negative) || (is_positive))
                        return SmartInt.BadValue;

                    is_negative = true;
                    pos++;
                    continue;
                }

                if (c == '+')
                {
                    if ((is_negative) || (is_positive))
                        return SmartInt.BadValue;

                    is_positive = true;
                    pos++;
                    continue;
                }

                return SmartInt.BadValue;
            }

            if (is_empty)
                return SmartInt.BadValue;

            if (is_negative)
                return -number;
            else
                return number;
        }

        /// <summary>
        /// Parses Double and returns SmartInt.
        /// Returns SmartInt.BadValue if d is too small or too big.
        /// Rounds d if d contains fraction part.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(Double d)
        {
            double r = Math.Round(d);

            if ((r < MinValue) || (MaxValue < r))
                return BadValue;

            return (Int32)r;
        }

        /// <summary>
        /// Parses Decimal and returns SmartInt.
        /// Returns SmartInt.BadValue if d is too small or too big.
        /// Rounds d if d contains fraction part.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(Decimal d)
        {
            Decimal r = Math.Round(d);

            if ((r < MinValue) || (MaxValue < r))
                return BadValue;

            return (Int32)r;
        }

        /// <summary>
        /// Parses SmartDouble and returns SmartInt.
        /// Returns SmartInt.BadValue if d is too small or too big.
        /// Rounds d if d contains fraction part.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(SmartDouble d)
        {
            if (d.isBad())
                return SmartInt.BadValue;

            return Parse((Double)d);
        }

        /// <summary>
        /// Parses System.Int64 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Int64 v)
        {
            if ((v < MinValue) || (MaxValue < v))
                return BadValue;

            return (Int32)v;
        }

        /// <summary>
        /// Parses System.UInt64 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.UInt64 v)
        {
            if ((System.UInt64)(System.Int64)MaxValue < v)
                return BadValue;

            return (Int32)v;
        }

        /// <summary>
        /// Parses System.Int32 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Int32 v)
        {
            if ((v < MinValue) || (MaxValue < v))
                return BadValue;

            return (Int32)v;
        }

        /// <summary>
        /// Parses System.UInt32 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.UInt32 v)
        {
            if (MaxValue < v)
                return BadValue;

            return (Int32)v;
        }

        /// <summary>
        /// Parses System.Int16 and returns SmartInt.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Int16 v)
        {
            return (Int32)v;
        }

        /// <summary>
        /// Parses System.UInt16 and returns SmartInt.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.UInt16 v)
        {
            return (Int32)v;
        }

        /// <summary>
        /// Parses System.SByte and returns SmartInt.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.SByte v)
        {
            return (Int32)v;
        }

        /// <summary>
        /// Parses System.Byte and returns SmartInt.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Byte v)
        {
            return (Int32)v;
        }

        /// <summary>
        /// Parses object and returns SmartInt.
        /// Returns SmartInt.BadValue if o is null, is too small or too large.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(object o)
        {
            if (o == null)
                return SmartInt.BadValue;

            if (o is SmartInt)
                return (SmartInt)o;

            if (o is String)
                return SmartInt.Parse((String)o);

            if (o is Double)
                return SmartInt.Parse((Double)o);

            if (o is SmartDouble)
                return SmartInt.Parse((SmartDouble)o);

            if (o is System.Int64)
                return SmartInt.Parse((System.Int64)o);

            if (o is System.UInt64)
                return SmartInt.Parse((System.UInt64)o);

            if (o is Int32)
                return new SmartInt((Int32)o);

            if (o is System.UInt32)
                return SmartInt.Parse((System.UInt32)o);

            if (o is System.Int16)
                return SmartInt.Parse((System.Int16)o);

            if (o is System.UInt16)
                return SmartInt.Parse((System.UInt16)o);

            if (o is System.Byte)
                return SmartInt.Parse((System.Byte)o);

            if (o is System.SByte)
                return SmartInt.Parse((System.SByte)o);

            return Parse(o.ToString());
        }

        /// <summary>
        /// Parses object and returns SmartInt.
        /// For some cases is more effective than Parse(object o).
        /// Returns SmartInt.BadValue if o is null, is negative or too large.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt ParsePositive(object o)
        {
            if (o == null)
                return SmartInt.BadValue;

            if (o is String)
                return SmartInt.ParsePositive((String)o);

            SmartInt si = Parse(o);

            if (si < 0)
                return SmartInt.BadValue;
            else
                return si;
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(12);
            SmartInt.ToStringBuilder(m_v, 0, sb);
            return sb.ToString();
        }


        /// <summary>
        /// Converts the numeric value to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public static string ToStringValue(SmartInt value)
        {
            StringBuilder sb = new StringBuilder(12);
            SmartInt.ToStringBuilder(value, 0, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation
        /// according to format.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public string ToString(string format)
        {
            if (isBad())
                return "BadValue";
            else
                return m_v.ToString(format);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public string ToString(int digits)
        {
            StringBuilder sb = new StringBuilder(12);
            SmartInt.ToStringBuilder(m_v, digits, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation
        /// into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(StringBuilder sb)
        {
            SmartInt.ToStringBuilder(m_v, 0, sb);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation
        /// into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(StringBuilder sb, int digits)
        {
            SmartInt.ToStringBuilder(m_v, digits, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public static void ToStringBuilder(
            SmartInt value,
            StringBuilder sb
            )
        {
            SmartInt.ToStringBuilder(value, 0, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public unsafe static void ToStringBuilder(
            SmartInt value,
            Int32 ndp,
            StringBuilder sb
            )
        {
            if (value == SmartInt.BadValue)
            {
                sb.Append("BadValue");
                return;
            }

            if (value == 0)
            {
                sb.Append('0');
                return;
            }

            // 12345678911
            Char* buffer = stackalloc Char[10];

            Int32 vzero = (Int32)'0';
            Int32 v1;
            Int32 v2;
            Int32 ndigits = 10;

            if (value < 0)
            {
                sb.Append("-");
                v1 = -value;
            }
            else
                v1 = value;

            for (int i = 9; i > 0; i--)
            {
                if (v1 > 0)
                    ndigits--;

                v2 = v1 / 10;

                buffer[i] = (Char)(vzero + v1 - (v2 << 3) - v2 - v2);

                v1 = v2;
            }

            int leading_zeros = ndp - 10 + ndigits;

            while (leading_zeros > 0)
            {
                sb.Append('0');
                leading_zeros--;
            }

            for (int i = ndigits; i < 10; i++)
                sb.Append(buffer[i]);

            return;
        }

        // IEquatable
        public int CompareTo(SmartInt other)
        {
            // Need to use compare because subtraction will wrap
            // to positive for very large neg numbers, etc.
            if (m_v < other) return -1;
            if (m_v > other) return 1;
            return 0;
        }

        // IEquatable
        public bool Equals(SmartInt other)
        {
            return m_v == other.m_v;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is SmartInt))
                return false;

            return m_v == ((SmartInt)obj).m_v;
        }

        public override int GetHashCode()
        {
            return m_v;
        }

        // IComparable
        public int CompareTo(Object obj)
        {
            if (obj == null)
                return 1;

            if (obj is SmartInt)
            {
                // Need to use compare because subtraction will wrap
                // to positive for very large neg numbers, etc. 
                int i = (SmartInt)obj;
                if (m_v < i) return -1;
                if (m_v > i) return 1;
                return 0;
            }

            SmartInt v2 = SmartInt.Parse(obj);

            if (!v2.isBad())
            {
                // Need to use compare because subtraction will wrap
                // to positive for very large neg numbers, etc. 
                if (m_v < v2) return -1;
                if (m_v > v2) return 1;
                return 0;
            }

            throw new ArgumentException("Type must be compatible with SSTypes.SmartInt");
        }

    }

}
