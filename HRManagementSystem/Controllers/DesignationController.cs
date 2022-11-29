using HRManagementSystem.Database;
using HRManagementSystem.Models;
using HRManagementSystem.Repository.IRepository;
using HRManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers {
    public class DesignationController : Controller {

        private readonly IRepository<DesignationModel> _designation;

        public DesignationController(HRDBContext db) {
            _designation = new Repository<DesignationModel>(db);
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult GetAllDesignation() {
            return Json(new { data = _designation.GetAll() });
            
        }

        public IActionResult AddDesignation([FromBody]string name) {
            _designation.Add(new DesignationModel { DesignationName = name });
            _designation.Save();
            return Ok("Designation Added Successfully");
        }
    }


}
