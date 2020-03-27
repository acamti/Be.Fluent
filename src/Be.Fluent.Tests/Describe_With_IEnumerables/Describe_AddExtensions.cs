using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            IEnumerable<string> expected = new[] { "newItem" };

            IEnumerable<string> initialList = Enumerable.Empty<string>();

            IEnumerable<string> result = initialList.Add("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItem_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] { "oldItem", "newItem" };

            var initialList = new[] { "oldItem" };

            IEnumerable<string> result = initialList.Add("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItemFromPredicate()
        {
            IEnumerable<string> expected = new[] { "newItem" };

            IEnumerable<string> initialList = Enumerable.Empty<string>();

            IEnumerable<string> result = initialList.Add(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_Should_ReturnIEnumerable_WithAddedItemFromPredicate_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] { "oldItem", "newItem" };

            var initialList = new[] { "oldItem" };

            IEnumerable<string> result = initialList.Add(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithAddedAsyncItem()
        {
            IEnumerable<string> expected = new[] { "newItem" };

            Task<IEnumerable<string>> initialList = Task.FromResult(Enumerable.Empty<string>());

            IEnumerable<string> result = await initialList.AddAsync("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithAddedAsyncItem_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] { "oldItem", "newItem" };

            Task<IEnumerable<string>> initialList = Task.FromResult(new[] { "oldItem" }.AsEnumerable());

            IEnumerable<string> result = await initialList.AddAsync("newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithAddedAsyncItemFromPredicate()
        {
            IEnumerable<string> expected = new[] { "newItem" };

            Task<IEnumerable<string>> initialList = Task.FromResult(Enumerable.Empty<string>());

            IEnumerable<string> result = await initialList.AddAsync(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ReturnIEnumerable_WithAddedAsyncItemFromPredicate_WhenNotEmpty()
        {
            IEnumerable<string> expected = new[] { "oldItem", "newItem" };

            Task<IEnumerable<string>> initialList = Task.FromResult(new[] { "oldItem" }.AsEnumerable());

            IEnumerable<string> result = await initialList.AddAsync(() => "newItem");

            result.Should().BeEquivalentTo(expected);
        }
    }
}
