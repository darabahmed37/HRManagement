using System.Net;
using HRManagementSystem.Database;
using HRManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
namespace HRManagementSystem.Controllers;

public class AuthController : Controller {
    private readonly HRDBContext _db;

    public AuthController(HRDBContext db) {
        _db = db;
    }


    public IActionResult SignIn() {
        return View(new UsersModel());
    }

    [HttpPost]
    public IActionResult LoginEmployee(UsersModel employee) {

        var emp =
            _db.Users.FirstOrDefault(e => e.Email == employee.Email);
        if (emp != null) {
            if (emp.Password == employee.Password) {
                return RedirectToAction("NewEmployee", "Home");
            }
            return StatusCode((int)HttpStatusCode.Unauthorized, "Invalid Password");


        }

        return StatusCode((int)HttpStatusCode.NotFound, "Invalid Email");
    }

    public IActionResult SignUp() {
        return View(new UsersModel());
    }

    [HttpPost]
    public IActionResult CreateEmployee(UsersModel employee) {
        var emp = _db.Users.FirstOrDefault(e => e.Email == employee.Email);
        if (emp == null) {
            _db.Users.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("SignIn");
        }

        return StatusCode((int)HttpStatusCode.Conflict, "Email already exists");

    }


}