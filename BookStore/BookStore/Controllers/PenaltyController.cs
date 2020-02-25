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
    public class PenaltyController : Controller
    {
        private readonly IPenaltyRepository _repository;

        public PenaltyController(IPenaltyRepository repository)
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
            var penalty = _repository.GetAll();
            return new JsonResult(penalty);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Penalty penalty)
        {
            if (penalty is null)
            {
                return BadRequest("Penalty is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (penalty.PenaltyId == 0)
            {
                _repository.Create(penalty);
                return new JsonResult(new { create = true, penalty });
            }
            else
            {
                _repository.Update(penalty);
                return new JsonResult(new { update = true, penalty });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Penalty penalty)
        {
            _repository.Delete(penalty);
            return new JsonResult(new { delete = true });
        }
    }
}