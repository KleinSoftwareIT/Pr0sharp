using System.Text.Json;
using System.Text.Json.Serialization;

namespace pr0sharp.Converters
{
    public class UnixTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number)
                throw new Exception($"Token type not matching. Expected token type 'Number', but got '{reader.TokenType}'");

            return DateTimeOffset.FromUnixTimeSeconds(reader.TryGetInt64(out var timestamp) ? timestamp : DateTimeOffset.UnixEpoch.UtcTicks).DateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteNumberValue(value.Ticks);
    }
}
