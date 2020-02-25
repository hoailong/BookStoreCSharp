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
    public class RentController : Controller
    {
        private readonly IRentRepository _repository;

        public RentController(IRentRepository repository)
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
            var penalties = _repository.GetAll();
            return View(penalties);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var rent = _repository.GetAll();
            return new JsonResult(rent);
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