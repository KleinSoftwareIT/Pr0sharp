namespace pr0sharp.Responses
{
    public class UserChangePasswordResponse
    {
        public UserChangePasswordSuccessResponse SuccessResponse { get; set; } = null!;
        public UserChangePasswordErrorResponse ErrorResponse { get; set; } = null!;
    }
}
