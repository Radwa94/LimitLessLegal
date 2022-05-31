using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class LGL_AuthorizationController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_AuthorizationController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            var mydbcontext = _context.LGL_Authorizations.Where(x => 1 == 1);
            if (string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.Client_name.Contains(id) || x.authorization_code.Contains(id));
                return View(await mydbcontext.ToListAsync());
            }

        }




        //// GET: LGL_Authorization
        //public async Task<IActionResult> Index()
        //{
        //    var myDbContext = _context.LGL_Authorizations.Include(l => l.LGL_Authorization_kinds);
        //    return View(await myDbContext.ToListAsync());
        //}

        // GET: LGL_Authorization/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Authorization = await _context.LGL_Authorizations
                .Include(l => l.LGL_Authorization_kinds)
                .FirstOrDefaultAsync(m => m.authorization_id == id);
            if (lGL_Authorization == null)
            {
                return NotFound();
            }

            return View(lGL_Authorization);
        }

        // GET: LGL_Authorization/Create
        public IActionResult Create()
        {
            ViewData["authorization_kinds_id"] = new SelectList(_context.LGL_Authorization_kindss, "authorization_kinds_id", "authorization_kinds_name");
            return View();
        }

        // POST: LGL_Authorization/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("authorization_id,authorization_code,authorization_source,authorization_character,authorization_year,authorization_kinds_id,authorization_name,Client_name,creation_user,last_update_user,authorization_img,authorization_disable")] LGL_Authorization lGL_Authorization)
        {
            if (ModelState.IsValid)
            {
                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                lGL_Authorization.creation_user = loginuser;
                lGL_Authorization.last_update_user = loginuser;
                _context.Add(lGL_Authorization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["authorization_kinds_id"] = new SelectList(_context.LGL_Authorization_kindss, "authorization_kinds_id", "authorization_kinds_name", lGL_Authorization.authorization_kinds_id);
            return View(lGL_Authorization);
        }

        // GET: LGL_Authorization/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Authorization = await _context.LGL_Authorizations.FindAsync(id);
            if (lGL_Authorization == null)
            {
                return NotFound();
            }
            ViewData["authorization_kinds_id"] = new SelectList(_context.LGL_Authorization_kindss, "authorization_kinds_id", "authorization_kinds_name", lGL_Authorization.authorization_kinds_id);
            return View(lGL_Authorization);
        }

        // POST: LGL_Authorization/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("authorization_id,authorization_code,authorization_source,authorization_character,authorization_year,authorization_kinds_id,authorization_name,Client_name,creation_user,last_update_user,authorization_img,authorization_disable")] LGL_Authorization lGL_Authorization)
        {
            if (id != lGL_Authorization.authorization_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    lGL_Authorization.creation_user = loginuser;
                    lGL_Authorization.last_update_user = loginuser;

                    _context.Update(lGL_Authorization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LGL_AuthorizationExists(lGL_Authorization.authorization_id))
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
            ViewData["authorization_kinds_id"] = new SelectList(_context.LGL_Authorization_kindss, "authorization_kinds_id", "authorization_kinds_name", lGL_Authorization.authorization_kinds_id);
            return View(lGL_Authorization);
        }

        // GET: LGL_Authorization/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Authorization = await _context.LGL_Authorizations
                .Include(l => l.LGL_Authorization_kinds)
                .FirstOrDefaultAsync(m => m.authorization_id == id);
            if (lGL_Authorization == null)
            {
                return NotFound();
            }

            return View(lGL_Authorization);
        }

        // POST: LGL_Authorization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lGL_Authorization = await _context.LGL_Authorizations.FindAsync(id);
            _context.LGL_Authorizations.Remove(lGL_Authorization);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LGL_AuthorizationExists(int id)
        {
            return _context.LGL_Authorizations.Any(e => e.authorization_id == id);
        }
    }
}
