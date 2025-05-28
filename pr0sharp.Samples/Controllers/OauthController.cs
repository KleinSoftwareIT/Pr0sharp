using System.Security.Claims;
using Duende.IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using pr0sharp.Samples.Configuration;

namespace pr0sharp.Samples.Controllers
{
    public class OauthController(IConfiguration configuration, ILogger<OauthController> logger) : Controller
    {
        private readonly HttpClient _httpClient = new();
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<OauthController> _logger = logger;

        [HttpGet("oauth/initiate")]
        public IActionResult Initiate()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var oauthConfiguration = new OauthConfiguration();
            var state = RandomStringHelper.CreateString(16);

            _configuration.GetSection("Pr0grammAPI").Bind(oauthConfiguration);

            var ru = new RequestUrl("https://pr0gramm.com/oauth/authorize");
            var url = ru.CreateAuthorizeUrl(
                clientId: oauthConfiguration.ClientId,
                responseType: "code",
                scope: "user.me user.name user.info inbox.post",
                redirectUri: $"http://{HttpContext.Request.Host}/oauth/process-login",
                state: state.ToString()
                );

            TempData["OauthState"] = state;

            return Redirect(url);
        }

        [HttpGet("oauth/process-login")]
        public async Task<IActionResult> ProcessRegistrationAsync(string code, string state, string userId)
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var storedState = TempData["OauthState"] as string;

            if (string.IsNullOrEmpty(state) || state != storedState)
            {
                _logger.LogError("Oauth state not matching, cancelling login process. Expected: {storedState}. Got: {state}", storedState, state);

                // We still cancel login here because even with the samples, someone tried to interfere
                return RedirectToAction("Index", "Home");
            }

            var oauthConfiguration = new OauthConfiguration();
            var codeTokenRequest = new AuthorizationCodeTokenRequest();

            _configuration.GetSection("Pr0grammAPI").Bind(oauthConfiguration);

            codeTokenRequest.Address = "https://pr0gramm.com/api/oauth/createAccessToken";
            codeTokenRequest.ClientId = oauthConfiguration.ClientId;
            codeTokenRequest.ClientSecret = oauthConfiguration.ClientSecret;
            codeTokenRequest.RedirectUri = $"http://{HttpContext.Request.Host}/oauth/process-login";
            codeTokenRequest.Resource.Add("user.me user.name user.info inbox.post");
            codeTokenRequest.Code = code;

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "pr0sharp.Samples Login");
            var response = await _httpClient.RequestAuthorizationCodeTokenAsync(codeTokenRequest);

            if (response.IsError)
            {
                _logger.LogError("Login for user {userId} failed, could not get access token. Error message: {message}", userId, response.ErrorDescription);

                return RedirectToAction("Index", "Home");
            }

            var apiClient = new Pr0grammApiClient(response.AccessToken!);
            var userNameResponse = await apiClient.GetUserNameAsync();

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, userNameResponse.Name),
                new(ClaimTypes.NameIdentifier, userId),
                new(ClaimTypes.UserData, response.AccessToken!) //For the samples we store the access token as claim. In real applications this would be stored in the database or similar
            };

            var claimsIdentity = new ClaimsIdentity(claims, "pr0sharp.Samples.Login");

            await HttpContext.SignInAsync("pr0sharp.Samples.Login", new(claimsIdentity));

            return RedirectToAction("LoginRedirect");
        }

        //Necessary workaround because immediately after returning from oauth login, the browser will not send cookies due to security reasons when cookies are configured to be same-site
        //To send cookies and be identified by the application we need to do a basic redirect
        //Further reading: https://brockallen.com/2019/01/11/same-site-cookies-asp-net-core-and-external-authentication-providers/
        [HttpGet("successful-login")]
        public IActionResult LoginRedirect() => View("Redirect");

        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("pr0sharp.Samples.Login");

            return RedirectToAction("Index", "Home");
        }
    }
}
