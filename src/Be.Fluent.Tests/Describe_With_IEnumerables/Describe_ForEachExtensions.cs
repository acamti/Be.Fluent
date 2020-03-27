using System.Collections.Generic;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_IEnumerables
{
    [TestClass]
    public class Describe_ForEachExtensions
    {
        [TestMethod]
        public void It_Should_ProduceDesireAction_WhenSourceIsSync_AndActionIsSync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            IEnumerable<int> initialList = new[] { 1, 2, 3 };
            var container = new List<bool>();

            initialList.ForEach(item => container.Add(item == 2));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenSourceIsSync_AndActionIsAsync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            IEnumerable<int> initialList = new[] { 1, 2, 3 };
            var container = new List<bool>();

            await initialList.ForEachAsync(async item => await Task.Run(() => container.Add(item == 2)));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenSourceIsAsync_AndActionIsSync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            Task<IEnumerable<int>> initialList = Task.FromResult(new[] { 1, 2, 3 } as IEnumerable<int>);
            var container = new List<bool>();

            await initialList.ForEachAsync(item => container.Add(item == 2));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenSourceIsAsync_AndActionIsASync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            Task<IEnumerable<int>> initialList = Task.FromResult(new[] { 1, 2, 3 } as IEnumerable<int>);
            var container = new List<bool>();

            await initialList.ForEachAsync(async item => await Task.Run(() => container.Add(item == 2)));

            container.Should().BeEquivalentTo(expected);
        }
    }
}
