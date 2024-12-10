using Microsoft.AspNetCore.Mvc;

namespace SymphonyLimited.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
