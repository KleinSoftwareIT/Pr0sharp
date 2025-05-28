using System.Text.Json.Serialization;

namespace pr0sharp.DataTypes
{
    public class AuthorizedAppScope
    {
        [JsonPropertyName("Scope")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
