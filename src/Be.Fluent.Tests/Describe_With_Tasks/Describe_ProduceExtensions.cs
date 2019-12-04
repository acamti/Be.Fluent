using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Tasks;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_Tasks
{
    [TestClass]
    public class Describe_ProduceExtensions
    {
        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget()
        {
            var source = Task.FromResult(1);
            var expected = "1";

            var result = await source.WaitAndProduce(s => Task.Run(() => $"{s}"));

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With1Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0";

            var result = await source.WaitAndProduce((s, p1) => Task.Run(() => $"{s}.{p1}"), 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With2Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0";

            var result = await source.WaitAndProduce((s, p1, p2) => Task.Run(() => $"{s}.{p1}.{p2}"), 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With3Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0.0";

            var result = await source.WaitAndProduce((s, p1, p2, p3) => Task.Run(() => $"{s}.{p1}.{p2}.{p3}"), 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_SynchronousTarget()
        {
            var source = Task.FromResult(1);
            var expected = "1";

            var result = await source.WaitAndProduce((s => $"{s}"));

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With1Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0";

            var result = await source.WaitAndProduce((s, p1) => $"{s}.{p1}", 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With2Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0";

            var result = await source.WaitAndProduce((s, p1, p2) => $"{s}.{p1}.{p2}", 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With3Param()
        {
            var source = Task.FromResult(1);
            var expected = "1.0.0.0";

            var result = await source.WaitAndProduce((s, p1, p2, p3) => $"{s}.{p1}.{p2}.{p3}", 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
