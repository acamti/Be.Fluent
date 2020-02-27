using System;
using System.Linq.Expressions;
using System.Reflection;
using Acamti.Be.Fluent.Builders.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace Acamti.Be.Fluent.With.GenericBuilder
{
    public static class WithValueExtensions
    {
        public static GenericBuilder<T> WithValue<T, TValue>(
            this GenericBuilder<T> builder,
            Expression<Func<T, TValue>> property,
            TValue value
        ) where T : class
        {
            if (!IsValidProperty(property)) return builder;

            var doc = new JsonPatchDocument<T>();
            doc.Replace(property, value);

            (builder as IGenericBuilder<T>)
                .Patches
                .AddRange(doc.Operations);

            return builder;
        }

        private static bool IsValidProperty<T, TProp>(Expression<Func<T, TProp>> memberLambda)
        {
            var memberSelectorExpression = memberLambda.Body as MemberExpression;

            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null) return true;
            }

            return false;
        }
    }
}
