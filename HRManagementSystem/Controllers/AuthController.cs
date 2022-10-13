using HRManagementSystem.Database;
using HRManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

public class AuthController : Controller {
    private readonly HRDBContext _db;

    public AuthController(HRDBContext db) {
        _db = db;
    }


    public IActionResult SignIn() {
        return View(new EmployeesModel());
    }

    [HttpPost]
    public IActionResult LoginEmployee(EmployeesModel employee) {
        var emp =
            _db.Employees.FirstOrDefault(e => e.Email == employee.Email);
        if (emp != null) {
            if (emp.Password == employee.Password)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("SignIn", "Auth");
        }

        return RedirectToAction("SignIn", "Auth");
    }

    public IActionResult SignUp() {
        return View(new EmployeesModel());
    }


    public IActionResult CreateEmployee([FromBody] EmployeesModel? employee) {
        if (employee != null) {
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        return RedirectToAction(nameof(SignIn));
    }
}