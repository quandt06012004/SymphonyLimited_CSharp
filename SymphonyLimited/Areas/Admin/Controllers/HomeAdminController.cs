using Microsoft.AspNetCore.Mvc;

namespace SymphonyLimited.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
