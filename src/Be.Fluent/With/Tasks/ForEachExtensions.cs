using Acamti.Be.Fluent.With.IEnumerables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Tasks
{
    public static class ForEachExtensions
    {
        public static async Task ForEach<TSource>(this Task<IEnumerable<TSource>> source, Action<TSource> action)
        {
            (await source).ForEach(action);
        }

        public static async Task ForEach<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task> action)
        {
            await (await source).ForEach(action);
        }
    }
}
