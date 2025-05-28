using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class AvailableProfileBackgroundSetting
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonConverter(typeof(BoolConverter))]
        public bool IsCommon { get; set; }
        public string SmallImageUrl { get; set; } = string.Empty;
    }
}
