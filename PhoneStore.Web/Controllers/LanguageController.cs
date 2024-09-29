using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace PhoneStore.Web.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            if (string.IsNullOrEmpty(culture))
            {
                return LocalRedirect(returnUrl);
            }
            CultureInfo cInfo = new CultureInfo(culture);
            CultureInfo cInfoInvarian = new CultureInfo("en-GB");
            cInfoInvarian.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            cInfoInvarian.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            cInfoInvarian.DateTimeFormat.Calendar = new GregorianCalendar();
            cInfo.DateTimeFormat.Calendar = new GregorianCalendar();
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}
