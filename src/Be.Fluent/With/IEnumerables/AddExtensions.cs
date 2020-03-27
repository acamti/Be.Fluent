using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acamti.Be.Fluent.With.Generics;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class AddExtensions
    {
        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, TTSource item) =>
            source.Concat(item.ToEnumerable());

        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, Func<TTSource> funcOfItem) =>
            source.Concat(funcOfItem().ToEnumerable());

        public static async Task<IEnumerable<TTSource>> AddAsync<TTSource>(this Task<IEnumerable<TTSource>> source, TTSource item) =>
            (await source).Concat(item.ToEnumerable());

        public static async Task<IEnumerable<TTSource>> AddAsync<TTSource>(this Task<IEnumerable<TTSource>> source, Func<TTSource> funcOfItem) =>
            (await source).Concat(funcOfItem().ToEnumerable());
    }
}
