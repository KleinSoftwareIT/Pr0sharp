using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class InvitedUser
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Mark { get; set; }
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Created")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime RegistrationDate { get; set; }
    }
}
