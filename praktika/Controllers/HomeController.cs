using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using praktika.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace praktika.Controllers
{
    public class HomeController : Controller
    {              

        private course_workContext db;
        public HomeController(course_workContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            //return Content(Worker.);
            return View();
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.Workers.ToListAsync());
        //}
        
        public IActionResult CreateApplication()
        {
            //return View();
            return RedirectToAction("Create", "ApplicationForVacations");
        }

        public IActionResult ViewingVacations()
        {
            //return View();
            return RedirectToAction("Index", "Vacations");
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Worker worker)
        //{
        //    db.Workers.Add(worker);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
    //public class HomeController : Controller
    //{
    //    private readonly ILogger<HomeController> _logger;

    //    public HomeController(ILogger<HomeController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }

    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}
}
