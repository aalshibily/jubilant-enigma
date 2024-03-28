using Aegis.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aegis.Core.Extensions
{
    public class JokeTypeConverter : JsonConverter<JokeType>
    {
        public override JokeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            return value switch
            {
                "random" => JokeType.Random,
                "general" => JokeType.General,
                "knock-knock" => JokeType.Knock_knock,
                "programming" => JokeType.Programming,
                _ => throw new JsonException($"Unknown joke type: {value}")
            };
        }

        public override void Write(Utf8JsonWriter writer, JokeType value, JsonSerializerOptions options)
        {
            var stringValue = value switch
            {
                JokeType.Random => "random",
                JokeType.General => "general",
                JokeType.Knock_knock => "knock-knock",
                JokeType.Programming => "programming",
                _ => throw new JsonException($"Unknown joke type: {value}")
            };

            writer.WriteStringValue(stringValue);
        }
    }
}
