using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_PipeExtensions
    {
        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget()
        {
            var source = 1;
            var expected = "1";

            string result = await source.Pipe(s => Task.Run(() => $"{s}"));

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";

            string result = await source.Pipe((s, p1) => Task.Run(() => $"{s}.{p1}"), 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";

            string result = await source.Pipe((s, p1, p2) => Task.Run(() => $"{s}.{p1}.{p2}"), 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";

            string result = await source.Pipe((s, p1, p2, p3) => Task.Run(() => $"{s}.{p1}.{p2}.{p3}"), 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget()
        {
            var source = 1;
            var expected = "1";

            string result = source.Pipe(s => $"{s}");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";

            string result = source.Pipe((s, p1) => $"{s}.{p1}", 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";

            string result = source.Pipe((s, p1, p2) => $"{s}.{p1}.{p2}", 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";

            string result = source.Pipe((s, p1, p2, p3) => $"{s}.{p1}.{p2}.{p3}", 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousSource_to_SynchronousTarget()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1";

            string result = await source.PipeAsync(s => $"{s}");

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousSource_to_SynchronousTarget_With1Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0";

            string result = await source.PipeAsync((s, p1) => $"{s}.{p1}", 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousSource_to_SynchronousTarget_With2Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0.0";

            string result = await source.PipeAsync((s, p1, p2) => $"{s}.{p1}.{p2}", 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_AsynchronousSource_to_SynchronousTarget_With3Param()
        {
            Task<int> source = Task.FromResult(1);
            var expected = "1.0.0.0";

            string result = await source.PipeAsync((s, p1, p2, p3) => $"{s}.{p1}.{p2}.{p3}", 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
