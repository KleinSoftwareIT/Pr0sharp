using System.Net.Http.Json;
using pr0sharp.Requests;
using pr0sharp.Responses;

namespace pr0sharp
{
    public class Pr0grammApiClient
    {
        private readonly HttpClient _httpClient;

        public Pr0grammApiClient(string accessToken, string baseAddress = "https://pr0gramm.com/api/")
        {
            _httpClient = new()
            {
                BaseAddress = new(baseAddress),
            };

            _httpClient.DefaultRequestHeaders.Add("User-Agent", $"keyb0x.Pr0grammApi/{ThisAssembly.AssemblyInformationalVersion}");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }

        public async Task<UserMeResponse> GetUserMeAsync() => (await _httpClient.GetFromJsonAsync<UserMeResponse>("user/me"))!;
        public async Task<UserInfoResponse> GetUserInfoAsync() => (await _httpClient.GetFromJsonAsync<UserInfoResponse>("user/info"))!;

        public async Task<UserNameResponse> GetUserNameAsync() => (await _httpClient.GetFromJsonAsync<UserNameResponse>("user/name"))!;

        public async Task<UserChangePasswordResponse> ChangeUserPasswordAsync(UserChangePasswordRequest request)
        {
            var content = new FormUrlEncodedContent(
                [
                    new("password", request.NewPassword),
                    new("currentPassword", request.CurrentPassword)
                ]);

            var response = await _httpClient.PostAsync("user/changePassword", content);

            return (await response.Content.ReadFromJsonAsync<UserChangePasswordResponse>())!;
        }
    }
}
