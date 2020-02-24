using System;
using System.Collections.Generic;
using System.Linq;
using Acamti.Be.Fluent.With.Generics;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class AddExtensions
    {
        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, TTSource item) =>
            source
                .Safe()
                .Concat(item.ToEnumerable());

        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, Func<TTSource> funcOfItem) =>
            source
                .Safe()
                .Concat(funcOfItem().ToEnumerable());
    }
}
