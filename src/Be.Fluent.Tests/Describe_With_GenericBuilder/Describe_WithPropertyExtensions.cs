using Acamti.Be.Fluent.Builders.Generic;
using Acamti.Be.Fluent.With.GenericBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_GenericBuilder
{
    [TestClass]
    public class Describe_WithPropertyExtensions
    {
        [TestMethod]
        public void It_ShouldAddPropertyToBuilderPatches()
        {
            var expected = new Operation<TestHelperClass>("replace", "/prop1", null, "new value");

            var sut = new GenericBuilder<TestHelperClass>(new TestHelperClass());
            sut.WithProperty(x => x.Prop1, "new value");

            ((IGenericBuilder<TestHelperClass>) sut).Patches.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldNotAddPropertyToBuilderPatches_WhenPropIsInvalid()
        {
            var sut = new GenericBuilder<TestHelperClass>(new TestHelperClass());
            sut.WithProperty(x => x.Prop2 == 54, false);

            ((IGenericBuilder<TestHelperClass>) sut).Patches.Should().BeEmpty();
        }

        [TestMethod]
        public void It_ShouldBuildAfterAddingValues()
        {
            var expected = new TestHelperClass
            {
                Prop1 = "some value",
                Prop3 = true
            };

            var sut = new GenericBuilder<TestHelperClass>(new TestHelperClass());

            sut
                .WithProperty(x => x.Prop1, "some value")
                .WithProperty(x => x.Prop3, true);

            sut.Build().Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void It_ShouldBuildAfterAddingValuesAndReset()
        {
            var expected = new TestHelperClass
            {
                Prop2 = 54
            };

            var sut = new GenericBuilder<TestHelperClass>(new TestHelperClass {Prop2 = 54});

            sut.WithProperty(x => x.Prop1, "some value")
                .WithProperty(x => x.Prop3, true)
                .Reset();

            sut.Build().Should().BeEquivalentTo(expected);
        }

        private class TestHelperClass
        {
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
            public bool Prop3 { get; set; }
        }
    }
}
