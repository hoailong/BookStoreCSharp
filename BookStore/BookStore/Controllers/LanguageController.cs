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
    public class LanguageController : Controller
    {
        private readonly ILanguageRepository _repository;

        public LanguageController(ILanguageRepository repository)
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
            var languages = _repository.GetAll();
            return View(languages);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var language = _repository.GetAll();
            return new JsonResult(language);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Language language)
        {
            if (language is null)
            {
                return BadRequest("Language is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (language.LangId == 0)
            {
                _repository.Create(language);
                return new JsonResult(new { create = true, language });
            }
            else
            {
                _repository.Update(language);
                return new JsonResult(new { update = true, language });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Language language)
        {
            _repository.Delete(language);
            return new JsonResult(new { delete = true });
        }
    }
}