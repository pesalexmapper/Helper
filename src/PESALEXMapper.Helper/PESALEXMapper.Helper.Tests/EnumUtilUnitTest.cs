using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PESALEXMapper.Helper.Tests.Mock;

namespace PESALEXMapper.Helper.Tests
{
    [TestClass]
    public class EnumUtilUnitTest
    {
        [TestMethod]
        public void DescriptionList_Count_4()
        {
            var result = EnumUtil.DescriptionList<EnumValue>();
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void GetDescription_FooBarMember_3rdName()
        {
            var result = EnumUtil.GetDescription<EnumValue>(EnumValue.FooBar.ToString());
            Assert.AreEqual("3ª name", result);
        }

        [TestMethod]
        public void GetDescriptionOfType_EnumValue_Values()
        {
            var result = EnumUtil.GetDescriptionOfType<EnumValue>();
            Assert.AreEqual("Values", result);
        }
    }
}
