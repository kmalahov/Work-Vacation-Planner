using Microsoft.AspNetCore.Mvc;
using Practice.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private course_workContext db;
        public HomeController(course_workContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Workers.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Worker worker)
        {
            db.Workers.Add(worker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}