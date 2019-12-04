using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class ForEachExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source.Safe())
            {
                action.Invoke(item);
            }
        }

        public static async Task ForEach<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
        {
            foreach (var item in source.Safe())
            {
                await action.Invoke(item);
            }
        }
    }
}
