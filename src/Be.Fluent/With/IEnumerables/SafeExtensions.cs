using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class SafeExtensions
    {
        public static IEnumerable<TSource> Safe<TSource>(this IEnumerable<TSource> source) =>
            source ?? Enumerable.Empty<TSource>();

        public static async Task<IEnumerable<TSource>> SafeAsync<TSource>(this Task<IEnumerable<TSource>> source) =>
            await source ?? Enumerable.Empty<TSource>();
    }
}
