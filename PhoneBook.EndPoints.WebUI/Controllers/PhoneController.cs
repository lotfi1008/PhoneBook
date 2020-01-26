using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.EndPoints.WebUI.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}