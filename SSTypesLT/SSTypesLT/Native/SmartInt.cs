/**********************************************************************************

Simple Smart Types Lite
-----------------------

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
    /// <summary>
    /// Used for quick and save operations with System.Int32 type.
    /// Compatible with System.Int32 and can be used whenever System.Int32 used.
    /// </summary>
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct SmartInt : System.IComparable, System.IComparable<SmartInt>, System.IEquatable<SmartInt>
    {
        private System.Int32 m_v;

        /// <summary>
        /// Bad value represented absent data, wrong data, e.t.c.
        /// </summary>
        public static readonly SmartInt BadValue = System.Int32.MinValue;

        /// <summary>
        /// Maximal valid value (2147483647)
        /// </summary>
        public static readonly SmartInt MaxValue = System.Int32.MaxValue;

        /// <summary>
        /// Minimal valid value (-2147483647)
        /// </summary>
        public static readonly SmartInt MinValue = System.Int32.MinValue + 1;

        // Private constants
        // Used internally to control possible overloading.
        private static readonly System.Int32 max_predparse_value = ((System.Int32.MaxValue - 1) / 10);

        /// <summary>
        /// Construct SmartInt from System.Int32.
        /// </summary>
        public SmartInt(System.Int32 value)
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
        /// Converts the value of System.Int32 to SmartInt.
        /// </summary>
        public static implicit operator SmartInt(System.Int32 value)
        {
            return new SmartInt(value);
        }

        /// <summary>
        /// Converts the value of SmartInt to System.Int32.
        /// </summary>
        public static implicit operator System.Int32(SmartInt value)
        {
            return value.m_v;
        }

        /// <summary>
        /// Converts the value of System.Int16 to SmartInt.
        /// </summary>
        public static implicit operator SmartInt(System.Int16 value)
        {
            return new SmartInt(value);
        }

        /// <summary>
        /// Converts the value of SmartInt to System.Int16.
        /// </summary>
        public static explicit operator System.Int16(SmartInt value)
        {
            return (System.Int16)value.m_v;
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
        public static explicit operator SmartInt(System.Int64 value)
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
        public static explicit operator SmartInt(System.Double value)
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
        public static explicit operator SmartInt(System.Decimal value)
        {
            if (value < SmartInt.MinValue)
                return SmartInt.BadValue;

            if (SmartInt.MaxValue < value)
                return SmartInt.BadValue;

            return new SmartInt((System.Int32)value);
        }

        /// <summary>
        /// Was not tested well !!!
        /// Parses to SmartInt binary values represented as string containing 0s and 1s.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, empty, cannot parse or contained a too long number.
        /// </summary>
        public static SmartInt ParseBinary(System.String b)
        {
            if (b == null)
                return SmartInt.BadValue;

            System.Int32 l = b.Length;

            System.Int32 number = 0;
            System.Int32 mr = 1;

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
        /// Parses System.String and returns SmartInt.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// </summary>
        public static SmartInt Parse(System.String s)
        {
            if (s != null)
                return SmartInt.Parse(s, 0, s.Length - 1);
            else
                return SmartInt.BadValue;
        }

        /// <summary>
        /// Parses System.String from inclusive start position to inclusive end position and returns SmartInt.
        /// Does not throw exception.
        /// Returns SmartInt.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// </summary>
        public static SmartInt Parse(System.String s, int start, int end)
        {
            if (s == null)
                return SmartInt.BadValue;

            int end2 = end + 1;

            if (end2 > s.Length)
                return SmartInt.BadValue;

            System.Int32 number = 0;

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
                    number += (System.Int32)(c - '0');

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
        /// Parses System.Double and returns SmartInt.
        /// Returns SmartInt.BadValue if d is too small or too big.
        /// Rounds d.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Double d)
        {
            double r = System.Math.Round(d);

            if ((r < MinValue) || (MaxValue < r))
                return BadValue;

            return (System.Int32)r;
        }

        /// <summary>
        /// Parses Decimal and returns SmartInt.
        /// Returns SmartInt.BadValue if d is too small or too big.
        /// Rounds d.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Decimal d)
        {
            System.Decimal r = System.Math.Round(d);

            if ((r < MinValue) || (MaxValue < r))
                return BadValue;

            return (System.Int32)r;
        }

        /// <summary>
        /// Parses SmartDouble and returns SmartInt.
        /// Returns SmartInt.BadValue if d is BadValue.
        /// Rounds d.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(SmartDouble d)
        {
            if (d.isBad())
                return SmartInt.BadValue;

            return Parse((System.Double)d);
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

            return (System.Int32)v;
        }

        /// <summary>
        /// Parses System.UInt64 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.UInt64 v)
        {
            if ((System.UInt64)(System.Int64)MaxValue < v)
                return BadValue;

            return (System.Int32)v;
        }

        /// <summary>
        /// Parses System.UInt32 and returns SmartInt.
        /// Returns SmartInt.BadValue if v is too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.UInt32 v)
        {
            if (MaxValue < v)
                return BadValue;

            return (System.Int32)v;
        }

        /// <summary>
        /// Parses System.Object and returns SmartInt.
        /// Returns SmartInt.BadValue if value of o is null, is too small or too large.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt Parse(System.Object o)
        {
            if (o == null)
                return SmartInt.BadValue;

            if (o is SmartInt)
                return (SmartInt)o;

            if (o is System.String)
                return SmartInt.Parse((System.String)o);

            if (o is System.Double)
                return SmartInt.Parse((System.Double)o);

            if (o is SmartDouble)
                return SmartInt.Parse((SmartDouble)o);

            if (o is System.Int64)
                return SmartInt.Parse((System.Int64)o);

            if (o is System.UInt64)
                return SmartInt.Parse((System.UInt64)o);

            if (o is System.Int32)
                return new SmartInt((System.Int32)o);

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
        /// Parses System.Object and returns SmartInt.
        /// For some cases is more effective than Parse(object o).
        /// Returns SmartInt.BadValue if o is null, is negative or too large.
        /// Does not throw exception.
        /// </summary>
        public static SmartInt ParsePositive(System.Object o)
        {
            if (o == null)
                return SmartInt.BadValue;

            if (o is System.String)
                return SmartInt.ParsePositive((System.String)o);

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
            System.Text.StringBuilder sb = new System.Text.StringBuilder(12);
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder(12);
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
        public string ToString(System.String format)
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder(12);
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
        public void ToStringBuilder(System.Text.StringBuilder sb)
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
        public void ToStringBuilder(System.Text.StringBuilder sb, int digits)
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
        public static void ToStringBuilder(SmartInt value, System.Text.StringBuilder sb)
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
            System.Int32 ndp,
            System.Text.StringBuilder sb
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
            System.Char* buffer = stackalloc System.Char[10];

            System.Int32 vzero = (System.Int32)'0';
            System.Int32 v1;
            System.Int32 v2;
            System.Int32 ndigits = 10;

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

                buffer[i] = (System.Char)(vzero + v1 - (v2 << 3) - v2 - v2);

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

        public override bool Equals(System.Object obj)
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
        public int CompareTo(System.Object obj)
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

            throw new System.ArgumentException("Type must be compatible with SSTypes.SmartInt");
        }
    }
}
