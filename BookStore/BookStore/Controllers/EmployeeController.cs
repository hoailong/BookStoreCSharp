using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.Controllers
{
    //[Route("category")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("/admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            var employees = _repository.GetAll();
            return View(employees);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var employee = _repository.GetAll();
            return new JsonResult(employee);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Employee employee)
        {
            if (employee is null)
            {
                return BadRequest("Employee is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (employee.EmployeeId == 0)
            {
                _repository.Create(employee);
                return new JsonResult(new { create = true, employee });
            }
            else
            {
                _repository.Update(employee);
                return new JsonResult(new { update = true, employee });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Employee employee)
        {
            _repository.Delete(employee);
            return new JsonResult(new { delete = true });
        }
    }
}