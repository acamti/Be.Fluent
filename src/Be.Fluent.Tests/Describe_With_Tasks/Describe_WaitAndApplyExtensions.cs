using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Acamti.Be.Fluent.With.Tasks;
using FluentAssertions;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_WaitAndApplyExtensions
    {
        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithDesireTransformation_WhenActionIsSync()
        {
            IEnumerable<string> expected = new[] { "item 1", "item 2", "item 3" };
            Task<IEnumerable<string>> initialList = Task.FromResult(new[] { "1", "2", "3" } as IEnumerable<string>);

            var result = await initialList.WaitAndApply(item => $"item {item}");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithDesireTransformation_WhenActionIsASync()
        {
            IEnumerable<string> expected = new[] { "item 1", "item 2", "item 3" };
            Task<IEnumerable<string>> initialList = Task.FromResult(new[] { "1", "2", "3" } as IEnumerable<string>);

            var result = await initialList.WaitAndApply(async item => await Task.FromResult($"item {item}"));

            result.Should().BeEquivalentTo(expected);
        }
    }
}
