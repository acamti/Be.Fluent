using System.Collections.Generic;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ToEnumerableExtensions
    {
        public static IEnumerable<TSource> ToEnumerable<TSource>(this TSource source) =>
            new[] { source.Clone() };
    }
}
