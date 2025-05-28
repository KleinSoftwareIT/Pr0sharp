using System.Text.Json.Serialization;

namespace pr0sharp.DataTypes
{
    public class DigestSettings
    {
        [JsonPropertyName("Daily")]
        public bool DailyDigestEnabled { get; set; }

        [JsonPropertyName("Weekly")]
        public bool WeeklyDigestEnabled { get; set; }
    }
}
