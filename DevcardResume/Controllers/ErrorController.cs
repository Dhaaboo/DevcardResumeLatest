using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevcardResume.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage =
                            "Sorry, 404 requested could not be found";
                    ViewBag.Path = statusCodeResult.OriginalPath.ToString();
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;
            }

            return View("NotFound");
        }
    }
}
