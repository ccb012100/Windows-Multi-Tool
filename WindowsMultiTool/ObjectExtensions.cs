using System.Text.Json;

namespace WindowsMultiTool
{
    internal static class ObjectExtensions
    {
        public static string Dump(this object o) => ObjectDumper.Dump(o);

        public static string ToPrettyPrintJson(this object o) =>
            JsonSerializer.Serialize(o, new JsonSerializerOptions { WriteIndented = true });
    }
}
