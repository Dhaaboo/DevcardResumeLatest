using Microsoft.AspNetCore.Mvc;

namespace DevcardResume.ViewComponents
{
    public class _HeaderViewComponent : ViewComponent
    {

        public _HeaderViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }

}
