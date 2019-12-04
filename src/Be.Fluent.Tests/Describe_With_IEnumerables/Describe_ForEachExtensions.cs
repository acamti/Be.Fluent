using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Acamti.Be.Fluent.With.IEnumerables;
using FluentAssertions;
using System.Threading.Tasks;

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
            List<bool> container = new List<bool>();

            initialList.ForEach(item=> container.Add(item == 2));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenSourceIsSync_AndActionIsASync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            IEnumerable<int> initialList = new[] { 1, 2, 3 };
            List<bool> container = new List<bool>();

            await initialList.ForEach(async item => await Task.Run(() => container.Add(item == 2)));

            container.Should().BeEquivalentTo(expected);
        }
    }
}
