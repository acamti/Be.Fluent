using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class PipeExtensions
    {
        public static TResult Pipe<TSource, TResult>(this TSource source,
                                                     Func<TSource, TResult> producer) =>
            producer(source.Clone());

        public static TResult Pipe<TSource, TParam1, TResult>(this TSource source,
                                                              Func<TSource, TParam1, TResult> producer,
                                                              TParam1 p1) =>
            producer(source.Clone(), p1);

        public static TResult Pipe<TSource, TParam1, TParam2, TResult>(this TSource source,
                                                                       Func<TSource, TParam1, TParam2, TResult> producer,
                                                                       TParam1 p1,
                                                                       TParam2 p2) =>
            producer(source.Clone(), p1, p2);

        public static TResult Pipe<TSource, TParam1, TParam2, TParam3, TResult>(this TSource source,
                                                                                Func<TSource, TParam1, TParam2, TParam3, TResult> producer,
                                                                                TParam1 p1,
                                                                                TParam2 p2,
                                                                                TParam3 p3) =>
            producer(source.Clone(), p1, p2, p3);

        public static async Task<TResult> PipeAsync<TSource, TResult>(this Task<TSource> source,
                                                                      Func<TSource, TResult> producer)
        {
            TSource immutableSource = await source.CloneAsync();

            return immutableSource.Pipe(producer);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TResult>(this Task<TSource> source,
                                                                               Func<TSource, TParam1, TResult> producer,
                                                                               TParam1 p1)
        {
            TSource immutableSource = await source.CloneAsync();

            return immutableSource.Pipe(producer, p1);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TParam2, TResult>(this Task<TSource> source,
                                                                                        Func<TSource, TParam1, TParam2, TResult> producer,
                                                                                        TParam1 p1,
                                                                                        TParam2 p2)
        {
            TSource immutableSource = await source.CloneAsync();

            return immutableSource.Pipe(producer, p1, p2);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TParam2, TParam3, TResult>(this Task<TSource> source,
                                                                                                 Func<TSource, TParam1, TParam2, TParam3, TResult> producer,
                                                                                                 TParam1 p1,
                                                                                                 TParam2 p2,
                                                                                                 TParam3 p3)
        {
            TSource immutableSource = await source.CloneAsync();

            return immutableSource.Pipe(producer, p1, p2, p3);
        }

        public static async Task<TResult> PipeAsync<TSource, TResult>(this TSource source,
                                                                      Func<TSource, Task<TResult>> producer)
        {
            TSource immutableSource = source.Clone();

            return await producer(immutableSource);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TResult>(this TSource source,
                                                                               Func<TSource, TParam1, Task<TResult>> producer,
                                                                               TParam1 p1)
        {
            TSource immutableSource = source.Clone();

            return await producer(immutableSource, p1);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TParam2, TResult>(this TSource source,
                                                                                        Func<TSource, TParam1, TParam2, Task<TResult>> producer,
                                                                                        TParam1 p1,
                                                                                        TParam2 p2)
        {
            TSource immutableSource = source.Clone();

            return await producer(immutableSource, p1, p2);
        }

        public static async Task<TResult> PipeAsync<TSource, TParam1, TParam2, TParam3, TResult>(this TSource source,
                                                                                                 Func<TSource, TParam1, TParam2, TParam3, Task<TResult>> producer,
                                                                                                 TParam1 p1,
                                                                                                 TParam2 p2,
                                                                                                 TParam3 p3)
        {
            TSource immutableSource = source.Clone();

            return await producer(immutableSource, p1, p2, p3);
        }
    }
}
