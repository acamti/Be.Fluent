using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class GetValueExtensions
    {
        public static async Task<TProp> GetValueAsync<TModel, TProp>(this Task<TModel> source,
                                                                     Expression<Func<TModel, TProp>> prop) =>
            prop.Compile()
                .Invoke(await source);

        public static async Task<TProp> GetValueAsync<TModel, TProp>(this Func<Task<TModel>> source,
                                                                     Expression<Func<TModel, TProp>> prop) =>
            prop.Compile()
                .Invoke(await source());
    }
}
