using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class WithValueExtensions
    {
        public static async Task<TProp> WithValueAsync<TModel, TProp>(this Task<TModel> source,
                                                                      Expression<Func<TModel, TProp>> prop) =>
            prop.Compile()(await source);

        public static async Task<TProp> WithValueAsync<TModel, TProp>(this Func<Task<TModel>> source,
                                                                      Expression<Func<TModel, TProp>> prop) =>
            prop.Compile()(await source());
    }
}
