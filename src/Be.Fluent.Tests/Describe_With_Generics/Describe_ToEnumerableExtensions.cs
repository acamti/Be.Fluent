using System.Collections.Generic;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ToEnumerableExtensions
    {
        [TestMethod]
        public void It_ShouldReturnAnEnumerable_WithAnySingleObject()
        {
            var expected = new[] { "some item" };
            IEnumerable<string> result = "some item".ToEnumerable();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldReturnAnEnumerable_WithAnyEnumerableObject()
        {
            var input = new[] { "string 1", "string 2" };
            object[] expected = { new[] { "string 1", "string 2" } };

            IEnumerable<string[]> result = input.ToEnumerable();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldReturnAnEnumerable_WithAnySingleAsyncObject()
        {
            var expected = new[] { "some item" };
            IEnumerable<string> result = await Task.FromResult("some item").ToEnumerableAsync();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldReturnAnEnumerable_WithAnyAsyncEnumerableObject()
        {
            Task<string[]> input = Task.FromResult(new[] { "string 1", "string 2" });
            object[] expected = { new[] { "string 1", "string 2" } };

            IEnumerable<string[]> result = await input.ToEnumerableAsync();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
