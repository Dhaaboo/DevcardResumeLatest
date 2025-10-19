using Microsoft.AspNetCore.Mvc;

namespace DevcardResume.ViewComponents
{
    public class _ConfigStyleViewComponent : ViewComponent
    {
        public _ConfigStyleViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
