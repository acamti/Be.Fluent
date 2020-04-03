using System;
using Acamti.Be.Fluent.With.DateTimes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Be.Fluent.Tests.Describe_With_DateTimes
{
    [TestClass]
    public class Describe_IsBetweenExtensions
    {
        [TestMethod]
        [DataRow(0, -1, 1)]
        [DataRow(0, 0, 1)]
        [DataRow(1, -1, 1)]
        public void It_ShouldReturnTrue_WhenIsBetweenInclusively(int minuteToAddCurrent, int minuteToAddFrom, int minuteToAddTo)
        {
            DateTime now = DateTime.Now;

            DateTime date = now.AddMinutes(minuteToAddCurrent);
            DateTime from = now.AddMinutes(minuteToAddFrom);
            DateTime to = now.AddMinutes(minuteToAddTo);

            bool result = date.IsBetween(from, to, ComparisonType.Inclusive);

            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(-1, 0, 1)]
        [DataRow(2, 0, 1)]
        public void It_ShouldReturnFalse_WhenIsBetweenInclusively(int minuteToAddCurrent, int minuteToAddFrom, int minuteToAddTo)
        {
            DateTime now = DateTime.Now;

            DateTime date = now.AddMinutes(minuteToAddCurrent);
            DateTime from = now.AddMinutes(minuteToAddFrom);
            DateTime to = now.AddMinutes(minuteToAddTo);

            bool result = date.IsBetween(from, to, ComparisonType.Inclusive);

            result.Should().BeFalse();
        }

        [TestMethod]
        [DataRow(0, -1, 1)]
        [DataRow(0, 0, 1)]
        public void It_ShouldReturnTrue_WhenIsBetweenExclusively(int minuteToAddCurrent, int minuteToAddFrom, int minuteToAddTo)
        {
            DateTime now = DateTime.Now;

            DateTime date = now.AddMinutes(minuteToAddCurrent);
            DateTime from = now.AddMinutes(minuteToAddFrom);
            DateTime to = now.AddMinutes(minuteToAddTo);

            bool result = date.IsBetween(from, to, ComparisonType.Exclusive);

            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow(-1, 0, 1)]
        [DataRow(2, 0, 1)]
        [DataRow(1, -1, 1)]
        public void It_ShouldReturnFalse_WhenIsBetweenExclusively(int minuteToAddCurrent, int minuteToAddFrom, int minuteToAddTo)
        {
            DateTime now = DateTime.Now;

            DateTime date = now.AddMinutes(minuteToAddCurrent);
            DateTime from = now.AddMinutes(minuteToAddFrom);
            DateTime to = now.AddMinutes(minuteToAddTo);

            bool result = date.IsBetween(from, to, ComparisonType.Exclusive);

            result.Should().BeFalse();
        }
    }
}
