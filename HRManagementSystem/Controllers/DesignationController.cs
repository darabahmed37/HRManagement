using System.Text.Json;
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

            return View(_designation.GetAll());
        }

        public IActionResult GetAllDesignation() {
            return Json(new { data = _designation.GetAll() });
            
        }
        [HttpPost]
        public async Task<IActionResult> AddDesignation() {
            var designation =  await JsonSerializer.DeserializeAsync<DesignationModel>(Request.Body);
            _designation.Add(designation!);
            _designation.Save();
            return Ok("Designation Added Successfully");
        }


        public async Task<IActionResult> UpdateDesignation() {
            var designation = await JsonSerializer.DeserializeAsync<DesignationModel>(Request.Body);
            _designation.Update(designation!);
            _designation.Save();
            return Ok("Updated");
        }
    }


}
