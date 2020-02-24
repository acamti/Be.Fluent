using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class ForEachExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source.Safe())
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task> action)
        {
            foreach (TSource item in source.Safe())
            {
                await action(item);
            }
        }

        public static async Task AwaitAndForEachAsync<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource> action) => 
            (await source).ForEach(action);

        public static async Task AwaitAndForEachAsync<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
        {
            await (await source).ForEachAsync(action);
        }
    }
}
