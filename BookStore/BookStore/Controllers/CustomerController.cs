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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
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
            var customers = _repository.GetAll();
            return View(customers);
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var customer = _repository.GetAll();
            return new JsonResult(customer);
        }

        [HttpPost]
        public IActionResult Save([FromBody] Customer customer)
        {
            if (customer is null)
            {
                return BadRequest("Customer is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (customer.CustomerId == 0)
            {
                var customerByPhone = _repository.getWithCustomerPhone(customer.CustomerPhone);
                if(customerByPhone is null)
                {
                    _repository.Create(customer);
                    return new JsonResult(new { create = true, customer });
                } else {
                    return new JsonResult(new { error = "Số điện thoại đã tồn tại" });
                }
            }
            else
            {
                var customerById = _repository.GetById(customer.CustomerId);
                var customerByPhone = _repository.getWithCustomerPhone(customer.CustomerPhone);
                if (customerByPhone is null || customerByPhone.CustomerPhone == customerById.CustomerPhone)
                {
                    _repository.Update(customer);
                    return new JsonResult(new { update = true, customer });
                }
                else
                {
                    return new JsonResult(new { error = "Số điện thoại đã tồn tại" });
                }
            }
        }

        [HttpPost]
        public IActionResult GetByPhone([FromBody] Customer customer)
        {
            var customerByPhone = _repository.getWithCustomerPhone(customer.CustomerPhone);
            return new JsonResult(customerByPhone);
        }

        [HttpPost]
        public IActionResult GetById([FromBody] Customer customer)
        {
            var customerById = _repository.getWithCustomerId(customer.CustomerId);
            return new JsonResult(customerById);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Customer customer)
        {
            _repository.Delete(customer);
            return new JsonResult(new { delete = true });
        }
    }
}