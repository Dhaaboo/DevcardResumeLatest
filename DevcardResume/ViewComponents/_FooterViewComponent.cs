using Microsoft.AspNetCore.Mvc;

namespace DevcardResume.ViewComponents
{
    public class _FooterViewComponent : ViewComponent
    {
        public _FooterViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}
