using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Test test = new Test(1005, "Phan Van hoai", 20);
            var tests = new List<Test>();
            tests.Add(new Test(1005, "Phan Van Hoai", 20));
            tests.Add(new Test(1006, "Phan Van Linh", 19));
            tests.Add(new Test(1007, "Phan Thi Ha", 25));
            //ViewBag.test = test;
            return View(tests);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult LoadData()
        {
            var listCategory = new List<Category>();
            listCategory.Add(new Category()
            {
                CategoryId = 1000,
                CategoryName = "Doraemon",
                CategoryCode = "doraemon"
            });
            listCategory.Add(new Category()
            {
                CategoryId = 1001,
                CategoryName = "Conan",
                CategoryCode = "conan"
            });
            return new JsonResult(listCategory);
        }

        [HttpPost]
        public IActionResult SetData([FromBody] Test test)
        {
            
            return new JsonResult("ok");
        }

    }
}
