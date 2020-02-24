using System.Collections.Generic;
using System.Linq;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class SafeExtensions
    {
        public static IEnumerable<TSource> Safe<TSource>(this IEnumerable<TSource> source) => 
            source ?? Enumerable.Empty<TSource>();
    }
}
