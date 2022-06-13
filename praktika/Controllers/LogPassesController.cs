using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using praktika.ViewModels;
using praktika.Models;

namespace praktika.Controllers
{
    public class LogPassesController : Controller
    {
        private readonly course_workContext _context;

        public static bool LogIn = false;

        public LogPassesController(course_workContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogPass model)
        {
            LogIn = false;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            LogPass logPass = await _context.LogPasses.FirstOrDefaultAsync(l => l.Login == model.Login && l.Password == model.Password);
            Role.role = logPass; 
            if (logPass != null)
            {


                Worker w = await _context.Workers.FirstOrDefaultAsync(w => w.IdWorker == logPass.IdWorker);

                if (w != null)
                {
                    await Authenticate(model.Login); // аутентификация

                    LogIn = true;

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            //if (ModelState.IsValid)
            //{
            //    LogPass logPass = await _context.LogPasses.FirstOrDefaultAsync(l => l.Login == model.Login && l.Password == model.Password);
            //    if (logPass != null)
            //    {
            //        Worker worker = await _context.Workers.FirstOrDefaultAsync(w => w.IdWorker == logPass.UserId);

            //        if (model != null)
            //        {
            //            await Authenticate(model.Login); // аутентификация

            //            return RedirectToAction("Index", "Home");
            //        }
            //        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //    }                
            //}
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            LogIn = false;
            Role.role = null;
            return RedirectToAction("Login", "LogPasses");
        }

        // GET: LogPasses
        public async Task<IActionResult> Index()
        {
            var course_workContext = _context.LogPasses.Include(l => l.IdWorkerNavigation);
            return View(await course_workContext.ToListAsync());
        }

        // GET: LogPasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logPass = await _context.LogPasses
                .Include(l => l.IdWorkerNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (logPass == null)
            {
                return NotFound();
            }

            return View(logPass);
        }

        // GET: LogPasses/Create
        public IActionResult Create()
        {
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name");
            return View();
        }

        // POST: LogPasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Login,Password,IdWorker,Admin")] LogPass logPass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logPass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", logPass.IdWorker);
            return View(logPass);
        }

        // GET: LogPasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logPass = await _context.LogPasses.FindAsync(id);
            if (logPass == null)
            {
                return NotFound();
            }
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", logPass.IdWorker);
            return View(logPass);
        }

        // POST: LogPasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Login,Password,IdWorker,Admin")] LogPass logPass)
        {
            if (id != logPass.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logPass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogPassExists(logPass.UserId))
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
            ViewData["IdWorker"] = new SelectList(_context.Workers, "IdWorker", "Name", logPass.IdWorker);
            return View(logPass);
        }

        // GET: LogPasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logPass = await _context.LogPasses
                .Include(l => l.IdWorkerNavigation)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (logPass == null)
            {
                return NotFound();
            }

            return View(logPass);
        }

        // POST: LogPasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logPass = await _context.LogPasses.FindAsync(id);
            _context.LogPasses.Remove(logPass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogPassExists(int id)
        {
            return _context.LogPasses.Any(e => e.UserId == id);
        }
    }
}
