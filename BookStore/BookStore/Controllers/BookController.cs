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
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
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
            var books = _repository.GetAll();
            return View(books);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var book = _repository.GetAll();
            return new JsonResult(book);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Book book)
        {
            if (book is null)
            {
                return BadRequest("Book is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (book.BookId == 0)
            {
                _repository.Create(book);
                return new JsonResult(new { create = true, book });
            }
            else
            {
                _repository.Update(book);
                return new JsonResult(new { update = true, book });
            }
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Book book)
        {
            _repository.Delete(book);
            return new JsonResult(new { delete = true });
        }

        [HttpPost]
        public IActionResult AddQuantity(IEnumerable<Book> books)
        {
            try
            {
                foreach (Book book in books)
                {
                    _repository.AddQuantity(book.BookId);
                }
                return new JsonResult(new { done = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { done = false, error = ex });
            }
        }

        [HttpPost]
        public IActionResult SubQuantity(IEnumerable<Book> books)
        {
            try
            {
                foreach (Book book in books)
                {
                    _repository.SubQuantity(book.BookId);
                }
                return new JsonResult(new { done = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { done = false, error = ex });
            }
        }
    }
}