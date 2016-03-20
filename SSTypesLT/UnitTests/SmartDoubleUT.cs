using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSTypes;
using System.Text;

namespace UnitTests
{

    [TestClass]
    public class SmartDoubleUT
    {
        [TestMethod]
        public void Test_SmartDouble_Parse_String()
        {
            #region Similar to SmartInt

            // Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("0"), 0, "Parsing \"0\"");
            Assert.AreEqual((double)SmartDouble.Parse("01"), 1, "Parsing \"01\"");
            Assert.AreEqual((double)SmartDouble.Parse("001"), 1, "Parsing \"001\"");
            Assert.AreEqual((double)SmartDouble.Parse("0001"), 1, "Parsing \"0001\"");
            Assert.AreEqual((double)SmartDouble.Parse("00001"), 1, "Parsing \"00001\"");
            Assert.AreEqual((double)SmartDouble.Parse("000001"), 1, "Parsing \"000001\"");
            Assert.AreEqual((double)SmartDouble.Parse("0000001"), 1, "Parsing \"0000001\"");

            Assert.AreEqual((double)SmartDouble.Parse("0123"), 123, "Parsing \"0123\"");
            Assert.AreEqual((double)SmartDouble.Parse("00123"), 123, "Parsing \"00123\"");
            Assert.AreEqual((double)SmartDouble.Parse("000123"), 123, "Parsing \"000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("0000123"), 123, "Parsing \"0000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("00000123"), 123, "Parsing \"00000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("000000123"), 123, "Parsing \"000000123\"");

            // Negative Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("-0"), -0, "Parsing \"-0\""); // double32.Parse("-0") throws here
            Assert.AreEqual((double)SmartDouble.Parse("-01"), -1, "Parsing \"-01\"");
            Assert.AreEqual((double)SmartDouble.Parse("-001"), -1, "Parsing \"-001\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0001"), -1, "Parsing \"-0001\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00001"), -1, "Parsing \"-00001\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000001"), -1, "Parsing \"-000001\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0000001"), -1, "Parsing \"-0000001\"");

            Assert.AreEqual((double)SmartDouble.Parse("-0123"), -123, "Parsing \"-0123\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00123"), -123, "Parsing \"-00123\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000123"), -123, "Parsing \"-000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0000123"), -123, "Parsing \"-0000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00000123"), -123, "Parsing \"-00000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000000123"), -123, "Parsing \"-000000123\"");

            // Positively Sihned Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("+0"), 0, "Parsing \"+0\"");
            Assert.AreEqual((double)SmartDouble.Parse("+01"), 1, "Parsing \"+01\"");
            Assert.AreEqual((double)SmartDouble.Parse("+001"), 1, "Parsing \"+001\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0001"), 1, "Parsing \"+0001\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00001"), 1, "Parsing \"+00001\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000001"), 1, "Parsing \"+000001\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0000001"), 1, "Parsing \"+0000001\"");

            Assert.AreEqual((double)SmartDouble.Parse("+0123"), 123, "Parsing \"+0123\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00123"), 123, "Parsing \"+00123\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000123"), 123, "Parsing \"+000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0000123"), 123, "Parsing \"+0000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00000123"), 123, "Parsing \"+00000123\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000000123"), 123, "Parsing \"+000000123\"");

            // Leading & Finaling Spaces

            Assert.AreEqual((double)SmartDouble.Parse(" 0 "), 0, "Parsing \" 0 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" 01 "), 1, "Parsing \" 01 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" 0123 "), 123, "Parsing \" 0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse(" -0 "), 0, "Parsing \" -0 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" -01 "), -1, "Parsing \" -01 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" -0123 "), -123, "Parsing \" -0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse(" +0 "), 0, "Parsing \" +0 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" +01 "), 1, "Parsing \" +01 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" +0123 "), 123, "Parsing \" +0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse("   0     "), 0, "Parsing \"   0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   01    "), 1, "Parsing \"   01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   0123  "), 123, "Parsing \"   0123  \"");

            Assert.AreEqual((double)SmartDouble.Parse("   -0     "), -0, "Parsing \"   -0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -01    "), -1, "Parsing \"   -01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0123  "), -123, "Parsing \"   -0123  \"");

            Assert.AreEqual((double)SmartDouble.Parse("   +0     "), 0, "Parsing \"   +0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +01    "), 1, "Parsing \"   +01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0123  "), 123, "Parsing \"   +0123  \"");

            // Leading Spaces

            Assert.AreEqual((double)SmartDouble.Parse(" 0"), 0, "Parsing \" 0\"");
            Assert.AreEqual((double)SmartDouble.Parse(" 01"), 1, "Parsing \" 01\"");
            Assert.AreEqual((double)SmartDouble.Parse(" 0123"), 123, "Parsing \" 0123\"");

            Assert.AreEqual((double)SmartDouble.Parse(" -0"), 0, "Parsing \" -0\"");
            Assert.AreEqual((double)SmartDouble.Parse(" -01"), -1, "Parsing \" -01\"");
            Assert.AreEqual((double)SmartDouble.Parse(" -0123"), -123, "Parsing \" -0123\"");

            Assert.AreEqual((double)SmartDouble.Parse(" +0"), 0, "Parsing \" +0\"");
            Assert.AreEqual((double)SmartDouble.Parse(" +01"), 1, "Parsing \" +01\"");
            Assert.AreEqual((double)SmartDouble.Parse(" +0123"), 123, "Parsing \" +0123\"");

            Assert.AreEqual((double)SmartDouble.Parse("   0"), 0, "Parsing \"   0\"");
            Assert.AreEqual((double)SmartDouble.Parse("   01"), 1, "Parsing \"   01\"");
            Assert.AreEqual((double)SmartDouble.Parse("   0123"), 123, "Parsing \"   0123\"");

            Assert.AreEqual((double)SmartDouble.Parse("   -0"), -0, "Parsing \"   -0\"");
            Assert.AreEqual((double)SmartDouble.Parse("   -01"), -1, "Parsing \"   -01\"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0123"), -123, "Parsing \"   -0123\"");

            Assert.AreEqual((double)SmartDouble.Parse("   +0"), 0, "Parsing \"   +0\"");
            Assert.AreEqual((double)SmartDouble.Parse("   +01"), 1, "Parsing \"   +01\"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0123"), 123, "Parsing \"   +0123\"");

            // Finaling Spaces

            Assert.AreEqual((double)SmartDouble.Parse("0 "), 0, "Parsing \"0 \"");
            Assert.AreEqual((double)SmartDouble.Parse("01 "), 1, "Parsing \"01 \"");
            Assert.AreEqual((double)SmartDouble.Parse("0123 "), 123, "Parsing \"0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse("-0 "), 0, "Parsing \"-0 \"");
            Assert.AreEqual((double)SmartDouble.Parse("-01 "), -1, "Parsing \"-01 \"");
            Assert.AreEqual((double)SmartDouble.Parse("-0123 "), -123, "Parsing \"-0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse("+0 "), 0, "Parsing \"+0 \"");
            Assert.AreEqual((double)SmartDouble.Parse("+01 "), 1, "Parsing \"+01 \"");
            Assert.AreEqual((double)SmartDouble.Parse("+0123 "), 123, "Parsing \"+0123 \"");

            Assert.AreEqual((double)SmartDouble.Parse("0     "), 0, "Parsing \"0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("01    "), 1, "Parsing \"01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("0123  "), 123, "Parsing \"0123  \"");

            Assert.AreEqual((double)SmartDouble.Parse("-0     "), -0, "Parsing \"-0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("-01    "), -1, "Parsing \"-01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("-0123  "), -123, "Parsing \"-0123  \"");

            Assert.AreEqual((double)SmartDouble.Parse("+0     "), 0, "Parsing \"+0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("+01    "), 1, "Parsing \"+01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("+0123  "), 123, "Parsing \"+0123  \"");

            // Values that shall be parsed to SmartDouble.BadValue without throwing

            Assert.AreEqual(SmartDouble.Parse("").isBad(), true, "Parsing \"\"");
            Assert.AreEqual(SmartDouble.Parse(" ").isBad(), true, "Parsing \" \"");
            Assert.AreEqual(SmartDouble.Parse("           ").isBad(), true, "Parsing \"           \"");
            Assert.AreEqual(SmartDouble.Parse("           -").isBad(), true, "Parsing \"           -\"");
            Assert.AreEqual(SmartDouble.Parse("           +").isBad(), true, "Parsing \"           +\"");
            Assert.AreEqual(SmartDouble.Parse("-           ").isBad(), true, "Parsing \"-           \"");
            Assert.AreEqual(SmartDouble.Parse("-           ").isBad(), true, "Parsing \"+           \"");
            Assert.AreEqual(SmartDouble.Parse("      -     ").isBad(), true, "Parsing \"      -     \"");
            Assert.AreEqual(SmartDouble.Parse("      +     ").isBad(), true, "Parsing \"      +     \"");
            Assert.AreEqual(SmartDouble.Parse("-").isBad(), true, "Parsing \"-\"");
            Assert.AreEqual(SmartDouble.Parse("+").isBad(), true, "Parsing \"+\"");
            Assert.AreEqual(SmartDouble.Parse(null).isBad(), true, "Parsing null");
            Assert.AreEqual(SmartDouble.Parse("abrakadabra").isBad(), true, "Parsing \"abrakadabra\"");

 //           Assert.AreEqual(SmartDouble.Parse("1.0").isBad(), true, "Parsing \"1.0\"");
            Assert.AreEqual(SmartDouble.Parse("1 m.").isBad(), true, "Parsing \"1 m.\"");
            Assert.AreEqual(SmartDouble.Parse("x1").isBad(), true, "Parsing \"x1\"");

            // Extremal values that shall be parsed to SmartDouble.BadValue without throwing

            // Digits
            {
                int strlen = 16 * 1024;
                StringBuilder sb = new StringBuilder(strlen);

                for (int i = 0; i < strlen; i++)
                    sb.Append((i % 10).ToString());

                Assert.AreEqual(SmartDouble.Parse(sb.ToString()).isBad(), true, "Parsing \"Extremal, Digits\"");
            }

            // Letters
            {
                int strlen = 16 * 1024;
                StringBuilder sb = new StringBuilder(strlen);

                for (int i = 0; i < strlen; i++)
                    sb.Append("A" + (i % 10));

                Assert.AreEqual(SmartDouble.Parse(sb.ToString()).isBad(), true, "Parsing \"Extremal, Letters\"");
            }

            #endregion

            #region Doubles

            Assert.AreEqual((double)SmartDouble.Parse(".34"), 0.34, "Parsing \".34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-.34"), -0.34, "Parsing \"-.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+.34"), 0.34, "Parsing \"+.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("     .34     "), 0.34, "Parsing \"     .34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("     -.34     "), -0.34, "Parsing \"     -.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("     +.34     "), 0.34, "Parsing \"     +.34     \"");

            Assert.AreEqual((double)SmartDouble.Parse("     .34"), 0.34, "Parsing \"     .34\"");
            Assert.AreEqual((double)SmartDouble.Parse("     -.34"), -0.34, "Parsing \"     -.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("     +.34"), 0.34, "Parsing \"     +.34\"");

            Assert.AreEqual((double)SmartDouble.Parse(".34     "), 0.34, "Parsing \".34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("-.34     "), -0.34, "Parsing \"-.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("+.34     "), 0.34, "Parsing \"+.34     \"");

            // Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("0.34"), 0.34, "Parsing \"0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("01.34"), 1.34, "Parsing \"01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("001.34"), 1.34, "Parsing \"001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("0001.34"), 1.34, "Parsing \"0001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("00001.34"), 1.34, "Parsing \"00001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("000001.34"), 1.34, "Parsing \"000001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("0000001.34"), 1.34, "Parsing \"0000001.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("0123.34"), 123.34, "Parsing \"0123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("00123.34"), 123.34, "Parsing \"00123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("000123.34"), 123.34, "Parsing \"000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("0000123.34"), 123.34, "Parsing \"0000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("00000123.34"), 123.34, "Parsing \"00000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("000000123.34"), 123.34, "Parsing \"000000123.34\"");

            // Negative Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("-0.34"), -0.34, "Parsing \"-0.34\""); // double32.Parse("-0") throws here
            Assert.AreEqual((double)SmartDouble.Parse("-01.34"), -1.34, "Parsing \"-01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-001.34"), -1.34, "Parsing \"-001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0001.34"), -1.34, "Parsing \"-0001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00001.34"), -1.34, "Parsing \"-00001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000001.34"), -1.34, "Parsing \"-000001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0000001.34"), -1.34, "Parsing \"-0000001.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("-0123.34"), -123.34, "Parsing \"-0123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00123.34"), -123.34, "Parsing \"-00123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000123.34"), -123.34, "Parsing \"-000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0000123.34"), -123.34, "Parsing \"-0000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-00000123.34"), -123.34, "Parsing \"-00000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("-000000123.34"), -123.34, "Parsing \"-000000123.34\"");

            // Positively Sihned Leading zeros
            Assert.AreEqual((double)SmartDouble.Parse("+0.34"), 0.34, "Parsing \"+0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+01.34"), 1.34, "Parsing \"+01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+001.34"), 1.34, "Parsing \"+001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0001.34"), 1.34, "Parsing \"+0001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00001.34"), 1.34, "Parsing \"+00001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000001.34"), 1.34, "Parsing \"+000001.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0000001.34"), 1.34, "Parsing \"+0000001.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("+0123.34"), 123.34, "Parsing \"+0123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00123.34"), 123.34, "Parsing \"+00123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000123.34"), 123.34, "Parsing \"+000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0000123.34"), 123.34, "Parsing \"+0000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+00000123.34"), 123.34, "Parsing \"+00000123.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("+000000123.34"), 123.34, "Parsing \"+000000123.34\"");

            // Leading & Finaling Spaces

            Assert.AreEqual((double)SmartDouble.Parse(" 0.34 "), 0.34, "Parsing \" 0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" 01.34 "), 1.34, "Parsing \" 01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" 0123.34 "), 123.34, "Parsing \" 0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse(" -0.34 "), -0.34, "Parsing \" -0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" -01.34 "), -1.34, "Parsing \" -01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" -0123.34 "), -123.34, "Parsing \" -0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse(" +0.34 "), 0.34, "Parsing \" +0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" +01.34 "), 1.34, "Parsing \" +01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse(" +0123.34 "), 123.34, "Parsing \" +0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse("   0.34     "), 0.34, "Parsing \"   0     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   01.34    "), 1.34, "Parsing \"   01    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   0123.34  "), 123.34, "Parsing \"   0123  \"");

            Assert.AreEqual((double)SmartDouble.Parse("   -0.34     "), -0.34, "Parsing \"   -0.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -01.34    "), -1.34, "Parsing \"   -01.34    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0123.34  "), -123.34, "Parsing \"   -0123.34  \"");

            Assert.AreEqual((double)SmartDouble.Parse("   +0.34     "), 0.34, "Parsing \"   +0.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +01.34    "), 1.34, "Parsing \"   +01.34    \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0123.34  "), 123.34, "Parsing \"   +0123.34  \"");

            // Leading Spaces

            Assert.AreEqual((double)SmartDouble.Parse(" 0.34"), 0.34, "Parsing \" 0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" 01.34"), 1.34, "Parsing \" 01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" 0123.34"), 123.34, "Parsing \" 0123.34\"");

            Assert.AreEqual((double)SmartDouble.Parse(" -0.34"), -0.34, "Parsing \" -0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" -01.34"), -1.34, "Parsing \" -01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" -0123.34"), -123.34, "Parsing \" -0123.34\"");

            Assert.AreEqual((double)SmartDouble.Parse(" +0.34"), 0.34, "Parsing \" +0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" +01.34"), 1.34, "Parsing \" +01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse(" +0123.34"), 123.34, "Parsing \" +0123.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("   0.34"), 0.34, "Parsing \"   0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   01.34"), 1.34, "Parsing \"   01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   0123.34"), 123.34, "Parsing \"   0123.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("   -0.34"), -0.34, "Parsing \"   -0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   -01.34"), -1.34, "Parsing \"   -01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0123.34"), -123.34, "Parsing \"   -0123.34\"");

            Assert.AreEqual((double)SmartDouble.Parse("   +0.34"), 0.34, "Parsing \"   +0.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   +01.34"), 1.34, "Parsing \"   +01.34\"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0123.34"), 123.34, "Parsing \"   +0123.34\"");

            // Finaling Spaces

            Assert.AreEqual((double)SmartDouble.Parse("0.34 "), 0.34, "Parsing \"0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("01.34 "), 1.34, "Parsing \"01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("0123.34 "), 123.34, "Parsing \"0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse("-0.34 "), -0.34, "Parsing \"-0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("-01.34 "), -1.34, "Parsing \"-01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("-0123.34 "), -123.34, "Parsing \"-0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse("+0.34 "), 0.34, "Parsing \"+0.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("+01.34 "), 1.34, "Parsing \"+01.34 \"");
            Assert.AreEqual((double)SmartDouble.Parse("+0123.34 "), 123.34, "Parsing \"+0123.34 \"");

            Assert.AreEqual((double)SmartDouble.Parse("0.34     "), 0.34, "Parsing \"0.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("01.34    "), 1.34, "Parsing \"01.34    \"");
            Assert.AreEqual((double)SmartDouble.Parse("0123.34  "), 123.34, "Parsing \"0123.34  \"");

            Assert.AreEqual((double)SmartDouble.Parse("-0.34     "), -0.34, "Parsing \"-0.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("-01.34    "), -1.34, "Parsing \"-01.34    \"");
            Assert.AreEqual((double)SmartDouble.Parse("-0123.34  "), -123.34, "Parsing \"-0123.34  \"");

            Assert.AreEqual((double)SmartDouble.Parse("+0.34     "), 0.34, "Parsing \"+0.34     \"");
            Assert.AreEqual((double)SmartDouble.Parse("+01.34    "), 1.34, "Parsing \"+01.34    \"");
            Assert.AreEqual((double)SmartDouble.Parse("+0123.34  "), 123.34, "Parsing \"+0123.34  \"");

            Assert.AreEqual((double)SmartDouble.Parse("0."), 0, "Parsing \"0.\"");
            Assert.AreEqual((double)SmartDouble.Parse("0.   "), 0, "Parsing \"0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   0.   "), 0, "Parsing \"   0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   0."), 0, "Parsing \"   0.\"");

            Assert.AreEqual((double)SmartDouble.Parse("-0."), 0, "Parsing \"-0.\"");
            Assert.AreEqual((double)SmartDouble.Parse("-0.   "), 0, "Parsing \"-0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0.   "), 0, "Parsing \"   -0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   -0.   "), 0, "Parsing \"   -0.   \"");

            Assert.AreEqual((double)SmartDouble.Parse("+0."), 0, "Parsing \"+0.\"");
            Assert.AreEqual((double)SmartDouble.Parse("+0.   "), 0, "Parsing \"+0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0.   "), 0, "Parsing \"   +0.   \"");
            Assert.AreEqual((double)SmartDouble.Parse("   +0."), 0, "Parsing \"   +0.\"");

            #endregion
        }

        [TestMethod]
        public void Test_SmartDouble_ToString()
        {
            #region Similar to SmartInt

            Assert.AreEqual("1", (new SmartDouble(1)).ToString(), "ToString \"1\"");
            Assert.AreEqual("123", (new SmartDouble(123)).ToString(), "ToString \"123\"");
            Assert.AreEqual("123456789", (new SmartDouble(123456789)).ToString(), "ToString \"123456789\"");

            Assert.AreEqual("-1", (new SmartDouble(-1)).ToString(), "ToString \"-1\"");
            Assert.AreEqual("-123", (new SmartDouble(-123)).ToString(), "ToString \"-123\"");
            Assert.AreEqual("-123456789", (new SmartDouble(-123456789)).ToString(), "ToString \"-123456789\"");

            #endregion

            #region -1 .. 1

            // -0.x

            Assert.AreEqual("-0.111111111111", (new SmartDouble(-0.111111111111)).ToString(), "ToString \"-0.111111111111\"");
            Assert.AreEqual("-0.99", (new SmartDouble(-0.99)).ToString(), "ToString \"-0.99\"");
            Assert.AreEqual("-0.11", (new SmartDouble(-0.11)).ToString(), "ToString \"-0.11\"");
            Assert.AreEqual("-0.9", (new SmartDouble(-0.9)).ToString(), "ToString \"-0.9\"");

            Assert.AreEqual("-0.123456789123", (new SmartDouble(-0.123456789123)).ToString(), "ToString \"-0.123456789123\"");
            Assert.AreEqual("-0.12345678912", (new SmartDouble(-0.12345678912)).ToString(), "ToString \"-0.12345678912\"");
            Assert.AreEqual("-0.1234567891", (new SmartDouble(-0.1234567891)).ToString(), "ToString \"-0.1234567891\"");
            Assert.AreEqual("-0.123456789", (new SmartDouble(-0.123456789)).ToString(), "ToString \"-0.123456789\"");
            Assert.AreEqual("-0.12345678", (new SmartDouble(-0.12345678)).ToString(), "ToString \"-0.12345678\"");
            Assert.AreEqual("-0.1234567", (new SmartDouble(-0.1234567)).ToString(), "ToString \"-0.1234567\"");
            Assert.AreEqual("-0.123456", (new SmartDouble(-0.123456)).ToString(), "ToString \"-0.123456\"");
            Assert.AreEqual("-0.12345", (new SmartDouble(-0.12345)).ToString(), "ToString \"-0.12345\"");
            Assert.AreEqual("-0.1234", (new SmartDouble(-0.1234)).ToString(), "ToString \"-0.1234\"");
            Assert.AreEqual("-0.123", (new SmartDouble(-0.123)).ToString(), "ToString \"-0.123\"");
            Assert.AreEqual("-0.12", (new SmartDouble(-0.12)).ToString(), "ToString \"-0.12\"");
            Assert.AreEqual("-0.1", (new SmartDouble(-0.1)).ToString(), "ToString \"-0.1\"");

            Assert.AreEqual("0", (new SmartDouble(-0.0)).ToString(), "ToString \"-0.0\"");

            Assert.AreEqual("-0.1", (new SmartDouble(-0.1)).ToString(), "ToString \"-0.1\"");
            Assert.AreEqual("-0.01", (new SmartDouble(-0.01)).ToString(), "ToString \"-0.01\"");
            Assert.AreEqual("-0.001", (new SmartDouble(-0.001)).ToString(), "ToString \"-0.001\"");
            Assert.AreEqual("-0.0001", (new SmartDouble(-0.0001)).ToString(), "ToString \"-0.0001\"");
            Assert.AreEqual("-0.00001", (new SmartDouble(-0.00001)).ToString(), "ToString \"-0.00001\"");
            Assert.AreEqual("-0.000001", (new SmartDouble(-0.000001)).ToString(), "ToString \"-0.000001\"");
            Assert.AreEqual("-0.0000001", (new SmartDouble(-0.0000001)).ToString(), "ToString \"-0.0000001\"");
            Assert.AreEqual("-0.00000001", (new SmartDouble(-0.00000001)).ToString(), "ToString \"-0.00000001\"");
            Assert.AreEqual("-0.000000001", (new SmartDouble(-0.000000001)).ToString(), "ToString \"-0.000000001\"");
            Assert.AreEqual("-0.0000000001", (new SmartDouble(-0.0000000001)).ToString(), "ToString \"-0.0000000001\"");
            Assert.AreEqual("-0.00000000001", (new SmartDouble(-0.00000000001)).ToString(), "ToString \"-0.00000000001\"");
            Assert.AreEqual("-0.000000000001", (new SmartDouble(-0.000000000001)).ToString(), "ToString \"-0.000000000001\"");

            // 0.x
            Assert.AreEqual("0.111111111111", (new SmartDouble(0.111111111111)).ToString(), "ToString \"0.111111111111\"");
            Assert.AreEqual("0.99", (new SmartDouble(0.99)).ToString(), "ToString \"0.99\"");
            Assert.AreEqual("0.11", (new SmartDouble(0.11)).ToString(), "ToString \"0.11\"");
            Assert.AreEqual("0.9", (new SmartDouble(0.9)).ToString(), "ToString \"0.9\"");
            Assert.AreEqual("0.1", (new SmartDouble(0.1)).ToString(), "ToString \"0.1\"");

            Assert.AreEqual("0.123456789123", (new SmartDouble(0.123456789123)).ToString(), "ToString \"0.123456789123\"");
            Assert.AreEqual("0.12345678912", (new SmartDouble(0.12345678912)).ToString(), "ToString \"0.12345678912\"");
            Assert.AreEqual("0.1234567891", (new SmartDouble(0.1234567891)).ToString(), "ToString \"0.1234567891\"");
            Assert.AreEqual("0.123456789", (new SmartDouble(0.123456789)).ToString(), "ToString \"0.123456789\"");
            Assert.AreEqual("0.12345678", (new SmartDouble(0.12345678)).ToString(), "ToString \"0.12345678\"");
            Assert.AreEqual("0.1234567", (new SmartDouble(0.1234567)).ToString(), "ToString \"0.1234567\"");
            Assert.AreEqual("0.123456", (new SmartDouble(0.123456)).ToString(), "ToString \"0.123456\"");
            Assert.AreEqual("0.12345", (new SmartDouble(0.12345)).ToString(), "ToString \"0.12345\"");
            Assert.AreEqual("0.1234", (new SmartDouble(0.1234)).ToString(), "ToString \"0.1234\"");
            Assert.AreEqual("0.123", (new SmartDouble(0.123)).ToString(), "ToString \"0.123\"");
            Assert.AreEqual("0.12", (new SmartDouble(0.12)).ToString(), "ToString \"0.12\"");
            Assert.AreEqual("0.1", (new SmartDouble(0.1)).ToString(), "ToString \"0.1\"");

            Assert.AreEqual("0", (new SmartDouble(0.0)).ToString(), "ToString \"0.0\"");

            Assert.AreEqual("0.1", (new SmartDouble(0.1)).ToString(), "ToString \"0.1\"");
            Assert.AreEqual("0.01", (new SmartDouble(0.01)).ToString(), "ToString \"0.01\"");
            Assert.AreEqual("0.001", (new SmartDouble(0.001)).ToString(), "ToString \"0.001\"");
            Assert.AreEqual("0.0001", (new SmartDouble(0.0001)).ToString(), "ToString \"0.0001\"");
            Assert.AreEqual("0.00001", (new SmartDouble(0.00001)).ToString(), "ToString \"0.00001\"");
            Assert.AreEqual("0.000001", (new SmartDouble(0.000001)).ToString(), "ToString \"0.000001\"");
            Assert.AreEqual("0.0000001", (new SmartDouble(0.0000001)).ToString(), "ToString \"0.0000001\"");
            Assert.AreEqual("0.00000001", (new SmartDouble(0.00000001)).ToString(), "ToString \"0.00000001\"");
            Assert.AreEqual("0.000000001", (new SmartDouble(0.000000001)).ToString(), "ToString \"0.000000001\"");
            Assert.AreEqual("0.0000000001", (new SmartDouble(0.0000000001)).ToString(), "ToString \"0.0000000001\"");
            Assert.AreEqual("0.00000000001", (new SmartDouble(0.00000000001)).ToString(), "ToString \"0.00000000001\"");
            Assert.AreEqual("0.000000000001", (new SmartDouble(0.000000000001)).ToString(), "ToString \"0.000000000001\"");

            // -.x
            Assert.AreEqual("-0.111111111111", (new SmartDouble(-.111111111111)).ToString(), "ToString \"-.111111111111\"");
            Assert.AreEqual("-0.99", (new SmartDouble(-.99)).ToString(), "ToString \"-.99\"");
            Assert.AreEqual("-0.11", (new SmartDouble(-.11)).ToString(), "ToString \"-.11\"");
            Assert.AreEqual("-0.9", (new SmartDouble(-.9)).ToString(), "ToString \"-.9\"");
            Assert.AreEqual("-0.1", (new SmartDouble(-.1)).ToString(), "ToString \"-.1\"");

            Assert.AreEqual("-0.123456789123", (new SmartDouble(-.123456789123)).ToString(), "ToString \"-.123456789123\"");
            Assert.AreEqual("-0.12345678912", (new SmartDouble(-.12345678912)).ToString(), "ToString \"-.12345678912\"");
            Assert.AreEqual("-0.1234567891", (new SmartDouble(-.1234567891)).ToString(), "ToString \"-.1234567891\"");
            Assert.AreEqual("-0.123456789", (new SmartDouble(-.123456789)).ToString(), "ToString \"-.123456789\"");
            Assert.AreEqual("-0.12345678", (new SmartDouble(-.12345678)).ToString(), "ToString \"-.12345678\"");
            Assert.AreEqual("-0.1234567", (new SmartDouble(-.1234567)).ToString(), "ToString \"-.1234567\"");
            Assert.AreEqual("-0.123456", (new SmartDouble(-.123456)).ToString(), "ToString \"-.123456\"");
            Assert.AreEqual("-0.12345", (new SmartDouble(-.12345)).ToString(), "ToString \"-.12345\"");
            Assert.AreEqual("-0.1234", (new SmartDouble(-.1234)).ToString(), "ToString \"-.1234\"");
            Assert.AreEqual("-0.123", (new SmartDouble(-.123)).ToString(), "ToString \"-.123\"");
            Assert.AreEqual("-0.12", (new SmartDouble(-.12)).ToString(), "ToString \"-.12\"");
            Assert.AreEqual("-0.1", (new SmartDouble(-.1)).ToString(), "ToString \"-.1\"");

            Assert.AreEqual("0", (new SmartDouble(-.0)).ToString(), "ToString \"-.0\"");

            Assert.AreEqual("-0.1", (new SmartDouble(-.1)).ToString(), "ToString \"-.1\"");
            Assert.AreEqual("-0.01", (new SmartDouble(-.01)).ToString(), "ToString \"-.01\"");
            Assert.AreEqual("-0.001", (new SmartDouble(-.001)).ToString(), "ToString \"-.001\"");
            Assert.AreEqual("-0.0001", (new SmartDouble(-.0001)).ToString(), "ToString \"-.0001\"");
            Assert.AreEqual("-0.00001", (new SmartDouble(-.00001)).ToString(), "ToString \"-.00001\"");
            Assert.AreEqual("-0.000001", (new SmartDouble(-.000001)).ToString(), "ToString \"-.000001\"");
            Assert.AreEqual("-0.0000001", (new SmartDouble(-.0000001)).ToString(), "ToString \"-.0000001\"");
            Assert.AreEqual("-0.00000001", (new SmartDouble(-.00000001)).ToString(), "ToString \"-.00000001\"");
            Assert.AreEqual("-0.000000001", (new SmartDouble(-.000000001)).ToString(), "ToString \"-.000000001\"");
            Assert.AreEqual("-0.0000000001", (new SmartDouble(-.0000000001)).ToString(), "ToString \"-.0000000001\"");
            Assert.AreEqual("-0.00000000001", (new SmartDouble(-.00000000001)).ToString(), "ToString \"-.00000000001\"");
            Assert.AreEqual("-0.000000000001", (new SmartDouble(-.000000000001)).ToString(), "ToString \"-.000000000001\"");

            // .x
            Assert.AreEqual("0.111111111111", (new SmartDouble(.111111111111)).ToString(), "ToString \"-0.111111111111\"");
            Assert.AreEqual("0.99", (new SmartDouble(.99)).ToString(), "ToString \".99\"");
            Assert.AreEqual("0.11", (new SmartDouble(.11)).ToString(), "ToString \".11\"");
            Assert.AreEqual("0.9", (new SmartDouble(.9)).ToString(), "ToString \".9\"");
            Assert.AreEqual("0.1", (new SmartDouble(.1)).ToString(), "ToString \".1\"");

            Assert.AreEqual("0.123456789123", (new SmartDouble(.123456789123)).ToString(), "ToString \".123456789123\"");
            Assert.AreEqual("0.12345678912", (new SmartDouble(.12345678912)).ToString(), "ToString \".12345678912\"");
            Assert.AreEqual("0.1234567891", (new SmartDouble(.1234567891)).ToString(), "ToString \".1234567891\"");
            Assert.AreEqual("0.123456789", (new SmartDouble(.123456789)).ToString(), "ToString \".123456789\"");
            Assert.AreEqual("0.12345678", (new SmartDouble(.12345678)).ToString(), "ToString \".12345678\"");
            Assert.AreEqual("0.1234567", (new SmartDouble(.1234567)).ToString(), "ToString \".1234567\"");
            Assert.AreEqual("0.123456", (new SmartDouble(.123456)).ToString(), "ToString \".123456\"");
            Assert.AreEqual("0.12345", (new SmartDouble(.12345)).ToString(), "ToString \".12345\"");
            Assert.AreEqual("0.1234", (new SmartDouble(.1234)).ToString(), "ToString \".1234\"");
            Assert.AreEqual("0.123", (new SmartDouble(.123)).ToString(), "ToString \".123\"");
            Assert.AreEqual("0.12", (new SmartDouble(.12)).ToString(), "ToString \".12\"");
            Assert.AreEqual("0.1", (new SmartDouble(.1)).ToString(), "ToString \".1\"");

            Assert.AreEqual("0", (new SmartDouble(.0)).ToString(), "ToString \".0\"");

            Assert.AreEqual("0.1", (new SmartDouble(.1)).ToString(), "ToString \".1\"");
            Assert.AreEqual("0.01", (new SmartDouble(.01)).ToString(), "ToString \".01\"");
            Assert.AreEqual("0.001", (new SmartDouble(.001)).ToString(), "ToString \".001\"");
            Assert.AreEqual("0.0001", (new SmartDouble(.0001)).ToString(), "ToString \".0001\"");
            Assert.AreEqual("0.00001", (new SmartDouble(.00001)).ToString(), "ToString \".00001\"");
            Assert.AreEqual("0.000001", (new SmartDouble(.000001)).ToString(), "ToString \".000001\"");
            Assert.AreEqual("0.0000001", (new SmartDouble(.0000001)).ToString(), "ToString \".0000001\"");
            Assert.AreEqual("0.00000001", (new SmartDouble(.00000001)).ToString(), "ToString \".00000001\"");
            Assert.AreEqual("0.000000001", (new SmartDouble(.000000001)).ToString(), "ToString \".000000001\"");
            Assert.AreEqual("0.0000000001", (new SmartDouble(.0000000001)).ToString(), "ToString \".0000000001\"");
            Assert.AreEqual("0.00000000001", (new SmartDouble(.00000000001)).ToString(), "ToString \".00000000001\"");
            Assert.AreEqual("0.000000000001", (new SmartDouble(.000000000001)).ToString(), "ToString \".000000000001\"");

            #endregion
        }

        [TestMethod]
        public void Test_SmartDouble_ToStringN()
        {
            Assert.AreEqual("99999.98324", (new SmartDouble(99999.98324)).ToString(8), "SmartDouble.ToString(8) 99999.98324");
            Assert.AreEqual("2999.99971", (new SmartDouble(2999.99971)).ToString(8), "SmartDouble.ToString(8) 2999.99971");
        }

        [TestMethod]
        public void Test_SmartDouble_Parse_ToString_BruteForce()
        {
            int test_count = 10000000;
            int parta_max = 1000000;
            int partb_max = 1000000;

            Random R = new Random();

            for (int i = 0; i < test_count; i++)
            {
                string s_parta = R.Next(parta_max).ToString();
                string s_partb = R.Next(partb_max).ToString();

                // if (s_partb == "0")
                //    continue;

                while((s_partb.Length > 0) && (s_partb[s_partb.Length - 1] == '0'))
                    s_partb = s_partb.Substring(0, s_partb.Length - 1);

                string s_sd1 = s_parta;
                if(!string.IsNullOrEmpty(s_partb))
                    s_sd1 += ("." + s_partb);

                //if (s_sd1.Length > 12)
                //    s_sd1 = s_sd1.Substring(0, 12);

                SmartDouble sd = SmartDouble.Parse(s_sd1);
                string s_sd2 = sd.ToString(8);

                Double d = Double.Parse(s_sd1);
                string s_d2 = d.ToString();

                Assert.AreEqual(s_sd2, s_d2, "Compare2Double " + s_sd1);
            }

        }

        [TestMethod]
        public void Test_SmartDouble_Parse_ToString_BruteForce_Heavy()
        {
            int test_count = 10000000;
            int parta_max = 1000000000;
            int partb_max = 1000000000;

            Random R = new Random();

            for (int i = 0; i < test_count; i++)
            {
                string s_parta = R.Next(parta_max).ToString();
                string s_partb = R.Next(partb_max).ToString();

                while ((s_partb.Length > 0) && (s_partb[s_partb.Length - 1] == '0'))
                    s_partb = s_partb.Substring(0, s_partb.Length - 1);

                string s_sd1 = s_parta;
                if (!string.IsNullOrEmpty(s_partb))
                    s_sd1 += ("." + s_partb);

                SmartDouble sd = SmartDouble.Parse(s_sd1);
                string s_sd2 = sd.ToString();

                Double d = Double.Parse(s_sd1);
                string s_d2 = d.ToString();

                // Cross
                d = Double.Parse(s_sd2);
                sd = SmartDouble.Parse(s_d2);

                Double error = Math.Abs((d - sd) / d);

                Assert.IsTrue(error < 1E-14, "Compare2DoubleHeavy " + s_sd1);
            }

        }


    }

}