using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSTypes;
using System.Text;

namespace UnitTests
{

    [TestClass]
    public class SmartIntUT
    {
        [TestMethod]
        public void Test_SmartInt_Parse_String()
        {
            #region General

            Assert.AreEqual(1, (int)SmartInt.Parse("1"), "Parsing \"1\"");
            Assert.AreEqual(73, (int)SmartInt.Parse("73"), "Parsing \"73\"");
            Assert.AreEqual(9462, (int)SmartInt.Parse("9462"), "Parsing \"9462\"");
            Assert.AreEqual(123456789, (int)SmartInt.Parse("123456789"), "Parsing \"123456789\"");

            Assert.AreEqual(-1, (int)SmartInt.Parse("-1"), "Parsing \"-1\"");
            Assert.AreEqual(-73, (int)SmartInt.Parse("-73"), "Parsing \"-73\"");
            Assert.AreEqual(-9462, (int)SmartInt.Parse("-9462"), "Parsing \"-9462\"");
            Assert.AreEqual(-123456789, (int)SmartInt.Parse("-123456789"), "Parsing \"-123456789\"");

            #endregion

            #region Leading zeros

            // Positive Sihned Leading zeros
            Assert.AreEqual(0, (int)SmartInt.Parse("0"), "Parsing \"0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("01"), "Parsing \"01\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("001"), "Parsing \"001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("0001"), "Parsing \"0001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("00001"), "Parsing \"00001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("000001"), "Parsing \"000001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("0000001"), "Parsing \"0000001\"");

            Assert.AreEqual(123, (int)SmartInt.Parse("0123"), "Parsing \"0123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("00123"), "Parsing \"00123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("000123"), "Parsing \"000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("0000123"), "Parsing \"0000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("00000123"), "Parsing \"00000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("000000123"), "Parsing \"000000123\"");

            // Negative Leading zeros
            Assert.AreEqual(0, (int)SmartInt.Parse("-0"), "Parsing \"-0\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-01"), "Parsing \"-01\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-001"), "Parsing \"-001\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-0001"), "Parsing \"-0001\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-00001"), "Parsing \"-00001\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-000001"), "Parsing \"-000001\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-0000001"), "Parsing \"-0000001\"");

            Assert.AreEqual(-123, (int)SmartInt.Parse("-0123"), "Parsing \"-0123\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-00123"), "Parsing \"-00123\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-000123"), "Parsing \"-000123\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-0000123"), "Parsing \"-0000123\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-00000123"), "Parsing \"-00000123\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-000000123"), "Parsing \"-000000123\"");

            // Positively Sihned Leading zeros
            Assert.AreEqual(0, (int)SmartInt.Parse("+0"), "Parsing \"+0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+01"), "Parsing \"+01\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+001"), "Parsing \"+001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+0001"), "Parsing \"+0001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+00001"), "Parsing \"+00001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+000001"), "Parsing \"+000001\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+0000001"), "Parsing \"+0000001\"");

            Assert.AreEqual(123, (int)SmartInt.Parse("+0123"), "Parsing \"+0123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+00123"), "Parsing \"+00123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+000123"), "Parsing \"+000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+0000123"), "Parsing \"+0000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+00000123"), "Parsing \"+00000123\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+000000123"), "Parsing \"+000000123\"");

            #endregion

            #region With Spaces

            Assert.AreEqual(0, (int)SmartInt.Parse(" 0 "), "Parsing \" 0 \"");
            Assert.AreEqual(1, (int)SmartInt.Parse(" 01 "), "Parsing \" 01 \"");
            Assert.AreEqual(123, (int)SmartInt.Parse(" 0123 "), "Parsing \" 0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse(" -0 "), "Parsing \" -0 \"");
            Assert.AreEqual(-1, (int)SmartInt.Parse(" -01 "), "Parsing \" -01 \"");
            Assert.AreEqual(-123, (int)SmartInt.Parse(" -0123 "), "Parsing \" -0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse(" +0 "), "Parsing \" +0 \"");
            Assert.AreEqual(1, (int)SmartInt.Parse(" +01 "), "Parsing \" +01 \"");
            Assert.AreEqual(123, (int)SmartInt.Parse(" +0123 "), "Parsing \" +0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   0     "), "Parsing \"   0     \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("   01    "), "Parsing \"   01    \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("   0123  "), "Parsing \"   0123  \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   -0     "), "Parsing \"   -0     \"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("   -01    "), "Parsing \"   -01    \"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("   -0123  "), "Parsing \"   -0123  \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   +0     "), "Parsing \"   +0     \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("   +01    "), "Parsing \"   +01    \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("   +0123  "), "Parsing \"   +0123  \"");

            // Leading Spaces
            Assert.AreEqual(0, (int)SmartInt.Parse(" 0"), "Parsing \" 0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse(" 01"), "Parsing \" 01\"");
            Assert.AreEqual(123, (int)SmartInt.Parse(" 0123"), "Parsing \" 0123\"");

            Assert.AreEqual(0, (int)SmartInt.Parse(" -0"), "Parsing \" -0\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse(" -01"), "Parsing \" -01\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse(" -0123"), "Parsing \" -0123\"");

            Assert.AreEqual(0, (int)SmartInt.Parse(" +0"), "Parsing \" +0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse(" +01"), "Parsing \" +01\"");
            Assert.AreEqual(123, (int)SmartInt.Parse(" +0123"), "Parsing \" +0123\"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   0"), "Parsing \"   0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("   01"), "Parsing \"   01\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("   0123"), "Parsing \"   0123\"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   -0"), "Parsing \"   -0\"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("   -01"), "Parsing \"   -01\"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("   -0123"), "Parsing \"   -0123\"");

            Assert.AreEqual(0, (int)SmartInt.Parse("   +0"), "Parsing \"   +0\"");
            Assert.AreEqual(1, (int)SmartInt.Parse("   +01"), "Parsing \"   +01\"");
            Assert.AreEqual(123, (int)SmartInt.Parse("   +0123"), "Parsing \"   +0123\"");

            // Finaling Spaces
            Assert.AreEqual(0, (int)SmartInt.Parse("0 "), "Parsing \"0 \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("01 "), "Parsing \"01 \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("0123 "), "Parsing \"0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("-0 "), "Parsing \"-0 \"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-01 "), "Parsing \"-01 \"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-0123 "), "Parsing \"-0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("+0 "), "Parsing \"+0 \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+01 "), "Parsing \"+01 \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+0123 "), "Parsing \"+0123 \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("0     "), "Parsing \"0     \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("01    "), "Parsing \"01    \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("0123  "), "Parsing \"0123  \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("-0     "), "Parsing \"-0     \"");
            Assert.AreEqual(-1, (int)SmartInt.Parse("-01    "), "Parsing \"-01    \"");
            Assert.AreEqual(-123, (int)SmartInt.Parse("-0123  "), "Parsing \"-0123  \"");

            Assert.AreEqual(0, (int)SmartInt.Parse("+0     "), "Parsing \"+0     \"");
            Assert.AreEqual(1, (int)SmartInt.Parse("+01    "), "Parsing \"+01    \"");
            Assert.AreEqual(123, (int)SmartInt.Parse("+0123  "), "Parsing \"+0123  \"");

            #endregion

            #region Values that shall be parsed to SmartDouble.BadValue without throwing

            Assert.AreEqual(true, SmartInt.Parse("").isBad(), "Parsing \"\"");
            Assert.AreEqual(true, SmartInt.Parse(" ").isBad(), "Parsing \" \"");
            Assert.AreEqual(true, SmartInt.Parse("           ").isBad(), "Parsing \"           \"");
            Assert.AreEqual(true, SmartInt.Parse("           -").isBad(), "Parsing \"           -\"");
            Assert.AreEqual(true, SmartInt.Parse("           +").isBad(), "Parsing \"           +\"");
            Assert.AreEqual(true, SmartInt.Parse("-           ").isBad(), "Parsing \"-           \"");
            Assert.AreEqual(true, SmartInt.Parse("-           ").isBad(), "Parsing \"+           \"");
            Assert.AreEqual(true, SmartInt.Parse("      -     ").isBad(), "Parsing \"      -     \"");
            Assert.AreEqual(true, SmartInt.Parse("      +     ").isBad(), "Parsing \"      +     \"");
            Assert.AreEqual(true, SmartInt.Parse("-").isBad(), "Parsing \"-\"");
            Assert.AreEqual(true, SmartInt.Parse("+").isBad(), "Parsing \"+\"");
            Assert.AreEqual(true, SmartInt.Parse(null).isBad(), "Parsing null");
            Assert.AreEqual(true, SmartInt.Parse("abrakadabra").isBad(), "Parsing \"abrakadabra\"");

            Assert.AreEqual(true, SmartInt.Parse("1.0").isBad(), "Parsing \"1.0\"");
            Assert.AreEqual(true, SmartInt.Parse("1 m.").isBad(), "Parsing \"1 m.\"");
            Assert.AreEqual(true, SmartInt.Parse("x1").isBad(), "Parsing \"x1\"");

            #endregion

            #region Extremal values that shall be parsed to SmartDouble.BadValue without throwing

            // 8 bills
            Assert.AreEqual(true, SmartInt.Parse("8123123123").isBad(), "Parsing \"8123123123\"");

            // Digits
            {
                int strlen = 16 * 1024;
                StringBuilder sb = new StringBuilder(strlen);

                for (int i = 0; i < strlen; i++)
                    sb.Append((i % 10).ToString());

                Assert.AreEqual(true, SmartInt.Parse(sb.ToString()).isBad(), "Parsing \"Extremal, Digits\"");

                sb = null;
                GC.Collect();
            }

            // Letters
            {
                int strlen = 16 * 1024;
                StringBuilder sb = new StringBuilder(strlen);

                for (int i = 0; i < strlen; i++)
                    sb.Append("A" + (i % 10));

                Assert.AreEqual(true, SmartInt.Parse(sb.ToString()).isBad(), "Parsing \"Extremal, Letters\"");

                sb = null;
                GC.Collect();
            }

            #endregion
        }

        [TestMethod]
        public void Test_SmartInt_ToString()
        {
            Assert.AreEqual("0", (new SmartInt(0)).ToString(), "Parsing \"0\"");
            Assert.AreEqual("1", (new SmartInt(1)).ToString(), "Parsing \"1\"");
            Assert.AreEqual("123", (new SmartInt(123)).ToString(), "Parsing \"123\"");
            Assert.AreEqual("123456789", (new SmartInt(123456789)).ToString(), "Parsing \"123456789\"");

            Assert.AreEqual("0", (new SmartInt(-0)).ToString(), "Parsing \"-0\"");
            Assert.AreEqual("-1", (new SmartInt(-1)).ToString(), "Parsing \"-1\"");
            Assert.AreEqual("-123", (new SmartInt(-123)).ToString(), "Parsing \"-123\"");
            Assert.AreEqual("-123456789", (new SmartInt(-123456789)).ToString(), "Parsing \"-123456789\"");
        }
    }

}
