using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class MapExtensions
    {
        public static TResult Map<TSource, TResult>(
            this TSource source,
            Func<TSource, TResult> producer
        ) =>
            producer(source);

        public static TResult Map<TSource, TParam1, TResult>(
            this TSource source,
            Func<TSource, TParam1, TResult> producer,
            TParam1 p1
        ) =>
            producer(source, p1);

        public static TResult Map<TSource, TParam1, TParam2, TResult>(
            this TSource source,
            Func<TSource, TParam1, TParam2, TResult> producer,
            TParam1 p1,
            TParam2 p2
        ) =>
            producer(source, p1, p2);

        public static TResult Map<TSource, TParam1, TParam2, TParam3, TResult>(
            this TSource source,
            Func<TSource, TParam1, TParam2, TParam3, TResult> producer,
            TParam1 p1,
            TParam2 p2,
            TParam3 p3
        ) =>
            producer(source, p1, p2, p3);

        public static async Task<TResult> AwaitAndMapAsync<TSource, TResult>(
            this Task<TSource> source,
            Func<TSource, TResult> producer
        ) =>
            (await source).Map(producer);

        public static async Task<TResult> AwaitAndMapAsync<TSource, TParam1, TResult>(
            this Task<TSource> source,
            Func<TSource, TParam1, TResult> producer,
            TParam1 p1
        ) =>
            (await source).Map(producer, p1);

        public static async Task<TResult> AwaitAndMapAsync<TSource, TParam1, TParam2, TResult>(
            this Task<TSource> source,
            Func<TSource, TParam1, TParam2, TResult> producer,
            TParam1 p1,
            TParam2 p2
        ) =>
            (await source).Map(producer, p1, p2);

        public static async Task<TResult> AwaitAndMapAsync<TSource, TParam1, TParam2, TParam3, TResult>(
            this Task<TSource> source,
            Func<TSource, TParam1, TParam2, TParam3, TResult> producer,
            TParam1 p1,
            TParam2 p2,
            TParam3 p3
        ) =>
            (await source).Map(producer, p1, p2, p3);
    }
}
