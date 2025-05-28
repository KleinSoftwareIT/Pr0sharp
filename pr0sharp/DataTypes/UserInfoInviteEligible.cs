using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class UserInfoInviteEligible
    {
        public bool CanInvite { get; set; }
        public CurrentAndMaxRequirement CurrentInvites { get; set; } = null!;
        public CurrentAndRequiredRequirement TotalComments { get; set; } = null!;
        public CurrentAndRequiredRequirement TotalUploads { get; set; } = null!;
        public CurrentAndRequiredRequirement CommentsWindow180 { get; set; } = null!;
        public CurrentAndRequiredRequirement UploadsWindow180 { get; set; } = null!;
        public CurrentAndRequiredRequirement Score { get; set; } = null!;

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime NextRoundDate { get; set; }
    }
}
