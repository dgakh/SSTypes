/**********************************************************************************
Simple Smart Types Lite
https://github.com/dgakh/SSTypes
File: SmartBool
Updated: March 28, 2019
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
    using System;

    /// <summary>
    /// Used for quick and save operations with ternary logic.
    /// Includes <see cref="SmartBool.Unknown"/> value.
    /// https://referencesource.microsoft.com/#mscorlib/system/boolean.cs
    /// </summary>
#if !COREFX
    [System.Serializable, System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
#endif
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct SmartBool : IComparable, IComparable<SmartBool>, IEquatable<SmartBool>, IConvertible
    {
        private System.SByte m_v;

        /// <summary>
        /// The false value.
        /// </summary>
        internal const sbyte ibFalse = -1;

        /// <summary>
        /// The true value. 
        /// </summary>
        internal const sbyte ibTrue = 1;

        /// <summary>
        /// The Unknown value. 
        /// </summary>
        internal const sbyte ibUnknown = 0;

        /// <summary>
        /// The internal string representation of false.
        /// </summary>
        internal const String FalseLiteral = "False";

        /// <summary>
        /// The internal string representation of true.
        /// </summary>
        internal const String TrueLiteral = "True";

        /// <summary>
        /// The internal string representation of Unknown.
        /// </summary>
        internal const String UnknownLiteral = "Unknown";

        /// <summary>
        /// The public string representation of false.
        /// </summary>
        public static readonly String FalseString = FalseLiteral;

        /// <summary>
        /// The public string representation of true.
        /// </summary>
        public static readonly String TrueString = TrueLiteral;

        /// <summary>
        /// The public string representation of Unknown.
        /// </summary>
        public static readonly String UnknownString = TrueLiteral;

        /// <summary>
        /// The value of false.
        /// </summary>
        public static readonly SmartBool False = new SmartBool(ibFalse);

        /// <summary>
        /// The value of true.
        /// </summary>
        public static readonly SmartBool True = new SmartBool(ibTrue);

        /// <summary>
        /// The value of Unknown.
        /// </summary>
        public static readonly SmartBool Unknown = new SmartBool(ibUnknown);

        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartBool" /> struct.
        /// </summary>
        /// <param name="value">The initial value 
        /// (<see cref="SmartBool.ibFalse" /> equals false,
        /// <see cref="SmartBool.ibTrue" /> equals true,
        /// other values equal Unknown).</param>
        public SmartBool(Int32 value)
        {
            if (value == ibFalse)
                m_v = ibFalse;
            else
                if (value == ibTrue)
                m_v = ibTrue;
            else
                m_v = ibUnknown;
        }
        */

        /// <summary>
        /// Constructs <see cref="SmartBool" /> struct from s byte.
        /// Is internal because does not check value fo range.
        /// </summary>
        /// <param name="value">The initial value</param>
        SmartBool(sbyte value)
        {
            m_v = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartBool" /> struct.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public SmartBool(bool value)
        {
            m_v = (value ? ibTrue : ibFalse);
        }

        /// <summary>
        /// Constructs <see cref="SmartBool"/> from <see cref="System.Boolean?"/>.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public SmartBool(System.Boolean? value)
        {
            if (value.HasValue)
                m_v = (value.Value ? ibTrue : ibFalse);
            else
                m_v = ibUnknown;
        }

        /// <summary>
        /// Constructs <see cref="SmartBool"/> from <see cref="SmartBool?"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        public SmartBool(SmartBool? value)
        {
            if (value.HasValue)
                m_v = (value.Value ? ibTrue : ibFalse);
            else
                m_v = ibUnknown;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmartBool"/> struct 
        /// from the case insensitive string. See <see cref="SmartBool.Parse(string)"/>
        /// for details.
        /// </summary>
        /// <param name="s">The text string.</param>
        public SmartBool(string s)
        {
            this = Parse(s);
        }

        /// <summary>
        /// Returns true if value is Unknown. Operator == cannot be used
        /// to compare value with Unknown constant because it olways returns
        /// Unknown as the result.
        /// </summary>
        /// <returns><c>true</c> if this instance is Unknown; otherwise, <c>false</c>.</returns>
        public bool isUnknown()
        {
            return m_v == ibUnknown;
        }

        /// <summary>
        /// Returns true if value is False.
        /// </summary>
        /// <returns><c>true</c> if this instance is false; otherwise, <c>false</c>.</returns>
        public bool isFalse()
        {
            return m_v == ibFalse;
        }

        /// <summary>
        /// Returns true if value is True.
        /// </summary>
        /// <returns><c>true</c> if this instance is true; otherwise, <c>false</c>.</returns>
        public bool isTrue()
        {
            return m_v == ibTrue;
        }

        /// <summary>
        /// Returns true if value is Unknown. Operator == cannot be used
        /// to compare value with Unknown constant because it olways returns
        /// Unknown as the result.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is Unknown; otherwise, <c>false</c>.</returns>
        public static bool isUnknown(SmartBool v)
        {
            return v.m_v == ibUnknown;
        }

        /// <summary>
        /// Returns true if value is False.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is false; otherwise, <c>false</c>.</returns>
        public static bool isFalse(SmartBool v)
        {
            return v.m_v == ibFalse;
        }

        /// <summary>
        /// Returns true if value is True.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is true; otherwise, <c>false</c>.</returns>
        public static bool isTrue(SmartBool v)
        {
            return v.m_v == ibTrue;
        }

        /// <summary>
        /// Returns true if value is Unknown. Operator == cannot be used
        /// to compare value with Unknown constant because it olways returns
        /// Unknown as the result.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is Unknown; otherwise, <c>false</c>.</returns>
        public static bool isUnknown(bool v)
        {
            return false;
        }

        /// <summary>
        /// Returns true if value is False.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is false; otherwise, <c>false</c>.</returns>
        public static bool isFalse(bool v)
        {
            return !v;
        }

        /// <summary>
        /// Returns true if value is True.
        /// </summary>
        /// <param name="v">Value to be tested</param>
        /// <returns><c>true</c> if this instance is true; otherwise, <c>false</c>.</returns>
        public static bool isTrue(bool v)
        {
            return v;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Boolean"/> to
        /// <see cref="SmartBool"/>.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator SmartBool(System.Boolean value)
        {
            return new SmartBool(value);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SmartBool"/> to
        /// <see cref="System.Boolean"/>.
        /// !!! Converts <see cref="SmartBool.Unknown"/> to <c>false</c>. !!!
        /// </summary>
        /// <param name="value"><see cref="SmartBool"/> operand.</param>
        /// <returns><c>true</c> if operand is <see cref="SmartBool.True"/>.
        /// <c>false</c> for other values.</returns>
        public static explicit operator System.Boolean(SmartBool value)
        {
            return (value.m_v == ibTrue);
        }

        /// <summary>
        /// Converts the value of <c>System.Boolean?</c> to <see cref="SmartBool"/>.
        /// Nullable compatibility support.
        /// </summary>
        public static implicit operator SmartBool(System.Boolean? value)
        {
            return new SmartBool(value);
        }

        /// <summary>
        /// Converts the value of <see cref="SmartBool" /> to <c>System.Boolean?</c>.
        /// Nullable compatibility support.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator System.Boolean? (SmartBool value)
        {
            if (value.m_v == ibUnknown)
                return null;

            return (value.m_v == ibTrue);
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// Nullable compatibility support.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public bool HasValue
        {
            get
            {
                return (m_v != ibUnknown);
            }
        }

        /// <summary>
        /// Gets the value.
        /// Nullable compatibility support.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="System.InvalidOperationException">SmartBool must have a value.</exception>
        public SmartBool Value
        {
            get
            {
                if (!HasValue)
                    throw new System.InvalidOperationException("SmartBool must have a value.");
                else
                    return this;
            }
        }

        /// <summary>
        /// Gets the value or default.
        /// Nullable compatibility support.
        /// </summary>
        /// <returns>the value or default.</returns>
        public SmartBool GetValueOrDefault()
        {
            return HasValue ? this : default(SmartBool);
        }

        /// <summary>
        /// Negates a value.
        /// </summary>
        /// <param name="v">Value to be negated</param>
        /// <returns>Negated value of the argument</returns>
        public static SmartBool operator !(SmartBool v)
        {
            return new SmartBool((sbyte)-v.m_v);
        }

        /// <summary>
        /// Implements the logical OR operator.
        /// (Not tested)
        /// </summary>
        /// <param name="a">Operand a.</param>
        /// <param name="b">Operand b.</param>
        /// <returns>
        /// <see cref="SmartBool.True"/> if a or b is <see cref="SmartBool.True"/>,
        /// <see cref="SmartBool.False"/> if a or b is <see cref="SmartBool.False"/>,
        /// <see cref="SmartBool.Unknown"/> in other cases.
        /// </returns>
        public static SmartBool operator |(SmartBool a, SmartBool b)
        {
            if ((a.m_v == ibTrue) || (b.m_v == ibTrue))
            {
                return True;
            }

            if ((a.m_v == ibUnknown) || (b.m_v == ibUnknown))
            {
                return Unknown;
            }

            return False;
        }

        /// <summary>
        /// Implements the logical AND operator.
        /// </summary>
        /// <param name="a">Operand a.</param>
        /// <param name="b">Operand b.</param>
        /// <returns>
        /// <see cref="SmartBool.Unknown"/> if a or b is <see cref="SmartBool.Unknown"/>,
        /// <see cref="SmartBool.False"/> if a or b is <see cref="SmartBool.False"/>,
        /// <see cref="SmartBool.True"/> in other cases.
        /// </returns>
        public static SmartBool operator &(SmartBool a, SmartBool b)
        {
            if ((a.m_v == ibFalse) || (b.m_v == ibFalse))
            {
                return False;
            }

            if ((a.m_v == ibUnknown) || (b.m_v == ibUnknown))
            {
                return Unknown;
            }

            return True;
        }

        /// <summary>
        /// Implements the == operator.
        /// (Not tested)
        /// </summary>
        /// <param name="a">Operand a.</param>
        /// <param name="b">Operand b.</param>
        /// <returns>
        /// <see cref="SmartBool.True"/> if values of operands equal.
        /// <see cref="SmartBool.False"/> if values of operands are not equal.
        /// <see cref="SmartBool.Unknown"/> if operand a or operand b is,
        /// or both are <see cref="SmartBool.Unknown"/>.
        /// </returns>
        public static SmartBool operator ==(SmartBool a, SmartBool b)
        {
            if ((a.m_v == ibUnknown) || (b.m_v == ibUnknown))
            {
                return SmartBool.Unknown;
            }

            return (a.m_v == b.m_v);
        }

        /// <summary>
        /// Implements the != operator.
        /// (Not tested)
        /// </summary>
        /// <param name="a">Operand a.</param>
        /// <param name="b">Operand b.</param>
        /// <returns>
        /// <see cref="SmartBool.True"/> if values of operands are not equal.
        /// <see cref="SmartBool.False"/> if values of operands equal.
        /// <see cref="SmartBool.Unknown"/> if operand a or operand b is,
        /// or both are <see cref="SmartBool.Unknown"/>.
        /// </returns>
        public static SmartBool operator !=(SmartBool a, SmartBool b)
        {
            if ((a.m_v == ibUnknown) || (b.m_v == ibUnknown))
            {
                return SmartBool.Unknown;
            }

            return (a.m_v != b.m_v);
        }

        /// <summary>
        /// Performs Exclusive OR between operand a and operand b.
        /// </summary>
        /// <param name="a">Operand a.</param>
        /// <param name="b">Operand b.</param>
        /// <returns>Result of Exclusive OR.</returns>
        public static SmartBool operator ^(SmartBool a, SmartBool b)
        {
            return (a | b) & !(a & b);
        }

        /// <summary>
        /// Performs Implification between this instance and the given value.
        /// </summary>
        /// <param name="value">the given value</param>
        /// <returns>Result of Implification.</returns>
        public SmartBool Implies(SmartBool value)
        {
            return !this | value;
        }

        /// <summary>
        /// Implements the true operator.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if the operand is <see cref="SmartBool.True"/>, <c>false</c> otherwise.
        /// </returns>
        public static bool operator true(SmartBool value)
        {
            return value.m_v == ibTrue;
        }

        /// <summary>
        /// Implements the false operator.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if the operand is <see cref="SmartBool.False"/>, <c>false</c> otherwise.
        /// </returns>
        public static bool operator false(SmartBool value)
        {
            return value.m_v == ibFalse;
        }

        /// <summary>
        /// Parses the specified string for only "true"/"false".
        /// </summary>
        /// <param name="s">The operand - case insensitive string - "true" or "false".</param>
        /// <returns><see cref="SmartBool"/> value.</returns>
        public static SmartBool ParseTF(string s)
        {
            SmartBool sb;

            if ((s == null) || (s.Length < 4) || (5 < s.Length))
            {
                sb.m_v = ibUnknown;
                return sb;
            }

            if ((s[0] == 't') || (s[0] == 'T'))
            {
                // if (s.ToUpper().Equals("TRUE"))
                if (s.Equals("TRUE", StringComparison.OrdinalIgnoreCase))
                {
                    sb.m_v = ibTrue;
                    return sb;
                }
            }

            if ((s[0] == 'f') || (s[0] == 'F'))
            {
                // if (s.ToUpper().Equals("FALSE"))
                if (s.Equals("FALSE", StringComparison.OrdinalIgnoreCase))
                {
                    sb.m_v = ibFalse;
                    return sb;
                }
            }

            sb.m_v = ibUnknown;
            return sb;
        }

        /// <summary>
        /// Parses the specified string.
        /// </summary>
        /// <param name="s">The operand - case insensitive string. Possible values are:
        /// "true" or "false";
        /// "on" or "off";
        /// "yes" or "no";
        /// "y" or "n":
        /// "t" or "f".
        /// </param>
        /// <returns><see cref="SmartBool"/> value.</returns>
        public static SmartBool Parse(string s)
        {
            SmartBool sb;

            if (string.IsNullOrEmpty(s))
            {
                sb.m_v = ibUnknown;
                return sb;
            }

            string s2 = s.Trim().ToLower();

            if (s2 == "true")
            {
                sb.m_v = ibTrue;
                return sb;
            }

            if (s2 == "false")
            {
                sb.m_v = ibFalse;
                return sb;
            }

            if (s2 == "on")
            {
                sb.m_v = ibTrue;
                return sb;
            }

            if (s2 == "off")
            {
                sb.m_v = ibFalse;
                return sb;
            }

            if (s2 == "yes")
            {
                sb.m_v = ibTrue;
                return sb;
            }

            if (s2 == "no")
            {
                sb.m_v = ibFalse;
                return sb;
            }

            if (s2 == "y")
            {
                sb.m_v = ibTrue;
                return sb;
            }

            if (s2 == "n")
            {
                sb.m_v = ibFalse;
                return sb;
            }

            if (s2 == "t")
            {
                sb.m_v = ibTrue;
                return sb;
            }

            if (s2 == "f")
            {
                sb.m_v = ibFalse;
                return sb;
            }

            sb.m_v = ibUnknown;
            return sb;
        }

        /// <summary>
        /// Parses the specified object.
        /// </summary>
        /// <param name="o">The operand.</param>
        /// <returns><see cref="SmartBool"/> value.</returns>
        public static SmartBool Parse(object o)
        {
            if (o == null)
                return SmartBool.Unknown;

            if (o is bool)
                return new SmartBool((bool)o);

            if (o is string)
                return new SmartBool((string)o);

            if (o is SmartBool)
                return new SmartBool(((SmartBool)o).m_v);

            return new SmartBool(o.ToString());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            if (isTrue())
                return TrueLiteral;

            if (isFalse())
                return FalseLiteral;

            return UnknownLiteral;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// Designing to increase perdormance by prevent boxing.
        /// </summary>
        public static string ToStringValue(SmartBool value)
        {
            if (value.isTrue())
                return TrueLiteral;

            if (value.isFalse())
                return FalseLiteral;

            return UnknownLiteral;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for
        /// use in hashing algorithms and data structures like
        /// a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return m_v;
        }

        // IComparable<SmartInt>
        /// <summary>
        /// Compares this instance to the other. Unknown is the less than False.
        /// False is less than True.
        /// (Not tested)
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>
        /// -1 if this instance is in less significance than the other.
        /// 0 if this instance is equals to the other.
        /// 1 if this instance is in greater significance than the other.
        /// </returns>
        public int CompareTo(SmartBool other)
        {
            if (m_v == other.m_v)
                return 0;

            if (m_v == ibUnknown)
                return -1;

            if ((m_v == ibFalse) && (other.m_v == ibTrue))
                return -1;

            return 1;
        }

        // IComparable
        /// <summary>
        ///  Compares this instance to the other as an object.
        ///  Does not throw exception.
        ///  Object of not supported type considers as less significant.
        /// (Not tested)
        /// </summary>
        /// <param name="obj">The other instance as an object.</param>
        /// <returns>
        /// -1 if this instance is in less significance than the other.
        /// 0 if this instance is equals to the other.
        /// 1 if this instance is in greater significance than the other.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is SmartBool)
            {
                return CompareTo((SmartBool)obj);
            }

            return CompareTo(SmartBool.Parse(obj));
        }

        // IEquatable<SmartBool>
        /// <summary>
        /// Equalses the specified other.
        /// (Not tested)
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns><c>true</c> if both instances are equal,
        /// <c>false</c> if both are Unknown or not equal.</returns>
        public bool Equals(SmartBool other)
        {
            if ((m_v == ibUnknown) && (other.m_v == ibUnknown))
                return false;

            return m_v == other.m_v;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SmartBool))
                return false;

            return Equals((SmartBool)obj);
        }

        // IConvertible
        public Type GetType()
        {
            return m_v.GetType();
        }

        // IConvertible
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return m_v.ToString(format, formatProvider);
        }

        // IConvertible
        public TypeCode GetTypeCode()
        {
            return TypeCode.Int32;
        }

        // IConvertible
        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(m_v);
        }

        // IConvertible
        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(m_v);
        }

        // IConvertible
        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(m_v);
        }

        // IConvertible
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(m_v);
        }

        // IConvertible
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(m_v);
        }

        // IConvertible
        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(m_v);
        }

        // IConvertible
        public int ToInt32(IFormatProvider provider)
        {
            return m_v;
        }

        // IConvertible
        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(m_v);
        }

        // IConvertible
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(m_v);
        }

        // IConvertible
        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(m_v);
        }

        // IConvertible
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(m_v);
        }

        // IConvertible
        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(m_v);
        }

        // IConvertible
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(m_v);
        }

        // IConvertible
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException("InvalidCast from SmartBool to DateTime");
        }

        // IConvertible
        public string ToString(IFormatProvider provider)
        {
            return m_v.ToString(provider);
        }

        // IConvertible
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException("SmartBool.ToType is not implemented");
            // return Convert.DefaultToType((IConvertible)this, type, provider);
        }

    }

}
