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
    public class ShiftController : Controller
    {
        private readonly IShiftRepository _repository;

        public ShiftController(IShiftRepository repository)
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
            var shifts = _repository.GetAll();
            return View(shifts);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var shift = _repository.GetAll();
            return new JsonResult(shift);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Shift shift)
        {
            if (shift is null)
            {
                return BadRequest("Shift is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (shift.ShiftId == 0)
            {
                _repository.Create(shift);
                return new JsonResult(new { create = true, shift });
            }
            else
            {
                _repository.Update(shift);
                return new JsonResult(new { update = true, shift });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Shift shift)
        {
            _repository.Delete(shift);
            return new JsonResult(new { delete = true });
        }
    }
}