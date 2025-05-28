using System.Text.Json.Serialization;
using pr0sharp.Enums;

namespace pr0sharp.DataTypes
{
    public class AppOwnerData
    {
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Mark")]
        public Pr0grammRanks Rank { get; set; }
    }
}
