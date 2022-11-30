using System.Diagnostics;
using System.Text.Json;
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
    private readonly IRepository<DesignationModel> _designation;


    public EmployeeController(HRDBContext db) {
        _emp = new Repository<EmployeeModel>(db);
        _designation = new Repository<DesignationModel>(db);
    }

    [Route("index")]
    public IActionResult Index() {
        ViewData["Designation"] = _designation.GetAll();
    
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

        try {

            var emp = await JsonSerializer.DeserializeAsync<EmployeeModel>(Request.Body);
            if (emp != null && emp.Name != "") {
                _emp.Add(emp);
                _emp.Save();
            }
        } catch (Exception e) {
            return BadRequest();
        }

        return Ok("Employee Added");
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdateEmployee() {

        try {
            var emp = await JsonSerializer.DeserializeAsync<EmployeeModel>(Request.Body);

            _emp.Update(emp);
            _emp.Save();
        } catch (Exception e) {
            return BadRequest();
        }

        return Ok();


    }

    [HttpDelete]
    public IActionResult DeleteEmployeeById([FromQuery] int id) {
        var emp = _emp.GetFirstOrDefault(e => e.Code == id);
        if (emp == null) return NotFound();
        _emp.Remove(emp);
        _emp.Save();
        return Ok();
    }





}