using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers {
    public class HomeController : Controller {
        public IActionResult Dashboard() {
            return View();
        }
    }

    
}