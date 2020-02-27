using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Acamti.Be.Fluent.Builders.Generic
{
    public interface IGenericBuilder<T>
        where T : class
    {
        List<Operation<T>> Patches { get; set; }
        T Build();
        void Reset();
    }
}
