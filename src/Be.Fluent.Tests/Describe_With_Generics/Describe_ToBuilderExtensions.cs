using Acamti.Be.Fluent.Builders.Generic;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ToBuilderExtensions
    {
        [TestMethod]
        public void It_ShouldCreateBuilderOutOfModel()
        {
            var myClass = new TestHelperClass
            {
                Prop1 = "some value",
                Prop2 = 54,
                Prop3 = true
            };

            var expected = new TestHelperClass
            {
                Prop1 = "some value",
                Prop2 = 54,
                Prop3 = true
            };

            GenericBuilder<TestHelperClass> result = myClass.ToBuilder();

            result.Build().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldCreateEmptyBuilderOutOfModel()
        {
            var myClass = new TestHelperClass
            {
                Prop1 = "some value",
                Prop2 = 54,
                Prop3 = true
            };

            var expected = new TestHelperClass();

            GenericBuilder<TestHelperClass> result = myClass.ToEmptyBuilder();

            result.Build().Should().BeEquivalentTo(expected);
        }

        private class TestHelperClass
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public bool Prop3 { get; set; }
        }
    }
}
