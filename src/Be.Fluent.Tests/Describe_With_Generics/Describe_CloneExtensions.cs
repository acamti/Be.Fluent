using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Acamti.Be.Fluent.With.Generics;
using System;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_CloneExtensions
    {
        private class Obj1
        {
            public string s { get; set; }
            public DateTime d { get; set; }
            public Obj2 o { get; set; }
        }

        private class Obj2
        {
            public int i { get; set; }
            public bool b { get; set; }
        }

        [TestMethod]
        public void It_ShouldReturnAnObjectIdentical()
        {
            var objToClone = new Obj1 { s = "some string", d = DateTime.Now, o = new Obj2 { i = 4, b = true } };

            var result = objToClone.Clone();

            result.Should().BeEquivalentTo(objToClone);

        }

        [TestMethod]
        public void It_ShouldProduceAnImmutableObject()
        {
            var objToClone = new Obj1 { s = "some string", d = DateTime.Now, o = new Obj2 { i = 4, b = true } };

            var result = objToClone.Clone();

            objToClone.o.i = 5;

            result.Should().NotBeEquivalentTo(objToClone);
        }
    }
}
