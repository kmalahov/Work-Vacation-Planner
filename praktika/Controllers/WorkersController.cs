using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using praktika.Models;

namespace praktika.Controllers
{
    public class WorkersController : Controller
    {
        private readonly course_workContext _context;

        public WorkersController(course_workContext context)
        {
            _context = context;
        }

        public FileResult Export()  //экспорт отчета
        {
            //var databaseconfigContext = _context.Posts.Include(r => r.AmountMemoryRamNavigation).Include(r => r.NumbersModulesRamNavigation).Include(r => r.TypeMemoryRamNavigation);
            course_workContext entities = new course_workContext();
            DataTable dt = new DataTable("Workers");
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Фамилия "),
                                            new DataColumn("Имя"),
                                            new DataColumn("Отчество"),
                                            new DataColumn("Табельный номер"),
                                            new DataColumn("Email"),
                                            new DataColumn("Номер телефона"),
                                            new DataColumn("Дата трудоустройства"),
                                            new DataColumn("Отдел"),
                                            new DataColumn("Пол"),
                                            new DataColumn("Должность")});



            var customers = from customer in entities.Workers.Take(10)
                            select customer;

            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.Name, customer.Surname, customer.Patronymic, customer.ServiceNumber, customer.Email, 
                    customer.Phone, customer.DateHiring, customer.Department, customer.Post, customer.Gender);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Workers.xlsx");
                }
            }
        }

        // GET: Workers
        public async Task<IActionResult> Index()
        {
            var course_workContext = _context.Workers.Include(w => w.DepartmentNavigation).Include(w => w.GenderNavigation).Include(w => w.PostNavigation);
            return View(await course_workContext.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Search) //реализация поиска
        {
            var databaseconfigContext = _context.Workers;

            if (Search != null)
            {
                var result = databaseconfigContext.ToList().Where(x => x.Name.Contains(Search) || x.Surname.Contains(Search));
                return View(result);
            }
            return View(await _context.Workers.ToListAsync());

        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.DepartmentNavigation)
                .Include(w => w.GenderNavigation)
                .Include(w => w.PostNavigation)
                .FirstOrDefaultAsync(m => m.IdWorker == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            ViewData["Department"] = new SelectList(_context.Departments, "IdDepartment", "IdDepartment");
            ViewData["Gender"] = new SelectList(_context.Genders, "IdGender", "GenderName");
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Post1");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWorker,Surname,Name,Patronymic,ServiceNumber,Post,Email,Phone,DateHiring,Gender,Department")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Department"] = new SelectList(_context.Departments, "IdDepartment", "IdDepartment", worker.Department);
            ViewData["Gender"] = new SelectList(_context.Genders, "IdGender", "GenderName", worker.Gender);
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Post1", worker.Post);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }
            ViewData["Department"] = new SelectList(_context.Departments, "IdDepartment", "IdDepartment", worker.Department);
            ViewData["Gender"] = new SelectList(_context.Genders, "IdGender", "GenderName", worker.Gender);
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Post1", worker.Post);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWorker,Surname,Name,Patronymic,ServiceNumber,Post,Email,Phone,DateHiring,Gender,Department")] Worker worker)
        {
            if (id != worker.IdWorker)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.IdWorker))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Department"] = new SelectList(_context.Departments, "IdDepartment", "IdDepartment", worker.Department);
            ViewData["Gender"] = new SelectList(_context.Genders, "IdGender", "GenderName", worker.Gender);
            ViewData["Post"] = new SelectList(_context.Posts, "IdPost", "Post1", worker.Post);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(w => w.DepartmentNavigation)
                .Include(w => w.GenderNavigation)
                .Include(w => w.PostNavigation)
                .FirstOrDefaultAsync(m => m.IdWorker == id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var worker = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.IdWorker == id);
        }
    }
}
