using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PELEXMapper;
using PESALEXMapper.Helper.Tests.Mock;

namespace PESALEXMapper.Helper.Tests
{
    [TestClass]
    public class EnumUtilUnitTest
    {
        [TestMethod]
        public void DescriptionArray_Count_4()
        {
            var result = EnumUtil.DescriptionArray<EnumValue>();
            Assert.AreEqual("1ª name", result[0]);
            Assert.AreEqual(4, result.Length);
        }

        [TestMethod]
        public void GetDescription_FooBarMember_3rdName()
        {
            var result = EnumUtil.GetDescription<EnumValue>(EnumValue.FooBar.ToString());
            Assert.AreEqual("3ª name", result);
        }

        [TestMethod]
        public void GetDescription_FooBarName_3rdName()
        {
            var result = EnumUtil.GetDescription<EnumValue>("FooBar");
            Assert.AreEqual("3ª name", result);
        }

        [TestMethod]
        public void GetDescriptionOfType_EnumValue_Values()
        {
            var result = EnumUtil.GetDescriptionOfType<EnumValue>();
            Assert.AreEqual("Values", result);
        }

        [TestMethod]
        public void GetDescription_ByValueEquals3_4ªname()
        {
            var result = EnumUtil.GetDescription<EnumValue>(3);
            Assert.AreEqual("4ª name", result);
        }

        [TestMethod]
        public void GetValue_BydescriptionEquals4ªname_ValueEquals3()
        {
            var result = EnumUtil.GetValue<EnumValue>("4ª name");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetByName_NameEqualBar_ValueEqualBar()
        {
            var result = EnumUtil.GetByName<EnumValue>("Bar");
            Assert.AreEqual(EnumValue.Bar, result);
        }
    }
}
