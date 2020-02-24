using System.Collections.Generic;
using System.Linq;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class AsIndexExtensions
    {
        public static IEnumerable<KeyValuePair<int, TSource>> AsIndex<TSource>(this IEnumerable<TSource> source)
        {
            return source?.Select(
                (item, index) =>
                    new KeyValuePair<int, TSource>(index, item)
            );
        }
    }
}
