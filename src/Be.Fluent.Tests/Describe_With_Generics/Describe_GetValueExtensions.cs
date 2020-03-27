using System;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_GetValueExtensions
    {
        [TestMethod]
        public async Task It_ShouldReturnPropertyValueOfObject()
        {
            Task<TestHelperClass> model = Task.FromResult(
                new TestHelperClass
                {
                    Prop1 = "some value",
                    Prop2 = 43,
                    Prop3 = true
                }
            );

            var expected = 43;

            int result = await model.WithValueAsync(m => m.Prop2);

            result.Should().Be(expected);
        }

        [TestMethod]
        public async Task It_ShouldReturnPropertyValueOfFunc()
        {
            Func<Task<TestHelperClass>> getModel = () => Task.FromResult(
                new TestHelperClass
                {
                    Prop1 = "some value",
                    Prop2 = 43,
                    Prop3 = true
                }
            );

            var expected = 43;

            int result = await getModel.WithValueAsync(m => m.Prop2);

            result.Should().Be(expected);
        }

        private class TestHelperClass
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public bool Prop3 { get; set; }
        }
    }
}
