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
    public class ReportController : Controller
    {
        private readonly IRentDetailRepository _rentDetaiRepository;
        private readonly IPayRepository _payRepository;
        private readonly IReportRepository _reportRepository;

        public ReportController(IRentDetailRepository rendDetailRepository, IReportRepository reportRepository, IPayRepository payRepository)
        {
            _rentDetaiRepository = rendDetailRepository;
            _reportRepository = reportRepository;
            _payRepository = payRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rentting()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            var books = _rentDetaiRepository.GetBookRentting();
            return View(books);
        }
        [HttpGet]
        public IActionResult GetRentting()
        {
            var books = _rentDetaiRepository.GetBookRentting();
            return new JsonResult(books);
        }

        public IActionResult TopRent()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            var books = _rentDetaiRepository.GetTop5();
            return View(books);
        }
        [HttpGet]
        public IActionResult GetTopRent()
        {
            var books = _rentDetaiRepository.GetTop5();
            return new JsonResult(books);
        }
        [HttpGet]
        public IActionResult GetRevenue()
        {
            if (HttpContext.Session.GetString("user") is null)
            {
                Response.Redirect("admin/login");
            }
            ViewBag.User = HttpContext.Session.GetString("user");
            return View();
        }
    }
}