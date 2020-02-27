using System;
using System.Threading.Tasks;
using Acamti.Be.Fluent.Builders.Generic;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ToBuilderExtensions
    {
        public static GenericBuilder<T> ToBuilder<T>(this T source)
            where T : class =>
            new GenericBuilder<T>(source);

        public static GenericBuilder<T> ToBuilder<T>(this Func<T> getSource)
            where T : class =>
            getSource().ToBuilder();

        public static async Task<GenericBuilder<T>> ToBuilderAsync<T>(this Func<Task<T>> getSource)
            where T : class =>
            (await getSource()).ToBuilder();
    }
}
