using System.Collections.Generic;
using System.Linq;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_AddExtensions
    {
        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItem()
        {
            IEnumerable<string> expected = new[] {"newItem"};

            IEnumerable<string> initialList = Enumerable.Empty<string>();

            IEnumerable<string> result = initialList.Add("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItem_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] {"oldItem", "newItem"};

            var initialList = new[] {"oldItem"};

            IEnumerable<string> result = initialList.Add("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItemFromPredicate()
        {
            IEnumerable<string> expected = new[] {"newItem"};

            IEnumerable<string> initialList = Enumerable.Empty<string>();

            IEnumerable<string> result = initialList.Add(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItemFromPredicate_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] {"oldItem", "newItem"};

            var initialList = new[] {"oldItem"};

            IEnumerable<string> result = initialList.Add(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItem_WhenSourceIsNull()
        {
            IEnumerable<string> expected = new[] {"newItem"};

            IEnumerable<string> initialList = null;

            IEnumerable<string> result = initialList.Add("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItemFromPredicate_WhenSourceIsNull()
        {
            IEnumerable<string> expected = new[] {"newItem"};

            IEnumerable<string> initialList = null;

            IEnumerable<string> result = initialList.Add(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }
    }
}
