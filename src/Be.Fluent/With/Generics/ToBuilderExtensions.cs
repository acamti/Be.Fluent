using Acamti.Be.Fluent.Builders.Generic;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class ToBuilderExtensions
    {
        public static GenericBuilder<T> ToBuilder<T>(this T source)
            where T : class =>
            new GenericBuilder<T>(source);

        public static GenericBuilder<T> ToEmptyBuilder<T>(this T source)
            where T : class, new() =>
            new GenericBuilder<T>(new T());
    }
}
