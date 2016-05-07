using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace SSTypes.Tests
{
    [TestClass]
    public class SmartIntTests
    {
        [TestMethod]
        [Description("SmartInt.Parse")]
        public void SmartInt_Parse_String_Test()
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

            string null_str = null;
            Assert.AreEqual(true, SmartInt.Parse(null_str).isBad(), "Parsing null");
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
            }

            // Letters
            {
                int strlen = 16 * 1024;
                StringBuilder sb = new StringBuilder(strlen);

                for (int i = 0; i < strlen; i++)
                    sb.Append("A" + (i % 10));

                Assert.AreEqual(true, SmartInt.Parse(sb.ToString()).isBad(), "Parsing \"Extremal, Letters\"");
            }

            #endregion
        }

        [TestMethod]
        [Description("SmartInt.ToString")]
        public void SmartInt_ToString_Test()
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

        [TestMethod]
        [Description("Based on comparing in cycle of int and SmartInt.Parse(int.ToString())")]
        public void SmartInt_Parse_BruteForce_Test()
        {
            int test_count = 10000000;
            Random rnd = new Random();

            for (int i = 0; i < test_count; i++)
            {
                int v = rnd.Next();

                string s = v.ToString();
                string sp = "+" + s;
                string sn = "-" + s;

                SmartInt siv = SmartInt.Parse(s);
                SmartInt sipv = SmartInt.Parse(sp);
                SmartInt sinv = SmartInt.Parse(sn);

                Assert.IsTrue((siv == v) && (sipv == v) && (sinv == -v), "Parsing " + v.ToString());
            }
        }

        [TestMethod]
        [Description("Based on comparing in cycle of int.ToString() and SmartInt.ToString()")]
        public void SmartInt_ToString_BruteForce_Test()
        {
            int test_count = 10000000;
            Random rnd = new Random();

            for (int i = 0; i < test_count; i++)
            {
                int v = rnd.Next();
                int vn = -v;

                string s = v.ToString();
                string sn = vn.ToString();

                SmartInt siv = v;
                SmartInt sivn = vn;

                string sis = siv.ToString();
                string sisn = sivn.ToString();

                Assert.IsTrue((sis == s) && (sisn == sn), "ToString " + v.ToString());
            }
        }

    }

}
