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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
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
            var categories = _repository.GetAll();
            return View(categories);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var category = _repository.GetAll();
            return new JsonResult(category);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Category category)
        {
            if (category is null)
            {
                return BadRequest("Category is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (category.CategoryId == 0)
            {
                _repository.Create(category);
                return new JsonResult(new { create = true, category });
            }
            else
            {
                _repository.Update(category);
                return new JsonResult(new { update = true, category});
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Category category)
        {
            _repository.Delete(category);
            return new JsonResult(new { delete = true });
        }
    }
}