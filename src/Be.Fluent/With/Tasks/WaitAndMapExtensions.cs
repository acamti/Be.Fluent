using Acamti.Be.Fluent.With.Generics;
using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Tasks
{
    public static class WaitAndMapExtensions
    {

        public static async Task<TResult> WaitAndMap<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> producer)
        {
            return (await source).Map(producer);
        }

        public static async Task<TResult> WaitAndMap<TSource, TResult>(this Task<TSource> source, Func<TSource, Task<TResult>> producer)
        {
            return await (await source).Map(producer);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TResult>(this Task<TSource> source, Func<TSource, TParam1, TResult> producer, TParam1 p1)
        {
            return (await source).Map(producer, p1);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TResult>(this Task<TSource> source, Func<TSource, TParam1, Task<TResult>> producer, TParam1 p1)
        {
            return await (await source).Map(producer, p1);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TParam2, TResult>(this Task<TSource> source, Func<TSource, TParam1, TParam2, TResult> producer, TParam1 p1, TParam2 p2)
        {
            return (await source).Map(producer, p1, p2);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TParam2, TResult>(this Task<TSource> source, Func<TSource, TParam1, TParam2, Task<TResult>> producer, TParam1 p1, TParam2 p2)
        {
            return await (await source).Map(producer, p1, p2);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TParam2, TParam3, TResult>(this Task<TSource> source, Func<TSource, TParam1, TParam2, TParam3, TResult> producer, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            return (await source).Map(producer, p1, p2, p3);
        }

        public static async Task<TResult> WaitAndMap<TSource, TParam1, TParam2, TParam3, TResult>(this Task<TSource> source, Func<TSource, TParam1, TParam2, TParam3, Task<TResult>> producer, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            return await (await source).Map(producer, p1, p2, p3);
        }
    }
}
