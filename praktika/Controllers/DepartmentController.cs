using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using praktika.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace praktika.Controllers
{
    public class DepartmentController : Controller
    {
        private course_workContext db;
        public DepartmentController(course_workContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Departments.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            db.Departments.Add(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
