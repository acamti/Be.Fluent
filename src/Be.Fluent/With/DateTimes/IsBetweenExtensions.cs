using System;

namespace Acamti.Be.Fluent.With.DateTimes
{
    public static class IsBetweenExtensions
    {
        public static bool IsBetween(this DateTime dateTime, DateTime from, DateTime to, ComparisonType comparison) =>
            comparison switch
            {
                ComparisonType.Inclusive => dateTime >= from && dateTime <= to,
                ComparisonType.Exclusive => dateTime >= from && dateTime < to,
                _                        => throw new ArgumentException($"{nameof(ComparisonType)} value {comparison} is not valid")
            };
    }
}
