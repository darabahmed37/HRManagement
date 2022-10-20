using HRManagementSystem.Database;
using HRManagementSystem.Models;
using HRManagementSystem.Repository;
using HRManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

[Route("Dashboard/Employee")]
public class EmployeeController : Controller {
    private readonly IRepository<EmployeeModel> _emp;


    public EmployeeController(HRDBContext db) {
        _emp = new Repository<EmployeeModel>(db);
    }

    public IActionResult ViewEmp() {
        return View();
    }
    [HttpGet]
    [Route("/{id?}")]
    public IActionResult GetEmployeeById(int id) {
        var emp = _emp.GetFirstOrDefault(e => e.Code == id);
        return Json(emp);
    }
    [HttpPost]
    public IActionResult AddEmployee(EmployeeModel employee) {
        var findEmp = _emp.GetFirstOrDefault(e => e.Code == employee.Code);
        if (findEmp == null) {
            _emp.Add(employee);
            _emp.Save();
            return StatusCode(201, "Employee Added Successfully");

        }
        ModelState.AddModelError("Email", "Email already exists");
        return StatusCode(400, ModelState);
    }

    [Route("/{id?}")]
    [HttpPatch]
    public IActionResult UpdateEmployee(int id, EmployeeModel model) {
        var emp = _emp.GetFirstOrDefault(x => x.Code == id);
        if (emp == null) {
            ModelState.AddModelError("ID", "No Employee Exists with this ID");
            return BadRequest(ModelState);
        }
        _emp.Update(model);
        _emp.Save();
        return Json(_emp.GetFirstOrDefault(x => x.Code == id));
    }
}