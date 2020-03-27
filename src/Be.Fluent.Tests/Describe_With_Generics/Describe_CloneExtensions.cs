using System;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_Generics
{
    [TestClass]
    public class Describe_CloneExtensions
    {
        [TestMethod]
        public void It_ShouldReturnAnObjectIdentical()
        {
            var objToClone = new Obj1
            {
                S = "some string",
                D = DateTime.Now,
                O = new Obj2
                {
                    I = 4,
                    B = true
                }
            };

            Obj1 result = objToClone.Clone();

            result.Should().BeEquivalentTo(objToClone);
        }

        [TestMethod]
        public async Task It_ShouldReturnAnObjectIdenticalFromTask()
        {
            Task<Obj1> objToClone = Task.FromResult(
                new Obj1
                {
                    S = "some string",
                    D = DateTime.Now,
                    O = new Obj2
                    {
                        I = 4,
                        B = true
                    }
                }
            );

            Obj1 result = await objToClone.CloneAsync();

            result.Should().BeEquivalentTo(await objToClone);
        }

        [TestMethod]
        public void It_ShouldProduceAnImmutableObject()
        {
            var objToClone = new Obj1
            {
                S = "some string",
                D = DateTime.Now,
                O = new Obj2
                {
                    I = 4,
                    B = true
                }
            };

            Obj1 result = objToClone.Clone();

            objToClone.O.I = 5;

            result.Should().NotBeEquivalentTo(objToClone);
        }

        private class Obj1
        {
            public string S { get; set; }
            public DateTime D { get; set; }
            public Obj2 O { get; set; }
        }

        private class Obj2
        {
            public int I { get; set; }
            public bool B { get; set; }
        }
    }
}
