using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PESALEXMapper.Helper.Tests
{
    [TestClass]
    public class StringUtilUnitTest
    {
        private string _arrange = " a'1234567890-=\"!@#$%¨&*()_+¹²³£¢¬§`{^}<>,.;/:?\\|A";

        [TestMethod]
        public void Alphabetic_AnyChar_Letters()
        {
            var result = _arrange.Alphabetic();
            Assert.AreEqual("aA", result);
        }

        [TestMethod]
        public void Alphanumeric_AnyChar_LettersAndNumbers()
        {
            var result = _arrange.Alphanumeric();
            Assert.AreEqual("a1234567890A", result);
        }

        [TestMethod]
        public void Numerics_AnyChar_Numbers()
        {
            var result = _arrange.Numerics();
            Assert.AreEqual("1234567890", result);
        }

        [TestMethod]
        public void RemoveSpecialChars_WithParentheses_WithoutParentheses()
        {
            var result = _arrange.RemoveSpecialChars("(", ")");
            Assert.AreEqual(_arrange.Replace("(", string.Empty).Replace(")", string.Empty), result);
        }

        [TestMethod]
        public void TrimNull_AnyChar_Trim()
        {
            var arrange = " A a ";
            var result = arrange.TrimNull();
            Assert.AreEqual("A a", result);
        }


        [TestMethod]
        public void TrimNull_Empty_Null()
        {
            var result = string.Empty.TrimNull();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Tyne_AnyChar_tinyWithoutSpace()
        {
            var arrange = " TYNE Tyne ";
            var result = arrange.Tyne();
            Assert.AreEqual("tynetyne", result);
        }

        [TestMethod]
        public void Capitalize_AnyChar_CapitalizeSentence()
        {
            var arrange = "capitalize sentence";
            var result = arrange.Capitalize();
            Assert.AreEqual("Capitalize Sentence", result);
        }

        [TestMethod]
        public void CapitalizeFirst_AnyChar_CapitalizeFirstLetter()
        {
            var arrange = "capitalize first letter";
            var result = arrange.CapitalizeFirst();
            Assert.AreEqual("Capitalize first letter", result);
        }

    }
}
