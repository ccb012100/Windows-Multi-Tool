using System.Text.Json;

namespace WindowsMultiTool
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Get the object's representation as a human-readable string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Dump(this object obj) => ObjectDumper.Dump(obj);

        /// <summary>
        /// Get the object's representation as an indented JSON string.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToPrettyPrintJson(this object o) =>
            JsonSerializer.Serialize(o, new JsonSerializerOptions { WriteIndented = true });
    }
}