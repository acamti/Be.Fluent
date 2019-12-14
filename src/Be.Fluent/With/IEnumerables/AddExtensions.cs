using Acamti.Be.Fluent.With.Generics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acamti.Be.Fluent.With.IEnumerables
{
    public static class AddExtensions
    {
        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, TTSource item)
        {
            return source
                .Clone()
                .Safe()
                .Concat(item.ToEnumerable());
        }

        public static IEnumerable<TTSource> Add<TTSource>(this IEnumerable<TTSource> source, Func<TTSource> funcOfitem)
        {
            return source
                .Clone()
                .Safe()
                .Concat(funcOfitem().ToEnumerable());
        }
    }
}
