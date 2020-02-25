using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Interfaces;
using BookStore.Models;
using Type = BookStore.Models.Type;

namespace BookStore.Controllers
{
    //[Route("category")]
    public class TypeController : Controller
    {
        private readonly ITypeRepository _repository;

        public TypeController(ITypeRepository repository)
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
            var types = _repository.GetAll();
            return View(types);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var type = _repository.GetAll();
            return new JsonResult(type);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Type type)
        {
            if (type is null)
            {
                return BadRequest("Type is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (type.TypeId == 0)
            {
                _repository.Create(type);
                return new JsonResult(new { create = true, type });
            }
            else
            {
                _repository.Update(type);
                return new JsonResult(new { update = true, type });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Type type)
        {
            _repository.Delete(type);
            return new JsonResult(new { delete = true });
        }
    }
}