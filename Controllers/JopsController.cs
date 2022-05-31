using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class JopsController : Controller
    {
        private readonly MyDbContext _context;

        public JopsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Jops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jop.ToListAsync());
        }

        // GET: Jops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jop = await _context.Jop
                .FirstOrDefaultAsync(m => m.ID_jop == id);
            if (jop == null)
            {
                return NotFound();
            }

            return View(jop);
        }

        // GET: Jops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_jop,Name")] Jop jop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jop);
        }

        // GET: Jops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jop = await _context.Jop.FindAsync(id);
            if (jop == null)
            {
                return NotFound();
            }
            return View(jop);
        }

        // POST: Jops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_jop,Name")] Jop jop)
        {
            if (id != jop.ID_jop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JopExists(jop.ID_jop))
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
            return View(jop);
        }

        // GET: Jops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jop = await _context.Jop
                .FirstOrDefaultAsync(m => m.ID_jop == id);
            if (jop == null)
            {
                return NotFound();
            }

            return View(jop);
        }

        // POST: Jops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jop = await _context.Jop.FindAsync(id);
            _context.Jop.Remove(jop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JopExists(int id)
        {
            return _context.Jop.Any(e => e.ID_jop == id);
        }
    }
}
