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
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository _repository;

        public PublisherController(IPublisherRepository repository)
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
            var publisher = _repository.GetAll();
            return new JsonResult(publisher);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Publisher publisher)
        {
            if (publisher is null)
            {
                return BadRequest("Publisher is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (publisher.PublisherId == 0)
            {
                _repository.Create(publisher);
                return new JsonResult(new { create = true, publisher });
            }
            else
            {
                _repository.Update(publisher);
                return new JsonResult(new { update = true, publisher });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Publisher publisher)
        {
            _repository.Delete(publisher);
            return new JsonResult(new { delete = true });
        }
    }
}