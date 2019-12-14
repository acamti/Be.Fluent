using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Tasks;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_TaskofActExtensions
    {
        [TestMethod]
        public async Task It_ShouldPerformAction_AsynchronousTarget()
        {
            var source = Task.FromResult(1);
            var expected = "1";
            string container = null;

            var result = await source.Act(item => Task.Run(() => container = item.ToString()));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_AsynchronousTarget_With1Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0";
            string container = null;

            var result = await source.Act(async (s, p1) => await Task.Run(() => container = $"{s}.{p1}"), 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_AsynchronousTarget_With2Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0";
            string container = null;

            var result = await source.Act(async (s, p1, p2) => await Task.Run(() => container = $"{s}.{p1}.{p2}"), 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_AsynchronousTarget_With3Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0.0";
            string container = null;

            var result = await source.Act(async (s, p1, p2, p3) => await Task.Run(() => container = $"{s}.{p1}.{p2}.{p3}"), 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget()
        {
            var source = Task.FromResult(1);
            var expected = "1";
            string container = null;

            var result = await source.Act(s => container = s.ToString());

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With1Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0";
            string container = null;

            var result = await source.Act((s, p1) => container = $"{s}.{p1}", 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With2Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0";
            string container = null;

            var result = await source.Act((s, p1, p2) => container = $"{s}.{p1}.{p2}", 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With3Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0.0";
            string container = null;

            var result = await source.Act((s, p1, p2, p3) => container = $"{s}.{p1}.{p2}.{p3}", 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }
    }
}
