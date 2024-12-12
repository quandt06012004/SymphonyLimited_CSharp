using Data_DAL;
using Microsoft.AspNetCore.Mvc;
using Services.IRepositoryMain;

namespace SymphonyLimited.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository) 
        {
            this._contactRepository = contactRepository;
        }
        public async Task<IActionResult> Index()
        {
            var listContact = await this._contactRepository.GetAllOf();
           return View(listContact);
        }
    }
}
