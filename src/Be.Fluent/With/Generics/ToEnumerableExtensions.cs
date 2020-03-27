using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ToEnumerableExtensions
    {
        public static IEnumerable<TSource> ToEnumerable<TSource>(this TSource source) =>
            new[] { source.Clone() };

        public static async Task<IEnumerable<TSource>> ToEnumerableAsync<TSource>(this Task<TSource> source) =>
            new[] { await source.CloneAsync() };
    }
}
