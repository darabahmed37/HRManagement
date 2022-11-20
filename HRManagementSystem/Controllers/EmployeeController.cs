﻿using System.Text.Json;
using System.Text.Json.Nodes;
using HRManagementSystem.Database;
using HRManagementSystem.Models;
using HRManagementSystem.Repository;
using HRManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

[Route("Dashboard")]
public class EmployeeController : Controller {
    private readonly IRepository<EmployeeModel> _emp;


    public EmployeeController(HRDBContext db) {
        _emp = new Repository<EmployeeModel>(db);
    }

    [Route("index")]
    public IActionResult Index() {
        return View();
    }

    [HttpGet]
    public IActionResult GetEmployeeById([FromQuery] int id) {
        var emp = _emp.GetFirstOrDefault(e => e.Code == id);
        if (emp == null) return NotFound();
        return Ok(emp);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddEmployee() {
        var emp = await JsonSerializer.DeserializeAsync<EmployeeModel>(Request.Body);
        if (emp == null) return BadRequest(Request.Body);
        _emp.Add(emp);
        _emp.Save();
        return Ok(emp);
    }

    [HttpPatch("update")]
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