using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Acamti.Be.Fluent.With.Tasks;
using FluentAssertions;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_ITasks
{
    [TestClass]
    public class Describe_TaskOfForEachExtensions
    {
        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenActionIsSync()
        {
            IEnumerable<bool> expected = new[] { false, true, false } ;
            Task<IEnumerable<int>> initialList = Task.FromResult(new[] { 1, 2, 3 } as IEnumerable<int>);
            List<bool> container = new List<bool>();

            await initialList.ForEach(item=> container.Add(item == 2));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_Should_ProduceDesireAction_WhenSourceIsSync_AndActionIsASync()
        {
            IEnumerable<bool> expected = new[] { false, true, false };
            Task<IEnumerable<int>> initialList = Task.FromResult(new[] { 1, 2, 3 } as IEnumerable<int>);
            List<bool> container = new List<bool>();

            await initialList.ForEach(async item => await Task.Run(() => container.Add(item == 2)));

            container.Should().BeEquivalentTo(expected);
        }
    }
}
