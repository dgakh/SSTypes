using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SSTypes.Tests
{
    [TestClass]
    public class SmartBoolTests
    {
        [TestMethod]
        [Description(" SmartBool.Logic")]
        public void SmartBool_Logic_Test()
        {
            Assert.IsTrue((bool)SmartBool.True, "SmartBool.True");
            Assert.IsFalse((bool)SmartBool.False, "SmartBool.False");
            Assert.IsFalse((bool)SmartBool.Unknown, "SmartBool.Unknown");

            // !
            Assert.IsTrue(SmartBool.isFalse((!SmartBool.True)), "!SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue((!SmartBool.False)), "!SmartBool.False");
            Assert.IsTrue(SmartBool.isUnknown((!SmartBool.Unknown)), "!SmartBool.Unknown");

            // |
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True | SmartBool.True), "SmartBool.True | SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.False | SmartBool.True), "SmartBool.False | SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True | SmartBool.False), "SmartBool.True | SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False | SmartBool.False), "SmartBool.False | SmartBool.False");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Unknown | SmartBool.True), "SmartBool.Unknown | SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True | SmartBool.Unknown), "SmartBool.True | SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown | SmartBool.False), "SmartBool.Unknown | SmartBool.False");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.False | SmartBool.Unknown), "SmartBool.False | SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown | SmartBool.Unknown), "SmartBool.Unknown | SmartBool.Unknown");

            // &
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True & SmartBool.True), "SmartBool.True & SmartBool.True");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False & SmartBool.True), "SmartBool.False & SmartBool.True");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.True & SmartBool.False), "SmartBool.True & SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False & SmartBool.False), "SmartBool.False & SmartBool.False");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown & SmartBool.True), "SmartBool.Unknown & SmartBool.True");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.True & SmartBool.Unknown), "SmartBool.True & SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Unknown & SmartBool.False), "SmartBool.Unknown & SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False & SmartBool.Unknown), "SmartBool.False & SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown & SmartBool.Unknown), "SmartBool.Unknown & SmartBool.Unknown");

            // ||
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True || SmartBool.True), "SmartBool.True || SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.False || SmartBool.True), "SmartBool.False || SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True || SmartBool.False), "SmartBool.True || SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False || SmartBool.False), "SmartBool.False || SmartBool.False");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Unknown || SmartBool.True), "SmartBool.Unknown || SmartBool.True");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True || SmartBool.Unknown), "SmartBool.True || SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown || SmartBool.False), "SmartBool.Unknown || SmartBool.False");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.False || SmartBool.Unknown), "SmartBool.False || SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown || SmartBool.Unknown), "SmartBool.Unknown || SmartBool.Unknown");

            // &&
            Assert.IsTrue(SmartBool.isTrue(SmartBool.True && SmartBool.True), "SmartBool.True && SmartBool.True");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False && SmartBool.True), "SmartBool.False && SmartBool.True");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.True && SmartBool.False), "SmartBool.True && SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False && SmartBool.False), "SmartBool.False && SmartBool.False");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown && SmartBool.True), "SmartBool.Unknown && SmartBool.True");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.True && SmartBool.Unknown), "SmartBool.True && SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Unknown && SmartBool.False), "SmartBool.Unknown && SmartBool.False");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.False && SmartBool.Unknown), "SmartBool.False && SmartBool.Unknown");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Unknown && SmartBool.Unknown), "SmartBool.Unknown && SmartBool.Unknown");

            SmartBool a, b;

            // ==
            a = SmartBool.True; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isTrue(a == b), "SmartBool.True == SmartBool.True");

            a = SmartBool.False; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isFalse(a == b), "SmartBool.False == SmartBool.True");

            a = SmartBool.True; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isFalse(a == b), "SmartBool.True == SmartBool.False");

            a = SmartBool.False; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isTrue(a == b), "SmartBool.False == SmartBool.False");

            a = SmartBool.Unknown; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isUnknown(a == b), "SmartBool.Unknown == SmartBool.True");

            a = SmartBool.True; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a == b), "SmartBool.True == SmartBool.Unknown");

            a = SmartBool.Unknown; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isUnknown(a == b), "SmartBool.Unknown == SmartBool.False");

            a = SmartBool.False; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a == b), "SmartBool.False == SmartBool.Unknown");

            a = SmartBool.Unknown; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a == b), "SmartBool.Unknown == SmartBool.Unknown");


            // !=
            a = SmartBool.True; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isFalse(a != b), "SmartBool.True != SmartBool.True");

            a = SmartBool.False; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isTrue(a != b), "SmartBool.False != SmartBool.True");

            a = SmartBool.True; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isTrue(a != b), "SmartBool.True != SmartBool.False");

            a = SmartBool.False; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isFalse(a != b), "SmartBool.False != SmartBool.False");

            a = SmartBool.Unknown; b = SmartBool.True;
            Assert.IsTrue(SmartBool.isUnknown(a != b), "SmartBool.Unknown != SmartBool.True");

            a = SmartBool.True; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a != b), "SmartBool.True != SmartBool.Unknown");

            a = SmartBool.Unknown; b = SmartBool.False;
            Assert.IsTrue(SmartBool.isUnknown(a != b), "SmartBool.Unknown != SmartBool.False");

            a = SmartBool.False; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a != b), "SmartBool.False != SmartBool.Unknown");

            a = SmartBool.Unknown; b = SmartBool.Unknown;
            Assert.IsTrue(SmartBool.isUnknown(a != b), "SmartBool.Unknown != SmartBool.Unknown");


        }

        [TestMethod]
        [Description(" SmartBool.Parse")]
        public void SmartBool_Parse_Test()
        {
            // ParseTF
            Assert.IsTrue(SmartBool.isTrue(SmartBool.ParseTF("true")), "SmartBool.ParseTF(true)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.ParseTF("false")), "SmartBool.ParseTF(false)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("unknown")), "SmartBool.ParseTF(unknown)");

            Assert.IsTrue(SmartBool.isTrue(SmartBool.ParseTF("True")), "SmartBool.ParseTF(True)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.ParseTF("False")), "SmartBool.ParseTF(False)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("Unknown")), "SmartBool.ParseTF(Unknown)");

            Assert.IsTrue(SmartBool.isTrue(SmartBool.ParseTF("TRUE")), "SmartBool.ParseTF(TRUE)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.ParseTF("FALSE")), "SmartBool.ParseTF(FALSE)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("UNKNOWN")), "SmartBool.ParseTF(UNKNOWN)");

            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("t")), "SmartBool.ParseTF(t)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("f")), "SmartBool.ParseTF(f)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("T")), "SmartBool.ParseTF(T)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("F")), "SmartBool.ParseTF(F)");

            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("")), "SmartBool.ParseTF()");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.ParseTF("lkdskdks")), "SmartBool.ParseTF(lkdskdks)");

            // Parse
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("true")), "SmartBool.Parse(true)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("false")), "SmartBool.Parse(false)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("unknown")), "SmartBool.Parse(unknown)");

            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("True")), "SmartBool.Parse(True)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("False")), "SmartBool.Parse(False)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("Unknown")), "SmartBool.Parse(Unknown)");

            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("TRUE")), "SmartBool.Parse(TRUE)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("FALSE")), "SmartBool.Parse(FALSE)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("UNKNOWN")), "SmartBool.Parse(UNKNOWN)");

            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("on")), "SmartBool.Parse(on)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("off")), "SmartBool.Parse(off)");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("yes")), "SmartBool.Parse(yes)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("no")), "SmartBool.Parse(no)");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("y")), "SmartBool.Parse(y)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("n")), "SmartBool.Parse(n)");
            Assert.IsTrue(SmartBool.isTrue(SmartBool.Parse("t")), "SmartBool.Parse(t)");
            Assert.IsTrue(SmartBool.isFalse(SmartBool.Parse("f")), "SmartBool.Parse(f)");

            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("")), "SmartBool.Parse()");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("u")), "SmartBool.Parse(u)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("U")), "SmartBool.Parse(U)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("blablabla")), "SmartBool.Parse(blablabla)");

            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("-1")), "SmartBool.Parse(-1)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("0")), "SmartBool.Parse(0)");
            Assert.IsTrue(SmartBool.isUnknown(SmartBool.Parse("1")), "SmartBool.Parse(1)");
        }
    }
}
