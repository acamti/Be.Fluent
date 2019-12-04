using System;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ActExtensions
    {

        public static TSource Act<TSource>(this TSource source, Action<TSource> action)
        {
            action.Invoke(source);

            return source;
        }

        public static async Task<TSource> Act<TSource>(this TSource source, Func<TSource, Task> action)
        {
            await action.Invoke(source);

            return source;
        }

        public static TSource Act<TSource, TParam1>(this TSource source, Action<TSource, TParam1> action, TParam1 p1)
        {
            action.Invoke(source, p1);

            return source;
        }

        public static async Task<TSource> Act<TSource, TParam1>(this TSource source, Func<TSource, TParam1, Task> action, TParam1 p1)
        {
            await action.Invoke(source, p1);

            return source;
        }

        public static TSource Act<TSource, TParam1, TParam2>(this TSource source, Action<TSource, TParam1, TParam2> action, TParam1 p1, TParam2 p2)
        {
            action.Invoke(source, p1, p2);

            return source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2>(this TSource source, Func<TSource, TParam1, TParam2, Task> action, TParam1 p1, TParam2 p2)
        {
            await action.Invoke(source, p1, p2);

            return source;
        }

        public static TSource Act<TSource, TParam1, TParam2, TParam3>(this TSource source, Action<TSource, TParam1, TParam2, TParam3> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            action.Invoke(source, p1, p2, p3);

            return source;
        }

        public static async Task<TSource> Act<TSource, TParam1, TParam2, TParam3>(this TSource source, Func<TSource, TParam1, TParam2, TParam3, Task> action, TParam1 p1, TParam2 p2, TParam3 p3)
        {
            await action.Invoke(source, p1, p2, p3);

            return source;
        }
    }
}
