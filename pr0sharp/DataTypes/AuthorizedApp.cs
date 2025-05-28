namespace pr0sharp.DataTypes
{
    public class AuthorizedApp
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AuthorizedAppScope[] Scopes { get; set; } = null!;
        public AppOwnerData Owner { get; set; } = null!;
    }
}
