namespace pr0sharp.DataTypes
{
    public class PromotedApp
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public AppOwnerData Owner { get; set; } = null!;
    }
}
