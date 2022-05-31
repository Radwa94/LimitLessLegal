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
    public class investigationsController : Controller
    {
        private readonly MyDbContext _context;

        public investigationsController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            var mydbcontext = _context.investigation.Where(x => 1 == 1);
            if (string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.Noofcomplain.Contains(id) || x.Employeename.Contains(id) || x.Employeeid.Contains(id) || x.Nationalid.Contains(id));
                return View(await mydbcontext.ToListAsync());
            }

        }




        //// GET: investigations
        //public async Task<IActionResult> Index()
        //{
        //    var myDbContext = _context.investigation.Include(i => i.department).Include(i => i.jop);
        //    return View(await myDbContext.ToListAsync());
        //}

        // GET: investigations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.investigation
                .Include(i => i.department)
                .Include(i => i.jop)
                .FirstOrDefaultAsync(m => m.ID_investigation == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // GET: investigations/Create
        public IActionResult Create()
        {
            ViewData["ID_Department"] = new SelectList(_context.Department, "ID_Department", "Name");
            ViewData["ID_jop"] = new SelectList(_context.Jop, "ID_jop", "Name");
            return View();
        }

        // POST: investigations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_investigation,Noofcomplain,Employeename,Employeeid,Nationalid,ID_jop,NatureComplaint,Invstdate,Decisionafterinvst,Invstnotes,ID_Department,Investigator,Idinvist,Invimage")] investigation investigation)
        {
            if (ModelState.IsValid)
            {
                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                investigation.creation_user = loginuser;
                investigation.last_update_user = loginuser;

                _context.Add(investigation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Department"] = new SelectList(_context.Department, "ID_Department", "Name", investigation.ID_Department);
            ViewData["ID_jop"] = new SelectList(_context.Jop, "ID_jop", "Name", investigation.ID_jop);
            return View(investigation);
        }

        // GET: investigations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.investigation.FindAsync(id);
            if (investigation == null)
            {
                return NotFound();
            }
            ViewData["ID_Department"] = new SelectList(_context.Department, "ID_Department", "Name", investigation.ID_Department);
            ViewData["ID_jop"] = new SelectList(_context.Jop, "ID_jop", "Name", investigation.ID_jop);
            return View(investigation);
        }

        // POST: investigations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_investigation,Noofcomplain,Employeename,Employeeid,Nationalid,ID_jop,NatureComplaint,Invstdate,Decisionafterinvst,Invstnotes,ID_Department,Investigator,Idinvist,Invimage")] investigation investigation)
        {
            if (id != investigation.ID_investigation)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    investigation.creation_user = loginuser;
                    investigation.last_update_user = loginuser;

                    _context.Update(investigation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!investigationExists(investigation.ID_investigation))
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
            ViewData["ID_Department"] = new SelectList(_context.Department, "ID_Department", "Name", investigation.ID_Department);
            ViewData["ID_jop"] = new SelectList(_context.Jop, "ID_jop", "Name", investigation.ID_jop);
            return View(investigation);
        }

        // GET: investigations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investigation = await _context.investigation
                .Include(i => i.department)
                .Include(i => i.jop)
                .FirstOrDefaultAsync(m => m.ID_investigation == id);
            if (investigation == null)
            {
                return NotFound();
            }

            return View(investigation);
        }

        // POST: investigations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investigation = await _context.investigation.FindAsync(id);
            _context.investigation.Remove(investigation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool investigationExists(int id)
        {
            return _context.investigation.Any(e => e.ID_investigation == id);
        }
    }
}
