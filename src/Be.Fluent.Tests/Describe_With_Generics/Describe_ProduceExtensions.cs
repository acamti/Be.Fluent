using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Generics;
using System;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ProduceExtensions
    {
        private readonly Func<int, string> _testPipe = source => $"{source}";
        private readonly Func<int, int, string> _testPipeWithOneParam = (source, param1) => $"{source}.{param1}";
        private readonly Func<int, int, Task<string>> _testPipeWithOneParamAsync = (source, param1) => Task.FromResult($"{source}.{param1}");
        private readonly Func<int, int, int, string> _testPipeWithTwoParam = (source, param1, param2) => $"{source}.{param1}.{param2}";
        private readonly Func<int, int, int, Task<string>> _testPipeWithTwoParamAsync = (source, param1, param2) => Task.FromResult($"{source}.{param1}.{param2}");
        private readonly Func<int, int, int, int, string> _testPipeWithThreeParam = (source, param1, param2, param3) => $"{source}.{param1}.{param2}.{param3}";
        private readonly Func<int, int, int, int, Task<string>> _testPipeWithThreeParamAsync = (source, param1, param2, param3) => Task.FromResult($"{source}.{param1}.{param2}.{param3}");

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget()
        {
            var source = 1;
            var expected = "1";

            var result = await source.Produce(sourceString => Task.Run(() => _testPipe(sourceString)));

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";

            var result = await source.Produce(_testPipeWithOneParamAsync, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";

            var result = await source.Produce(_testPipeWithTwoParamAsync, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";

            var result = await source.Produce(_testPipeWithThreeParamAsync, 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget()
        {
            var source = 1;
            var expected = "1";

            var result = source.Produce(_testPipe);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";

            var result = source.Produce(_testPipeWithOneParam, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";

            var result = source.Produce(_testPipeWithTwoParam, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";

            var result = source.Produce(_testPipeWithThreeParam, 0, 0, 0);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
