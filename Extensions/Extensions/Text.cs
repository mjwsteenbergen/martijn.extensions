using System;
using System.Text;
using System.Text.Json;

namespace Martijn.Extensions.Text
{
    public static class TextExtensions
    {
        public static void Print(this object obj)
        {
            Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
        }

        public static string Repeat(this string text, int amount) {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < amount; i++)
            {
                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}