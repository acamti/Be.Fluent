using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Generics;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ToEnumerableExtensions
    {
        [TestMethod]
        public void It_ShouldReturnAnEnumerable_WithAnySingleObject()
        {
            var expected = new[] { "some item" };
            var result = "some item".ToEnumerable();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldReturnAnEnumerable_WithAnyEnumerableObject()
        {
            var input = new[] { "string 1", "string 2" };
            object[] expected = { new[] { "string 1", "string 2" } };

            var result = input.ToEnumerable();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
