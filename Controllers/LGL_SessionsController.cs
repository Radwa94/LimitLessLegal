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
    public class LGL_SessionsController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_SessionsController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime DateFrom,DateTime DateTo)
        {
            var mydbcontext = _context.LGL_Sessionss.Include(l => l.LGL_Lawsuit).Where(x => 1 == 1);
            if (string.IsNullOrEmpty(DateFrom.ToShortDateString()) && string.IsNullOrEmpty(DateTo.ToShortDateString()))
            {
                return View(await mydbcontext.Include(l => l.LGL_Lawsuit).ToListAsync());
            }
            else
            {
              mydbcontext = mydbcontext.Where(x => x.session_next_date>= DateFrom && x.session_next_date <= DateTo);
                return View(await mydbcontext.ToListAsync());
            }

        }



        // GET: LGL_Sessions
        //public async Task<IActionResult> Index()
        //{
        //    var myDbContext = _context.LGL_Sessionss.Include(l => l.LGL_Lawsuit);
        //    return View(await myDbContext.ToListAsync());
        //}

        // GET: LGL_Sessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Sessions = await _context.LGL_Sessionss
                .Include(l => l.LGL_Lawsuit)
                .FirstOrDefaultAsync(m => m.sessions_id == id);
            if (lGL_Sessions == null)
            {
                return NotFound();
            }

            return View(lGL_Sessions);
        }

        // GET: LGL_Sessions/Create
        public IActionResult Create()
        {
            ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number");
            return View();
        }

        // POST: LGL_Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sessions_id,lawsuit_id,year,type,area,court_id,delay_reason,litigant_id,session_next_date,subject,finished,rollno,session_date,decision,requests")] LGL_Sessions lGL_Sessions)
        {
            if (ModelState.IsValid)
            {
                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                lGL_Sessions.creation_user = loginuser;
                lGL_Sessions.last_update_user = loginuser;


                _context.Add(lGL_Sessions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_Sessions.lawsuit_id);
            return View(lGL_Sessions);
        }

        // GET: LGL_Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Sessions = await _context.LGL_Sessionss.FindAsync(id);
            if (lGL_Sessions == null)
            {
                return NotFound();
            }
            ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_Sessions.lawsuit_id);
            return View(lGL_Sessions);
        }

        // POST: LGL_Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sessions_id,lawsuit_id,year,type,area,court_id,delay_reason,litigant_id,session_next_date,subject,finished,rollno,session_date,decision,requests")] LGL_Sessions lGL_Sessions)
        {
            if (id != lGL_Sessions.sessions_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    lGL_Sessions.creation_user = loginuser;
                    lGL_Sessions.last_update_user = loginuser;

                    _context.Update(lGL_Sessions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LGL_SessionsExists(lGL_Sessions.sessions_id))
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
            ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_Sessions.lawsuit_id);
            return View(lGL_Sessions);
        }

        // GET: LGL_Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Sessions = await _context.LGL_Sessionss
                .Include(l => l.LGL_Lawsuit)
                .FirstOrDefaultAsync(m => m.sessions_id == id);
            if (lGL_Sessions == null)
            {
                return NotFound();
            }

            return View(lGL_Sessions);
        }

        // POST: LGL_Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lGL_Sessions = await _context.LGL_Sessionss.FindAsync(id);
            _context.LGL_Sessionss.Remove(lGL_Sessions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LGL_SessionsExists(int id)
        {
            return _context.LGL_Sessionss.Any(e => e.sessions_id == id);
        }
    }
}
