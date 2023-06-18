

using Microsoft.AspNetCore.Localization;

namespace Web.ERP.Controllers
{
    public class LanguagesController : Controller
    {
        [HttpPost]//methode of select language //culture is selected language // returnUrl when we reload page 
        public IActionResult SelectLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires=DateTimeOffset.UtcNow.AddYears(1)});
            return LocalRedirect(returnUrl);
        }
    }
}

