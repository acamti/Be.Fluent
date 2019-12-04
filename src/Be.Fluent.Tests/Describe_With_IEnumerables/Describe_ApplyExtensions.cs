using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_ApplyExtensions
    {
        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithDesireTransformation_WhenSourceIsSync_AndActionIsSync()
        {
            IEnumerable<string> expected = new[] { "item 1", "item 2", "item 3" };
            IEnumerable<string> initialList = new[] { "1", "2", "3" };

            var result = initialList.Apply(item => $"item {item}");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithDesireTransformation_WhenSourceIsSync_AndActionIsASync()
        {
            IEnumerable<string> expected = new[] { "item 1", "item 2", "item 3" };
            IEnumerable<string> initialList = new[] { "1", "2", "3" };

            var result = await initialList.Apply(async item => await Task.FromResult($"item {item}"));

            result.Should().BeEquivalentTo(expected);
        }
    }
}
