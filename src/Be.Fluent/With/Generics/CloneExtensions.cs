using System.Text.Json;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class CloneExtensions
    {
        public static TObject Clone<TObject>(this TObject obj)
            where TObject: new()
        {
            return JsonSerializer
                .Serialize(obj)
                .Map(jsonString => JsonSerializer.Deserialize<TObject>(jsonString));
        }
    }
}
