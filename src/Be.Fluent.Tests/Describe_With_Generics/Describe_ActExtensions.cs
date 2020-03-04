using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ActExtensions
    {
        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousTarget()
        {
            var source = 1;
            var expected = "1";
            string container = null;

            int result = await source.ActAsync(item => Task.Run(() => container = item.ToString()));

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";
            string container = null;

            int result = await source.ActAsync((item, param1) => Task.Run(() => container = $"{source}.{param1}"), 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";
            string container = null;

            int result = await source.ActAsync((item, param1, param2) => Task.Run(() => container = $"{source}.{param1}.{param2}"), 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";
            string container = null;

            int result = await source.ActAsync((item, param1, param2, param3) => Task.Run(() => container = $"{source}.{param1}.{param2}.{param3}"), 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousTarget()
        {
            var source = 1;
            var expected = "1";
            string container = null;

            int result = source.Act(item => container = item.ToString());

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";
            string container = null;

            int result = source.Act((item, param1) => container = $"{source}.{param1}", 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";
            string container = null;

            int result = source.Act((item, param1, param2) => container = $"{source}.{param1}.{param2}", 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";
            string container = null;

            int result = source.Act((item, param1, param2, param3) => container = $"{source}.{param1}.{param2}.{param3}", 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1";
            string container = null;

            int result = await source.ActAsync(s => container = s.ToString());

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With1Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0";
            string container = null;

            int result = await source.ActAsync((s, p1) => container = $"{s}.{p1}", 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With2Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0.0";
            string container = null;

            int result = await source.ActAsync((s, p1, p2) => container = $"{s}.{p1}.{p2}", 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }

        [TestMethod]
        public async Task It_ShouldPerformAction_SynchronousTarget_With3Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0.0.0";
            string container = null;

            int result = await source.ActAsync((s, p1, p2, p3) => container = $"{s}.{p1}.{p2}.{p3}", 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
            result.Should().Be(await source);
        }
    }
}
