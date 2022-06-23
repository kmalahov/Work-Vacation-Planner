using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using praktika.Models;

namespace praktika.Controllers
{
    public class ApplicationForVacations1Controller : Controller
    {
        private readonly course_workContext _context;

        public ApplicationForVacations1Controller(course_workContext context)
        {
            _context = context;
        }

        // GET: ApplicationForVacations1
        public async Task<IActionResult> Index()
        {
            var course_workContext = _context.ApplicationForVacations.Include(a => a.IdClassificationVacationNavigation).Include(a => a.IdStatusApplicationNavigation).Include(a => a.IdWorkerNavigation);
            return View(await course_workContext.ToListAsync());
        }

        // GET: ApplicationForVacations1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForVacation = await _context.ApplicationForVacations
                .Include(a => a.IdClassificationVacationNavigation)
                .Include(a => a.IdStatusApplicationNavigation)
                .Include(a => a.IdWorkerNavigation)
                .FirstOrDefaultAsync(m => m.IdApplication == id);
            if (applicationForVacation == null)
            {
                return NotFound();
            }

            return View(applicationForVacation);
        }

        // GET: ApplicationForVacations1/Create
        public IActionResult Create()
        {
            ViewData["IdClassificationVacation"] = new SelectList(_context.ClassificationVacations, "IdClassificationVacation", "NameClassification");
            ViewData["IdStatusApplication"] = new SelectList(_context.StatusApplications, "IdStatusApplication", "NameStatusClassification");
            if (Role.role.Admin == 0)
            {
                ViewData["IdWorker"] = new SelectList(_context.Workers.Where(x => x.IdWorker == Role.role.IdWorker), "IdWorker", "Name");
            }
            else
            {
                ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name");
            }
            //ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name");
            return View();
        }

        // POST: ApplicationForVacations1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdApplication,DateBeginVacation,VacationCount,IdWorker,IdStatusApplication,IdClassificationVacation")] ApplicationForVacation applicationForVacation)
        {
            if (ModelState.IsValid)
            {
                applicationForVacation.IdStatusApplication = 1;

                _context.Add(applicationForVacation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClassificationVacation"] = new SelectList(_context.ClassificationVacations, "IdClassificationVacation", "CodeClassification", applicationForVacation.IdClassificationVacation);
            ViewData["IdStatusApplication"] = new SelectList(_context.StatusApplications, "IdStatusApplication", "NameStatusClassification", applicationForVacation.IdStatusApplication);
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", applicationForVacation.IdWorker);
            
            return View(applicationForVacation);
        }

        // GET: ApplicationForVacations1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForVacation = await _context.ApplicationForVacations.FindAsync(id);
            if (applicationForVacation == null)
            {
                return NotFound();
            }
            ViewData["IdClassificationVacation"] = new SelectList(_context.ClassificationVacations, "IdClassificationVacation", "NameClassification", applicationForVacation.IdClassificationVacation);
            ViewData["IdStatusApplication"] = new SelectList(_context.StatusApplications, "IdStatusApplication", "NameStatusClassification", applicationForVacation.IdStatusApplication);
            //ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", applicationForVacation.IdWorker);
            if (Role.role.Admin == 0)
            {
                ViewData["IdWorker"] = new SelectList(_context.Workers.Where(x => x.IdWorker == Role.role.IdWorker), "IdWorker", "Name");
            }
            else
            {
                ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name");
            }
            return View(applicationForVacation);
        }

        // POST: ApplicationForVacations1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdApplication,DateBeginVacation,VacationCount,IdWorker,IdStatusApplication,IdClassificationVacation")] ApplicationForVacation applicationForVacation)
        {
            if (id != applicationForVacation.IdApplication)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Role.role.Admin == 0)
                    {
                        applicationForVacation.IdStatusApplication = 1;
                        _context.Update(applicationForVacation);
                    }
                    else
                    {
                        _context.Update(applicationForVacation);
                    }                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationForVacationExists(applicationForVacation.IdApplication))
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
            ViewData["IdClassificationVacation"] = new SelectList(_context.ClassificationVacations, "IdClassificationVacation", "CodeClassification", applicationForVacation.IdClassificationVacation);
            ViewData["IdStatusApplication"] = new SelectList(_context.StatusApplications, "IdStatusApplication", "NameStatusClassification", applicationForVacation.IdStatusApplication);
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", applicationForVacation.IdWorker);
            return View(applicationForVacation);
        }

        // GET: ApplicationForVacations1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForVacation = await _context.ApplicationForVacations
                .Include(a => a.IdClassificationVacationNavigation)
                .Include(a => a.IdStatusApplicationNavigation)
                .Include(a => a.IdWorkerNavigation)
                .FirstOrDefaultAsync(m => m.IdApplication == id);
            if (applicationForVacation == null)
            {
                return NotFound();
            }

            return View(applicationForVacation);
        }

        // POST: ApplicationForVacations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationForVacation = await _context.ApplicationForVacations.FindAsync(id);
            _context.ApplicationForVacations.Remove(applicationForVacation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationForVacationExists(int id)
        {
            return _context.ApplicationForVacations.Any(e => e.IdApplication == id);
        }
    }
}
