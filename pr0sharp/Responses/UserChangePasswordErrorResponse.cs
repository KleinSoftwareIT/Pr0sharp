using pr0sharp.Enums;

namespace pr0sharp.Responses
{
    public class UserChangePasswordErrorResponse
    {
        public ErrorResponse ErrorResponse { get; set; } = new ErrorResponse();
        public ChangePasswordError Error { get; set; }
    }
}
