using System.Text.Json;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class CloneExtensions
    {
        public static TObject Clone<TObject>(this TObject obj) =>
            JsonSerializer.Deserialize<TObject>(JsonSerializer.Serialize(obj));
    }
}
