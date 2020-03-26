using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ActExtensions
    {
        public static TSource Act<TSource>(this TSource source, Action<TSource> action)
        {
            TSource immutableSource = source.Clone();

            action(immutableSource);

            return source;
        }

        public static TSource Act<TSource, TParam1>(this TSource source, Action<TSource, TParam1> action, TParam1 p1)
        {
            TSource immutableSource = source.Clone();

            action(immutableSource, p1);

            return source;
        }

        public static TSource Act<TSource, TParam1, TParam2>(this TSource source, Action<TSource, TParam1, TParam2> action, TParam1 p1, TParam2 p2)
        {
            TSource immutableSource = source.Clone();

            action(immutableSource, p1, p2);

            return source;
        }

        public static TSource Act<TSource, TParam1, TParam2, TParam3>(this TSource source, Action<TSource, TParam1, TParam2, TParam3> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            TSource immutableSource = source.Clone();

            action(immutableSource, p1, p2, p3);

            return source;
        }

        public static async Task<TSource> ActAsync<TSource>(this Task<TSource> source, Action<TSource> action)
        {
            TSource immutableSource = (await source).Clone();

            immutableSource.Act(action);

            return await source;
        }

        public static async Task<TSource> ActAsync<TSource>(this TSource source, Func<TSource, Task> action)
        {
            TSource immutableSource = source.Clone();

            await action(immutableSource);

            return source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1>(this TSource source, Func<TSource, TParam1, Task> action, TParam1 p1)
        {
            TSource immutableSource = source.Clone();

            await action(immutableSource, p1);

            return source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1>(this Task<TSource> source, Action<TSource, TParam1> action, TParam1 p1)
        {
            TSource immutableSource = (await source).Clone();

            immutableSource.Act(action, p1);

            return await source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1, TParam2>(this TSource source, Func<TSource, TParam1, TParam2, Task> action, TParam1 p1, TParam2 p2)
        {
            TSource immutableSource = source.Clone();

            await action(immutableSource, p1, p2);

            return source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1, TParam2>(this Task<TSource> source, Action<TSource, TParam1, TParam2> action, TParam1 p1, TParam2 p2)
        {
            TSource immutableSource = (await source).Clone();

            immutableSource.Act(action, p1, p2);

            return await source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1, TParam2, TParam3>(this TSource source, Func<TSource, TParam1, TParam2, TParam3, Task> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            TSource immutableSource = source.Clone();

            await action(immutableSource, p1, p2, p3);

            return source;
        }

        public static async Task<TSource> ActAsync<TSource, TParam1, TParam2, TParam3>(this Task<TSource> source, Action<TSource, TParam1, TParam2, TParam3> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            TSource immutableSource = (await source).Clone();

            immutableSource.Act(action, p1, p2, p3);

            return await source;
        }
    }
}
