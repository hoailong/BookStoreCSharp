using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.Controllers
{
    //[Route("category")]
    public class AdminController : Controller
    {
        private readonly IAccountRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;

        public AdminController(IAccountRepository repository, IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public void Index()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("/admin/login");
            }
            Response.Redirect("RentBook");
        }

        [HttpGet]
        public IActionResult Account()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("/admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            var penalties = _repository.GetAll();
            return View(penalties);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Name = HttpContext.Session.GetString("user");
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] Account account)
        {
            if (account is null)
            {
                return BadRequest("Account is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var _account = _repository.GetUser(account.Username, account.Password);
            if (_account.Count() > 0)
            {
                var acc = _account.ElementAt(0);
                var employee = _employeeRepository.GetById(acc.EmployeeId);
                UserView user = new UserView(acc.AccountId, employee.EmployeeId, employee.Fullname, acc.Role);
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }

        [HttpGet]
        public void Logout()
        {
            HttpContext.Session.Clear();
            Response.Redirect("login");
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var account = _repository.GetAll();
            return new JsonResult(account);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Account account)
        {
            if (account is null)
            {
                return BadRequest("Account is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (account.AccountId == 0)
            {
                _repository.Create(account);
                return new JsonResult(new { create = true, account });
            }
            else
            {
                _repository.Update(account);
                return new JsonResult(new { update = true, account });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Account account)
        {
            _repository.Delete(account);
            return new JsonResult(new { delete = true });
        }
    }
}