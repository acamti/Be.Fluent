using System.Text.Json;
using System.Threading.Tasks;

namespace Acamti.Be.Fluent.With.Generics
{
    public static class CloneExtensions
    {
        public static TObject Clone<TObject>(this TObject obj) =>
            JsonSerializer.Deserialize<TObject>(JsonSerializer.Serialize(obj));

        public static async Task<TObject> CloneAsync<TObject>(this Task<TObject> obj) =>
            JsonSerializer.Deserialize<TObject>(JsonSerializer.Serialize(await obj));
    }
}
