using System.Text.Json.Serialization;
using pr0sharp.Converters;
using pr0sharp.Enums;

namespace pr0sharp.DataTypes
{
    public class InvitedUser
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Mark")]
        public Pr0grammRanks Rank { get; set; }
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Created")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime RegistrationDate { get; set; }
    }
}
