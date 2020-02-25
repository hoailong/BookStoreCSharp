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
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
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
            var author = _repository.GetAll();
            return new JsonResult(author);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Author author)
        {
            if (author is null)
            {
                return BadRequest("Author is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (author.AuthorId == 0)
            {
                _repository.Create(author);
                return new JsonResult(new { create = true, author });
            }
            else
            {
                _repository.Update(author);
                return new JsonResult(new { update = true, author });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Author author)
        {
            _repository.Delete(author);
            return new JsonResult(new { delete = true });
        }
    }
}