using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Generics;
using System;
using System.Threading.Tasks;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_ActExtensions
    {
        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget()
        {
            var source = 1;
            var expected = "1";
            string container = null;

            await source.Act(item => Task.Run(() => container = item.ToString()));

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";
            string container = null;

            await source.Act(async (item, param1) => container = await Task.FromResult($"{source}.{param1}"), 0);

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";
            string container = null;

            await source.Act(async (item, param1, param2) => container = await Task.FromResult($"{source}.{param1}.{param2}"), 0, 0);

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task It_ShouldTransform_SynchronousSource_to_AsynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";
            string container = null;

            await source.Act(async (item, param1, param2, param3) => container = await Task.FromResult($"{source}.{param1}.{param2}.{param3}"), 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget()
        {
            var source = 1;
            var expected = "1";
            string container = null;

            source.Act(item => container = item.ToString());

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With1Param()
        {
            var source = 1;
            var expected = "1.0";
            string container = null;

            source.Act((item, param1) => container = $"{source}.{param1}", 0);

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With2Param()
        {
            var source = 1;
            var expected = "1.0.0";
            string container = null;

            source.Act((item, param1, param2) => container = $"{source}.{param1}.{param2}", 0, 0);

            container.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldTransform_SynchronousSource_to_SynchronousTarget_With3Param()
        {
            var source = 1;
            var expected = "1.0.0.0";
            string container = null;

            source.Act((item, param1, param2, param3) => container = $"{source}.{param1}.{param2}.{param3}", 0, 0, 0);

            container.Should().BeEquivalentTo(expected);
        }
    }
}
