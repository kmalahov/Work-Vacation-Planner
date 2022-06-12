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
    public class ClassificationVacationsController : Controller
    {
        private readonly course_workContext _context;

        public ClassificationVacationsController(course_workContext context)
        {
            _context = context;
        }

        // GET: ClassificationVacations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassificationVacations.ToListAsync());
        }

        // GET: ClassificationVacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationVacation = await _context.ClassificationVacations
                .FirstOrDefaultAsync(m => m.IdClassificationVacation == id);
            if (classificationVacation == null)
            {
                return NotFound();
            }

            return View(classificationVacation);
        }

        // GET: ClassificationVacations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassificationVacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClassificationVacation,CodeClassification,NameClassification,PeriodVacation,UsageCount")] ClassificationVacation classificationVacation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificationVacation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificationVacation);
        }

        // GET: ClassificationVacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationVacation = await _context.ClassificationVacations.FindAsync(id);
            if (classificationVacation == null)
            {
                return NotFound();
            }
            return View(classificationVacation);
        }

        // POST: ClassificationVacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClassificationVacation,CodeClassification,NameClassification,PeriodVacation,UsageCount")] ClassificationVacation classificationVacation)
        {
            if (id != classificationVacation.IdClassificationVacation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificationVacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificationVacationExists(classificationVacation.IdClassificationVacation))
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
            return View(classificationVacation);
        }

        // GET: ClassificationVacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificationVacation = await _context.ClassificationVacations
                .FirstOrDefaultAsync(m => m.IdClassificationVacation == id);
            if (classificationVacation == null)
            {
                return NotFound();
            }

            return View(classificationVacation);
        }

        // POST: ClassificationVacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificationVacation = await _context.ClassificationVacations.FindAsync(id);
            _context.ClassificationVacations.Remove(classificationVacation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificationVacationExists(int id)
        {
            return _context.ClassificationVacations.Any(e => e.IdClassificationVacation == id);
        }
    }
}
