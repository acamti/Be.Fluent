using Acamti.Be.Fluent.With.Generics;
using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Tasks
{
    public static class ActExtensions
    {

        public static async Task<TSource> Act<TSource>(this Task<TSource> source, Action<TSource> action)
        {
            (await source).Act(action);

            return await source;
        }

        public static async Task<TSource> Act<TSource>(this Task<TSource> source, Func<TSource, Task> action)
        {
            await (await source).Act(action);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1>(this Task<TSource> source, Action<TSource, TParam1> action, TParam1 p1)
        {
            (await source).Act(action, p1);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1>(this Task<TSource> source, Func<TSource, TParam1, Task> action, TParam1 p1)
        {
            await (await source).Act(action, p1);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2>(this Task<TSource> source, Action<TSource, TParam1, TParam2> action, TParam1 p1, TParam2 p2)
        {
            (await source).Act(action, p1, p2);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2>(this Task<TSource> source, Func<TSource, TParam1, TParam2, Task> action, TParam1 p1, TParam2 p2)
        {
            await (await source).Act(action, p1, p2);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2, TParam3>(this Task<TSource> source, Action<TSource, TParam1, TParam2, TParam3> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            (await source).Act(action, p1, p2, p3);

            return await source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2, TParam3>(this Task<TSource> source, Func<TSource, TParam1, TParam2, TParam3, Task> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            await (await source).Act(action, p1, p2, p3);

            return await source;
        }
    }
}
