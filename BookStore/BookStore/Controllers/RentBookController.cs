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
    public class RentBookController : Controller
    {
        private readonly IRentRepository _repository;

        public RentBookController(IRentRepository repository)
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
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("/admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var rents = _repository.GetAll();
            return new JsonResult(rents);
        }

        [HttpPost]
        public IActionResult GetByCustomer([FromBody] Rent rent)
        {
            var rents = _repository.GetByCustomerId(rent.CustomerId);
            return new JsonResult(rents);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Rent rent)
        {
            if (rent is null)
            {
                return BadRequest("Rent is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (rent.RentId == 0)
            {
                _repository.Create(rent);
                return new JsonResult(new { create = true, rent });
            }
            else
            {
                _repository.Update(rent);
                return new JsonResult(new { update = true, rent });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Rent rent)
        {
            _repository.Delete(rent);
            return new JsonResult(new { delete = true });
        }
    }
}