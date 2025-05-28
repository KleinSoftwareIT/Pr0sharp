namespace pr0sharp.DataTypes
{
    public class ProfileBackgroundSetting
    {
        public int? Current { get; set; }
        public AvailableProfileBackgroundSetting[] Available { get; set; } = null!;
    }
}
