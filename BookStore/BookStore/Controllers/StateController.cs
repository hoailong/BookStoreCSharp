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
    public class StateController : Controller
    {
        private readonly IStateRepository _repository;

        public StateController(IStateRepository repository)
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
            var states = _repository.GetAll();
            return View(states);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var state = _repository.GetAll();
            return new JsonResult(state);
        }

        [HttpPost]
        public IActionResult Save([FromBody] State state)
        {
            if (state is null)
            {
                return BadRequest("State is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (state.StateId == 0)
            {
                _repository.Create(state);
                return new JsonResult(new { create = true, state });
            }
            else
            {
                _repository.Update(state);
                return new JsonResult(new { update = true, state });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] State state)
        {
            _repository.Delete(state);
            return new JsonResult(new { delete = true });
        }
    }
}