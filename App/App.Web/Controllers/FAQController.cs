using App.Web.Models;
using App.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class FAQController : Controller
    {

        private readonly IFAQRepository _FAQRepository;

        public FAQController(IFAQRepository FAQRepository)
        {
            _FAQRepository = FAQRepository;
        }

        public IActionResult List()
        {
            var FAQListViewModel = new FAQListViewModel(_FAQRepository.GetAll);
            return View(FAQListViewModel);
        }
    }
}
