using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class MapExtensions
    {

        public static TResult Map<TSource, TResult>(this TSource source, Func<TSource, TResult> producer)
        {
            return producer(source);
        }

        public static async Task<TResult> Map<TSource, TResult>(this TSource source, Func<TSource, Task<TResult>> producer)
        {
            return await producer(source);
        }

        public static TResult Map<TSource, TParam1, TResult>(this TSource source, Func<TSource, TParam1, TResult> producer, TParam1 p1)
        {
            return producer(source, p1);
        }

        public static async Task<TResult> Map<TSource, TParam1, TResult>(this TSource source, Func<TSource, TParam1, Task<TResult>> producer, TParam1 p1)
        {
            return await producer(source, p1);
        }

        public static TResult Map<TSource, TParam1, TParam2, TResult>(this TSource source, Func<TSource, TParam1, TParam2, TResult> producer, TParam1 p1, TParam2 p2)
        {
            return producer(source, p1, p2);
        }

        public static async Task<TResult> Map<TSource, TParam1, TParam2, TResult>(this TSource source, Func<TSource, TParam1, TParam2, Task<TResult>> producer, TParam1 p1, TParam2 p2)
        {
            return await producer(source, p1, p2);
        }

        public static TResult Map<TSource, TParam1, TParam2, TParam3, TResult>(this TSource source, Func<TSource, TParam1, TParam2, TParam3, TResult> producer, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            return producer(source, p1, p2, p3);
        }

        public static async Task<TResult> Map<TSource, TParam1, TParam2, TParam3, TResult>(this TSource source, Func<TSource, TParam1, TParam2, TParam3, Task<TResult>> producer, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            return await producer(source, p1, p2, p3);
        }
    }
}
