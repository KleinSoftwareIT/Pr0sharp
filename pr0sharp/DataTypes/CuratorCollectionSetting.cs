using pr0sharp.Enums;

namespace pr0sharp.DataTypes
{
    public class CuratorCollectionSetting
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public int OwnerMark { get; set; }
        public string Slug { get; set; } = string.Empty;
        public CurationInviteStatus Accepted { get; set; }
    }
}
