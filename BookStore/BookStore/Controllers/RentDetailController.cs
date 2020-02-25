using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class RentDetailController : Controller
    {
        private readonly IRentDetailRepository _repository;

        public RentDetailController(IRentDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return new JsonResult(new { done = true });
        }

        [HttpGet]
        public IActionResult GetBookRentting()
        {
            var books = _repository.GetBookRentting();
            return new JsonResult(books);
        }

        [HttpGet]
        public IActionResult GetTop5()
        {
            var books = _repository.GetTop5();
            return new JsonResult(books);
        }

        [HttpPost]
        public IActionResult Save(IEnumerable<RentDetail> rents)
        {
            try
            {
                foreach (RentDetail rent in rents)
                {
                    _repository.Create(rent);
                }
                return new JsonResult(new { done = true });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { done = false, error = ex });
            }
        }

        [HttpPost]
        public IActionResult UpdatePayed(IEnumerable<RentDetail> rents)
        {
            try
            {
                foreach (RentDetail rent in rents)
                {
                    _repository.UpdatePayed(rent.BookId, rent.RentId);
                }
                return new JsonResult(new { done = true });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { done = false, error = ex });
            }
        }


        [HttpPost]
        public IActionResult GetByRentId([FromBody] RentDetail rent)
        {
            var rents = _repository.GetByRentId(rent.RentId);
            return new JsonResult(rents);
        }
    }
}