using System.Collections.Generic;
using Acamti.Be.Fluent.With.Generics;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Serialization;

namespace Acamti.Be.Fluent.Builders.Generic
{
    public class GenericBuilder<T> : IGenericBuilder<T>
        where T : class
    {
        private T Model { get; }
        private IGenericBuilder<T> ThisInterface => this;

        List<Operation<T>> IGenericBuilder<T>.Patches { get; set; }

        public GenericBuilder(T model)
        {
            Model = model;
            ThisInterface.Patches = new List<Operation<T>>();
        }

        public T Build()
        {
            T buildingBlocks = Model.Clone();

            new JsonPatchDocument<T>(ThisInterface.Patches, new DefaultContractResolver()).ApplyTo(buildingBlocks);

            return buildingBlocks;
        }

        public void Reset()
        {
            ThisInterface.Patches.Clear();
        }
    }
}
