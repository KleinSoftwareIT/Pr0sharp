using System.Text.Json.Serialization;
using pr0sharp.Converters;
using pr0sharp.DataTypes;

namespace pr0sharp.Responses
{
    public class UserInfoResponse
    {
        [JsonPropertyName("Account")]
        public AccountInfo AccountInfo { get; set; } = null!;

        [JsonPropertyName("Invited")]
        public ICollection<InvitedUser> InvitedUsers { get; set; } = null!;
        public int InvitesDetached { get; set; }
        public int InvitesRemaining { get; set; }

        [JsonPropertyName("Payments")]
        public int NumberOfPayments { get; set; }
        public ICollection<CuratorCollectionSetting> CuratorCollections { get; set; } = null!;
        public ICollection<AuthorizedApp> AuthorizedApps { get; set; } = null!;
        public ICollection<PromotedApp> PromotedApps { get; set; } = null!;

        [JsonPropertyName("Digests")]
        public DigestSettings DigestsSettings { get; set; } = null!;

        [JsonPropertyName("EnableEmailNotifications")]
        public bool EmailNotificationsEnabled { get; set; }

        [JsonPropertyName("Backgrounds")]
        public ProfileBackgroundSetting ProfileBackgroundSettings { get; set; } = null!;
        public bool CanChangeName { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        [JsonPropertyName("NameLastChanged")]
        public DateTime LastNameChangeDate { get; set; }

        [JsonPropertyName("InviteEligible")]
        public UserInfoInvite UserInviteEligibilityData { get; set; } = null!;

        [JsonPropertyName("InviteEligibilityData")]
        public UserInfoInviteEligible GeneralInviteEligibilityData { get; set; } = null!;
    }
}
