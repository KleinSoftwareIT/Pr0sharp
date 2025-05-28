using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class UserInfoInvite
    {
        public int CurrentInvites { get; set; }
        public bool InvitesForbidden { get; set; }
        public int Comments { get; set; }
        public int Uploads { get; set; }
        public int Comments180 { get; set; }
        public int Uploads180 { get; set; }
        public int Votes { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("Age")]
        public bool MinimumAccountAgeReached { get; set; }
    }
}
