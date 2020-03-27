using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_SafeExtensions
    {
        [TestMethod]
        public void It_Should_ReturnSameIEnumerable_WhenAlreadyInitialized()
        {
            IEnumerable<string> expected = new[] { "someItem" };

            var initialList = new[] { "someItem" };

            IEnumerable<string> result = initialList.Safe();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WhenNotAlreadyInitialized()
        {
            IEnumerable<string> expected = Enumerable.Empty<string>();

            IEnumerable<string> initialList = null;

            IEnumerable<string> result = initialList.Safe();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnSameAsyncIEnumerable_WhenAlreadyInitialized()
        {
            IEnumerable<string> expected = new[] { "someItem" };

            Task<IEnumerable<string>> initialList = Task.FromResult(new[] { "someItem" }.AsEnumerable());

            IEnumerable<string> result = await initialList.SafeAsync();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnAsyncIEnumerable_WhenNotAlreadyInitialized()
        {
            IEnumerable<string> expected = Enumerable.Empty<string>();

            Task<IEnumerable<string>> initialList = Task.FromResult((IEnumerable<string>) null);

            IEnumerable<string> result = await initialList.SafeAsync();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
