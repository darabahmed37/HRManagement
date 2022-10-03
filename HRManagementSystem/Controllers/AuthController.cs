using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.Models;
using HRManagementSystem.Database;

namespace HRManagementSystem.Controllers {
    public class AuthController : Controller {
        private readonly HRDBContext _db;

        public AuthController(HRDBContext db) {
            _db = db;
        }


        public IActionResult SignIn() {
            return View(new EmployeesModel());
        }

        public IActionResult LoginEmployee(EmployeesModel employee) {
            var emp =
                _db.Employees.Where(e => e.Email == employee.Email).FirstOrDefault();
            if (emp != null) {
                if (emp.Password == employee.Password) {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    return RedirectToAction("SignIn", "Auth");
                }
            }
            else {
                return RedirectToAction("SignIn", "Auth");
            }
        }

        public IActionResult SignUp() {
            return View(new EmployeesModel());
        }


        public IActionResult CreateEmployee(EmployeesModel employee) {
            _db.Employees.Add(employee);
            _db.SaveChanges();


            return RedirectToAction(nameof(SignIn));
        }
    }
}