using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using System.Linq;

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

            var result = initialList.Safe();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WhenNotAlreadyInitialized()
        {
            IEnumerable<string> expected = Enumerable.Empty<string>();

            IEnumerable<string> initialList = null;

            var result = initialList.Safe();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
