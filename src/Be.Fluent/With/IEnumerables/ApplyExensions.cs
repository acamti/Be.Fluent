using Acamti.Be.Fluent.With.IEnumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class ApplyExensions
    {
        public static IEnumerable<TSource> Apply<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource> action)
        {
            var newList = Enumerable.Empty<TSource>();

            foreach (var item in source.Safe())
            {
                newList = newList.Add(action.Invoke(item));
            }

            return newList;
        }

        public static async Task<IEnumerable<TSource>> Apply<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<TSource>> action)
        {
            var newList = Enumerable.Empty<TSource>();

            foreach (var item in source.Safe())
            {
                newList = newList.Add(await action.Invoke(item));
            }

            return newList;
        }
    }
}
