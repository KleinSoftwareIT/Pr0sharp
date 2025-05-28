namespace pr0sharp.Responses
{
    public class UserChangePasswordSuccessResponse
    {
        public SuccessResponse Success { get; } = new SuccessResponse();
        public UserInfoResponse UserInfo { get; set; } = null!;
    }
}
