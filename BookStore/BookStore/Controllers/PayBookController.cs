using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Interfaces;
using BookStore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class PayBookController : Controller
    {
        private readonly IPayRepository _repository;

        public PayBookController(IPayRepository repository)
        {
            _repository = repository;
        }
        // GET: /<controller>/
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
            var pays = _repository.GetAll();
            return new JsonResult(pays);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Pay pay)
        {
            if (pay is null)
            {
                return BadRequest("Pay is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (pay.PayId == 0)
            {
                _repository.Create(pay);
                return new JsonResult(new { create = true, pay });
            }
            else
            {
                _repository.Update(pay);
                return new JsonResult(new { update = true, pay });
            }
        }
    }
}
