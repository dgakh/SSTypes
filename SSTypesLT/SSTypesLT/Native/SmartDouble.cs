/**********************************************************************************

Simple Smart Types Lite
https://github.com/dgakh/SSTypes
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

using System;

namespace SSTypes
{
    /// <summary>
    /// Used for quick and save operations with System.Double type.
    /// Compatible with System.Double and can be used whenever System.Double used.
    /// </summary>
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct SmartDouble : System.IComparable, System.IFormattable, System.IConvertible, System.IComparable<SmartDouble>, System.IEquatable<SmartDouble>
    {
        private System.Double m_v;

        /// <summary>
        /// Maximal valid value (10000000000000000.0)
        /// </summary>
        public static readonly SmartDouble MaxValue = 1e16;

        /// <summary>
        /// Minimal valid value (-10000000000000000.0)
        /// </summary>
        public static readonly SmartDouble MinValue = -1e16;

        /// <summary>
        /// Minimal positive valid value (0.00000000000000001)
        /// </summary>
        public static readonly SmartDouble MinPositiveValue = 1e-17;

        /// <summary>
        /// Maximal negative valid value (-0.00000000000000001)
        /// </summary>
        public static readonly SmartDouble MaxnegativeValue = -1e-17;

        /// <summary>
        /// Bad value represented absent data, wrong data, e.t.c.
        /// </summary>
        public static readonly SmartDouble BadValue = System.Double.NaN;

        // Private constants

        // Initiate directly to avoid possible accumulation of error during calculations
        private readonly static double[][] kaa2d = new double[][] {
            new double[] { 0,  1e16,  2e16,  3e16,  4e16,  5e16,  6e16,  7e16,  8e16,  9e16,  10e16 },
            new double[] { 0,  1e15,  2e15,  3e15,  4e15,  5e15,  6e15,  7e15,  8e15,  9e15,  10e15 },
            new double[] { 0,  1e14,  2e14,  3e14,  4e14,  5e14,  6e14,  7e14,  8e14,  9e14,  10e14 },
            new double[] { 0,  1e13,  2e13,  3e13,  4e13,  5e13,  6e13,  7e13,  8e13,  9e13,  10e13 },
            new double[] { 0,  1e12,  2e12,  3e12,  4e12,  5e12,  6e12,  7e12,  8e12,  9e12,  10e12 },
            new double[] { 0,  1e11,  2e11,  3e11,  4e11,  5e11,  6e11,  7e11,  8e11,  9e11,  10e11 },
            new double[] { 0,  1e10,  2e10,  3e10,  4e10,  5e10,  6e10,  7e10,  8e10,  9e10,  10e10 },
            new double[] { 0,   1e9,   2e9,   3e9,   4e9,   5e9,   6e9,   7e9,   8e9,   9e9,   10e9 },
            new double[] { 0,   1e8,   2e8,   3e8,   4e8,   5e8,   6e8,   7e8,   8e8,   9e8,   10e8 },
            new double[] { 0,   1e7,   2e7,   3e7,   4e7,   5e7,   6e7,   7e7,   8e7,   9e7,   10e7 },
            new double[] { 0,   1e6,   2e6,   3e6,   4e6,   5e6,   6e6,   7e6,   8e6,   9e6,   10e6 },
            new double[] { 0,   1e5,   2e5,   3e5,   4e5,   5e5,   6e5,   7e5,   8e5,   9e5,   10e5 },
            new double[] { 0,   1e4,   2e4,   3e4,   4e4,   5e4,   6e4,   7e4,   8e4,   9e4,   10e4 },
            new double[] { 0,   1e3,   2e3,   3e3,   4e3,   5e3,   6e3,   7e3,   8e3,   9e3,   10e3 },
            new double[] { 0,   1e2,   2e2,   3e2,   4e2,   5e2,   6e2,   7e2,   8e2,   9e2,   10e2 },
            new double[] { 0,   1e1,   2e1,   3e1,   4e1,   5e1,   6e1,   7e1,   8e1,   9e1,   10e1 },
            new double[] { 0,     1,     2,     3,     4,     5,     6,     7,     8,     9,     10 },
            new double[] { 0,  1e-1,  2e-1,  3e-1,  4e-1,  5e-1,  6e-1,  7e-1,  8e-1,  9e-1,  10e-1 },
            new double[] { 0,  1e-2,  2e-2,  3e-2,  4e-2,  5e-2,  6e-2,  7e-2,  8e-2,  9e-2,  10e-2 },
            new double[] { 0,  1e-3,  2e-3,  3e-3,  4e-3,  5e-3,  6e-3,  7e-3,  8e-3,  9e-3,  10e-3 },
            new double[] { 0,  1e-4,  2e-4,  3e-4,  4e-4,  5e-4,  6e-4,  7e-4,  8e-4,  9e-4,  10e-4 },
            new double[] { 0,  1e-5,  2e-5,  3e-5,  4e-5,  5e-5,  6e-5,  7e-5,  8e-5,  9e-5,  10e-5 },
            new double[] { 0,  1e-6,  2e-6,  3e-6,  4e-6,  5e-6,  6e-6,  7e-6,  8e-6,  9e-6,  10e-6 },
            new double[] { 0,  1e-7,  2e-7,  3e-7,  4e-7,  5e-7,  6e-7,  7e-7,  8e-7,  9e-7,  10e-7 },
            new double[] { 0,  1e-8,  2e-8,  3e-8,  4e-8,  5e-8,  6e-8,  7e-8,  8e-8,  9e-8,  10e-8 },
            new double[] { 0,  1e-9,  2e-9,  3e-9,  4e-9,  5e-9,  6e-9,  7e-9,  8e-9,  9e-9,  10e-9 },
            new double[] { 0, 1e-10, 2e-10, 3e-10, 4e-10, 5e-10, 6e-10, 7e-10, 8e-10, 9e-10, 10e-10 },
            new double[] { 0, 1e-11, 2e-11, 3e-11, 4e-11, 5e-11, 6e-11, 7e-11, 8e-11, 9e-11, 10e-11 },
            new double[] { 0, 1e-12, 2e-12, 3e-12, 4e-12, 5e-12, 6e-12, 7e-12, 8e-12, 9e-12, 10e-12 },
            new double[] { 0, 1e-13, 2e-13, 3e-13, 4e-13, 5e-13, 6e-13, 7e-13, 8e-13, 9e-13, 10e-13 },
            new double[] { 0, 1e-14, 2e-14, 3e-14, 4e-14, 5e-14, 6e-14, 7e-14, 8e-14, 9e-14, 10e-14 },
            new double[] { 0, 1e-15, 2e-15, 3e-15, 4e-15, 5e-15, 6e-15, 7e-15, 8e-15, 9e-15, 10e-15 },
            new double[] { 0, 1e-16, 2e-16, 3e-16, 4e-16, 5e-16, 6e-16, 7e-16, 8e-16, 9e-16, 10e-16 },
            new double[] { 0, 1e-16, 2e-16, 3e-16, 4e-16, 5e-16, 6e-16, 7e-16, 8e-16, 9e-16, 10e-16 }
        };

        private readonly static System.Char[] chars = new System.Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private readonly static System.Int64[] correction_powers = new System.Int64[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        private readonly static System.Double[] decimal_powers = new System.Double[] { 1, 1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6, 1e-7, 1e-8, 1e-9, 1e-10, 1e-11, 1e-12, 1e-13, 1e-14, 1e-15, 1e-16, 1e-17, 1e-18 };

        /// <summary>
        /// Construct SmartDouble from System.Double.
        /// </summary>
        public SmartDouble(System.Double value)
        {
            m_v = value;
        }

        /// <summary>
        /// Construct SmartDouble from System.Double.
        /// </summary>
        public SmartDouble(System.Double? value)
        {
            if (value.HasValue)
                m_v = value.Value;
            else
                m_v = BadValue.m_v;
        }

        /// <summary>
        /// Construct SmartDouble from System.Single.
        /// </summary>
        private SmartDouble(System.Single value)
        {
            m_v = value;
        }

        /// <summary>
        /// Returns true if value is bad (is Double.NaN) or lies outside of limiting constants.
        /// </summary>
        public bool isBad()
        {
            return (
                System.Double.IsNaN(m_v) ||
                (MaxValue.m_v < m_v) || (m_v < MaxValue.m_v) ||
                ((m_v != 0) && (MaxnegativeValue < m_v) && (m_v < MinPositiveValue))
                );
        }

        /// <summary>
        /// Converts the value of System.Double to SmartDouble.
        /// </summary>
        public static implicit operator SmartDouble(System.Double value)
        {
            return new SmartDouble(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to System.Double.
        /// </summary>
        public static implicit operator System.Double(SmartDouble value)
        {
            return value.m_v;
        }

        /// <summary>
        /// Converts the value of System.Double? to SmartDouble.
        /// Nullable compatibility support.
        /// </summary>
        public static implicit operator SmartDouble(System.Double? value)
        {
            return new SmartDouble(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to System.Double?.
        /// Nullable compatibility support.
        /// </summary>
        public static implicit operator System.Double?(SmartDouble value)
        {
            if (value.isBad())
                return null;

            return new System.Double?(value.m_v);
        }

        // Nullable compatibility support.
        public bool HasValue
        {
            get
            {
                return !isBad();
            }
        }

        // Nullable compatibility support.
        public SmartDouble Value
        {
            get
            {
                if (!HasValue)
                    throw new System.InvalidOperationException("SmartDouble must have a value.");
                else
                    return this;
            }
        }

        // Nullable compatibility support.
        public SmartDouble GetValueOrDefault()
        {
            return HasValue ? this : default(SmartDouble);
        }

        /// <summary>
        /// Converts the value of System.Single to SmartDouble.
        /// </summary>
        public static implicit operator SmartDouble(System.Single value)
        {
            return new SmartDouble(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to System.Single.
        /// </summary>
        public static explicit operator System.Single(SmartDouble value)
        {
            return (System.Single)value.m_v;
        }

        /// <summary>
        /// Converts the value of SmartInt to SmartDouble.
        /// </summary>
        public static implicit operator SmartDouble(SmartInt value)
        {
            if (value.isBad())
                return SmartDouble.BadValue;

            return new SmartDouble(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to System.Int64.
        /// </summary>
        public static explicit operator System.Int64(SmartDouble value)
        {
            return (System.Int64)value.m_v;
        }

        /// <summary>
        /// Converts the value of System.Int64 to SmartDouble explicitly.
        /// </summary>
        public static implicit operator SmartDouble(System.Int64 value)
        {
            return SmartDouble.Parse(value);
        }

        /// <summary>
        /// Converts the value of SmartDouble to System.Decimal.
        /// </summary>
        public static explicit operator System.Decimal(SmartDouble value)
        {
            return (System.Decimal)value.m_v;
        }

        /// <summary>
        /// Converts the value of System.Decimal to SmartDouble.
        /// </summary>
        public static explicit operator SmartDouble(System.Decimal value)
        {
            return new SmartDouble((System.Double)value);
        }

        /// <summary>
        /// Parses System.Decimal and returns SmartDouble.
        /// Returns SmartDouble.BadValue if d is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.Decimal d)
        {
            if ((d < (System.Decimal)MinValue) || ((System.Decimal)MaxValue < d))
                return BadValue;

            return (System.Double)d;
        }

        /// <summary>
        /// Parses System.Int64 and returns SmartDouble.
        /// Returns SmartDouble.BadValue if v is too small or too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.Int64 v)
        {
            if ((v < MinValue) || (MaxValue < v))
                return BadValue;

            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.UInt64 and returns SmartDouble.
        /// Returns SmartDouble.BadValue if v is too big.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.UInt64 v)
        {
            if (MaxValue < v)
                return BadValue;

            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.Int32 and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.Int32 v)
        {
            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.UInt32 and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.UInt32 v)
        {
            return (SmartDouble)v;
        }

        /// <summary>
        /// Parses System.Int16 and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.Int16 v)
        {
            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.UInt16 and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.UInt16 v)
        {
            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.SByte and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.SByte v)
        {
            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.Byte and returns SmartDouble.
        /// Does not throw exception.
        /// </summary>
        public static SmartDouble Parse(System.Byte v)
        {
            return (System.Double)v;
        }

        /// <summary>
        /// Parses System.String and returns SmartDouble.
        /// Does not throw exception.
        /// Returns SmartDouble.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// Considers point and comma as decimal delimeter.
        /// </summary>
        public static SmartDouble Parse(System.String s)
        {
            if (s == null)
                return SmartDouble.BadValue;
            else
                return Parse(s, 0, s.Length - 1);
        }

        /// <summary>
        /// Parses System.String from inclusive start position to inclusive end position and returns SmartDouble.
        /// Does not throw exception.
        /// Returns SmartDouble.BadValue if error.
        /// Control if string is null, cannot parse or contained a too big number.
        /// Considers point as decimal delimeter and comma as thousands separator.
        /// </summary>
        public static SmartDouble Parse(System.String s, int start, int end)
        {
            System.UInt32 v1 = 0;
            System.UInt32 v2 = 0;

            int digits = 0;

            if (s == null)
                return SmartDouble.BadValue;

            int end2 = end + 1;

            if (end2 > s.Length)
                return SmartDouble.BadValue;

            int pw = 0;
            bool dec_sep = false;

            char sep_decimal = '.';
            char th_digital = ',';

            bool is_negative = false;
            bool is_positive = false;

            int pos = start;

            while (pos < end2)
            {
                char c = s[pos];

                if (('0' <= c) && (c <= '9'))
                {

                    if (digits < 9)
                    {
                        v1 = (v1 << 3) + v1 + v1;
                        v1 += (System.UInt32)(c - '0');
                        digits++;
                    }
                    else
                    {
                        if (digits > 17)
                            return SmartDouble.BadValue;

                        v2 = (v2 << 3) + v2 + v2;
                        v2 += (System.UInt32)(c - '0');
                        digits++;
                    }

                    if (dec_sep)
                        pw++;

                    pos++;
                    continue;
                }

                if (c == sep_decimal)
                {
                    if (dec_sep)
                        return SmartDouble.BadValue;

                    dec_sep = true;

                    pos++;
                    continue;
                }

                if (c == th_digital)
                {
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
                            return SmartDouble.BadValue;
                    }
                    else
                    {
                        while ((pos < end2) && (s[pos] == ' '))
                            pos++;

                        if (pos != end2)
                            return SmartDouble.BadValue;
                    }

                    continue;
                }

                if (c == '-')
                {
                    if ((is_negative) || (is_positive))
                        return SmartDouble.BadValue;

                    is_negative = true;
                    pos++;
                    continue;
                }

                if (c == '+')
                {
                    if ((is_negative) || (is_positive))
                        return SmartDouble.BadValue;

                    is_positive = true;
                    pos++;
                    continue;
                }

                return SmartDouble.BadValue;
            }

            if (digits < 9)
            {
                if (is_negative)
                    return -v1 * decimal_powers[pw];
                else
                    return v1 * decimal_powers[pw];
            }
            else
            {
                System.Int64 vv = correction_powers[digits - 9] * v1 + v2;

                if (is_negative)
                    return -vv * decimal_powers[pw];
                else
                    return vv * decimal_powers[pw];
            }
        }

        /// <summary>
        /// Parses System.Object and returns SmartDouble.
        /// Does not throw exception.
        /// Returns SmartDouble.BadValue if error.
        /// Control if containing value is null, cannot parse or contained a too big number.
        /// Considers point as decimal delimeter and comma as thousands separator.
        /// </summary>
        public static SmartDouble Parse(System.Object o)
        {
            if (o == null)
                return SmartDouble.BadValue;

            if (o is SmartDouble)
                return (SmartDouble)o;

            if (o is System.String)
                return SmartDouble.Parse((System.String)o);

            if (o is System.Double)
                return (System.Double)o;

            if (o is SmartDouble)
                return (SmartDouble)o;

            if (o is System.Int64)
                return SmartDouble.Parse((System.Int64)o);

            if (o is System.UInt64)
                return SmartDouble.Parse((System.UInt64)o);

            if (o is System.Int32)
                return (System.Double)(System.Int32)o;

            if (o is System.UInt32)
                return SmartDouble.Parse((System.UInt32)o);

            if (o is System.Int16)
                return SmartDouble.Parse((System.Int16)o);

            if (o is System.UInt16)
                return SmartDouble.Parse((System.UInt16)o);

            if (o is System.Byte)
                return SmartDouble.Parse((System.Byte)o);

            if (o is System.SByte)
                return SmartDouble.Parse((System.SByte)o);

            return SmartDouble.Parse(o.ToString());
        }

        /// <summary>
        /// Converts the value to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public string ToString(System.Int32 digits)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(16);
            ToStringBuilder('.', (System.Byte)digits, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the value to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public string ToString(char point, System.Int32 digits)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(16);
            ToStringBuilder(point, (System.Byte)digits, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the value to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public string ToString(char point)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(16);
            ToStringBuilder(point, 12, sb);
            return sb.ToString();
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
            System.Text.StringBuilder sb = new System.Text.StringBuilder(14);
            ToStringBuilder('.', 12, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the value to its equivalent string representation.
        /// Returns:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public static string ToStringValue(SmartDouble value)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(14);
            SmartDouble.ToStringBuilder(value, '.', 12, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(System.Int32 digits, System.Text.StringBuilder sb)
        {
            ToStringBuilder('.', (System.Byte)digits, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(char point, System.Int32 digits, System.Text.StringBuilder sb)
        {
            SmartDouble.ToStringBuilder(m_v, point, (System.Byte)digits, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(char point, System.Text.StringBuilder sb)
        {
            ToStringBuilder(point, 12, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        public void ToStringBuilder(System.Text.StringBuilder sb)
        {
            ToStringBuilder('.', 12, sb);
        }

        /// <summary>
        /// Converts the value to its equivalent string representation and puts it into StringBuilder.
        /// Returns into StringBuilder:
        ///     The string representation of the value of this instance, consisting of a
        ///     negative sign if the value is negative, and a sequence of digits ranging
        ///     from 0 to 9 with no leading zeroes.
        /// </summary>
        // max ndp = 16
        // Should be tested for not empty StringBuilder
        public unsafe static void ToStringBuilder(
            SmartDouble value,
            char point,
            System.Byte ndp,
            System.Text.StringBuilder sb
            )
        {
            System.SByte round_pos;

            System.Int32 sb_initial_length = sb.Length;

            if (ndp > 16)
                round_pos = 16;
            else
                round_pos = (System.SByte)ndp;

            System.SByte alen2 = (System.SByte)kaa2d.Length;

            System.Byte* aar = stackalloc System.Byte[alen2];

            if (value > MaxValue)
            {
                sb.Append("NaN");
                return;
            }

            double d1;

            if (value < 0)
            {
                d1 = -value;

                if (d1 > MaxValue)
                {
                    sb.Append("NaN");
                    return;
                }

                sb.Append('-');
            }
            else
            {
                d1 = value;

                if (value == 0.0)
                {
                    sb.Append('0');
                    return;
                }
            }

            System.SByte pos = 0;

            // Leading Zeros
            while ((pos < alen2) && (d1 < kaa2d[pos][1]))
            {
                aar[pos] = 0;
                pos++;
            }

            const System.SByte point_pos = 17;

            System.SByte start_pos;
            if (pos >= point_pos)
                start_pos = point_pos;
            else
                start_pos = pos;

            // Digits
            while (pos < kaa2d.Length)
            {
                if (d1 < kaa2d[pos][5])
                {
                    if (d1 < kaa2d[pos][3])
                    {
                        if (d1 < kaa2d[pos][2])
                        {
                            if (d1 < kaa2d[pos][1])
                                aar[pos] = 0;
                            else
                                aar[pos] = 1;
                        }
                        else
                        {
                            aar[pos] = 2;
                        }
                    }
                    else
                    {
                        if (d1 < kaa2d[pos][4])
                            aar[pos] = 3;
                        else
                            aar[pos] = 4;
                    }
                }
                else
                {
                    if (d1 < kaa2d[pos][8])
                    {
                        if (d1 < kaa2d[pos][7])
                        {
                            if (d1 < kaa2d[pos][6])
                                aar[pos] = 5;
                            else
                                aar[pos] = 6;
                        }
                        else
                        {
                            aar[pos] = 7;
                        }
                    }
                    else
                    {
                        if (d1 < kaa2d[pos][9])
                            aar[pos] = 8;
                        else
                            aar[pos] = 9;
                    }
                }

                d1 -= kaa2d[pos][aar[pos]];

                pos++;
            }

            pos--;

            // Round

            bool digit = false;
            round_pos += point_pos;

            // Force round
            while(pos > round_pos)
            {
                digit = (aar[pos] >= 4);
                pos--;
            }

            // Put digit if is and remove right 0-s till the point
            while (pos >= 0)
            {
                if (digit)
                {
                    if (aar[pos] < 9)
                    {
                        aar[pos]++;
                        digit = false;
                        break;
                    }
                    else
                    {
                        digit = true;
                        pos--;
                        continue;
                    }
                }
                else
                {
                    if (aar[pos] == 0)
                    {
                        if (pos == point_pos)
                        {
                            pos--;
                            break;
                        }

                        pos--;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (digit && (pos <= 0))
            {
                sb.Length = sb_initial_length;
                sb.Append("NaN");
                return;
            }

            if (start_pos == point_pos)
                sb.Append('0');

            System.SByte stop_pos = pos;

            pos = start_pos;
            while ((pos <= stop_pos) && (pos > 0))
            {
                if(pos == point_pos)
                    sb.Append('.');

                sb.Append(chars[aar[pos]]);

                pos++;
            }

            if(sb.Length == sb_initial_length)
                sb.Append('0');

            return;
        }

        // IEquatable
        public int CompareTo(SmartDouble other)
        {
            if (m_v < other) return -1;
            if (m_v > other) return 1;
            return 0;
        }

        // IEquatable
        public bool Equals(SmartDouble other)
        {
            return m_v == other.m_v;
        }

        public override bool Equals(System.Object obj)
        {
            if (!(obj is SmartDouble))
                return false;

            return m_v == ((SmartDouble)obj).m_v;
        }

        public override int GetHashCode()
        {
            return m_v.GetHashCode();
        }

        // IComparable
        public int CompareTo(System.Object obj)
        {
            if (obj == null)
                return 1;

            if (obj is SmartDouble)
            {
                System.Double d = (SmartDouble)obj;
                if (m_v < d) return -1;
                if (m_v > d) return 1;
                return 0;
            }

            SmartDouble v2 = SmartDouble.Parse(obj);

            if (!v2.isBad())
            {
                if (m_v < v2) return -1;
                if (m_v > v2) return 1;
                return 0;
            }

            throw new System.ArgumentException("Type must be compatible with SSTypes.SmartDouble");
        }

        public Type GetType()
        {
            return m_v.GetType();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return m_v.ToString(format, formatProvider);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Double;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(m_v);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(m_v);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(m_v);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(m_v);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(m_v);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(m_v);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(m_v);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(m_v);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(m_v);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(m_v);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(m_v);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return m_v;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(m_v);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("InvalidCast from SmartInt to DateTime");
        }

        public string ToString(IFormatProvider provider)
        {
            return m_v.ToString(provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException("SmartDouble.ToType is not implemented");
            // return Convert.DefaultToType((IConvertible)this, type, provider);
        }

    }
}
