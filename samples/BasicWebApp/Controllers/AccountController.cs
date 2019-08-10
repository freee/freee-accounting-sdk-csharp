using System.Threading.Tasks;

using Freee.Accounting;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest;

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

            var accountingClient = new AccountingClient(new TokenCredentials(accessToken));

            var user = await accountingClient.Users.GetMeAsync(companies: true);

            var deals = await accountingClient.Deals.ListAsync(user.User.Companies[0].Id, limit: 5);

            ViewBag.Deals = deals.Deals;

            return View(user.User);
        }
    }
}