using System.Text.Json.Serialization;

namespace pr0sharp.DataTypes
{
    public class ProfileBackgroundSetting
    {
        public int? Current { get; set; }

        [JsonPropertyName("Available")]
        public AvailableProfileBackgroundSetting[] AvailableBackgrounds { get; set; } = null!;
    }
}
