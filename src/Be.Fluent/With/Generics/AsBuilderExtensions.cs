using System;
using System.Threading.Tasks;
using Acamti.Be.Fluent.Builders.Generic;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class AsBuilderExtensions
    {
        public static GenericBuilder<T> AsBuilder<T>(this T source)
            where T : class =>
            new GenericBuilder<T>(source);

        public static GenericBuilder<T> AsBuilder<T>(this Func<T> getSource)
            where T : class =>
            getSource().AsBuilder();

        public static async Task<GenericBuilder<T>> AsBuilderAsync<T>(this Func<Task<T>> getSource)
            where T : class =>
            (await getSource()).AsBuilder();

        public static async Task<GenericBuilder<T>> AsBuilderAsync<T>(this Task<T> getSource)
            where T : class =>
            (await getSource).AsBuilder();
    }
}
