using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class PayDetailController : Controller
    {
        private readonly IPayDetailRepository _repository;

        public PayDetailController(IPayDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return new JsonResult(new { done = true });
        }


        [HttpPost]
        public IActionResult GetByPayId([FromBody] PayDetail pay)
        {
            var pays = _repository.GetByPayId(pay.PayId);
            return new JsonResult(pays);
        }

        [HttpPost]
        public IActionResult Save(IEnumerable<PayDetail> pays)
        {
            try
            {
                foreach (PayDetail pay in pays)
                {
                    _repository.Create(pay);
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