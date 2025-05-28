using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pr0sharp.Samples.Controllers
{
    [Authorize]
    public class SamplesController : Controller
    {
        [HttpGet("samples/GetUserName")]
        public async Task<IActionResult> GetUsernameAsync()
        {
            var accessToken = User.FindFirstValue(ClaimTypes.UserData)!;
            var apiClient = new Pr0grammApiClient(accessToken);

            return View(await apiClient.GetUserNameAsync());
        }

        [HttpGet("samples/GetUserMe")]
        public async Task<IActionResult> GetUserMeAsync()
        {
            var accessToken = User.FindFirstValue(ClaimTypes.UserData)!;
            var apiClient = new Pr0grammApiClient(accessToken);

            return View(await apiClient.GetUserMeAsync());
        }

        [HttpGet("samples/GetUserInfo")]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            var accessToken = User.FindFirstValue(ClaimTypes.UserData)!;
            var apiClient = new Pr0grammApiClient(accessToken);

            return View(await apiClient.GetUserInfoAsync());
        }
    }
}
