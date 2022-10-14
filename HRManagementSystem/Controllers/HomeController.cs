using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers {
    public class HomeController : Controller {
        public IActionResult NewEmployee() {
            return View();
        }
    }
}