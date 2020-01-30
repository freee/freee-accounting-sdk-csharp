using System.Threading.Tasks;

using Freee.Accounting.Api;
using Freee.Accounting.Client;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }

        public IActionResult Logout(string returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties { RedirectUri = returnUrl }, CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var config = new Configuration
            {
                AccessToken = accessToken
            };

            var usersApi = new UsersApi(config);
            var dealsApi = new DealsApi(config);

            var user = await usersApi.GetUsersMeAsync(companies: true);
            var deals = await dealsApi.GetDealsAsync(user.User.Companies[0].Id, limit: 5);

            ViewBag.Deals = deals.Deals;

            return View(user.User);
        }
    }
}