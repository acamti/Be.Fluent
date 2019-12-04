using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.IEnumerables;

namespace Acamti.Be.Fluent.With.Tasks
{
    public static class WaitAndApplyExensions
    {
        public static async Task<IEnumerable<TSource>> WaitAndApply<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, TSource> action)
        {
            return (await source).Apply(action);
        }

        public static async Task<IEnumerable<TSource>> WaitAndApply<TSource>(this Task<IEnumerable<TSource>> source, Func<TSource, Task<TSource>> action)
        {
            return await (await source).Apply(action);
        }
    }
}
