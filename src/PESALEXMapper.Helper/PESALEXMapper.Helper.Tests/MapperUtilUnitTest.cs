using Microsoft.VisualStudio.TestTools.UnitTesting;
using PELEXMapper;
using PESALEXMapper.Helper.Tests.Mock;

namespace PESALEXMapper.Helper.Tests
{
    [TestClass]
    public class MapperUtilUnitTest
    {
        private Foo _foo;

        [TestInitialize]
        public void Initialize()
        {
            _foo = new Foo
            {
                Id = 1,
                Name = "Foo",
                Bar = new Bar
                {
                    Id = 2,
                    Description = "Bar",
                    EnumValue = EnumValue.Bar
                }
            };
        }

        [TestMethod]
        public void KeepDependencies_DeepProperties_LinkAll()
        {
            var result = MapperUtil.MapKeepDependencies<Foo>(_foo);
            Assert.IsNotNull(result.Bar);
            Assert.AreEqual(EnumValue.Bar, result.Bar.EnumValue);
        }

        //[TestMethod]
        //public void IgnoreDependences_DynamicProperties_LinkAll()
        //{
        //    var arrange = new ExpandoObject();
        //    var temp = arrange as IDictionary<string, object>;
        //    temp["Id"] = 1;
        //    temp.Add("Name", "Foo");
        //    dynamic request = arrange;
        //    var result = (Foo)MapperUtil.MapIgnoreDependences<Foo>(request);
        //    Assert.IsNotNull(result);
        //    Assert.IsNull(result.Bar);
        //    Assert.AreEqual("Foo", result.Name);
        //    Assert.AreEqual(1, result.Id);
        //}

    }

    

    

    
}
