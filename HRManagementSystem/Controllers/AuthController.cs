using System.Net;
using HRManagementSystem.Database;
using HRManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using HRManagementSystem.Repository;
using HRManagementSystem.Repository.IRepository;

namespace HRManagementSystem.Controllers;

public class AuthController : Controller {
    private readonly IRepository<UsersModel> _userRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AuthController(HRDBContext db, IHttpContextAccessor accessor) {
        _userRepository = new Repository<UsersModel>(db);
        _contextAccessor = accessor;

    }


    public IActionResult SignIn() {
        return View(new UsersModel());
    }

    [HttpPost]
    public IActionResult LoginEmployee(UsersModel userParam) {

        UsersModel? user = _userRepository.GetFirstOrDefault(u => u.Email == userParam.Email && u.Password == userParam.Password);
        if (user != null) {
            _contextAccessor.HttpContext?.Session.SetInt32("ID", user.ID);
            return StatusCode((int)HttpStatusCode.OK, "Success");

            return StatusCode((int)HttpStatusCode.Unauthorized, "Invalid Password");


        }

        return StatusCode((int)HttpStatusCode.NotFound, "Invalid Email");
    }

    public IActionResult SignUp() {
        return View(new UsersModel());
    }

    [HttpPost]
    public IActionResult CreateEmployee(UsersModel usersModel) {

        UsersModel? user = _userRepository.GetFirstOrDefault(u => usersModel.Email == u.Email);
        if (user== null) {
            _userRepository.Add(usersModel);
            _userRepository.Save();
            return StatusCode((int)HttpStatusCode.OK, "Success");
        }

        return StatusCode((int)HttpStatusCode.Conflict, "Email already exists");

    }


}