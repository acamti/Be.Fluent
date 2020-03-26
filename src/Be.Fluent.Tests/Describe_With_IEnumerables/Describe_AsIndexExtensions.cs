using System.Collections.Generic;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_AsIndexExtensions
    {
        [TestMethod]
        public void It_Should_ReturnListOfSameSource_WithIndexedKey()
        {
            var expected = new[] { new KeyValuePair<int, string>(0, "someItem"), new KeyValuePair<int, string>(1, "someOtherItem") };

            var initialList = new[] { "someItem", "someOtherItem" };

            IEnumerable<KeyValuePair<int, string>> result = initialList.AsIndex();

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnNull_WhenNotInitialized()
        {
            IEnumerable<string> expected = null;

            IEnumerable<string> initialList = null;

            IEnumerable<KeyValuePair<int, string>> result = initialList.AsIndex();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
